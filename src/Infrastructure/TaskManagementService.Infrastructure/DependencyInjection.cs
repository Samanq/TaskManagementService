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
                options.UseSqlServer("Server=db;User ID=sa;Password=Aa@123456;Database=TaskManagement;MultipleActiveResultSets=true;TrustServerCertificate=true");
            });
            services.AddTransient<TaskRepository>();

            return services;
        }
    }
}
