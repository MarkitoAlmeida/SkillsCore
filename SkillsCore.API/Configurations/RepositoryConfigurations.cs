using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Repositories;

namespace SkillsCore.API.Configurations
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAcademicFormationRepository, AcademicFormationRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
