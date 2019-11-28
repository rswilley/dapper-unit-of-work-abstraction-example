using DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories;
using DapperGenericRepositoryUnitOfWorkExample.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperGenericRepositoryUnitOfWorkExample
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
            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IConnectionSession, ConnectionSession>();
            services.AddTransient<IStorageManager, StorageManager>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
