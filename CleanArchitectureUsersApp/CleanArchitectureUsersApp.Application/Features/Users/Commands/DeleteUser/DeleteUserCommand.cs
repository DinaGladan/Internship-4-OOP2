namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        public int WantedId { get;}

        public DeleteUserCommand(int wantedId)
        {
            WantedId = wantedId;
        }
    }
}
