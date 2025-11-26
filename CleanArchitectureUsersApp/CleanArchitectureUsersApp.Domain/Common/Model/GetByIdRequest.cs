namespace CleanArchitectureUsersApp.Domain.Common.Model
{
    public class GetByIdRequest<T>
    {
        public T Id { get; set; }
        GetByIdRequest(T id)
        {
            Id = id;
        }

    }
}
