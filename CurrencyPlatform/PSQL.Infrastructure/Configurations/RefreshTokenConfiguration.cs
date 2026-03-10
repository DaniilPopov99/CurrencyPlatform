using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSQL.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSQL.Infrastructure.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> b)
        {
            b.ToTable("refresh_tokens");

            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.UserId).HasColumnName("user_id").IsRequired();

            b.Property(x => x.TokenHash)
                .HasColumnName("token_hash")
                .HasMaxLength(256)
                .IsRequired();

            b.HasIndex(x => x.UserId);
            b.HasIndex(x => x.TokenHash).IsUnique();

            b.Property(x => x.ExpiresAtUtc).HasColumnName("expires_at_utc").IsRequired();
            b.Property(x => x.CreatedAtUtc).HasColumnName("created_at_utc").IsRequired();
            b.Property(x => x.RevokedAtUtc).HasColumnName("revoked_at_utc");

            b.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
