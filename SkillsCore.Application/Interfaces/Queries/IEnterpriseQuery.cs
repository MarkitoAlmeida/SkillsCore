using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using System;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IEnterpriseQuery
    {
        IEnumerable<EnterpriseViewModel> GetAllEnterprises();
        EnterpriseViewModel GetEnterpriseByFiscalNr(int fiscalNr);
        EnterpriseViewModel GetEnterpriseById(Guid enterpriseId);
    }
}
