using AutoMapper;

namespace SkillsCore.Application.Mapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig() { }

        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMap());
                cfg.AddProfile(new ViewModelToDomainMap());
            });
        }
    }
}
