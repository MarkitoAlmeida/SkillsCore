using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SkillsCore.Application.Mapper;

namespace SkillsCore.API.Helpers
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            var config = AutoMapperConfig.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
