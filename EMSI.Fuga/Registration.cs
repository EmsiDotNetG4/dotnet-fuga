using EMSI.Fuga.Bookings;
using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Flights;
using EMSI.Fuga.Passengers;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EMSI.Fuga;

public static class Registration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        //services
        services.AddScoped<IFlightsService, FlightsService>();
        services.AddScoped<IPassengersService, PassengersService>();
        services.AddScoped<IBookingsService, BookingsService>();
        
        //mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Registration).Assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
        
        return services;
    }
}