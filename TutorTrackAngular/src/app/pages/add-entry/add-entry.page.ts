import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

// Components
import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';
import { IncomesFilterComponent } from '../../components/incomes-filter/incomes-filter.component';
import { AddUpdateIncomeDialogComponent } from '../../components/add-update-income-dialog/add-update-income-dialog.component';
import { IncomeCardListComponent } from '../../components/income-card-list/income-card-list.component';
import { PagerComponent } from '../../components/pager/pager.component';

// Models
import { IncomeEntry } from '../../models/IncomeEntry';
import { IncomesFilter, DEFAULT_INCOMES_FILTER } from '../../models/filters/IncomesFilters';

// i18n
import { TranslateService, TranslatePipe } from '@ngx-translate/core';

// Services
import { IncomeService } from '../../services/api/income-entries.service';
import { ToastService } from '../../services/toast.service';
import { LanguageService } from '../../services/language.service';
import { forkJoin } from 'rxjs';
import { IncomeType } from '../../models/types/IncomeEntryType';
import { IncomeCategory } from '../../models/IncomeType';

@Component({
  selector: 'add-entry-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule,
    MatDialogModule,
    TranslatePipe,
    StateHandlerComponent,
    IncomesFilterComponent,
    IncomeCardListComponent,
    PagerComponent
  ],
  templateUrl: './add-entry.page.html',
  styleUrl: './add-entry.page.css'
})
export class AddEntryPage implements OnInit {
  private incomeService = inject(IncomeService);
  private toastService = inject(ToastService);
  private translate = inject(TranslateService);
  private dialog = inject(MatDialog);
  private languageService = inject(LanguageService);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);
  public monthlyTotal = signal<number>(0);
  public incomes = signal<IncomeEntry[]>([]);
  public incomeTypes = signal<IncomeCategory[] | null>(null);
  public currentFilters = signal<IncomesFilter>({ ...DEFAULT_INCOMES_FILTER });
  public lang = this.languageService.language();

  public totalItems = signal<number>(0);
  public pageSize = signal<number>(10);
  public pageIndex = signal<number>(0);

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.isLoading.set(true);
    this.isError.set(false);

    const month = new Date().getMonth() + 1;
    const year = new Date().getFullYear();

    forkJoin({
      total: this.incomeService.getMonthTotalIncome(month, year),
      paged: this.incomeService.getPagedIncomes(this.lang, this.pageSize(), this.pageIndex() + 1, this.currentFilters()),
      types: this.incomeService.getIncomeTypes(this.lang),
    }).subscribe({
      next: (res) => {
        if (res.total.success) {
          this.monthlyTotal.set(res.total.data);
        }

        if (res.paged.success) {
          this.incomes.set(res.paged.data.items);
          this.totalItems.set(res.paged.data.totalCount);
        }

        if(res.types.success) {
          this.incomeTypes.set(res.types.data);
          console.log(res);
        }

        this.isLoading.set(false);
      },
      error: (err) => {
        this.isError.set(true);
        this.isLoading.set(false);
      }
    });
  }

  onFilterChanged(filters: IncomesFilter): void {
    this.currentFilters.set(filters);
    this.pageIndex.set(0);
    this.loadData();
  }

  resetFilters(): void {
    this.currentFilters.set({ ...DEFAULT_INCOMES_FILTER });
    this.pageIndex.set(0);
    this.loadData();
    this.toastService.success(this.translate.instant('Incomes.Messages.FiltersReset'));
  }

  handlePageEvent(e: PageEvent): void {
    this.pageIndex.set(e.pageIndex);
    this.pageSize.set(e.pageSize);
    this.loadData();
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddUpdateIncomeDialogComponent, {
      width: '400px',
      data: { 
        title: 'Incomes.Dialog.TitleAdd',
        text: 'Incomes.Dialog.TextAdd',
        categories: this.incomeTypes()
      },
      panelClass: "dialog-with-theme"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.incomeService.createIncome(result).subscribe(res => {
          if (res.success) {
            this.loadData();
            this.toastService.success(this.translate.instant('Incomes.Messages.AddSuccess'));
          }
        });
      }
    });
  }

  onEditIncome(income: IncomeEntry): void {
    const dialogRef = this.dialog.open(AddUpdateIncomeDialogComponent, {
      width: '400px',
      data: { income: income, title: 'Incomes.Dialog.TitleUpdate' },
      panelClass: "dialog-with-theme"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.incomeService.updateIncome(income.id, result).subscribe(res => {
          if (res.success) {
            this.loadData();
            this.toastService.success(this.translate.instant('Incomes.Messages.UpdateSuccess'));
          }
        });
      }
    });
  }

  onDeleteIncome(id: number): void {
    this.incomeService.deleteIncome(id).subscribe(res => {
      if(res.success) {
        this.loadData();
        this.toastService.success(this.translate.instant('Incomes.Messages.DeleteSuccess'));
      }
    });
  }
}