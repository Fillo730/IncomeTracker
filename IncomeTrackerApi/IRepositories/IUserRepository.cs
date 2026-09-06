using IncomeTrackerApi.Models;

namespace IncomeTrackerApi.IRepositories;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> AnyAsync();
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
