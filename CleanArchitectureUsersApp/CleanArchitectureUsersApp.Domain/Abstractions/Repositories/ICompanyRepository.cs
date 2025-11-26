using CleanArchitectureUsersApp.Domain.Entitis;

namespace CleanArchitectureUsersApp.Domain.Abstractions.Repositories
{
    public interface ICompanyRepository :IRepository<Company, int>
    {
        Task<Company?>GetCompanyByNameAsync(string companyName);
        Task<bool> DoesCompanyNameExistsAsync(string companyName);
    }
}
