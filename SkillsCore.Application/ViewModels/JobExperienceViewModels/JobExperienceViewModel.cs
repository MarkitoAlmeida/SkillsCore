using System;

namespace SkillsCore.Application.ViewModels.JobExperienceViewModels
{
    public class JobExperienceViewModel
    {
        public Guid Id { get;  set; }
        public string EnterpriseName { get;  set; }
        public DateTime BeginDate { get;  set; }
        public DateTime FinalDate { get;  set; }
        public string JobTitle { get;  set; }
        public string ProjectDescription { get;  set; }
        public string ProjectResponsabilities { get;  set; }
        public string TecnologiesUsed { get;  set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid IdUser { get;  set; }
    }
}
