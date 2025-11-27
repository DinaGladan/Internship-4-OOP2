using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.DeactiveUser
{
    public class DeactiveUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUnitOfWork _userUnitOfWork;

        public DeactiveUserCommandHandler(IUserRepository userRepository, IUserUnitOfWork userUnitOfWork)
        {
            _userRepository = userRepository;
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<Result<bool>> Handle(DeactiveUserCommand command)
        {
            var user = await _userRepository.GetByIdAsync(command.WantedId);
            var validation = new ResultValidation();

            if(user == null)
            {
                validation.AddValidationItem(ValidationItems.User.UserInvalidById);
                return new Result<bool>(false, validation);
            }

            user.IsActive = false;
            await _userRepository.UpdateAsync(user);
            await _userUnitOfWork.SaveChangesAsync();

            return new Result<bool>(true, validation);
        }
    }
}
