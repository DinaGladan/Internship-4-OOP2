using CleanArchitectureUsersApp.Application.DTOs.Requests;

namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand
    {
        public UpdateCompanyRequest Request { get; set; }

        public UpdateCompanyCommand(UpdateCompanyRequest request)
        {
            Request = request;
        }
    }
}
