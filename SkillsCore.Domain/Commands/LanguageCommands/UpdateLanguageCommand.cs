using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Enums;
using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.LanguageCommands
{
    public class UpdateLanguageCommand : Notifiable, IValidatable, ICommand
    {
        #region Properties

        public Guid Id { get; set; }
        public string LanguageName { get; set; }
        public ELanguageLevel LanguageUnderstanding { get; set; }
        public ELanguageLevel LanguageWriting { get; set; }
        public ELanguageLevel LanguageSpeaking { get; set; }
        public Guid IdUser { get; set; }

        #endregion

        #region Methods

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(LanguageName, 30, "LanguageName", "O nome do língua deve conter no máximo 30 caracteres.")
                    .HasMinLen(LanguageName, 1, "LanguageName", "O nome do usuário deve conter no mínimo 1 caracter")
                    .IsNotNull(LanguageUnderstanding, "LanguageUnderstanding", "O campo 'Understanding' não pode estar vazio.")
                    .IsNotNull(LanguageWriting, "LanguageWriting", "O campo 'Writing' não pode estar vazio.")
                    .IsNotNull(LanguageSpeaking, "LanguageSpeaking", "O campo 'Speaking' não pode estar vazio.")
            );
        }

        #endregion
    }
}
