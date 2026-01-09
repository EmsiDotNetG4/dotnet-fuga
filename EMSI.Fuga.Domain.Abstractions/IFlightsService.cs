using EMSI.Fuga.Domain.Models;

namespace EMSI.Fuga.Domain.Abstractions;

public interface IFlightsService
{
    Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(DateOnly departureDate, DateOnly? returnDate, string departureFrom, string arrivalTo, bool directFlightsOnly);
}