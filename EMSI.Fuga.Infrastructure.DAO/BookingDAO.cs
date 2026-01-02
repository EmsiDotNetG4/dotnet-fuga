#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Fuga.Infrastructure.DAO;

public class BookingDAO
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public Guid PassengerId { get; set; }
    public Guid FlightId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime? CheckingDate { get; set; }
    public int SeatNumber { get; set; }
    public PassengerDAO Passenger { get; set; }
    public FlightDAO Flight { get; set; }
}