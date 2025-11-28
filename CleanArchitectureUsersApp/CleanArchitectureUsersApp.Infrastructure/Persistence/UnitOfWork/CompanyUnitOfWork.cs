using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Database;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.UnitOfWork
{
    public sealed class CompanyUnitOfWork : UnitOfWork, ICompanyUnitOfWork
    {
        public ICompanyRepository Companies { get; }

        public CompanyUnitOfWork(
            CompaniesDb companiesDb,
            ICompanyRepository companyRepository
        ) : base(companiesDb)
        {
            Companies = companyRepository;
        }
    }
}
