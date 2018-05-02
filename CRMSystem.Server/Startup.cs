using CRMSystem.Data;
using CRMSystem.Data.Repository;
using CRMSystem.Implementations.Services;
using CRMSystem.Server.Extensions;
using CRMSystem.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRMSystem.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CRMDbContext>(opt => opt.
                UseSqlServer(Configuration.GetConnectionString("CRMSystem")));

            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyEmployees", policy =>
                {
                    policy.AddAuthenticationSchemes(IISDefaults.AuthenticationScheme);
                    policy.RequireRole("S - 1 - 5 - 4");
                });
            });
            
            services.AddRouting(r => r.LowercaseUrls = true);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.AddingMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("Customer", "{controller=Customer}/action=GetStatus/{nameForStatus?}");
                routes.MapRoute("default","{controller}/{action}/{id?}");
            });
        }
    }
}
