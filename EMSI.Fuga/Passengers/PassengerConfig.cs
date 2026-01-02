using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Infrastructure.DAO;
using Mapster;

namespace EMSI.Fuga.Passengers;

public class PassengerMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Passenger, PassengerDAO>();
        config.NewConfig<PassengerDAO, Passenger>();
    }
}