namespace CleanArchitectureUsersApp.Domain.Abstractions.Services
{
    public interface IUserUniqueness
    {
        Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null);
        Task<bool> IsSurnameUniqueAsync(string surname, int? excludeId = null);
    }
}
