export interface IncomesFilter {
  query: string;
  year: number | null;
  month: number | null;
  incomeTypeId: number | null;
}

export const DEFAULT_INCOMES_FILTER: IncomesFilter = {
  query: '',
  year: new Date().getFullYear(),
  month: new Date().getMonth() + 1,
  incomeTypeId: null
};