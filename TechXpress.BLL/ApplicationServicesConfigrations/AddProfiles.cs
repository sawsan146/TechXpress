
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechXpress.DAL.Entities;

namespace TechXpress.Services.ApplicationServicesConfigrations
{
    public static class AddProfiles
    {

        public static IServiceCollection AddApplicationProfiles(this IServiceCollection services, IConfiguration configuration)
        {
            
            return services;
        }
    }
}
