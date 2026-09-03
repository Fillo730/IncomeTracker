using TutorTrackApi.Models;

namespace TutorTrackApi.IRepositories;

public interface IIncomeGoalRepository
{
    Task<IncomeGoal?> GetAsync();
    Task SetMonthlyAmountAsync(decimal amount);
}
