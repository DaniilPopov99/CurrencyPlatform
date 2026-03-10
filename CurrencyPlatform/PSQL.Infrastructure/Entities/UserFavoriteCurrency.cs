namespace PSQL.Infrastructure.Entities
{
    public class UserFavoriteCurrency
    {
        public Guid UserId { get; set; }
        public Guid CurrencyId { get; set; }
    }
}
