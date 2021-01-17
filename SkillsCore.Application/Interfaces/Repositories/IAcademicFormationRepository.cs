using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IAcademicFormationRepository
    {
        Task<AcademicFormation> Get(Guid id);
        Task Insert(AcademicFormation academicFormation);
        Task Update(AcademicFormation academicFormation);
        Task Delete(AcademicFormation academicFormation);
    }
}
