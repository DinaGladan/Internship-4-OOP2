using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler
    {
        private readonly ICompaniesReadRepository _companiesReadRepository;

        public GetCompaniesQueryHandler(ICompaniesReadRepository companiesReadRepository)
        {
            _companiesReadRepository = companiesReadRepository;
        }

        public async Task<Result<IEnumerable<CompanyResponse>>> Handle()
        {
            var companies = await _companiesReadRepository.GetAllAsync();
            var validation = new ResultValidation();
            return new Result<IEnumerable<CompanyResponse>>(companies, validation);
        }
    }
}
