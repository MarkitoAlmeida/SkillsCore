using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IFileFactory
    {
        void CreateWordFile(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise);
    }
}
