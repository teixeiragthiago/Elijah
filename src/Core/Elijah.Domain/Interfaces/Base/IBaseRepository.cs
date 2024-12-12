using System.Linq.Expressions;

namespace Elijah.Domain.Interfaces.Base;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Expression<Func<T, bool>> filter, CancellationToken ct);
    Task<T?> GetByIdAsync(Expression<Func<T?, bool>> filter, CancellationToken ct, params string[] include);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter, CancellationToken ct);

    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter, CancellationToken ct, params string[] include);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken ct, params string[] include);
    Task<int> PostAsync(T item, CancellationToken ct);
    Task Delete(T item, CancellationToken ct);
    Task Put(T item, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken ct);
    Task<T?> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken ct);
    Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken ct);
    Task<T?> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken ct, params string[] include);
}