using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.Services;
using System;

namespace SkillsCore.API.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SkillsCore.Application");
            services.AddMediatR(assembly);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IAcademicFormationService, AcademicFormationService>();

            return services;
        }
    }
}
