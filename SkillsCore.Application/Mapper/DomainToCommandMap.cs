using AutoMapper;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Mapper
{
    public class DomainToCommandMap : Profile
    {
        public DomainToCommandMap()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
