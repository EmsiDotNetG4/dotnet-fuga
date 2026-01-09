using AutoFixture;
using AutoFixture.Xunit2;
using EMSI.Fuga.Flights;
using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;
using Moq;
using Xunit;

namespace EMSI.Fuga.Tests;

public class FlightsServiceTests : TestBase
{
    //System Under Test
    private readonly FlightsService _sut;
    
    // dependencies
    private readonly Mock<IFlightsRepository> _flightsRepositoryMock = new ();
    
    public FlightsServiceTests()
    {
        _sut = new FlightsService(_flightsRepositoryMock.Object, Mapper);
    }

    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_DepartureOnly_ReturnsFlights(DateTime departureDateTime, string departureFrom, string arrivalTo,
        bool directFlightsOnly)
    {
        //arrange
        //data set/jeux de données
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        var flightsDao = Fixture.CreateMany<FlightDAO>(10).ToList();
        flightsDao[0].DepartureDate = departureDateTime;
        flightsDao[0].DepartureFrom = departureFrom;
        flightsDao[0].ArrivalTo = arrivalTo;
        if(directFlightsOnly)
            flightsDao[0].DirectFlight = directFlightsOnly;
        _flightsRepositoryMock.Setup(x => x.GetAllQueryable()).Returns(flightsDao.AsQueryable());
        
        //act
        //call to method
        var actual = await _sut.SearchFlightsAsync(departureDate, null, departureFrom, arrivalTo, directFlightsOnly);
        
        //assert
        //check results
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Single(actual);
    }
    
    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_RoundTrip_ReturnsFlights(DateTime departureDateTime, DateTime returnDateTime, string departureFrom, string arrivalTo, bool directFlightsOnly)
    {
        //arrange
        //data set/jeux de données
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        var returnDate = DateOnly.FromDateTime(returnDateTime);
        var flightsDao = Fixture.CreateMany<FlightDAO>(10).ToList();
        
        //departure flight arrangement
        flightsDao[0].DepartureDate = departureDateTime;
        flightsDao[0].DepartureFrom = departureFrom;
        flightsDao[0].ArrivalTo = arrivalTo;
        if(directFlightsOnly)
            flightsDao[0].DirectFlight = directFlightsOnly;
        //return flight arrangement
        flightsDao[1].DepartureDate = returnDateTime;
        flightsDao[1].ArrivalTo = departureFrom;
        flightsDao[1].DepartureFrom = arrivalTo;
        if(directFlightsOnly)
            flightsDao[1].DirectFlight = directFlightsOnly;

        _flightsRepositoryMock.Setup(x => x.GetAllQueryable()).Returns(flightsDao.AsQueryable());
        
        //act
        //call to method
        var actual = await _sut.SearchFlightsAsync(departureDate, returnDate, departureFrom, arrivalTo, directFlightsOnly);
        
        //assert
        //check results
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Equal(2, actual.Count);
    }
}