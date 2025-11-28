using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Database;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.UnitOfWork
{
    public sealed class UserUnitOfWork : UnitOfWork, IUserUnitOfWork
    {
        public IUserRepository Users { get; }

        public UserUnitOfWork(
            UsersDb usersDb,
            IUserRepository userRepository
        ) : base(usersDb)
        {
            Users = userRepository;
        }
    }
}
