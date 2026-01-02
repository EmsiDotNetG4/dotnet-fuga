#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace EMSI.Fuga.Infrastructure.DAO;

public class BookingDetailsDao
{
    public Guid Id { get; set; }
    public FlightDAO Flight { get; set; }
    public PassengerDAO Passenger { get; set; }
    public int Order { get; set; }
}