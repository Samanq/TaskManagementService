using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementService.Infrastructure.DataContexts;
using TaskManagementService.Infrastructure.Repositories;

namespace TaskManagementService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server=localhost;User ID=sa;Password=1234;Database=TaskManagement;MultipleActiveResultSets=true;TrustServerCertificate=true");
            });
            services.AddTransient<TaskRepository>();

            return services;
        }
    }
}
