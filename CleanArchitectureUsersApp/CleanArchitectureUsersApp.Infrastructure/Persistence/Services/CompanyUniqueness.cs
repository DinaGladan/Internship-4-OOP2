using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;

namespace CleanArchitectureUsersApp.Infrastructure.Services
{
    public class CompanyUniqueness : ICompanyUniqueness
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyUniqueness(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> IsCompanyNameUniqueAsync(string companyName, int? excludeId = null)
        {
            var company = await _companyRepository.GetCompanyByNameAsync(companyName);
            if (company == null)
                return true;
            if (excludeId.HasValue && company.Id == excludeId.Value)
                return true;
            return false;
        }
    }
}
