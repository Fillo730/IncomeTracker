using Microsoft.EntityFrameworkCore;
using TutorTrackApi.Data;
using TutorTrackApi.IRepositories;
using TutorTrackApi.Models;

namespace TutorTrackApi.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .AsNoTracking()
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Students.FindAsync(id);

        if (entity is null)
        {
            return false;
        }

        _context.Students.Remove(entity);

        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
