using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.Database.Bookings;
using EMSI.Fuga.Infrastructure.Database.Flights;
using EMSI.Fuga.Infrastructure.Database.Passengers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMSI.Fuga.Infrastructure.Database;

public static class Registration
{
    public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, string connectionString)
    {
        //Repositories
        services.AddScoped<IPassengersRepository, PassengersRepository>();
        services.AddScoped<IBookingsRepository, BookingsRepository>();
        services.AddScoped<IFlightsRepository, FlightsRepository>();
        
        //Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>(provider => provider.GetRequiredService<UnitOfWork>());
        
        //DB Context
        services.AddDbContext<UnitOfWork>(options => options.UseNpgsql(connectionString));
        
        return services;
    }
}