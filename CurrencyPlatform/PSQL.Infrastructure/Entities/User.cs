namespace PSQL.Infrastructure.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
