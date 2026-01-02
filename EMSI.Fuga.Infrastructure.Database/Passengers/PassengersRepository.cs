using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Database.Passengers;

internal class PassengersRepository : RepositoryBase<UnitOfWork, PassengerDAO, Guid>, IPassengersRepository
{
    protected PassengersRepository(UnitOfWork context) : base(context)
    {
    }
}