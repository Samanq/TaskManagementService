using Microsoft.EntityFrameworkCore;

namespace TaskManagementService.Infrastructure.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {

        }

        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
