//Angular
import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

//Rxjs
import { Observable, of } from 'rxjs';

//Constants
import { getApiUrl } from '../../constants/app.config';

//Models
import { ApiResponse } from '../../models/ApiResponse.model';
import { CategoryIncome } from '../../models/stats/CategoryIncome';
import { MonthlyIncome } from '../../models/stats/MonthlyIncome';
import { MonthlyHours } from '../../models/stats/MonthlyHours';
import { StudentIncome } from '../../models/stats/StudentIncome';
import { IncomeEntry } from '../../models/IncomeEntry';
import { PagedResponse } from '../../models/PagedResponse';
import { IncomesFilter } from '../../models/filters/IncomesFilters';
import { IncomeType } from '../../models/types/IncomeEntryType';
import { IncomeCategory } from '../../models/IncomeType';

@Injectable({
  providedIn: 'root'
})
export class IncomeService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = getApiUrl("INCOMES");

  public getMonthTotalIncome(month: number, year: number): Observable<ApiResponse<number>> {
    let params = new HttpParams().set("year", year).set("month", month);
    return this.http.get<ApiResponse<number>>(`${this.apiUrl}/total-month`, { params });
  }

  public getMonthTotalHours(month: number, year: number): Observable<ApiResponse<number>> {
    let params = new HttpParams().set("year", year).set("month", month);
    return this.http.get<ApiResponse<number>>(`${this.apiUrl}/total-hours-month`, { params });
  }

  public getIncomeByCategory(month: number, year: number, lang: string): Observable<ApiResponse<CategoryIncome[]>> {
    let params = new HttpParams()
      .set("year", year)
      .set("month", month)
      .set("lang", lang);
    return this.http.get<ApiResponse<CategoryIncome[]>>(`${this.apiUrl}/stats/by-category`, { params });
  }

  public getIncomeByCategoryForYear(year: number, lang: string): Observable<ApiResponse<CategoryIncome[]>> {
    let params = new HttpParams()
      .set("year", year)
      .set("lang", lang);
    return this.http.get<ApiResponse<CategoryIncome[]>>(`${this.apiUrl}/stats/by-category-year`, { params });
  }

  public getIncomeByStudentForYear(year: number): Observable<ApiResponse<StudentIncome[]>> {
    let params = new HttpParams().set("year", year);
    return this.http.get<ApiResponse<StudentIncome[]>>(`${this.apiUrl}/stats/by-student-year`, { params });
  }

  public getMonthlyIncomeForYear(year: number): Observable<ApiResponse<MonthlyIncome[]>> {
    let params = new HttpParams().set("year", year);
    return this.http.get<ApiResponse<MonthlyIncome[]>>(`${this.apiUrl}/stats/monthly-income`, { params });
  }

  public getMonthlyHoursForYear(year: number): Observable<ApiResponse<MonthlyHours[]>> {
    let params = new HttpParams().set("year", year);
    return this.http.get<ApiResponse<MonthlyHours[]>>(`${this.apiUrl}/stats/monthly-hours`, { params });
  }

  public getPagedIncomes(lang: string, pageSize: number, pageNumber: number, incomesFilter: IncomesFilter): Observable<ApiResponse<PagedResponse<IncomeEntry>>> {
    let params = new HttpParams()
      .set("lang", lang)
      .set("pageSize", pageSize.toString())
      .set("pageNumber", pageNumber.toString());

    params = this.applyFilters(params, incomesFilter);

    return this.http.get<ApiResponse<PagedResponse<IncomeEntry>>>(this.apiUrl, { params });
  }

  public getIncomeTypes(lang : string) {
    let params = new HttpParams()
      .set("lang", lang);
      return this.http.get<ApiResponse<IncomeCategory[]>>(`${this.apiUrl}/types`, { params });
  }

  public createIncome(entry: any): Observable<ApiResponse<any>> {
    return this.http.post<ApiResponse<any>>(this.apiUrl, entry);
  }

  public updateIncome(id: number, entry: any): Observable<ApiResponse<any>> {
    return this.http.put<ApiResponse<any>>(`${this.apiUrl}/${id}`, entry);
  }

  public deleteIncome(id: number): Observable<ApiResponse<any>> {
    return this.http.delete<ApiResponse<any>>(`${this.apiUrl}/${id}`);
  }

  private applyFilters(params: HttpParams, filter: IncomesFilter): HttpParams {
    if (!filter) return params;

    if (filter.query) {
      params = params.set("query", filter.query);
    }

    if (filter.year) {
      params = params.set("year", filter.year.toString());
    }

    if (filter.month) {
      params = params.set("month", filter.month.toString());
    }

    if (filter.incomeTypeId !== null && filter.incomeTypeId !== undefined) {
      params = params.set("incomeTypeId", filter.incomeTypeId.toString());
    }

    if (filter.studentId !== null && filter.studentId !== undefined) {
      params = params.set("studentId", filter.studentId.toString());
    }

    return params;
  }
}