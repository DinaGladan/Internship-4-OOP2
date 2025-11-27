using CleanArchitectureUsersApp.Application.DTOs.Requests;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand
    {
        public CreateCompanyRequest CreateCompanyRequest { get; }

        public CreateCompanyCommand(CreateCompanyRequest createCompanyRequest)
        {
            CreateCompanyRequest = createCompanyRequest;
        }
    }
}
