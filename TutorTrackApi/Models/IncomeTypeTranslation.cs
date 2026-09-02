using TutorTrackApi.Models;

namespace TutorTrackApi.Models;

public class IncomeTypeTranslation : BaseEntity
{
    public int IncomeTypeId { get; set; }
    public int LanguageId { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public virtual IncomeType IncomeType { get; set; } = null!;
    public virtual Language Language { get; set; } = null!;
}