using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using SkillsCore.Application.ViewModels.CompetenceViewModels;
using SkillsCore.Application.ViewModels.JobExperienceViewModels;
using SkillsCore.Application.ViewModels.LanguageViewModels;
using System;
using System.Collections.Generic;

namespace SkillsCore.Application.ViewModels.SkillsDossierViewModels
{
    public class UserSkillsDossierViewModel
    {
        public Guid Id { get; set; }
        public string CompleteName { get; set; }
        public DateTime BirthDay { get; set; }
        public string CarrerTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ExperienceTime { get; set; }
        public string Summary { get; set; }
        public List<AcademicFormationViewModel> AcademicFormation { get; set; }
        public List<LanguageViewModel> Language { get; set; }
        public List<JobExperienceViewModel> JobExperience { get; set; }
        public List<CompetenceViewModel> Competence { get; set; }
    }
}
