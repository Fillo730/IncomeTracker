using TutorTrackApi.Dtos;
using TutorTrackApi.IRepositories;
using TutorTrackApi.IServices;

namespace TutorTrackApi.Services;

public class IncomeGoalService(IIncomeGoalRepository goalRepository) : IIncomeGoalService
{
    private readonly IIncomeGoalRepository _goalRepository = goalRepository;

    public async Task<IncomeGoalDto> GetMonthlyGoalAsync()
    {
        var goal = await _goalRepository.GetAsync();

        return new IncomeGoalDto { MonthlyAmount = goal is null ? 0 : (double)goal.MonthlyAmount };
    }

    public async Task SetMonthlyGoalAsync(double amount)
    {
        await _goalRepository.SetMonthlyAmountAsync((decimal)amount);
    }

    public async Task<AnnualIncomeGoalDto> GetAnnualGoalAsync()
    {
        var goal = await _goalRepository.GetAsync();

        return new AnnualIncomeGoalDto { AnnualAmount = goal is null ? 0 : (double)goal.AnnualAmount };
    }

    public async Task SetAnnualGoalAsync(double amount)
    {
        await _goalRepository.SetAnnualAmountAsync((decimal)amount);
    }
}
