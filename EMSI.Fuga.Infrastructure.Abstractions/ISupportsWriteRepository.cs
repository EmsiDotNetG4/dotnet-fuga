namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface ISupportsWriteRepository<T, in TKey>
    where T : class
    where TKey : struct
{
    Task<T> AddAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(TKey id);
}