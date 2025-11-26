using CleanArchitectureUsersApp.Domain.Common.Model;

namespace CleanArchitectureUsersApp.Domain.Abstractions.Repositories
{
    public interface IRepository <TEntity, TId> where TEntity : class
    {
        Task<GetAllResponse<TEntity>> GetAllAsync();
        Task<GetByIdRequest<TId>> GetByIdAsync(TId id);
        Task InsertAsync (TEntity entity);
        Task UpdateAsync (TEntity entity);
        Task DeleteAsync (TId id);
        Task Delete(TEntity entity);
    }
}
