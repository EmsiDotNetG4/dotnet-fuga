using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Infrastructure.Abstractions;
using MapsterMapper;

namespace EMSI.Fuga.Flights;

public class FlightsService : IFlightsService
{
    private readonly IFlightsRepository _flightsRepository;
    private readonly IMapper _mapper;

    public FlightsService(IFlightsRepository flightsRepository, IMapper mapper)
    {
        _flightsRepository = flightsRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(DateOnly departureDate, DateOnly? returnDate, string departureFrom, string arrivalTo,
        bool directFlightsOnly, bool cheapestFlightsFirst)
    {
        var departureDateTime = departureDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var flightsQuery = _flightsRepository.GetAllQueryable()
            .Where(f => f.DepartureDate.Date == departureDateTime
                        && f.DepartureFrom == departureFrom
                        && f.ArrivalTo == arrivalTo);
        
        if (directFlightsOnly)
            flightsQuery = flightsQuery.Where(f => f.DirectFlight);
        
        flightsQuery = cheapestFlightsFirst 
            ? flightsQuery.OrderBy(f => f.Price) 
            : flightsQuery.OrderByDescending(f => f.Price);

        var flightsDao = await flightsQuery.ToAsyncEnumerable().ToListAsync();
        
        var flights = flightsDao.Select(f => _mapper.Map<Flight>(f)).ToList();

        if (returnDate is null) 
            return flights;
        
        var returnFlights = await SearchFlightsAsync(returnDate.Value, null, arrivalTo, departureFrom, directFlightsOnly, cheapestFlightsFirst);
        flights.AddRange(returnFlights);
        return flights;
    }
}