using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IBookingsRepository : IRepository<BookingDAO, Guid>
{
}