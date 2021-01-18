using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Data.Queries;

namespace SkillsCore.API.Configurations
{
    public static class QueryConfigurations
    {
        public static IServiceCollection AddQueryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAcademicFormationQuery, AcademicFormationQuery>();
            services.AddScoped<ICompetenceQuery, CompetencesQuery>();
            services.AddScoped<IEnterpriseQuery, EnterpriseQuery>();
            services.AddScoped<ILanguageQuery, LanguageQuery>();
            services.AddScoped<IUserQuery, UserQuery>();

            return services;
        }
    }
}
