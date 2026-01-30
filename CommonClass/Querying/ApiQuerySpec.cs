namespace CommonClass.Querying;

public sealed class ApiQuerySpec
{
    public string? Relations { get; init; }  // "employee.user,pays"
    public string? Sort { get; init; }       // "name,-id"
    public int Page { get; init; } = 1;          // 1
    public int PerPage { get; init; } = 20;    // 20

    public Dictionary<string, string>? Filter { get; init; }
}
