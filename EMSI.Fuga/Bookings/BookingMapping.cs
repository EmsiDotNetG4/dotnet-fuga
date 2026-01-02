using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Infrastructure.DAO;
using Mapster;

namespace EMSI.Fuga.Bookings;

public class BookingMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BookingDAO, Booking>();
        config.NewConfig<Booking, BookingDAO>()
            .Map(dest => dest.FlightId, src => src.Flight.Id)
            .Map(dest => dest.PassengerId, src => src.Passenger.Id);
    }
}