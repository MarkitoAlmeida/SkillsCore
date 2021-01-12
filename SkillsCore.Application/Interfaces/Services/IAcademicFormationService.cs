using SkillsCore.Application.Commands.AcademicFormationCommands;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using System;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IAcademicFormationService
    {
        IEnumerable<AcademicFormationViewModel> GetFormationByUser(Guid id);
        List<ResultViewModel> CreateAcademicFormation(CreateListAcademicFormationCommand createFormation);
        List<ResultViewModel> UpdateAcademicFormation(UpdateListAcademicFormationCommand updateFormation);
    }
}
