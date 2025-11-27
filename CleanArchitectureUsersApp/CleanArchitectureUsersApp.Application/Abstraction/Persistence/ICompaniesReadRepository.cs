using CleanArchitectureUsersApp.Application.DTOs.Responses;

namespace CleanArchitectureUsersApp.Application.Abstraction.Persistence
{
    public interface ICompaniesReadRepository
    {
        Task<IEnumerable<CompanyResponse>> GetAllAsync();
        Task<CompanyResponse?> GetByIdAsync(int id);
    }
}
