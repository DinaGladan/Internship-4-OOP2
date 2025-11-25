namespace CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollBack();
        Task SaveChangesAsync();
    }
}
