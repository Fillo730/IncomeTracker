using IncomeTrackerApi.Models;

namespace IncomeTrackerApi.IRepositories;

public interface IIncomeGoalRepository
{
    Task<IncomeGoal?> GetAsync();
    Task SetMonthlyAmountAsync(decimal amount);
    Task SetAnnualAmountAsync(decimal amount);
}
