namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface ISupportsWriteRepository<T, in TKey>
    where T : class
    where TKey : struct
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(TKey id);
}