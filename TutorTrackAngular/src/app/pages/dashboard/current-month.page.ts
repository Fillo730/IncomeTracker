import { Component, OnInit, Signal, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { BaseChartDirective, provideCharts, withDefaultRegisterables } from 'ng2-charts';
import { ChartConfiguration } from 'chart.js';

import { StatCardComponent } from '../../components/stat-card/stat-card.component';
import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';

import { IncomeService } from '../../services/api/income-entries.service';
import { ThemeService } from '../../services/theme.service';
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
  imports: [CommonModule, MatCardModule, TranslatePipe, BaseChartDirective, StatCardComponent, StateHandlerComponent],
  providers: [provideCharts(withDefaultRegisterables())],
  templateUrl: './current-month.page.html',
  styleUrl: './current-month.page.css'
})

export class CurrentMonthPage implements OnInit {
  private readonly incomeService = inject(IncomeService);
  private readonly themeService = inject(ThemeService);
  private readonly translate = inject(TranslateService);
  private readonly languageService = inject(LanguageService);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);

  public currentMonthName = signal<string | null>(null);
  public totalIncome = signal<number | null>(null);
  public totalHoursWorked = signal<number | null>(null);
  public incomeForCategory = signal<CategoryIncome[] | null>(null);

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

  public loadData(): void {
    const now = new Date();
    const month = now.getMonth() + 1;
    const year = now.getFullYear();

    this.currentMonthName.set(DateHelper.getMonthName(month, year, this.languageService.language()));

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
    }).subscribe({
      next: (res) => {
        this.totalIncome.set(res.total.data);
        this.totalHoursWorked.set(res.hours.data);
        this.incomeForCategory.set(res.incomeCategory.data);
        this.setUpPieChart(res.incomeCategory.data);
        this.setUpEntriesChart(res.entries.data.items);
        this.isLoading.set(false);
      },
      error: () => {
        this.isError.set(true);
        this.isLoading.set(false);
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

    const labels = sorted.map(e => e.description || e.categoryName);
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