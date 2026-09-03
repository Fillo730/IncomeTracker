using TutorTrackApi.Dtos;

namespace TutorTrackApi.IServices;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllAsync();
    Task<bool> CreateStudentAsync(StudentDto student);
    Task<bool> UpdateStudentAsync(int id, StudentDto student);
    Task<bool> DeleteStudentAsync(int id);
}
