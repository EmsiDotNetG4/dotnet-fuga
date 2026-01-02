using EMSI.Fuga.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EMSI.Fuga.Infrastructure.Database;

internal class RepositoryBase<TDbContext, T, TPk> : IRepository<T, TPk>
    where T : class
    where TDbContext : DbContext
    where TPk : struct
{
    protected readonly TDbContext Context;
    private readonly DbSet<T> _set;
    protected RepositoryBase(TDbContext context)
    {
        Context = context;
        _set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(TPk id) => 
        await _set.FindAsync(id);

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _set.AsAsyncEnumerable().ToListAsync();
    }

    public IQueryable<T> GetAllQueryable()
    {
        return _set.AsNoTracking();
    }

    public async Task<T> AddAsync(T entity)
    {
        var result = await _set.AddAsync(entity);
        return result.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var result = _set.Update(entity);
        return await Task.FromResult(result.Entity);
    }

    public async Task DeleteAsync(TPk id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return;
        _set.Remove(entity);
    }
}