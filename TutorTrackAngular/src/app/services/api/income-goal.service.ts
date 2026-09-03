//Angular
import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//Rxjs
import { Observable } from 'rxjs';

//Constants
import { getApiUrl } from '../../constants/app.config';

//Models
import { ApiResponse } from '../../models/ApiResponse.model';
import { IncomeGoal } from '../../models/IncomeGoal';

@Injectable({
  providedIn: 'root'
})
export class IncomeGoalService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = getApiUrl("INCOME_GOALS");

  public getMonthlyGoal(): Observable<ApiResponse<IncomeGoal>> {
    return this.http.get<ApiResponse<IncomeGoal>>(`${this.apiUrl}/monthly`);
  }

  public setMonthlyGoal(monthlyAmount: number): Observable<ApiResponse<IncomeGoal>> {
    return this.http.put<ApiResponse<IncomeGoal>>(`${this.apiUrl}/monthly`, { monthlyAmount });
  }
}
