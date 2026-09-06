using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IncomeTrackerApi.Dtos;
using IncomeTrackerApi.Dtos.Enum;
using IncomeTrackerApi.IServices;
using IncomeTrackerApi.Models.Responses;

namespace IncomeTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IncomeGoalsController(IIncomeGoalService goalService, ILogger<IncomeGoalsController> logger) : BaseController
{
    private readonly IIncomeGoalService _goalService = goalService;
    private readonly ILogger<IncomeGoalsController> _logger = logger;
    private const string GenericErrorMessage = "Si è verificato un errore. Riprova più tardi.";

    [HttpGet("monthly")]
    public async Task<ActionResult> GetMonthly()
    {
        try
        {
            var result = await _goalService.GetMonthlyGoalAsync();

            return Ok(ApiResponse<IncomeGoalDto>.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero dell'obiettivo mensile");
            return Ok(ApiResponse<IncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpPut("monthly")]
    public async Task<ActionResult> SetMonthly([FromBody] IncomeGoalDto goal)
    {
        if (goal.MonthlyAmount < 0)
        {
            return Ok(ApiResponse<IncomeGoalDto>.Fail(
                AppStatusCode.ValidationError, "L'obiettivo non può essere negativo"));
        }

        try
        {
            await _goalService.SetMonthlyGoalAsync(goal.MonthlyAmount);

            return Ok(ApiResponse<IncomeGoalDto>.Ok(goal, "Obiettivo aggiornato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'aggiornamento dell'obiettivo mensile");
            return Ok(ApiResponse<IncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpGet("annual")]
    public async Task<ActionResult> GetAnnual()
    {
        try
        {
            var result = await _goalService.GetAnnualGoalAsync();

            return Ok(ApiResponse<AnnualIncomeGoalDto>.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero dell'obiettivo annuale");
            return Ok(ApiResponse<AnnualIncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpPut("annual")]
    public async Task<ActionResult> SetAnnual([FromBody] AnnualIncomeGoalDto goal)
    {
        if (goal.AnnualAmount < 0)
        {
            return Ok(ApiResponse<AnnualIncomeGoalDto>.Fail(
                AppStatusCode.ValidationError, "L'obiettivo non può essere negativo"));
        }

        try
        {
            await _goalService.SetAnnualGoalAsync(goal.AnnualAmount);

            return Ok(ApiResponse<AnnualIncomeGoalDto>.Ok(goal, "Obiettivo aggiornato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'aggiornamento dell'obiettivo annuale");
            return Ok(ApiResponse<AnnualIncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }
}
