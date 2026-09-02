export interface IncomeEntry {
  id: number;
  date: Date | string;
  description: string;
  amount: number;
  hours?: number;
  categoryKey: string;
  categoryName: string;
  notes : string;
}