namespace TutorTrackApi.DTOs;

public class IncomeEntryDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Amount { get; set; }
    public double? Hours { get; set; }
    public DateTime Date { get; set; }
    public string CategoryName { get; set; } = string.Empty; 
    public string CategoryKey { get; set; } = string.Empty;
}