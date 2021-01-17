using SkillsCore.Domain.Commands.EnterpriseCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface IEnterpriseHandler :
        MediatR.IRequestHandler<CreateEnterpriseCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateEnterpriseCommand, ResponseApi>,
        MediatR.IRequestHandler<DeleteEnterpriseCommand, ResponseApi>
    {
    }
}
