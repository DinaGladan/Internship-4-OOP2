using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyUnitOfWork _companyUnitOfWork;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, ICompanyUnitOfWork companyUnitOfWork)
        {
            _companyRepository = companyRepository;
            _companyUnitOfWork = companyUnitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCompanyCommand command)
        {
            var company = await _companyRepository.GetByIdAsync(command.WantedId);
            var validation = new ResultValidation();

            if (company == null)
            {
                validation.AddValidationItem(ValidationItems.Company.CompanyInvalidById);
                return new Result<bool>(false, validation);
            }

            await _companyRepository.Delete(company);
            await _companyUnitOfWork.SaveChangesAsync();
            return new Result<bool>(true, validation);
        }
    }
}
