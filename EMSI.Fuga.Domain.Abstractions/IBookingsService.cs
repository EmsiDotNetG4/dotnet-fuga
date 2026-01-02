using EMSI.Fuga.Domain.Models;

namespace EMSI.Fuga.Domain.Abstractions;

public interface IBookingsService
{
    Task BookFlightAsync(Guid flightId, Guid passengerId, decimal price, int seatNumber, int? numberOfKg);
    Task CancelFlightAsync(Guid flightId, Guid passengerId);
    Task CheckingFlightAsync(Guid flightId, Guid passengerId, string passportNumber);
}