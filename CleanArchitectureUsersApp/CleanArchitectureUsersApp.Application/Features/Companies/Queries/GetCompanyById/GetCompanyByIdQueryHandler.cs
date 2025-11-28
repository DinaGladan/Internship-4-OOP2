using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler
    {
        private readonly ICompaniesReadRepository _companiesReadRepository;

        public GetCompanyByIdQueryHandler(ICompaniesReadRepository companiesReadRepository)
        {
            _companiesReadRepository = companiesReadRepository;
        }

        public async Task<Result<CompanyResponse>> Handle(GetCompanyByIdQuery query)
        {
            var company = await _companiesReadRepository.GetByIdAsync(query.Id);
            var validation = new ResultValidation();

            if (company == null)
            {
                validation.AddValidationItem(ValidationItems.Company.CompanyInvalidById);
                return new Result<CompanyResponse>(null!, validation);
            }

            return new Result<CompanyResponse>(company, validation);
        }
    }
}
