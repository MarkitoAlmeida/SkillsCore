using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Enums;
using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.CompetenceCommands
{
    public class UpdateCompetenceCommand : Notifiable, IValidatable, ICommand
    {
        #region Properties

        public Guid Id { get; set; }
        public string CompetenceName { get; set; }
        public int CompetenceExperienceTime { get; set; }
        public ETimeType TimeType { get; set; }
        public Guid IdUser { get; set; }

        #endregion

        #region Methods

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(CompetenceName, 100, "CompetenceName", "O nome da competência deve conter no máximo 100 caracteres.")
                    .HasMinLen(CompetenceName, 1, "CompetenceName", "O nome da competência deve conter no mínimo 1 caracter")
                    .IsNotNull(CompetenceExperienceTime, "CompetenceExperienceTime", "O campo  'tempo de experiência' não pode estar vazio.")
                    .IsNotNull(TimeType, "TimeType", "O campo 'tipo do tempo' não pode estar vazio.")
            );
        }

        #endregion
    }
}
