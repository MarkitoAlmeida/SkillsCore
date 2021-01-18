using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class Language : Entity
    {
        #region Constructor

        public Language() { }

        public Language(string languageName, ELanguageLevel languageUnderstanding, ELanguageLevel languageWriting, ELanguageLevel languageSpeaking,
            Guid idUser)
        {
            LanguageName = languageName;
            LanguageUnderstanding = languageUnderstanding;
            LanguageWriting = languageWriting;
            LanguageSpeaking = languageSpeaking;
            IdUser = idUser;
        }

        #endregion

        #region Properties

        public string LanguageName { get; private set; }
        public ELanguageLevel LanguageUnderstanding { get; private set; }
        public ELanguageLevel LanguageWriting { get; private set; }
        public ELanguageLevel LanguageSpeaking { get; private set; }
        public Guid IdUser { get; private set; }

        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void UpdateFields(Language fields)
        {
            LanguageName = fields.LanguageName;
            LanguageUnderstanding = fields.LanguageUnderstanding;
            LanguageWriting = fields.LanguageWriting;
            LanguageSpeaking = fields.LanguageSpeaking;
            LastUpdate = DateTime.UtcNow;
        }

        #endregion
    }
}
