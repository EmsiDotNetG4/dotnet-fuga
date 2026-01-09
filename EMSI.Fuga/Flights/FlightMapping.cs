using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Infrastructure.DAO;
using Mapster;

namespace EMSI.Fuga.Flights;

public class FlightMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Flight, FlightDAO>();
        config.NewConfig<FlightDAO, Flight>();
    }
}