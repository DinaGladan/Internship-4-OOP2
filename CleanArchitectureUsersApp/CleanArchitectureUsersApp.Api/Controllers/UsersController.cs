using CleanArchitectureUsersApp.Api.Common;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.ActiveUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.CreateUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.DeactiveUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.DeleteUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.GetExternalUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.UpdateUser;
using CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUserById;
using CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureUsersApp.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly CreateUserCommandHandler _createUser;
        private readonly GetUsersQueryHandler _getUsers;
        private readonly GetUserByIdQueryHandler _getUserById;
        private readonly UpdateUserCommandHandler _updateUser;
        private readonly DeleteUserCommandHandler _deleteUser;
        private readonly ActiveUserCommandHandler _activeUser;
        private readonly DeactiveUserCommandHandler _deactiveUser;
        private readonly GetExternalUserCommandHandler _getExternalUser;

        public UsersController(CreateUserCommandHandler createUser, GetUsersQueryHandler getUsers, GetUserByIdQueryHandler getUserById, UpdateUserCommandHandler updateUser, DeleteUserCommandHandler deleteUser, ActiveUserCommandHandler activeUser, DeactiveUserCommandHandler deactiveUser, GetExternalUserCommandHandler getExternalUser)
        {
            _createUser = createUser;
            _getUsers = getUsers;
            _getUserById = getUserById;
            _updateUser = updateUser;
            _deleteUser = deleteUser;
            _activeUser = activeUser;
            _deactiveUser = deactiveUser;
            _getExternalUser = getExternalUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getUsers.Handle();
            return result.ToActionResult(this);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getUserById.Handle(new GetUserByIdQuery(id));
            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _createUser.Handle(command);
            return result.ToActionResult(this);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _updateUser.Handle(command);
            return result.ToActionResult(this);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteUser.Handle(new DeleteUserCommand(id));
            return result.ToActionResult(this);
        }

        [HttpPut("{id:int}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await _activeUser.Handle(new ActiveUserCommand(id));
            return result.ToActionResult(this);
        }

        [HttpPut("{id:int}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _deactiveUser.Handle(new DeactiveUserCommand(id));
            return result.ToActionResult(this);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportExternalUsers()
        {
            var result = await _getExternalUser.Handle();
            return result.ToActionResult(this);
        }
    }
}