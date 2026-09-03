using TutorTrackApi.Models;

namespace TutorTrackApi.IServices;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
