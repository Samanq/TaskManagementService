namespace TaskManagementService.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(int id);
        Task Edit(T entity);
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
