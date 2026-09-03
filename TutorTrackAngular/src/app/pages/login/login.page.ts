import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

//i18n
import { TranslatePipe, TranslateService } from '@ngx-translate/core';

//Services
import { AuthService } from '../../services/api/auth.service';

@Component({
  selector: 'login-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatProgressSpinnerModule,
    TranslatePipe
  ],
  templateUrl: './login.page.html',
  styleUrl: './login.page.css'
})
export class LoginPage implements OnInit {
  private authService = inject(AuthService);
  private router = inject(Router);
  private translate = inject(TranslateService);

  public username = '';
  public password = '';
  public isLoading = signal<boolean>(false);
  public errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/current-month']);
    }
  }

  onSubmit(): void {
    if (!this.username.trim() || !this.password) {
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.authService.login({ username: this.username.trim(), password: this.password }).subscribe({
      next: (res) => {
        this.isLoading.set(false);

        if (res.success) {
          this.router.navigate(['/current-month']);
        } else {
          this.errorMessage.set(res.message ?? null);
        }
      },
      error: () => {
        this.isLoading.set(false);
        this.errorMessage.set(this.translate.instant('Login.Errors.Generic'));
      }
    });
  }
}
