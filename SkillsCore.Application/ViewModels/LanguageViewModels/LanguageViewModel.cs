using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Application.ViewModels.LanguageViewModels
{
    public class LanguageViewModel
    {
        public Guid Id { get; set; }
        public string LanguageName { get;  set; }
        public ELanguageLevel LanguageUnderstanding { get;  set; }
        public ELanguageLevel LanguageWriting { get;  set; }
        public ELanguageLevel LanguageSpeaking { get;  set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid IdUser { get;  set; }

    }
}
