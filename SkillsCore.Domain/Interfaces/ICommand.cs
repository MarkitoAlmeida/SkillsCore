using SkillsCore.Domain.Models.Response;

namespace SkillsCore.Domain.Interfaces
{
    public interface ICommand : MediatR.IRequest<ResponseApi>
    {

    }
}
