
using Cars.Api.HealthChecks;
using Cars.Data.Sql;
using Cars.Data.Sql.Migrations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Cars.Api.BindingModels;
using Cars.Api.Middlewares;
using Cars.Api.Validation;
using Cars.Data.Sql.Ad;
using Cars.Data.Sql.User;
using Cars.IData.Ad;
using Cars.IData.User;
using Cars.IServices.Ad;
using Cars.IServices.User;
using Cars.Services.Ad;
using Cars.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Cars.Api
{
    public class Startup
    {
        //Reprezentuje zestaw właściwości konfiguracyjnych aplikacji klucz / wartość. (np z pliku appsettings.json)
        public IConfiguration Configuration { get; }
        private const string MySqlHealthCheckName = "mysql";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
           
            
            services.AddCors();

            services.AddDbContext<CarsDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("CarsDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddHealthChecks()
                .AddMySql(
                    Configuration.GetConnectionString("CarsDbServer"),
                    4,
                    10,
                    MySqlHealthCheckName);
            services.AddControllers().AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditUser>, EditUserValidator>();
            services.AddTransient<IValidator<CreateUser>, CreateUserValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IAdService, AdService>();
            services.AddScoped<IAdRepository, AdRepository>();
            
            services.AddApiVersioning( o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });

        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials()); 

            app.UseAuthentication();
        
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/healthy");
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CarsDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                
                var healthCheck = serviceScope.ServiceProvider.GetRequiredService<HealthCheckService>();
                if (healthCheck.CheckHealthAsync().Result?.Entries[MySqlHealthCheckName].Status 
                    == HealthCheckResult.Healthy().Status)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    databaseSeed.Seed();
                }
                app.UseMiddleware<ErrorHandlerMiddleware>();
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            }

        }
    }
}