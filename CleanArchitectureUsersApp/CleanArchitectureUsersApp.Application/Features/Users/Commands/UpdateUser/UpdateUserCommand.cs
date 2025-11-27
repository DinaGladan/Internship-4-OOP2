using CleanArchitectureUsersApp.Application.DTOs.Requests;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        public UpdateUserRequest Request { get; }
        public UpdateUserCommand(UpdateUserRequest request)
        {  
            Request = request; 
        }

    }
}
