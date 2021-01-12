using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IAcademicFormationQuery
    {
        IEnumerable<AcademicFormationViewModel> GetUserFormationById(Guid id);
        AcademicFormationViewModel GetAcamicFormationById(Guid academicFormationId);
    }
}
