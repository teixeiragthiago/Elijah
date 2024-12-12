using Microsoft.EntityFrameworkCore;

namespace Elijah.Infrastructure.Database.Repository.Base;

public static class BaseRepositoryExtensions
{
    public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> elements, int? page)
    {
        int total = await elements.CountAsync();
        return !page.HasValue ? elements.Take(total) : elements.Skip(10 * ((int)page - 1)).Take(10);
    }
}