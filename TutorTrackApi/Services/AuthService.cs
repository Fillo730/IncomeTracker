using TutorTrackApi.Dtos;
using TutorTrackApi.Helpers;
using TutorTrackApi.IRepositories;
using TutorTrackApi.IServices;

namespace TutorTrackApi.Services;

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
