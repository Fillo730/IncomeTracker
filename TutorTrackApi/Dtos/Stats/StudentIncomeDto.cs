namespace TutorTrackApi.Dtos.Stats;

public class StudentIncomeDto
{
    public string StudentName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public double TotalHours { get; set; }
}
