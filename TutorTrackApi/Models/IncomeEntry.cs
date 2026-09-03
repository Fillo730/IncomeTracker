using TutorTrackApi.Models;

namespace TutorTrackApi.Models;

public class IncomeEntry : BaseEntity
{
    public decimal Amount { get; set; }
    public double? Hours { get; set; }
    public DateTime Date { get; set; }

    public string Description { get; set; } = string.Empty;
    
    public int IncomeTypeId { get; set; }
    public virtual IncomeType IncomeType { get; set; } = null!;

    public int? StudentId { get; set; }
    public virtual Student? Student { get; set; }
}