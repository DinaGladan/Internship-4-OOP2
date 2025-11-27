namespace CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery
    {
        public int Id { get;}
        public GetCompanyByIdQuery(int id) 
        {
            Id = id;
        }
    }
}
