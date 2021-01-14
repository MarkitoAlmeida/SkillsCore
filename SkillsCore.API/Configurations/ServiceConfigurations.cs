using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.Services;

namespace SkillsCore.API.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IAcademicFormationService, AcademicFormationService>();

            return services;
        }
    }
}
