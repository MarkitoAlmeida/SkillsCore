using AutoMapper;
using SkillsCore.Domain.Commands.AcademicFormationCommands;
using SkillsCore.Domain.Commands.CompetenceCommands;
using SkillsCore.Domain.Commands.EnterpriseCommands;
using SkillsCore.Domain.Commands.UserCommands;
using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Mapper
{
    public class CommandToDomainMap : Profile
    {   
        public CommandToDomainMap()
        {
            //AcademicFormation
            CreateMap<CreateAcademicFormationCommand, AcademicFormation>();
            CreateMap<UpdateAcademicFormationCommand, AcademicFormation>();
            CreateMap<DeleteAcademicFormationCommand, AcademicFormation>();

            //Compenteces
            CreateMap<CreateCompetenceCommand, Competences>();
            CreateMap<UpdateCompetenceCommand, Competences>();
            CreateMap<DeleteCompetenceCommand, Competences>();

            //Enterprise
            CreateMap<CreateEnterpriseCommand, Enterprise>();
            CreateMap<UpdateEnterpriseCommand, Enterprise>();

            //User
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
