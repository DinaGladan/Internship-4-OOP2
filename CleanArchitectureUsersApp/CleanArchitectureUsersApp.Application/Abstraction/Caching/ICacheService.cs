namespace CleanArchitectureUsersApp.Application.Abstraction.Cashing
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, DateTime expiresAt);
    }
}
