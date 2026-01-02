using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Database.Flights;

internal class FlightsRepository : RepositoryBase<UnitOfWork, FlightDAO, Guid>, IFlightsRepository
{
    protected FlightsRepository(UnitOfWork context) : base(context)
    {
    }
}