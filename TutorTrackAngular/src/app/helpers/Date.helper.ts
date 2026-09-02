import { YEARS, MONTHS } from "../constants/contants";

export class DateHelper {
  
  static getYears(): number[] {
    return YEARS;
  }

  static getMonths(): number[] {
    return MONTHS;
  }

  static getMonthName(month: number, year: number, lang: string): string {
    const date = new Date(year, month - 1, 1);
    const monthName = new Intl.DateTimeFormat(lang, { month: 'long' }).format(date);
    return monthName.charAt(0).toUpperCase() + monthName.slice(1);
  }

  static getTranslatedMonths(year: number, lang: string) {
    return MONTHS.map(m => ({
      id: m,
      name: this.getMonthName(m, year, lang)
    }));
  }
}