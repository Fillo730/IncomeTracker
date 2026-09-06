using IncomeTrackerApi.Dtos;

namespace IncomeTrackerApi.IServices;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(string username, string password);
}
