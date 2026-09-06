using IncomeTrackerApi.Dtos;
using IncomeTrackerApi.Helpers;
using IncomeTrackerApi.IRepositories;
using IncomeTrackerApi.IServices;

namespace IncomeTrackerApi.Services;

public class AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

    public async Task<LoginResponseDto?> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);

        if (user is null || !PasswordHasher.Verify(password, user.PasswordHash))
        {
            return null;
        }

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResponseDto { Token = token, Username = user.Username };
    }
}
