using TutorTrackApi.Dtos;
using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.DTOs;
using TutorTrackApi.IMappers;
using TutorTrackApi.IRepositories;
using TutorTrackApi.IServices;
using TutorTrackApi.Models;
using TutorTrackApi.Models.Responses;

namespace TutorTrackApi.Services;

public class IncomeService(IIncomeRepository incomeRepository, IIncomeMapper incomeMapper) : IIncomeService
{
    private readonly IIncomeRepository _incomeRepository = incomeRepository;

    private readonly IIncomeMapper _incomeMapper = incomeMapper;

    public async Task<PagedResponse<IncomeEntryDto>> GetPagedIncomesAsync(string lang, int pageSize, int pageNumber, IncomesFilterDto filters)
    {
        var (items, totalCount) = await _incomeRepository.GetAllAsync(lang, pageSize, pageNumber, filters);

        var dtos = _incomeMapper.MapToListDto(items, lang);

        return new PagedResponse<IncomeEntryDto>(dtos, totalCount, pageNumber, pageSize);
    }

    public async Task<bool> CreateIncomeAsync(IncomeEntryDto entry)
    {
        var incomeType = await _incomeRepository.GetIncomeTypeByKeyAsync(entry.CategoryKey);

        if (incomeType is null)
        {
            return false;
        }

        var entity = _incomeMapper.MapToEntity(entry, incomeType.Id);

        await _incomeRepository.AddAsync(entity);
        await _incomeRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateIncomeAsync(int id, IncomeEntryDto entry)
    {
        var existing = await _incomeRepository.GetByIdAsync(id);

        if (existing is null)
        {
            return false;
        }

        var incomeType = await _incomeRepository.GetIncomeTypeByKeyAsync(entry.CategoryKey);

        if (incomeType is null)
        {
            return false;
        }

        existing.Description = entry.Description;
        existing.Amount = (decimal)entry.Amount;
        existing.Hours = entry.Hours;
        existing.Date = entry.Date;
        existing.IncomeTypeId = incomeType.Id;

        await _incomeRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteIncomeAsync(int id)
    {
        var deleted = await _incomeRepository.DeleteAsync(id);

        if (!deleted)
        {
            return false;
        }

        await _incomeRepository.SaveChangesAsync();

        return true;
    }

    public async Task<double> GetIncomeForMonth(int year, int month)
    {
        return await _incomeRepository.GetIncomeForMonth(year, month);
    }

    public async Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryAsync(int year, int month, string lang)
    {
        return await _incomeRepository.GetIncomeByCategoryAsync(year, month, lang);
    }

    public async Task<double> GetHoursWorkedForMonth(int year, int month)
    {
        return await _incomeRepository.GetHoursWorkenForMonth(year, month);
    }

    public async Task<IEnumerable<IncomeTypeDto>> GetIncomeTypesAsync(string lang)
    {
        var incomeTypes = await _incomeRepository.GetAllIncomeTypes(lang);

        var result = _incomeMapper.MapTypeToDtoList(incomeTypes, lang);

        return result;
    }
}