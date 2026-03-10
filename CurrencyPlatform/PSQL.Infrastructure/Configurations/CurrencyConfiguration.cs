using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSQL.Infrastructure.Entities;

namespace PSQL.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> b)
        {
            b.ToTable("currencies");

            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(16)
                .IsRequired();

            b.HasIndex(x => x.Name).IsUnique();

            b.Property(x => x.Rate)
                .HasColumnName("rate")
                .HasPrecision(18, 6)
                .IsRequired();

            b.Property(x => x.UpdatedAtUtc)
                .HasColumnName("updated_at_utc")
                .IsRequired();
        }
    }
}
