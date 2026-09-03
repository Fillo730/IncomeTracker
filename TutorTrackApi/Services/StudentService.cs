using TutorTrackApi.Dtos;
using TutorTrackApi.IMappers;
using TutorTrackApi.IRepositories;
using TutorTrackApi.IServices;

namespace TutorTrackApi.Services;

public class StudentService(IStudentRepository studentRepository, IStudentMapper studentMapper) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IStudentMapper _studentMapper = studentMapper;

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();

        return _studentMapper.MapToListDto(students);
    }

    public async Task<bool> CreateStudentAsync(StudentDto student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
        {
            return false;
        }

        var entity = _studentMapper.MapToEntity(student);

        await _studentRepository.AddAsync(entity);
        await _studentRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateStudentAsync(int id, StudentDto student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
        {
            return false;
        }

        var existing = await _studentRepository.GetByIdAsync(id);

        if (existing is null)
        {
            return false;
        }

        existing.Name = student.Name;

        await _studentRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var deleted = await _studentRepository.DeleteAsync(id);

        if (!deleted)
        {
            return false;
        }

        await _studentRepository.SaveChangesAsync();

        return true;
    }
}
