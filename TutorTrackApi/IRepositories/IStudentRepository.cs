using TutorTrackApi.Models;

namespace TutorTrackApi.IRepositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task<bool> DeleteAsync(int id);
    Task SaveChangesAsync();
}
