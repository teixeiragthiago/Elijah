using System.Linq.Expressions;

namespace Elijah.Domain.Interfaces.Base;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Expression<Func<T, bool>> filter);
    Task<T?> GetByIdAsync(Expression<Func<T?, bool>> filter, params string[] include);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);

    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter, params string[] include);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(params string[] include);
    Task<int> PostAsync(T item);
    Task Delete(T item);
    Task Put(T item);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    Task<T?> FirstAsync(Expression<Func<T, bool>> filter);
    Task<int> CountAsync(Expression<Func<T, bool>> filter);
    Task<T?> FirstAsync(Expression<Func<T, bool>> filter, params string[] include);
}