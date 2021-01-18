using SkillsCore.Domain.Commands.CompetenceCommands;
using SkillsCore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Domain.Interfaces.Handlers
{
    public interface ICompetenceHandler :
        MediatR.IRequestHandler<CreateListCompetenceCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateListCompetenceCommand, ResponseApi>,
        MediatR.IRequestHandler<DeleteCompetenceCommand, ResponseApi>
    {
    }
}
