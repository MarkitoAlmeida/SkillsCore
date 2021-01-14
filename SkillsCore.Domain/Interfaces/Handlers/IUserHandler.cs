using SkillsCore.Application.Commands.UserCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface IUserHandler : MediatR.IRequestHandler<CreateUserCommand, ResponseApi>
    {
    }
}
