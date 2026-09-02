namespace TutorTrackApi.Dtos.Filters;

public class IncomesFilterDto
{
    public string? Query { get; set; }
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? IncomeTypeId { get; set; }
}