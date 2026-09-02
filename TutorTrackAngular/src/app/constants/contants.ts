export const YEARS: number[] = Array.from(
  { length: 10 }, 
  (_, i) => new Date().getFullYear() - i
);

export const MONTHS: number[] = Array.from(
  { length: 12 }, 
  (_, i) => i + 1
);