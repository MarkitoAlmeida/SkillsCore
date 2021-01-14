using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Data.Queries;

namespace SkillsCore.API.Configurations
{
    public static class QueryConfigurations
    {
        public static IServiceCollection AddQueryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<IEnterpriseQuery, EnterpriseQuery>();
            services.AddScoped<IAcademicFormationQuery, AcademicFormationQuery>();

            return services;
        }
    }
}
