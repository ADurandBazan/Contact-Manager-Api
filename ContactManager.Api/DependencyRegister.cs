using ContactManager.Api.Common.Models;
using ContactManager.Application.Common.Interfaces;

namespace ContactManager.Api
{
    /// <summary>
    /// DependencyRegister class for registering api services
    /// </summary>
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddScoped<IUser, CurrentUser>();

            services.AddHttpContextAccessor();

            return services;

        }
    }
}
