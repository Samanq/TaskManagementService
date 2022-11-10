using Microsoft.EntityFrameworkCore;
using TaskManagementService.Infrastructure.DataContexts;
using TaskManagementService.Infrastructure.Repositories.Interfaces;

namespace TaskManagementService.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DataContext _dataContext;
        private DbSet<T> _table;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _table = _dataContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> Get(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Edit(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity == null) return;

            _table.Remove(entity);
            await _dataContext.SaveChangesAsync();

        }
    }
}
