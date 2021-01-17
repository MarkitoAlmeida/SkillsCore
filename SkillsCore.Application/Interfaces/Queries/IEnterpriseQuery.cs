using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IEnterpriseQuery
    {
        Task<IEnumerable<EnterpriseViewModel>> GetAllEnterprises();
        Task<EnterpriseViewModel> GetEnterpriseByFiscalNr(int fiscalNr);
        Task<EnterpriseViewModel> GetEnterpriseById(Guid enterpriseId);
    }
}
