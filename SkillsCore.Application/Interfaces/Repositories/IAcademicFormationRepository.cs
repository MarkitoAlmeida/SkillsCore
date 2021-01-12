using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IAcademicFormationRepository
    {
        void Insert(AcademicFormation enterprise);
        void Update(AcademicFormation enterprise);
    }
}
