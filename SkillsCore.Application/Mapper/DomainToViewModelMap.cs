using AutoMapper;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Mapper
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
