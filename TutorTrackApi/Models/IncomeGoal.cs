namespace TutorTrackApi.Models;

public class IncomeGoal : BaseEntity
{
    public decimal MonthlyAmount { get; set; }
    public decimal AnnualAmount { get; set; }
}
