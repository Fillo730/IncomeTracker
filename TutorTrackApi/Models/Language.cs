using TutorTrackApi.Models;

namespace TutorTrackApi.Models;

public class Language : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}