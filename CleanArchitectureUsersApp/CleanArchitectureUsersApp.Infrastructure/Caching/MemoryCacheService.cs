using CleanArchitectureUsersApp.Application.Abstraction.Cashing;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitectureUsersApp.Infrastructure.Caching
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T?> GetAsync<T>(string key)
        {
            _cache.TryGetValue(key, out T? value);
            return Task.FromResult(value);
        }

        public Task SetAsync<T>(string key, T value, DateTime expiresAt)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiresAt);
            
            _cache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }
    }
}
