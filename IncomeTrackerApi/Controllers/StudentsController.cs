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
public class StudentsController(IStudentService studentService, ILogger<StudentsController> logger) : BaseController
{
    private readonly IStudentService _studentService = studentService;
    private readonly ILogger<StudentsController> _logger = logger;
    private const string GenericErrorMessage = "Si è verificato un errore. Riprova più tardi.";

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var result = await _studentService.GetAllAsync();

            return Ok(ApiResponse<IEnumerable<StudentDto>>.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante il recupero degli studenti");
            return Ok(ApiResponse<IEnumerable<StudentDto>>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] StudentDto student)
    {
        try
        {
            var success = await _studentService.CreateStudentAsync(student);

            if (!success)
            {
                return Ok(ApiResponse<StudentDto>.Fail(
                    AppStatusCode.ValidationError, "I dati dello studente non sono validi"));
            }

            return Ok(ApiResponse<StudentDto>.Ok(student, "Studente creato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la creazione dello studente");
            return Ok(ApiResponse<StudentDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] StudentDto student)
    {
        try
        {
            var success = await _studentService.UpdateStudentAsync(id, student);

            if (!success)
            {
                return Ok(ApiResponse<StudentDto>.Fail(
                    AppStatusCode.ValidationError, "I dati dello studente non sono validi"));
            }

            return Ok(ApiResponse<StudentDto>.Ok(student, "Studente aggiornato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'aggiornamento dello studente {StudentId}", id);
            return Ok(ApiResponse<StudentDto>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var success = await _studentService.DeleteStudentAsync(id);

            if (!success)
            {
                return Ok(ApiResponse<bool>.Fail(
                    AppStatusCode.ValidationError, "Studente non trovato"));
            }

            return Ok(ApiResponse<bool>.Ok(true, "Studente eliminato con successo"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'eliminazione dello studente {StudentId}", id);
            return Ok(ApiResponse<bool>.Fail(
                AppStatusCode.DatabaseError, GenericErrorMessage));
        }
    }
}
