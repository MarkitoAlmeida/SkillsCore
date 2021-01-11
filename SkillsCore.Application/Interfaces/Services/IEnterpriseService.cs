using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IEnterpriseService
    {
        IEnumerable<EnterpriseViewModel> GetEnterprises();
        ResultViewModel CreateEnterprise(CreateEnterpriseViewModel createEnterprise);
        ResultViewModel UpdateEnterprise(UpdateEnterpriseViewModel createEnterprise);
    }
}
