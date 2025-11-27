using CleanArchitectureUsersApp.Application.DTOs.ExternalDTO;

namespace CleanArchitectureUsersApp.Application.Abstraction.External
{
    public interface IExternalService
    {
        public Task<List<ExternalUser>> GetExternalUsersAsync();
    }
}

