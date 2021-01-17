using SkillsCore.Domain.Commands.AcademicFormationCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface IAcademicFormationHandler : 
        MediatR.IRequestHandler<CreateListAcademicFormationCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateListAcademicFormationCommand, ResponseApi>,
        MediatR.IRequestHandler<DeleteAcademicFormationCommand, ResponseApi>
    {
    }
}
