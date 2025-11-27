namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.ActiveUser
{
    public class ActiveUserCommand
    {
        public int WantedId;

        public ActiveUserCommand(int wantedId)
        {
            WantedId = wantedId;
        }
    }
}
