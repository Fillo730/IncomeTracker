//Angular
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

//Angular Material
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterOutlet } from '@angular/router';

//Pipes
import { TranslatePipe } from '@ngx-translate/core';

//Components
import { LanguageSelectorComponent } from '../language-selector/language-selector.component';
import { ThemeSelectorComponent } from '../theme-selector/theme-selector.component';

//Services
import { ThemeService } from '../../services/theme.service';
import { NavigationService } from '../../services/navigation.service';

@Component({
  selector: 'layout-component',
  standalone: true,
  imports: [
    CommonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    RouterOutlet,
    TranslatePipe,
    LanguageSelectorComponent,
    ThemeSelectorComponent
  ],
  templateUrl: './layout.html',
  styleUrl: './layout.css'
})

export class LayoutComponent {
  public themeService = inject(ThemeService);
  public navigationService = inject(NavigationService);

}