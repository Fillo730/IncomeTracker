//Angular
import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//Rxjs
import { Observable, tap } from 'rxjs';

//Constants
import { getApiUrl } from '../../constants/app.config';
import { STORAGE_KEYS } from '../../constants/storage-keys.config';

//Utils
import { isLocalStorageValid } from '../../utils/window-guard.util';

//Models
import { ApiResponse } from '../../models/ApiResponse.model';
import { LoginRequest, LoginResponse } from '../../models/Auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = getApiUrl("AUTH");
  private readonly storageKey = STORAGE_KEYS.AUTH_TOKEN;

  public token = signal<string | null>(this.getStoredToken());

  public isAuthenticated(): boolean {
    return !!this.token();
  }

  public login(credentials: LoginRequest): Observable<ApiResponse<LoginResponse>> {
    return this.http.post<ApiResponse<LoginResponse>>(`${this.apiUrl}/login`, credentials).pipe(
      tap(res => {
        if (res.success) {
          this.setToken(res.data.token);
        }
      })
    );
  }

  public logout(): void {
    this.token.set(null);

    if (isLocalStorageValid()) {
      localStorage.removeItem(this.storageKey);
    }
  }

  public getToken(): string | null {
    return this.token();
  }

  private setToken(token: string): void {
    this.token.set(token);

    if (isLocalStorageValid()) {
      localStorage.setItem(this.storageKey, token);
    }
  }

  private getStoredToken(): string | null {
    if (isLocalStorageValid()) {
      return localStorage.getItem(this.storageKey);
    }
    return null;
  }
}
