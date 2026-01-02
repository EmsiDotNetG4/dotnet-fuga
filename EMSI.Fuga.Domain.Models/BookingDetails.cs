namespace EMSI.Fuga.Domain.Models;

public class BookingDetails
{
    public Flight Flight { get; set; }
    public Passenger Passenger { get; set; }
    public int Order { get; set; }
}