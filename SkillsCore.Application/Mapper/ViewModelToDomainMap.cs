using AutoMapper;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {   
        public ViewModelToDomainMap()
        {
            //User
            CreateMap<UserViewModel, User>();
        }
    }
}
