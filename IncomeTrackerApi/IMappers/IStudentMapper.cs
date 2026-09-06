using IncomeTrackerApi.Dtos;
using IncomeTrackerApi.Models;

namespace IncomeTrackerApi.IMappers;

public interface IStudentMapper
{
    StudentDto MapToDto(Student s);
    IEnumerable<StudentDto> MapToListDto(IEnumerable<Student> s);
    Student MapToEntity(StudentDto dto);
}
