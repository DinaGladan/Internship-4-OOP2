using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;

namespace CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler
    {
        private readonly IUsersReadRepository _usersReadRepository;

       public GetUsersQueryHandler(IUsersReadRepository usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }
        
        public async Task<IEnumerable<UserResponse>> Handle()
        {
            return await _usersReadRepository.GetAllAsync();
        }
    }
}
