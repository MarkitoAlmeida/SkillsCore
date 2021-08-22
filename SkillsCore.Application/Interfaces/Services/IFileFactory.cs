using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IFileFactory
    {
        (byte[] archieveData, string fileType, string archiveName) CreateWordFile(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise);
    }
}
