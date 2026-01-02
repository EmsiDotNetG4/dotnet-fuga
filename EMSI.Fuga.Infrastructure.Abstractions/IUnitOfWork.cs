namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}