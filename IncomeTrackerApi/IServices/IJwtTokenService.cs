using IncomeTrackerApi.Models;

namespace IncomeTrackerApi.IServices;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
