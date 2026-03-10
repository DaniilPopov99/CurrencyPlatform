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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.ToTable("users");

            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();

            b.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired();

            b.HasIndex(x => x.Name).IsUnique();

            b.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(256)
                .IsRequired();

            b.Property(x => x.CreatedAtUtc)
                .HasColumnName("created_at_utc")
                .IsRequired();
        }
    }
}
