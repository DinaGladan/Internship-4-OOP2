using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler
    {
        private readonly ICompaniesReadRepository _companiesReadRepository;

        public GetCompanyByIdQueryHandler(ICompaniesReadRepository companiesReadRepository)
        {
            _companiesReadRepository = companiesReadRepository;
        }

        public async Task<CompanyResponse> Handle(GetCompanyByIdQuery query)
        {
            return await _companiesReadRepository.GetByIdAsync(query.Id);
        }
    }
}
