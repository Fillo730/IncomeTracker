using TutorTrackApi.Dtos;
using TutorTrackApi.IMappers;
using TutorTrackApi.Models;

namespace TutorTrackApi.Mapper;

public class StudentMapper : IStudentMapper
{
    public StudentDto MapToDto(Student s)
    {
        return new StudentDto
        {
            Id = s.Id,
            Name = s.Name
        };
    }

    public IEnumerable<StudentDto> MapToListDto(IEnumerable<Student> s)
    {
        return s.Select(MapToDto);
    }

    public Student MapToEntity(StudentDto dto)
    {
        return new Student
        {
            Name = dto.Name
        };
    }
}
