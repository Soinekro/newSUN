namespace CommonClass.Domain.Wrappers;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int TotalPages => PerPage > 0 ? (int)Math.Ceiling(TotalItems / (double)PerPage) : 0;
}