export const INCOME_ENTRY_TYPES = {
    SALARY: "Salary",
    TUTORING: "Tutoring",
    OTHER: "Other"
}as const;

export type IncomeType = typeof INCOME_ENTRY_TYPES[keyof typeof INCOME_ENTRY_TYPES];