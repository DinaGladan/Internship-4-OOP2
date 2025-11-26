using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;

namespace CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler
    {
        private readonly IUsersReadRepository _usersReadRepository;

        public GetUserByIdQueryHandler(IUsersReadRepository usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery querry)
        {
            return await _usersReadRepository.GetByIdAsync(querry.Id);
        }

    }
}
