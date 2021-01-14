using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Data.Context;
using System;

namespace SkillsCore.API.Configurations
{
    public static class SkillsContextConfiguration
    {
        public static IServiceCollection AddSkillsContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = Environment.GetEnvironmentVariable("Development") ?? configuration.GetConnectionString("SkillsDB");

            services.AddScoped((provider) =>
            {
                return new DbContextOptionsBuilder<SkillsContext>()
                .UseSqlServer(connectionString)
                .Options;
            });

            services.AddDbContext<SkillsContext>();
            return services;
        }
    }
}
