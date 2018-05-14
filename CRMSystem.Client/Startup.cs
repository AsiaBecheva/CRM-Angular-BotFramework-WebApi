using CRMSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRMSystem.Client
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

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }
    }
}