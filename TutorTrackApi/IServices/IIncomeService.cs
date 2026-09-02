using TutorTrackApi.Models.Responses;
using TutorTrackApi.Models;
using TutorTrackApi.DTOs;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos;

namespace TutorTrackApi.IServices;

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
}