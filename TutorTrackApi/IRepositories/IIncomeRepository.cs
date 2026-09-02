using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.Models;

namespace TutorTrackApi.IRepositories;

public interface IIncomeRepository
{
    Task<(IEnumerable<IncomeEntry> Items, int TotalCount)> GetAllAsync(string lang, int pageSize, int pageNumber, IncomesFilterDto filters);
    Task AddAsync(IncomeEntry entry);
    Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryAsync(int year, int month, string lang);
    Task<IEnumerable<IncomeType>> GetAllIncomeTypes (string lang);
    Task<IncomeType?> GetIncomeTypeByKeyAsync(string key);
    Task<double> GetIncomeForMonth(int year, int month);
    Task<double> GetHoursWorkenForMonth(int year, int month);
    Task SaveChangesAsync();
}