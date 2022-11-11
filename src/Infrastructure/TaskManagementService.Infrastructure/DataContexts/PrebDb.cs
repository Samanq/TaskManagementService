using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagementService.Infrastructure.DataContexts;

public static class PrebDb
{
    public static void CreateDatabase(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            UpdateDatabase(serviceScope.ServiceProvider.GetService<DataContext>());
        };
    }

    private static void UpdateDatabase(DataContext dataContext)
    {
        dataContext.Database.EnsureCreated();
    }
}
