using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Entitis.Users;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User, int>,IUserRepository
    {
        private readonly UsersDb _usersDb;
        public UserRepository(UsersDb usersDb) : base(usersDb)
        {
            _usersDb = usersDb;
        }
        public async Task<bool> DoesEmailExistsAsync(string email)
        {
           return await _usersDb.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> DoesSurnameExistsAsync(string surname)
        {
            return await _usersDb.Users.AnyAsync(u => u.Username == surname);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _usersDb.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetBySurnameAsync(string surname)
        {
            return await _usersDb.Users.FirstOrDefaultAsync(u => u.Username == surname);
        }
    }
}
