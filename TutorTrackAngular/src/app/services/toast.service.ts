import { inject, Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  private readonly snackBar = inject(MatSnackBar);

  private readonly defaultConfig: MatSnackBarConfig = {
    duration: 2000,
    horizontalPosition: 'end',
    verticalPosition: 'top',
  };

  success(message: string) {
    this.snackBar.open(message, 'OK', {
      ...this.defaultConfig,
      panelClass: ['success-snackbar'],
    });
  }

  error(message: string) {
    this.snackBar.open(message, 'Chiudi', {
      ...this.defaultConfig,
      panelClass: ['error-snackbar'],
    });
  }
}