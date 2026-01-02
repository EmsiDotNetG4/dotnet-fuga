using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IFlightsRepository : IRepository<FlightDAO, Guid>
{
}