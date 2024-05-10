using ContactManager.Application.ApplicationServices.IServices;
using ContactManager.Application.ApplicationServices.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContactManager.Application
{
    /// <summary>
    /// DependencyRegister class for registering application services
    /// </summary>
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
