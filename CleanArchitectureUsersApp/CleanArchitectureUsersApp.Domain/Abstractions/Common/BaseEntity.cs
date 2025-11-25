namespace CleanArchitectureUsersApp.Domain.Abstractions.Common
{
    public class BaseEntity
    {
        public int Id { get; set; } //unutar infrastrcture 
        public DateTime CreatedAt { get; set; } //timestamp infrast
        public DateTime UpdatedAt { get; set; } //timestamp infrast

    }
}
