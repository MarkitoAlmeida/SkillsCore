using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Repositories;
using SkillsCore.Shared.Models;

namespace SkillsCore.API.Configurations
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IAcademicFormationRepository, AcademicFormationRepository>();

            return services;
        }
    }
}
