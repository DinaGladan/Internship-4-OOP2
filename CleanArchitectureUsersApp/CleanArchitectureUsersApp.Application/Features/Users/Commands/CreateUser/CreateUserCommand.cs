
using CleanArchitectureUsersApp.Application.DTOs.Requests;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserRequest Request { get; }
        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;
        }
    }
}
