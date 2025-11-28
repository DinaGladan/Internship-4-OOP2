using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler
    {
        private readonly IUsersReadRepository _usersReadRepository;

        public GetUserByIdQueryHandler(IUsersReadRepository usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery query)
        {
            var user = await _usersReadRepository.GetByIdAsync(query.Id);
            var validation = new ResultValidation();

            if (user == null)
            {
                validation.AddValidationItem(ValidationItems.User.UserInvalidById);
                return new Result<UserResponse>(null!, validation);
            }

            return new Result<UserResponse>(user, validation);
        }

    }
}
