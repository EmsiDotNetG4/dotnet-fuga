#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Fuga.Infrastructure.DAO;

public class FlightDAO
{
    public Guid Id { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal Price { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public int PlaneNumber { get; set; }
    public bool DirectFlight { get; set; }
    public int Category { get; set; }
    public int Status { get; set; }
}