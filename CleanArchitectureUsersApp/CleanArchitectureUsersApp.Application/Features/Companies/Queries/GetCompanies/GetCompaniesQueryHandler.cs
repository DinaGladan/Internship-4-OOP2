using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler
    {
        private readonly ICompaniesReadRepository _companiesReadRepository;

        public GetCompaniesQueryHandler(ICompaniesReadRepository companiesReadRepository)
        {
            _companiesReadRepository = companiesReadRepository;
        }

        public async Task<IEnumerable<CompanyResponse>> Handle()
        {
            return await _companiesReadRepository.GetAllAsync();
        }
    }
}
