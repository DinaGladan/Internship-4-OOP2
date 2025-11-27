using CleanArchitectureUsersApp.Application.Features.Users.Commands.CreateUser;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using CleanArchitectureUsersApp.Domain.Entitis;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHelper
    {
        private readonly  ICompanyRepository _companyRepository;
        private readonly ICompanyUnitOfWork _companyUnitOfWork;
        private readonly ICompanyUniqueness _companyUniqueness;

        public CreateCompanyCommandHelper(ICompanyRepository companyRepository, ICompanyUnitOfWork unitOfWork, ICompanyUniqueness companyUniqueness)
        {
            _companyRepository = companyRepository;
            _companyUnitOfWork = unitOfWork;
            _companyUniqueness = companyUniqueness;
        }

        public async Task<Result<bool>> Handle(CreateCompanyCommand command)
        {
            var req = command.CreateCompanyRequest;

            var company = new Company
            {
                CompanyName = req.CompanyName,

            };

            var validationResult = await company.CreateOrUpdateValidation();

            if (!await _companyUniqueness.IsCompanyNameUniqueAsync(company.CompanyName))
                validationResult.AddValidationItem(ValidationItems.Company.CompanyNameUnique);


            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            await _companyRepository.InsertAsync(company);
            await _companyUnitOfWork.SaveChangesAsync();
            return new Result<bool>(true, validationResult);
        }
    }
}
