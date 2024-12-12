using System.Linq.Expressions;
using Elijah.Domain.Interfaces.Base;
using Elijah.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Elijah.Infrastructure.Database.Repository.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
    }

    public async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity?, bool>> filter, params string[] include)
    {
        IQueryable<TEntity?> query = _context.Set<TEntity>().AsQueryable();

        query = include.Aggregate(query, (current, item) => current.Include(item).AsQueryable());

        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().AsQueryable().Where(filter).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] include)
    {
        var query = _context.Set<TEntity>().Where(filter);

        query = include.Aggregate(query, (current, item) => current.Include(item).AsQueryable());

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(params string[] include)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = include.Aggregate(query, (current, item) => current.Include(item).AsNoTracking().AsQueryable());
        return await query.ToListAsync();
    }

    public async Task<int> PostAsync(TEntity item)
    {
        _context.Set<TEntity>().Add(item);
        await _context.SaveChangesAsync();

        var idProperty = item.GetType().GetProperty("Id")?.GetValue(item, null);

        if (!(Convert.ChangeType(idProperty, typeof(int)) is int convertedId))
            return 0;

        return (int)convertedId;
    }

    public async Task Delete(TEntity item)
    {
        _context.Set<TEntity>().Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task Put(TEntity item)
    {
        _context.Set<TEntity>().Attach(item);
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().AnyAsync(filter);
    }

    public async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().CountAsync(filter);
    }

    public async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> filter, params string[] include)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        query = include.Aggregate(query, (current, item) => current.Include(item).AsQueryable());

        return await query.FirstOrDefaultAsync(filter);
    }
}