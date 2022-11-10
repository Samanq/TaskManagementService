using Microsoft.EntityFrameworkCore;
using TaskManagementService.Infrastructure.DataContexts;
using TaskManagementService.Infrastructure.Repositories.Interfaces;

namespace TaskManagementService.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private DataContext _dataContext;

        public TaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Entities.Task?> Get(int? id)
        {
            //return await _dataContext.Tasks.FindAsync(id);
            return await _dataContext.Tasks
                .Where(a => a.Id == id)
                .Include(t => t.SubTasks)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetAll()
        {
            return await _dataContext.Tasks.ToListAsync();
        }

        public async Task Add(Entities.Task task)
        {
            await _dataContext.Tasks.AddAsync(task);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Edit(Entities.Task task)
        {
            _dataContext.Entry(task).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var task = await _dataContext.Tasks.FindAsync(id);
            if (task != null)
            {
                _dataContext.Tasks.Remove(task);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
