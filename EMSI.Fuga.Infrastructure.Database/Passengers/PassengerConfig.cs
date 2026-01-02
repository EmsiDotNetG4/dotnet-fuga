using EMSI.Fuga.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Fuga.Infrastructure.Database.Passengers;

public class PassengerConfig : IEntityTypeConfiguration<PassengerDAO>
{
    public void Configure(EntityTypeBuilder<PassengerDAO> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(30);
        builder.Property(x => x.Nationality).HasMaxLength(10);
        builder.Property(x => x.Email).HasMaxLength(30);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Tel).HasMaxLength(20);
        builder.HasIndex(x => x.Tel).IsUnique();
        builder.Property(x => x.PassportNumber).IsRequired(false).HasMaxLength(30);
    }
}