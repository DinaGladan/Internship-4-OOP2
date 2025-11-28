using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;

namespace CleanArchitectureUsersApp.Infrastructure.Services
{
    public class UserUniqueness : IUserUniqueness
    {
        private readonly IUserRepository _userRepository;

        public UserUniqueness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return true;
            if (excludeId.HasValue && user.Id == excludeId.Value) return true;
            return false;
        }

        public async Task<bool> IsSurnameUniqueAsync(string username, int? excludeId = null)
        {
            var user = await _userRepository.GetBySurnameAsync(username);
            if (user == null) return true;
            if (excludeId.HasValue && user.Id == excludeId.Value) return true;
            return false;
        }
    }
}
