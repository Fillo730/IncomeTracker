using Microsoft.AspNetCore.Mvc;
using IncomeTrackerApi.Dtos;
using IncomeTrackerApi.Dtos.Enum;
using IncomeTrackerApi.IServices;
using IncomeTrackerApi.Models.Responses;

namespace IncomeTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : BaseController
{
    private readonly IAuthService _authService = authService;
    private readonly ILogger<AuthController> _logger = logger;

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return Ok(ApiResponse<LoginResponseDto>.Fail(
                AppStatusCode.ValidationError, "Username e password sono obbligatori"));
        }

        try
        {
            var result = await _authService.LoginAsync(request.Username, request.Password);

            if (result is null)
            {
                return Ok(ApiResponse<LoginResponseDto>.Fail(
                    AppStatusCode.Unauthorized, "Credenziali non valide"));
            }

            return Ok(ApiResponse<LoginResponseDto>.Ok(result, "Accesso effettuato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il login per l'utente {Username}", request.Username);
            return Ok(ApiResponse<LoginResponseDto>.Fail(
                AppStatusCode.DatabaseError, "Si è verificato un errore durante l'accesso. Riprova più tardi."));
        }
    }
}
