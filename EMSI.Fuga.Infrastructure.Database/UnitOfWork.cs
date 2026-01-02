using EMSI.Fuga.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EMSI.Fuga.Infrastructure.Database;

internal class UnitOfWork : DbContext, IUnitOfWork
{
    public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnitOfWork).Assembly);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();

    public async Task<bool> CommitAsync()
    {
        try
        {
            return await SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}