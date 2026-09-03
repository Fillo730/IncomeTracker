using Microsoft.EntityFrameworkCore;
using TutorTrackApi.Data;
using TutorTrackApi.IRepositories;
using TutorTrackApi.Models;

namespace TutorTrackApi.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> AnyAsync()
    {
        return await _context.Users.AnyAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
