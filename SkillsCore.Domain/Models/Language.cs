﻿using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Domain.Models
{
    public class Language : Entity
    {
        #region Constructor

        public Language() { }

        public Language(string languageName, ELanguageLevel languageUnderstanding, ELanguageLevel languageWriting, ELanguageLevel languageSpeaking)
        {
            LanguageName = languageName;
            LanguageUnderstanding = languageUnderstanding;
            LanguageWriting = languageWriting;
            LanguageSpeaking = languageSpeaking;
        }

        #endregion

        #region Properties

        public string LanguageName { get; private set; }
        public ELanguageLevel LanguageUnderstanding { get; private set; }
        public ELanguageLevel LanguageWriting { get; private set; }
        public ELanguageLevel LanguageSpeaking { get; private set; }

        public virtual IEnumerable<User> Users { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}