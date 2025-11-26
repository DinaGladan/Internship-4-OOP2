namespace CleanArchitectureUsersApp.Domain.Abstractions.Services
{
    public interface ICompanyUniqueness
    {
        Task<bool> IsCompanyNameUniqueAsync(string companyName, int? excludeId = null);
    }
}
