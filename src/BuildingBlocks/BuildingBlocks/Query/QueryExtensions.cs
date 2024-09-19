using BuildingBlocks.Requests;
using System.Linq.Expressions;

public static class QueryExtensions
{
    public static IQueryable<T> ApplyQueryParameters<T>(this IQueryable<T> query, QueryParameters queryParams)
    {
        // Apply Filtering
        query = query.ApplyFiltering(queryParams.FilterConditions, queryParams.UseOrOperator);

        // Apply Sorting
        query = query.ApplySorting(queryParams.SortBy, queryParams.IsSortDescending);

        // Apply Pagination
        query = query.ApplyPagination(queryParams.PageNumber, queryParams.PageSize);

        return query;
    }

    public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, List<FilterCondition> filters, bool useOrOperator)
    {
        if (filters == null || !filters.Any()) return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression predicateBody = null;

        foreach (var filter in filters)
        {
            var property = Expression.Property(parameter, filter.PropertyName);
            var constant = Expression.Constant(filter.Value);
            Expression condition = filter.Operator switch
            {
                "Equals" => Expression.Equal(property, constant),
                "Contains" => Expression.Call(property, "Contains", null, constant),
                _ => throw new NotImplementedException($"Operator '{filter.Operator}' not supported")
            };

            predicateBody = predicateBody == null
                ? condition
                : useOrOperator
                    ? Expression.OrElse(predicateBody, condition)
                    : Expression.AndAlso(predicateBody, condition);
        }

        var lambda = Expression.Lambda<Func<T, bool>>(predicateBody, parameter);
        return query.Where(lambda);
    }

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy, bool isSortDescending)
    {
        if (string.IsNullOrWhiteSpace(sortBy)) return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, sortBy);
        var lambda = Expression.Lambda(property, parameter);

        string sortMethod = isSortDescending ? "OrderByDescending" : "OrderBy";
        var result = Expression.Call(typeof(Queryable), sortMethod, new Type[] { query.ElementType, property.Type }, query.Expression, Expression.Quote(lambda));

        return query.Provider.CreateQuery<T>(result);
    }

    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
