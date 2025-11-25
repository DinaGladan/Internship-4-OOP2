namespace CleanArchitectureUsersApp.Domain.Abstractions.Common
{
    public class BaseEntity
    {
        public int Id { get; set; } // guid
        public DateTime CreatedAt { get; set; } //timestamp
        public DateTime UpdatedAt { get; set; } //timestamp
    }
}
