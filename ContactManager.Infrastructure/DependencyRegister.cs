using ContactManager.Infrastructure.Common.Interfaces;
using ContactManager.Infrastructure.Common.Utilies;
using ContactManager.Infrastructure.Data;
using ContactManager.Infrastructure.DataAccess.IRepositories;
using ContactManager.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// DependencyRegister class for registering infrastructure services
    /// </summary>
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                   options.UseSqlServer(connectionString);
            });
            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserHelper, UserHelper>();

            return services;
        }
    }
}
