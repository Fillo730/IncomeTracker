using TutorTrackApi.Models;

public class IncomeType : BaseEntity
{
    
    public string Key { get; set; } = string.Empty;

    public virtual ICollection<IncomeTypeTranslation> Translations { get; set; } = new List<IncomeTypeTranslation>();

    public virtual ICollection<IncomeEntry> Entries { get; set; } = new List<IncomeEntry>();
}