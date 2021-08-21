using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Application.ViewModels.CompetenceViewModels
{
    public class CompetenceViewModel
    {
        public Guid Id { get; set; }
        public string CompetenceName { get;  set; }
        public int CompetenceExperienceTime { get;  set; }
        public ETimeType TimeType { get;  set; }
        public ECompetenceType CompetenceType { get; set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid IdUser { get; set; }
    }
}
