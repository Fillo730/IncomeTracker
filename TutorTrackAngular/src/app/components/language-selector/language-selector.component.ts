//Angular Core
import { Component, computed, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

//Angular Material
import { MatSelectModule } from '@angular/material/select';

//Services
import { LanguageService } from '../../services/language.service';

//Constants
import { APP_CONFIG } from '../../constants/app.config';
import { LanguageType } from '../../models/types/Language.model';

@Component({
  selector: 'language-selector',
  imports: [MatSelectModule, FormsModule],
  templateUrl: './language-selector.component.html',
  styleUrl: './language-selector.component.css',
})

export class LanguageSelectorComponent {
  private readonly languageService = inject(LanguageService);

  public readonly languages = [...APP_CONFIG.LANG_OPTIONS];

  public lang = this.languageService.language;

  public currentOption = computed(() =>
    this.languages.find(l => l.value === this.lang()) ?? this.languages[0]
  );

  onLanguageChange(value: LanguageType) {
    this.languageService.setLanguage(value);
  }
}
