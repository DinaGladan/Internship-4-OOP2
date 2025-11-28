namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.DeactiveUser
{
    public class DeactiveUserCommand
    {
        public int WantedId { get;}

        public DeactiveUserCommand(int wantedId)
        {
            WantedId = wantedId;
        }
    }
}
