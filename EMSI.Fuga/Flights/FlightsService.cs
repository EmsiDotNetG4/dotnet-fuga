using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Infrastructure.Abstractions;

namespace EMSI.Fuga.Flights;

public class FlightsService(IFlightsRepository flightsRepository) : IFlightsService
{
    public async Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(DateOnly departureDate, DateOnly? returnDate, string departureFrom, string arrivalTo,
        bool directFlightsOnly, bool cheapestFlightsFirst)
    {
        var flightsQuery = flightsRepository.GetAllQueryable()
            .Where(f => f.DepartureDate.Date.Date == new DateTime(departureDate.Year, departureDate.Month, departureDate.Day)
                        && f.DepartureFrom == departureFrom
                        && f.ArrivalTo == arrivalTo
                        && f.DirectFlight == directFlightsOnly);
        if (cheapestFlightsFirst)
            flightsQuery = flightsQuery.OrderBy(f => f.Price);
        else
            flightsQuery = flightsQuery.OrderByDescending(f => f.Price);

        var flights = flightsQuery.ToList().Select(f => new Flight
        {
            Id = f.Id,
            DepartureDate = f.DepartureDate,
            ArrivalDate = f.ArrivalDate,
            DepartureFrom = f.DepartureFrom,
            ArrivalTo = f.ArrivalTo,
            Price = f.Price,
            Category = (FlightCategory)f.Category,
            Status = (FlightStatus)f.Status,
        }).ToList();

        if (returnDate is not null)
        {
            var returnFlights = await SearchFlightsAsync(returnDate.Value, null, arrivalTo, departureFrom, directFlightsOnly, cheapestFlightsFirst);
            flights.AddRange(returnFlights);
        }

        return flights;
    }
}