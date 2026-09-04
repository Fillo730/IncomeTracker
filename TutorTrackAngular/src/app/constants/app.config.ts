//Models
import { LANGUAGES } from "../models/types/Language.model";
import { THEMES } from "../models/types/Theme.model";

//Environment
import { environment } from "../../environments/environment";

export const APP_CONFIG = {
    DEFAULT_LANGUAGE: LANGUAGES.ITALIANO,
    SUPPORTED_LANGUAGES: [LANGUAGES.ITALIANO, LANGUAGES.ENGLISH],
    LANG_OPTIONS: [
        { label: "Italiano", value: LANGUAGES.ITALIANO, flag: "https://flagsapi.com/IT/flat/24.png" },
        { label: "English", value: LANGUAGES.ENGLISH, flag: "https://flagsapi.com/GB/flat/24.png" },
    ],
    DEFAULT_THEME: THEMES.DARK,
} as const;

export const API_BASE_URL = environment.apiBaseUrl;

export const API_ENDPOINTS =  {
    INCOMES: "incomes",
    STUDENTS: "students",
    INCOME_GOALS: "incomegoals",
    AUTH: "auth"
} as const;

export function getApiUrl (key : keyof typeof API_ENDPOINTS) : string {
    return `${API_BASE_URL}/${API_ENDPOINTS[key]}`;
}