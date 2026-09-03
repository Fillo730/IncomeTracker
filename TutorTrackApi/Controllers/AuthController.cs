using Microsoft.AspNetCore.Mvc;
using TutorTrackApi.Dtos;
using TutorTrackApi.Dtos.Enum;
using TutorTrackApi.IServices;
using TutorTrackApi.Models.Responses;

namespace TutorTrackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : BaseController
{
    private readonly IAuthService _authService = authService;

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
            return Ok(ApiResponse<LoginResponseDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }
}
