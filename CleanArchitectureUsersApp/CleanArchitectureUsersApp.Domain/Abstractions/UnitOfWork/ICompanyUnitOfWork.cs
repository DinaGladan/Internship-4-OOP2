using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;

namespace CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork
{
    public interface ICompanyUnitOfWork :IUnitOfWork
    {
        ICompanyRepository Companies { get; }
    }
}
