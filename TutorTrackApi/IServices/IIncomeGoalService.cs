using TutorTrackApi.Dtos;

namespace TutorTrackApi.IServices;

public interface IIncomeGoalService
{
    Task<IncomeGoalDto> GetMonthlyGoalAsync();
    Task SetMonthlyGoalAsync(double amount);
    Task<AnnualIncomeGoalDto> GetAnnualGoalAsync();
    Task SetAnnualGoalAsync(double amount);
}
