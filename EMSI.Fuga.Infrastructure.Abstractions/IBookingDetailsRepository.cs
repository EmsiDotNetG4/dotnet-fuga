using EMSI.Fuga.Infrastructure.DAO;

namespace EMSI.Fuga.Infrastructure.Abstractions;

public interface IBookingDetailsRepository : ISupportsReadRepository<BookingDetailsDao, Guid>
{
    
}