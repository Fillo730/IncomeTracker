namespace TutorTrackApi.Models;

public class Student : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<IncomeEntry> Entries { get; set; } = new List<IncomeEntry>();
}
