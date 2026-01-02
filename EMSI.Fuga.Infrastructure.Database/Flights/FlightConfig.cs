using EMSI.Fuga.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Fuga.Infrastructure.Database.Flights;

public class FlightConfig : IEntityTypeConfiguration<FlightDAO>
{
    public void Configure(EntityTypeBuilder<FlightDAO> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DepartureFrom).HasMaxLength(30);
        builder.Property(x => x.ArrivalTo).HasMaxLength(30);
    }
}