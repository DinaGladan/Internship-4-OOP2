namespace CleanArchitectureUsersApp.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand
    {
        public int WantedId { get; set; }
        public DeleteCompanyCommand(int wantedId)
        {
            WantedId = wantedId;
        }
    }
}
