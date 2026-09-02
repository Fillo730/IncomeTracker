using Microsoft.AspNetCore.Mvc;
using TutorTrackApi.Dtos;
using TutorTrackApi.Dtos.Enum;
using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.DTOs;
using TutorTrackApi.IServices;
using TutorTrackApi.Models;
using TutorTrackApi.Models.Responses;

namespace TutorTrackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomesController(IIncomeService incomeService) : BaseController 
{
    private readonly IIncomeService _incomeService = incomeService;

    [HttpGet]
public async Task<ActionResult> GetPaged(
    [FromQuery] string? lang, 
    [FromQuery] IncomesFilterDto filters,
    [FromQuery] int pageSize = 10, 
    [FromQuery] int pageNumber = 1)
{
    try
    {
        var currentLang = GetLang(lang);
        
        var pagedData = await _incomeService.GetPagedIncomesAsync(
            currentLang, 
            pageSize, 
            pageNumber, 
            filters);
        
        return Ok(ApiResponse<PagedResponse<IncomeEntryDto>>.Ok(pagedData));
    }
    catch (Exception ex)
    {
        return Ok(ApiResponse<PagedResponse<IncomeEntryDto>>.Fail(
            AppStatusCode.DatabaseError, ex.Message));
    }
}

    [HttpGet("total-month")]
    public async Task<ActionResult> GetTotal(
        [FromQuery] int? year, 
        [FromQuery] int? month)
    {
        var (targetYear, targetMonth) = GetYearMonth(year, month);

        try
        {
            var total = await _incomeService.GetIncomeForMonth(targetYear, targetMonth);
            return Ok(ApiResponse<double>.Ok(total));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<double>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpGet("total-hours-month")]
    public async Task<ActionResult> GetTotalHoursWorked(
        [FromQuery] int? year, 
        [FromQuery] int? month)
    {
        var (targetYear, targetMonth) = GetYearMonth(year, month);

        try
        {
            var total = await _incomeService.GetHoursWorkedForMonth(targetYear, targetMonth);

            return Ok(ApiResponse<double>.Ok(total));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<double>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }  

    [HttpGet("stats/by-category")]
    public async Task<IActionResult> GetIncomeByCategory([FromQuery] int year, [FromQuery] int month, [FromQuery] string lang = "it")
    {
        var (targetYear, targetMonth) = GetYearMonth(year, month);
        try
        {
            var result = await _incomeService.GetIncomeByCategoryAsync(targetYear, targetMonth, lang);
        
            return Ok(ApiResponse<IEnumerable<CategoryIncomeDto>>.Ok(result));
        }
        catch(Exception ex)
        {
            return Ok(ApiResponse<IncomeEntry>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpGet("stats/by-category-year")]
    public async Task<IActionResult> GetIncomeByCategoryYear([FromQuery] int? year, [FromQuery] string lang = "it")
    {
        var targetYear = year ?? DateTime.Now.Year;
        try
        {
            var result = await _incomeService.GetIncomeByCategoryForYearAsync(targetYear, lang);

            return Ok(ApiResponse<IEnumerable<CategoryIncomeDto>>.Ok(result));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<IEnumerable<CategoryIncomeDto>>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpGet("stats/monthly-income")]
    public async Task<IActionResult> GetMonthlyIncome([FromQuery] int? year)
    {
        var targetYear = year ?? DateTime.Now.Year;
        try
        {
            var result = await _incomeService.GetMonthlyIncomeForYearAsync(targetYear);

            return Ok(ApiResponse<IEnumerable<MonthlyIncomeDto>>.Ok(result));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<IEnumerable<MonthlyIncomeDto>>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpGet("stats/monthly-hours")]
    public async Task<IActionResult> GetMonthlyHours([FromQuery] int? year)
    {
        var targetYear = year ?? DateTime.Now.Year;
        try
        {
            var result = await _incomeService.GetMonthlyHoursForYearAsync(targetYear);

            return Ok(ApiResponse<IEnumerable<MonthlyHoursDto>>.Ok(result));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<IEnumerable<MonthlyHoursDto>>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpGet("types")]
    public async Task<ActionResult> GetIncomeTypes([FromQuery] string lang)
    {
        try
        {
            var result = await _incomeService.GetIncomeTypesAsync(lang);

            return Ok(ApiResponse<IEnumerable<IncomeTypeDto>>.Ok(result));
        }
        catch(Exception ex)
        {
            return Ok(ApiResponse<IncomeEntry>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] IncomeEntryDto entry)
    {
        try
        {
            var success = await _incomeService.CreateIncomeAsync(entry);

            if (!success)
            {
                return Ok(ApiResponse<IncomeEntryDto>.Fail(
                    AppStatusCode.ValidationError, "I dati dell'entrata non sono validi"));
            }

            return Ok(ApiResponse<IncomeEntryDto>.Ok(entry, "Entrata registrata con successo"));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<IncomeEntryDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] IncomeEntryDto entry)
    {
        try
        {
            var success = await _incomeService.UpdateIncomeAsync(id, entry);

            if (!success)
            {
                return Ok(ApiResponse<IncomeEntryDto>.Fail(
                    AppStatusCode.ValidationError, "I dati dell'entrata non sono validi"));
            }

            return Ok(ApiResponse<IncomeEntryDto>.Ok(entry, "Entrata aggiornata con successo"));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<IncomeEntryDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var success = await _incomeService.DeleteIncomeAsync(id);

            if (!success)
            {
                return Ok(ApiResponse<bool>.Fail(
                    AppStatusCode.ValidationError, "Entrata non trovata"));
            }

            return Ok(ApiResponse<bool>.Ok(true, "Entrata eliminata con successo"));
        }
        catch (Exception ex)
        {
            return Ok(ApiResponse<bool>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }
}