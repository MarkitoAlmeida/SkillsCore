using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface ISkillsDossierQuery
    {
        Task<UserViewModel> GetUserById(Guid idUser);
        Task<UserSkillsDossierViewModel> GetUserCompleteInformationById(Guid idUser);
        Task<EnterpriseViewModel> GetUserResquestEnterpise(Guid idEnterprise);
        Task<int> GetCountCreatedDossier(Guid idUser);
    }
}
