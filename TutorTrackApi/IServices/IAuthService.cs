using TutorTrackApi.Dtos;

namespace TutorTrackApi.IServices;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(string username, string password);
}
