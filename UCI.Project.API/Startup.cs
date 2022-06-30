using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UCI.Project.Domain.Core.Data;
using UCI.Project.Domain.Repositories;
using UCI.Project.Infraestructure.Data;
using UCI.Project.Infraestructure.Data.Context;
using UCI.Project.Infraestructure.Data.Repositories;

namespace UCI.Project.API
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
                .AddControllers()
                .AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UCI.Project.API", Version = "v1" });
            });

            string connectionString = Configuration.GetConnectionString("UCI.Project");

            //configure DB connection
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                        sqlOption =>
                        {
                            sqlOption.CommandTimeout(3600);
                            sqlOption.EnableRetryOnFailure(10);
                        });
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //configure services
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<INotificationRepository, NotificationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UCI.Project.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
