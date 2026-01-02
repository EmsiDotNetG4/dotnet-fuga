using EMSI.Fuga.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Fuga.Infrastructure.Database.Bookings;

public class BookingConfig : IEntityTypeConfiguration<BookingDAO>
{
    public void Configure(EntityTypeBuilder<BookingDAO> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Flight).WithMany().HasForeignKey(x => x.FlightId);
        builder.HasOne(x => x.Passenger).WithMany().HasForeignKey(x => x.PassengerId);
    }
}