import { Component, EventEmitter, Input, Output, OnInit, OnDestroy, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Subject, takeUntil, debounceTime } from 'rxjs';

//Helper
import { DateHelper } from '../../helpers/Date.helper';

//Models
import { IncomesFilter } from '../../models/filters/IncomesFilters';
import { IncomeCategory } from '../../models/IncomeType';
import { Student } from '../../models/Student';

//i18n
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'incomes-filter-component',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    ReactiveFormsModule,
    MatInputModule, 
    MatFormFieldModule, 
    MatSelectModule, 
    MatIconModule, 
    MatButtonModule, 
    TranslatePipe
  ],
  templateUrl: './incomes-filter.component.html',
  styleUrl: './incomes-filter.component.css'
})
export class IncomesFilterComponent implements OnInit, OnDestroy {
  private fb = inject(FormBuilder);
  private destroy$ = new Subject<void>();

  @Input() set filters(value: IncomesFilter) {
    if (this.filterForm) {
      this.filterForm.patchValue(value, { emitEvent: false });
    }
  }
  @Input() categories: IncomeCategory[] = [];
  @Input() students: Student[] = [];

  @Output() filterChanged = new EventEmitter<IncomesFilter>();
  @Output() filterReset = new EventEmitter<void>();

  public filterForm: FormGroup = this.fb.group({
    query: [''],
    year: [null],
    month: [null],
    incomeTypeId: [null],
    studentId: [null]
  });

  ngOnInit(): void {
    this.filterForm.valueChanges
      .pipe(
        debounceTime(300),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        this.filterChanged.emit(value);
      });
  }

  onResetClick() {
    this.filterReset.emit();
  }

  getYears(): number[] {
    return DateHelper.getYears();
  }

  getMonths(): number[] {
    return DateHelper.getMonths(); 
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}