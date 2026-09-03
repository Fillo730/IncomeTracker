using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorTrackApi.Dtos;
using TutorTrackApi.Dtos.Enum;
using TutorTrackApi.IServices;
using TutorTrackApi.Models.Responses;

namespace TutorTrackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IncomeGoalsController(IIncomeGoalService goalService) : BaseController
{
    private readonly IIncomeGoalService _goalService = goalService;

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
            return Ok(ApiResponse<IncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<IncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<AnnualIncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<AnnualIncomeGoalDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }
}
