using Microsoft.EntityFrameworkCore;
using TutorTrackApi.Data;
using TutorTrackApi.IRepositories;
using TutorTrackApi.Models;

namespace TutorTrackApi.Repositories;

public class IncomeGoalRepository(AppDbContext context) : IIncomeGoalRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IncomeGoal?> GetAsync()
    {
        return await _context.IncomeGoals.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task SetMonthlyAmountAsync(decimal amount)
    {
        var existing = await _context.IncomeGoals.FirstOrDefaultAsync();

        if (existing is null)
        {
            await _context.IncomeGoals.AddAsync(new IncomeGoal { MonthlyAmount = amount });
        }
        else
        {
            existing.MonthlyAmount = amount;
        }

        await _context.SaveChangesAsync();
    }
}
