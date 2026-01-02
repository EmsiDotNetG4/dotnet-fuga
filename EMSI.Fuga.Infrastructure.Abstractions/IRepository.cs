namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IRepository<T, in TKey> : ISupportsReadRepository<T, TKey>, ISupportsWriteRepository<T, TKey>
where T : class
where TKey : struct
{
}