using CleanArchitectureUsersApp.Domain.Entitis.Users;

namespace CleanArchitectureUsersApp.Domain.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User, int> //koristimo za radnje na bazi
    {
        Task<User?> GetBySurnameAsync (string surname);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> DoesSurnameExistsAsync(string surname);
        Task<bool> DoesEmailExistsAsync(string email);
    }
}
