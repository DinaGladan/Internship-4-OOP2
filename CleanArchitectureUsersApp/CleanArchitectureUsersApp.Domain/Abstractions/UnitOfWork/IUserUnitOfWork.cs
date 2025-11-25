using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;

namespace CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
