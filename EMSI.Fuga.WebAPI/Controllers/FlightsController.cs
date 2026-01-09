using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Presentation.Dto;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace EMSI.Fuga.WebAPI.Controllers;

[Route("flights")]
public class FlightsController : ControllerBase
{
    private readonly IFlightsService _flightService;
    private readonly IMapper _mapper;


    public FlightsController(IFlightsService flightService, IMapper mapper)
    {
        _flightService = flightService;
        _mapper = mapper;
    }

    [HttpPost("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SearchFlightsAsync([FromBody]SearchFlightsRequestDto request)
    {
        var flights = await _flightService.SearchFlightsAsync(request.DepartureDate,
            request.ReturnDate,
            request.DepartureFrom,
            request.ArrivalTo,
            request.DirectFlight);
        
        if(flights.Count == 0)
            return NoContent();
        
        return OkEncapsulated(flights.Select(_mapper.Map<FlightDto>));
    }
}