using CleanArchitectureUsersApp.Application.Features.Companies.Commands.CreateCompany;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyUnitOfWork _companyUnitOfWork;
        private readonly ICompanyUniqueness _companyUniqueness;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, ICompanyUnitOfWork unitOfWork, ICompanyUniqueness companyUniqueness)
        {
            _companyRepository = companyRepository;
            _companyUnitOfWork = unitOfWork;
            _companyUniqueness = companyUniqueness;
        }

        public async Task<Result<bool>> Handle(UpdateCompanyCommand command)
        {
            var req = command.Request;

            var company = await _companyRepository.GetByIdAsync(req.Id);

            if (company == null)
            {
                var validation = new ResultValidation();
                validation.AddValidationItem(ValidationItems.Company.CompanyInvalidById);
                return new Result<bool>(false, validation);
            }
            company.CompanyName = req.CompanyName;

            var validationResult = await company.CreateOrUpdateValidation();

            if (!await _companyUniqueness.IsCompanyNameUniqueAsync(company.CompanyName, company.Id))
                validationResult.AddValidationItem(ValidationItems.Company.CompanyNameUnique);

            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            await _companyRepository.UpdateAsync(company);
            await _companyUnitOfWork.SaveChangesAsync();
            return new Result<bool>(true, validationResult);
        }
    }
}
