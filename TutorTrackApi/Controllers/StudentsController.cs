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
public class StudentsController(IStudentService studentService) : BaseController
{
    private readonly IStudentService _studentService = studentService;

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
            return Ok(ApiResponse<IEnumerable<StudentDto>>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<StudentDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<StudentDto>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
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
            return Ok(ApiResponse<bool>.Fail(
                AppStatusCode.DatabaseError, ex.Message));
        }
    }
}
