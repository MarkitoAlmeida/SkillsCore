using SkillsCore.Domain.Commands.JobExperienceCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface IJobExperienceHandler : 
        MediatR.IRequestHandler<CreateListJobExperiencesCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateListJobExperiencesCommand, ResponseApi>,
        MediatR.IRequestHandler<DeleteJobExperienceCommand, ResponseApi>
    {
    }
}
