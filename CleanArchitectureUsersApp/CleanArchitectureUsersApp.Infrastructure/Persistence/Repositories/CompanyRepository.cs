using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Entitis;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        private readonly CompaniesDb _companiesDb;

        public CompanyRepository(CompaniesDb companiesDb) : base(companiesDb)
        {
            _companiesDb = companiesDb;
        }

        public async Task<bool> DoesCompanyNameExistsAsync(string companyName)
        {
            return await _companiesDb.Companies.AnyAsync(c => c.CompanyName == companyName );
        }

        public async Task<Company?> GetCompanyByNameAsync(string companyName)
        {
            return await _companiesDb.Companies.FirstOrDefaultAsync(c => c.CompanyName == companyName);
        }
    }
}
