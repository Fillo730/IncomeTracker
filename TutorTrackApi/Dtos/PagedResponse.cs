namespace TutorTrackApi.Models.Responses;

public class PagedResponse<T>(IEnumerable<T> items, int count, int pageNumber, int pageSize)
{
    public IEnumerable<T> Items { get; set; } = items;
    public int TotalCount { get; set; } = count;
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}