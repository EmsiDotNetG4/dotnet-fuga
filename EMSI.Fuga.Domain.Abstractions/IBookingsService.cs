using EMSI.Fuga.Domain.Models;

namespace EMSI.Fuga.Domain.Abstractions;

public interface IBookingsService
{
    Task BookFlightAsync(Booking booking);
    Task CancelFlightAsync(Guid bookingId, Guid passengerId);
    Task CheckingFlightAsync(Guid bookingId, Guid passengerId, string passportNumber);
}