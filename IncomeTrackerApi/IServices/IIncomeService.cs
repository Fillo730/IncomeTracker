using IncomeTrackerApi.Models.Responses;
using IncomeTrackerApi.Models;
using IncomeTrackerApi.Dtos.Stats;
using IncomeTrackerApi.Dtos.Filters;
using IncomeTrackerApi.Dtos;

namespace IncomeTrackerApi.IServices;

public interface IIncomeService
{
    Task<PagedResponse<IncomeEntryDto>> GetPagedIncomesAsync(string lang, int pageSize, int pageNumber, IncomesFilterDto filters);

    Task<double> GetIncomeForMonth(int year, int month);
    Task<double> GetHoursWorkedForMonth(int year, int month);
    Task<bool> CreateIncomeAsync(IncomeEntryDto entry);
    Task<bool> UpdateIncomeAsync(int id, IncomeEntryDto entry);
    Task<bool> DeleteIncomeAsync(int id);
    Task<IEnumerable<IncomeTypeDto>> GetIncomeTypesAsync(string lang);
    Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryAsync(int year, int month, string lang);
    Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryForYearAsync(int year, string lang);
    Task<IEnumerable<StudentIncomeDto>> GetIncomeByStudentForYearAsync(int year);
    Task<IEnumerable<MonthlyIncomeDto>> GetMonthlyIncomeForYearAsync(int year);
    Task<IEnumerable<MonthlyHoursDto>> GetMonthlyHoursForYearAsync(int year);
}