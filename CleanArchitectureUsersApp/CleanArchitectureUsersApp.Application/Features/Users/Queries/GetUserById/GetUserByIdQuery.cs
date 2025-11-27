namespace CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery
    {
        public int Id { get;}
        public GetUserByIdQuery(int id) {
            Id = id;
        }
    }
}
