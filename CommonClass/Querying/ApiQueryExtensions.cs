using System.Linq.Expressions;

namespace CommonClass.Querying;

public static class ApiQueryExtensions
{
    public static IQueryable<TEntity> ApplyIncludes<TEntity>(
        this IQueryable<TEntity> query,
        string? relations,
        IReadOnlyDictionary<string, Func<IQueryable<TEntity>, IQueryable<TEntity>>> allowedIncludes)
        where TEntity : class
    {
        if (string.IsNullOrWhiteSpace(relations)) return query;

        var tokens = relations
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var token in tokens)
        {
            if (!allowedIncludes.TryGetValue(token, out var apply))
                continue;

            query = apply(query);
        }

        return query;
    }

    public static IQueryable<TEntity> ApplyFiltering<TEntity>(
        this IQueryable<TEntity> query,
        Dictionary<string, string>? filter,
        IReadOnlyDictionary<string, Expression<Func<TEntity, bool>>> allowedFilters)
        where TEntity : class
    {
        if (filter is null || filter.Count == 0) return query;

        foreach (var (key, value) in filter)
        {
            if (!allowedFilters.TryGetValue(key, out var predicate))
                continue;

            query = query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<TEntity> ApplySort<TEntity>(
        this IQueryable<TEntity> query,
        string? sort,
        IReadOnlyDictionary<string, Expression<Func<TEntity, object?>>> allowedSorts)
        where TEntity : class
    {
        if (string.IsNullOrWhiteSpace(sort)) return query;

        var fields = sort.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        IOrderedQueryable<TEntity>? ordered = null;

        foreach (var raw in fields)
        {
            var desc = raw.StartsWith("-", StringComparison.Ordinal);
            var field = desc ? raw[1..] : raw;

            if (!allowedSorts.TryGetValue(field, out var selector))
                continue;

            ordered = ordered is null
                ? (desc ? query.OrderByDescending(selector) : query.OrderBy(selector))
                : (desc ? ordered.ThenByDescending(selector) : ordered.ThenBy(selector));
        }

        return ordered ?? query;
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(
        this IQueryable<TEntity> query,
        int? page,
        int? perPage,
        int maxPerPage = 200)
        where TEntity : class
    {
        if (perPage is null) return query;

        var size = Math.Clamp(perPage.Value, 1, maxPerPage);
        var p = Math.Max(page ?? 1, 1);

        return query.Skip((p - 1) * size).Take(size);
    }
}