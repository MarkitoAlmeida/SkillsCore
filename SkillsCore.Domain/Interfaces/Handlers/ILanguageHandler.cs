using SkillsCore.Domain.Commands.LanguageCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface ILanguageHandler : 
        MediatR.IRequestHandler<CreateListLanguagesCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateListLanguagesCommand, ResponseApi>,
        MediatR.IRequestHandler<DeleteLanguageCommand, ResponseApi>
    {
    }
}
