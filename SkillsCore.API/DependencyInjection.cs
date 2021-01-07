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
    public class DependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            ConfigureRepository(services);
            ConfigureServices(services);
            ConfigureQuery(services);
        }

        public static void ConfigureRepository(IServiceCollection services)
        {   
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();

            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {   
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureQuery(IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();
        }
    }
}
