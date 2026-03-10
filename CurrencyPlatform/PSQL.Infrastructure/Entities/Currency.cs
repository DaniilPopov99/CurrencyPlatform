namespace PSQL.Infrastructure.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
