using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.Services;
using SkillsCore.Data.Queries;
using SkillsCore.Data.Repositories;
using SkillsCore.Shared.Models;

namespace SkillsCore.API
{
    public static class DependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureQuery(services);
            ConfigureRepository(services);
        }

        public static void ConfigureServices(IServiceCollection services)
        {   
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IAcademicFormationService, AcademicFormationService>();
        }

        public static void ConfigureQuery(IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<IEnterpriseQuery, EnterpriseQuery>();
            services.AddScoped<IAcademicFormationQuery, AcademicFormationQuery>();
        }

        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IAcademicFormationRepository, AcademicFormationRepository>();
        }
    }
}
