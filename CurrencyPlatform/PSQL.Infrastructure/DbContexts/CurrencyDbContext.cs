using Microsoft.EntityFrameworkCore;
using PSQL.Infrastructure.Configurations;
using PSQL.Infrastructure.Entities;

namespace PSQL.Infrastructure.DbContexts
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavoriteCurrency> UserFavoriteCurrencies { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new UserFavoriteCurrencyConfiguration());
        }
    }
}
