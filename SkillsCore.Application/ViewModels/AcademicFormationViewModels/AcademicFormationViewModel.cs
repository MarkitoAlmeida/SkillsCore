using System;

namespace SkillsCore.Application.ViewModels.AcademicFormationViewModels
{
    public class AcademicFormationViewModel
    {
        public Guid Id { get; set; }
        public string InstituitionName { get; set; }
        public DateTime ConclusionDate { get; set; }
        public string CourseTitle { get; set; }
        public string FinalPaperTitle { get; set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
