using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSQL.Infrastructure.Entities;

namespace PSQL.Infrastructure.Configurations
{
    public class UserFavoriteCurrencyConfiguration : IEntityTypeConfiguration<UserFavoriteCurrency>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteCurrency> b)
        {
            b.ToTable("user_favorite_currency");

            b.HasKey(x => new { x.UserId, x.CurrencyId });

            b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            b.Property(x => x.CurrencyId).HasColumnName("currency_id").IsRequired();

            b.HasIndex(x => x.UserId);
            b.HasIndex(x => x.CurrencyId);

            b.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
