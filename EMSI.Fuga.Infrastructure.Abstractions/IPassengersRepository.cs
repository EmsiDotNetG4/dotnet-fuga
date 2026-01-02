using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IPassengersRepository : IRepository<PassengerDAO, Guid>
{
}