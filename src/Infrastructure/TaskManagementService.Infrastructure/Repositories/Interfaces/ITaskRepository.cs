namespace TaskManagementService.Infrastructure.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<Entities.Task?> Get(int? id);
        Task<IEnumerable<Entities.Task>> GetAll();
        Task Add(Entities.Task task);
        Task Edit(Entities.Task entity);
        Task Delete(int id);
    }
}
