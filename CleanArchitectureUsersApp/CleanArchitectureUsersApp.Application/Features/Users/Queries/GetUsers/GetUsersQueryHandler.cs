using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;

namespace CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler
    {
        private readonly IUsersReadRepository _usersReadRepository;

       public GetUsersQueryHandler(IUsersReadRepository usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }
        
        public async Task<Result<IEnumerable<UserResponse>>> Handle()
        {
            var users = await _usersReadRepository.GetAllAsync();
            var validation = new ResultValidation();
            return new Result<IEnumerable<UserResponse>>(users, validation);
        }
    }
}
