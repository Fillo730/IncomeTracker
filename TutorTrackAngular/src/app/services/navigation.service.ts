import { Injectable, inject } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  private router = inject(Router);

  public goToDashboard(): void {
    this.router.navigate(['/current-month']);
  }

  public goToCurrentYear(): void {
    this.router.navigate(['/current-year']);
  }

  public goToAddEntry(): void {
    this.router.navigate(['/add-entry']);
  }

  public navigateTo(path: string[]): void {
    this.router.navigate(path);
  }

  public goBack(): void {
    window.history.back();
  }
}