using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IAcademicFormationQuery
    {
        Task<IEnumerable<AcademicFormationViewModel>> GetUserFormationById(Guid id);
        Task<AcademicFormationViewModel> GetAcamicFormationById(Guid academicFormationId);
    }
}
