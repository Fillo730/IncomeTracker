using TutorTrackApi.Dtos;
using TutorTrackApi.Models;

namespace TutorTrackApi.IMappers;

public interface IStudentMapper
{
    StudentDto MapToDto(Student s);
    IEnumerable<StudentDto> MapToListDto(IEnumerable<Student> s);
    Student MapToEntity(StudentDto dto);
}
