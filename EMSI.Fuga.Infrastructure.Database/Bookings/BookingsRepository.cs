using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Database.Bookings;

internal class BookingsRepository : RepositoryBase<UnitOfWork, BookingDAO, Guid>, IBookingsRepository
{
    protected BookingsRepository(UnitOfWork context) : base(context)
    {
    }
}