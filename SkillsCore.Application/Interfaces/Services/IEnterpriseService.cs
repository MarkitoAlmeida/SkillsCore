using SkillsCore.Application.Commands.EnterpriseCommands;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IEnterpriseService
    {
        IEnumerable<EnterpriseViewModel> GetEnterprises();
        ResultViewModel CreateEnterprise(CreateEnterpriseCommand createEnterprise);
        ResultViewModel UpdateEnterprise(UpdateEnterpriseCommand createEnterprise);
    }
}
