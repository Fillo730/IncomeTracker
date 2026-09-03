import { Component, OnInit, effect, inject, signal } from '@angular/core';
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

import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';
import { SetGoalDialogComponent } from '../../components/set-goal-dialog/set-goal-dialog.component';

import { IncomeService } from '../../services/api/income-entries.service';
import { IncomeGoalService } from '../../services/api/income-goal.service';
import { ThemeService } from '../../services/theme.service';
import { ToastService } from '../../services/toast.service';
import { ChartOptionsHelper } from '../../helpers/ChartOptions.helper';
import { forkJoin } from 'rxjs';
import { CategoryIncome } from '../../models/stats/CategoryIncome';
import { MonthlyIncome } from '../../models/stats/MonthlyIncome';
import { MonthlyHours } from '../../models/stats/MonthlyHours';
import { StudentIncome } from '../../models/stats/StudentIncome';
import { LanguageService } from '../../services/language.service';
import { DateHelper } from '../../helpers/Date.helper';

const STUDENT_PIE_PALETTE = [
  '#3f51b5', '#ff9800', '#4caf50', '#f44336', '#9c27b0',
  '#00bcd4', '#8bc34a', '#e91e63', '#ffc107', '#795548'
];

@Component({
  selector: 'current-year-page',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule, MatProgressBarModule, MatTooltipModule, MatDialogModule, TranslatePipe, BaseChartDirective, StateHandlerComponent],
  providers: [provideCharts(withDefaultRegisterables())],
  templateUrl: './current-year.page.html',
  styleUrl: './current-year.page.css'
})
export class CurrentYearPage implements OnInit {
  private readonly incomeService = inject(IncomeService);
  private readonly incomeGoalService = inject(IncomeGoalService);
  private readonly themeService = inject(ThemeService);
  private readonly translate = inject(TranslateService);
  private readonly languageService = inject(LanguageService);
  private readonly toastService = inject(ToastService);
  private readonly dialog = inject(MatDialog);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);

  public selectedYear = signal<number>(new Date().getFullYear());

  public monthlyIncomeChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public monthlyHoursChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public yearCategoryChartData: ChartConfiguration<'pie'>['data'] = { labels: [], datasets: [] };
  public studentIncomeChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public studentHoursChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public studentIncomePieChartData: ChartConfiguration<'pie'>['data'] = { labels: [], datasets: [] };

  public hasStudentData = signal<boolean>(false);
  public annualGoal = signal<number>(0);
  public totalYearIncome = signal<number>(0);

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

  public isCurrentYear(): boolean {
    return this.selectedYear() === new Date().getFullYear();
  }

  public goToPreviousYear(): void {
    this.selectedYear.update(y => y - 1);
    this.loadData();
  }

  public goToNextYear(): void {
    if (this.isCurrentYear()) {
      return;
    }
    this.selectedYear.update(y => y + 1);
    this.loadData();
  }

  public loadData(): void {
    this.isLoading.set(true);
    this.isError.set(false);

    const year = this.selectedYear();

    forkJoin({
      yearlyIncome: this.incomeService.getMonthlyIncomeForYear(year),
      yearlyHours: this.incomeService.getMonthlyHoursForYear(year),
      yearlyCategory: this.incomeService.getIncomeByCategoryForYear(year, this.languageService.language()),
      studentIncome: this.incomeService.getIncomeByStudentForYear(year),
      goal: this.incomeGoalService.getAnnualGoal(),
    }).subscribe({
      next: (res) => {
        this.setUpMonthlyIncomeChart(res.yearlyIncome.data);
        this.setUpMonthlyHoursChart(res.yearlyHours.data);
        this.setUpYearCategoryChart(res.yearlyCategory.data);
        this.setUpStudentCharts(res.studentIncome.data);

        const total = (res.yearlyIncome.data ?? []).reduce((sum, m) => sum + m.totalAmount, 0);
        this.totalYearIncome.set(total);

        if (res.goal.success) {
          this.annualGoal.set(res.goal.data.annualAmount);
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
    const goal = this.annualGoal();
    const income = this.totalYearIncome();

    if (goal <= 0) {
      return 0;
    }

    return Math.min(100, Math.round((income / goal) * 100));
  }

  public openGoalDialog(): void {
    const dialogRef = this.dialog.open(SetGoalDialogComponent, {
      width: '400px',
      data: {
        currentAmount: this.annualGoal(),
        title: 'HomePage.Goal.AnnualDialogTitle',
        text: 'HomePage.Goal.AnnualDialogText',
        label: 'HomePage.Goal.AnnualDialogLabel'
      },
      panelClass: 'dialog-with-theme'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined && result !== null) {
        this.incomeGoalService.setAnnualGoal(result).subscribe(res => {
          if (res.success) {
            this.annualGoal.set(res.data.annualAmount);
            this.toastService.success(this.translate.instant('HomePage.Goal.UpdateSuccess'));
          }
        });
      }
    });
  }

  private setUpMonthlyIncomeChart(data: MonthlyIncome[] | null): void {
    if (!data || data.length === 0) {
      this.monthlyIncomeChartData = { labels: [], datasets: [] };
      return;
    }

    const lang = this.languageService.language();
    const labels = data.map(d => DateHelper.getMonthName(d.month, this.selectedYear(), lang));
    const totals = data.map(d => d.totalAmount);

    this.monthlyIncomeChartData = {
      labels,
      datasets: [{
        data: totals,
        label: this.translate.instant('HomePage.Labels.IncomeDataset'),
        backgroundColor: '#3f51b5'
      }]
    };
  }

  private setUpMonthlyHoursChart(data: MonthlyHours[] | null): void {
    if (!data || data.length === 0) {
      this.monthlyHoursChartData = { labels: [], datasets: [] };
      return;
    }

    const lang = this.languageService.language();
    const labels = data.map(d => DateHelper.getMonthName(d.month, this.selectedYear(), lang));
    const totals = data.map(d => d.totalHours);

    this.monthlyHoursChartData = {
      labels,
      datasets: [{
        data: totals,
        label: this.translate.instant('HomePage.Labels.HoursDataset'),
        backgroundColor: '#ff9800'
      }]
    };
  }

  private setUpStudentCharts(data: StudentIncome[] | null): void {
    if (!data || data.length === 0) {
      this.studentIncomeChartData = { labels: [], datasets: [] };
      this.studentHoursChartData = { labels: [], datasets: [] };
      this.studentIncomePieChartData = { labels: [], datasets: [] };
      this.hasStudentData.set(false);
      return;
    }

    this.hasStudentData.set(true);

    const labels = data.map(d => d.studentName);

    this.studentIncomeChartData = {
      labels,
      datasets: [{
        data: data.map(d => d.totalAmount),
        label: this.translate.instant('HomePage.Labels.IncomeDataset'),
        backgroundColor: '#4caf50'
      }]
    };

    this.studentHoursChartData = {
      labels,
      datasets: [{
        data: data.map(d => d.totalHours),
        label: this.translate.instant('HomePage.Labels.HoursDataset'),
        backgroundColor: '#9c27b0'
      }]
    };

    this.studentIncomePieChartData = {
      labels,
      datasets: [{
        data: data.map(d => d.totalAmount),
        backgroundColor: labels.map((_, i) => STUDENT_PIE_PALETTE[i % STUDENT_PIE_PALETTE.length])
      }]
    };
  }

  private setUpYearCategoryChart(data: CategoryIncome[] | null): void {
    if (!data || data.length === 0) {
      this.yearCategoryChartData = { labels: [], datasets: [] };
      return;
    }

    const categories = data.map(i => i.categoryName);
    const totals = data.map(i => i.totalAmount);

    this.yearCategoryChartData = {
      labels: categories,
      datasets: [{
        data: totals,
        backgroundColor: ['#3f51b5', '#ff9800', '#4caf50', '#f44336', '#9c27b0']
      }]
    };
  }
}
