import { Component, OnInit, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { BaseChartDirective, provideCharts, withDefaultRegisterables } from 'ng2-charts';
import { ChartConfiguration } from 'chart.js';

import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';

import { IncomeService } from '../../services/api/income-entries.service';
import { ThemeService } from '../../services/theme.service';
import { ChartOptionsHelper } from '../../helpers/ChartOptions.helper';
import { forkJoin } from 'rxjs';
import { CategoryIncome } from '../../models/stats/CategoryIncome';
import { MonthlyIncome } from '../../models/stats/MonthlyIncome';
import { MonthlyHours } from '../../models/stats/MonthlyHours';
import { LanguageService } from '../../services/language.service';
import { DateHelper } from '../../helpers/Date.helper';

@Component({
  selector: 'current-year-page',
  standalone: true,
  imports: [CommonModule, MatCardModule, TranslatePipe, BaseChartDirective, StateHandlerComponent],
  providers: [provideCharts(withDefaultRegisterables())],
  templateUrl: './current-year.page.html',
  styleUrl: './current-year.page.css'
})
export class CurrentYearPage implements OnInit {
  private readonly incomeService = inject(IncomeService);
  private readonly themeService = inject(ThemeService);
  private readonly translate = inject(TranslateService);
  private readonly languageService = inject(LanguageService);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);

  public currentYear = new Date().getFullYear();

  public monthlyIncomeChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public monthlyHoursChartData: ChartConfiguration<'bar'>['data'] = { labels: [], datasets: [] };
  public yearCategoryChartData: ChartConfiguration<'pie'>['data'] = { labels: [], datasets: [] };

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

  public loadData(): void {
    this.isLoading.set(true);
    this.isError.set(false);

    forkJoin({
      yearlyIncome: this.incomeService.getMonthlyIncomeForYear(this.currentYear),
      yearlyHours: this.incomeService.getMonthlyHoursForYear(this.currentYear),
      yearlyCategory: this.incomeService.getIncomeByCategoryForYear(this.currentYear, this.languageService.language()),
    }).subscribe({
      next: (res) => {
        this.setUpMonthlyIncomeChart(res.yearlyIncome.data);
        this.setUpMonthlyHoursChart(res.yearlyHours.data);
        this.setUpYearCategoryChart(res.yearlyCategory.data);
        this.isLoading.set(false);
      },
      error: () => {
        this.isError.set(true);
        this.isLoading.set(false);
      }
    });
  }

  private setUpMonthlyIncomeChart(data: MonthlyIncome[] | null): void {
    if (!data || data.length === 0) {
      this.monthlyIncomeChartData = { labels: [], datasets: [] };
      return;
    }

    const lang = this.languageService.language();
    const labels = data.map(d => DateHelper.getMonthName(d.month, this.currentYear, lang));
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
    const labels = data.map(d => DateHelper.getMonthName(d.month, this.currentYear, lang));
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
