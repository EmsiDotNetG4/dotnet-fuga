namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface ISupportsReadRepository<T, in TKey>
    where T : class
    where TKey : struct
{
    Task<T?> GetByIdAsync(TKey id);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    IQueryable<T> GetAllQueryable();
}