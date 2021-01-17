using SkillsCore.Domain.Commands.UserCommands;
using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface IUserHandler : 
        MediatR.IRequestHandler<CreateUserCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateUserCommand, ResponseApi>
    {
    }
}
