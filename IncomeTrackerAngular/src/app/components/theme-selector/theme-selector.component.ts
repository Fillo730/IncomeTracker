//Angular
import { Component, EventEmitter, Input, Output } from '@angular/core';

//AngularMaterial
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'theme-selector-component',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './theme-selector.component.html',
  styleUrl: './theme-selector.component.css',
})

export class ThemeSelectorComponent {
  @Input() isDark !: boolean;

  @Output() toggleTheme = new EventEmitter<void>();

  public handleToggleTheme() {
    this.toggleTheme.emit();
  }
}
