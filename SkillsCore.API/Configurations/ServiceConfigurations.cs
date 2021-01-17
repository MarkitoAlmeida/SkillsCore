using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SkillsCore.API.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SkillsCore.Application");
            services.AddMediatR(assembly);

            return services;
        }
    }
}
