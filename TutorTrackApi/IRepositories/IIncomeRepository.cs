using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.Models;

namespace TutorTrackApi.IRepositories;

public interface IIncomeRepository
{
    Task<(IEnumerable<IncomeEntry> Items, int TotalCount)> GetAllAsync(string lang, int pageSize, int pageNumber, IncomesFilterDto filters);
    Task AddAsync(IncomeEntry entry);
    Task<IncomeEntry?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryAsync(int year, int month, string lang);
    Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryForYearAsync(int year, string lang);
    Task<IEnumerable<StudentIncomeDto>> GetIncomeByStudentForYearAsync(int year);
    Task<IEnumerable<MonthlyIncomeDto>> GetMonthlyIncomeForYearAsync(int year);
    Task<IEnumerable<MonthlyHoursDto>> GetMonthlyHoursForYearAsync(int year);
    Task<IEnumerable<IncomeType>> GetAllIncomeTypes (string lang);
    Task<IncomeType?> GetIncomeTypeByKeyAsync(string key);
    Task<double> GetIncomeForMonth(int year, int month);
    Task<double> GetHoursWorkenForMonth(int year, int month);
    Task SaveChangesAsync();
}