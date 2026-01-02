using EMSI.Fuga.Domain.Models;

namespace EMSI.Fuga.Domain.Abstractions;

public interface IPassengerService
{
    Task CreatePassengerAsync(Passenger passenger);
    Task<Passenger> GetByIdAsync(Guid passengerId);
}