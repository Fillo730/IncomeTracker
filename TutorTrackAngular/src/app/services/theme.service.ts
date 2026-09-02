//Angular
import { computed, DOCUMENT, effect, inject, Injectable, signal } from '@angular/core';

//Constants
import { APP_CONFIG } from '../constants/app.config';
import { STORAGE_KEYS } from '../constants/storage-keys.config';

//Models
import { THEMES, ThemeType } from '../models/types/Theme.model';

//Utils
import { isLocalStorageValid } from '../utils/window-guard.util';

@Injectable({
  providedIn: 'root',
})

export class ThemeService {
    private readonly storageKey : string = STORAGE_KEYS.USER_THEME;
    private readonly defaultTheme : ThemeType = APP_CONFIG.DEFAULT_THEME;

    private readonly document = inject(DOCUMENT);

    private _theme = signal<ThemeType>(this.getStoredTheme());

    public theme = this._theme.asReadonly();

    public isDark = computed(() => this._theme() === THEMES.DARK);

    public readonly chartTextColor = computed(() => 
        this._theme() === THEMES.DARK ? '#ffffff' : '#0d0d0d'
    );

    constructor() {
        effect(() => {
            const currentTheme = this._theme();
            
            if(isLocalStorageValid()) {
                localStorage.setItem(this.storageKey, currentTheme);

                if(currentTheme === THEMES.DARK) {
                    this.document.body.classList.add("dark-mode");
                    this.document.body.classList.remove("light-mode");
                } else {
                    this.document.body.classList.add("light-mode");
                    this.document.body.classList.remove("dark-mode");
                }
            }
        })
    }



    public setTheme(newTheme : ThemeType) : void {
        this._theme.set(newTheme);
    }

    public toggleTheme() : void {
        this._theme.update(currentTheme => currentTheme === THEMES.DARK ? THEMES.LIGHT : THEMES.DARK);
    }

    private getStoredTheme() : ThemeType {
        if(isLocalStorageValid()) {
             return (localStorage.getItem(this.storageKey) as ThemeType) ?? this.defaultTheme; 
        }
        return this.defaultTheme;
    }
}
