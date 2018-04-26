using CRMSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRMSystem.Server.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddingMigration(this IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                scope.ServiceProvider.GetService<CRMDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
