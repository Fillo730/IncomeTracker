import { IncomeType } from "./types/IncomeEntryType";

export interface IncomeEntry {
  id: number;
  date: Date | string;
  description: string;
  amount: number;
  hours?: number;
  type: IncomeType;
  notes : string;
}