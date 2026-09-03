import { Component, OnInit, Signal, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { BaseChartDirective, provideCharts, withDefaultRegisterables } from 'ng2-charts';
import { ChartConfiguration } from 'chart.js';

import { StatCardComponent } from '../../components/stat-card/stat-card.component';
import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';
import { SetGoalDialogComponent } from '../../components/set-goal-dialog/set-goal-dialog.component';

import { IncomeService } from '../../services/api/income-entries.service';
import { IncomeGoalService } from '../../services/api/income-goal.service';
import { ThemeService } from '../../services/theme.service';
import { ToastService } from '../../services/toast.service';
import { ChartOptionsHelper } from '../../helpers/ChartOptions.helper';
import { forkJoin } from 'rxjs';
import { CategoryIncome } from '../../models/stats/CategoryIncome';
import { IncomeEntry } from '../../models/IncomeEntry';
import { DEFAULT_INCOMES_FILTER } from '../../models/filters/IncomesFilters';
import { LanguageService } from '../../services/language.service';
import { DateHelper } from '../../helpers/Date.helper';

@Component({
  selector: 'home-page',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule, MatProgressBarModule, MatTooltipModule, MatDialogModule, TranslatePipe, BaseChartDirective, StatCardComponent, StateHandlerComponent],
  providers: [provideCharts(withDefaultRegisterables())],
  templateUrl: './current-month.page.html',
  styleUrl: './current-month.page.css'
})

export class CurrentMonthPage implements OnInit {
  private readonly incomeService = inject(IncomeService);
  private readonly incomeGoalService = inject(IncomeGoalService);
  private readonly themeService = inject(ThemeService);
  private readonly translate = inject(TranslateService);
  private readonly languageService = inject(LanguageService);
  private readonly toastService = inject(ToastService);
  private readonly dialog = inject(MatDialog);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);

  public selectedMonth = signal<number>(new Date().getMonth() + 1);
  public selectedYear = signal<number>(new Date().getFullYear());

  public currentMonthName = signal<string | null>(null);
  public totalIncome = signal<number | null>(null);
  public totalHoursWorked = signal<number | null>(null);
  public incomeForCategory = signal<CategoryIncome[] | null>(null);
  public monthlyGoal = signal<number>(0);

  public pieChartData: ChartConfiguration<'pie'>['data'] = { labels: [], datasets: [] };
  public entriesChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };

  public pieChartOptions: ChartConfiguration['options'] = ChartOptionsHelper.getPieChartOptions();
  public barChartOptions: ChartConfiguration['options'] = ChartOptionsHelper.getLineBarChartOptions();

  constructor() {
    effect(() => {
      const textColor = this.themeService.chartTextColor();
      const isDark = this.themeService.isDark();
      this.pieChartOptions = ChartOptionsHelper.updatePieTheme(this.pieChartOptions, textColor);
      this.barChartOptions = ChartOptionsHelper.updateBarLineScalesTheme(this.barChartOptions, textColor, isDark);
    });
  }

  ngOnInit(): void {
    this.loadData();
    this.translate.onLangChange.subscribe(() => this.loadData());
  }

  public isCurrentMonth(): boolean {
    const now = new Date();
    return this.selectedMonth() === now.getMonth() + 1 && this.selectedYear() === now.getFullYear();
  }

  public goToPreviousMonth(): void {
    this.shiftMonth(-1);
  }

  public goToNextMonth(): void {
    if (this.isCurrentMonth()) {
      return;
    }
    this.shiftMonth(1);
  }

  private shiftMonth(offset: number): void {
    let month = this.selectedMonth() + offset;
    let year = this.selectedYear();

    if (month < 1) {
      month = 12;
      year -= 1;
    } else if (month > 12) {
      month = 1;
      year += 1;
    }

    this.selectedMonth.set(month);
    this.selectedYear.set(year);
    this.loadData();
  }

  public loadData(): void {
    const month = this.selectedMonth();
    const year = this.selectedYear();

    this.currentMonthName.set(`${DateHelper.getMonthName(month, year, this.languageService.language())} ${year}`);

    this.isLoading.set(true);
    this.isError.set(false);

    forkJoin({
      total: this.incomeService.getMonthTotalIncome(month, year),
      hours: this.incomeService.getMonthTotalHours(month, year),
      incomeCategory: this.incomeService.getIncomeByCategory(month, year, this.languageService.language()),
      entries: this.incomeService.getPagedIncomes(this.languageService.language(), 100, 1, {
        ...DEFAULT_INCOMES_FILTER,
        year,
        month
      }),
      goal: this.incomeGoalService.getMonthlyGoal(),
    }).subscribe({
      next: (res) => {
        this.totalIncome.set(res.total.data);
        this.totalHoursWorked.set(res.hours.data);
        this.incomeForCategory.set(res.incomeCategory.data);
        this.setUpPieChart(res.incomeCategory.data);
        this.setUpEntriesChart(res.entries.data.items);

        if (res.goal.success) {
          this.monthlyGoal.set(res.goal.data.monthlyAmount);
        }

        this.isLoading.set(false);
      },
      error: () => {
        this.isError.set(true);
        this.isLoading.set(false);
      }
    });
  }

  public goalProgressPercent(): number {
    const goal = this.monthlyGoal();
    const income = this.totalIncome() ?? 0;

    if (goal <= 0) {
      return 0;
    }

    return Math.min(100, Math.round((income / goal) * 100));
  }

  public openGoalDialog(): void {
    const dialogRef = this.dialog.open(SetGoalDialogComponent, {
      width: '400px',
      data: { currentAmount: this.monthlyGoal() },
      panelClass: 'dialog-with-theme'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined && result !== null) {
        this.incomeGoalService.setMonthlyGoal(result).subscribe(res => {
          if (res.success) {
            this.monthlyGoal.set(res.data.monthlyAmount);
            this.toastService.success(this.translate.instant('HomePage.Goal.UpdateSuccess'));
          }
        });
      }
    });
  }

  refreshAllCharts(currentMonth: any[], allData: any[]): void {
    this.setUpPieChart(currentMonth);
  }

  private setUpPieChart(data: CategoryIncome[] | null): void {
    if (!data || data.length === 0) {
      this.pieChartData = { labels: [], datasets: [] };
      return;
    }

    const categories = data.map(i => i.categoryName);
    const totals = data.map(i => i.totalAmount);

    this.pieChartData = {
      labels: categories,
      datasets: [{
        data: totals,
        backgroundColor: ['#3f51b5', '#ff9800', '#4caf50', '#f44336', '#9c27b0']
      }]
    };
  }

  private setUpEntriesChart(entries: IncomeEntry[] | null): void {
    if (!entries || entries.length === 0) {
      this.entriesChartData = { labels: [], datasets: [] };
      return;
    }

    const sorted = [...entries].sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

    const labels = sorted.map(e => e.categoryName);
    const totals = sorted.map(e => e.amount);

    this.entriesChartData = {
      labels,
      datasets: [{
        data: totals,
        label: this.translate.instant('HomePage.Labels.IncomeDataset'),
        backgroundColor: '#3f51b5'
      }]
    };
  }
}