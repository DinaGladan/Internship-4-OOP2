namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.DeactiveUser
{
    public class DeactiveUserCommand
    {
        public int WantedId { get;}

        DeactiveUserCommand(int wantedId)
        {
            WantedId = wantedId;
        }
    }
}
