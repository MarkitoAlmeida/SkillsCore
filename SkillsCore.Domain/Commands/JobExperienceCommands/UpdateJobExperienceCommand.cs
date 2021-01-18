using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.JobExperienceCommands
{
    public class UpdateJobExperienceCommand : Notifiable, IValidatable, ICommand
    {
        #region Properties

        public Guid Id { get; set; }
        public string EnterpriseName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string JobTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectResponsabilities { get; set; }
        public string TecnologiesUsed { get; set; }
        public Guid IdUser { get; set; }

        #endregion

        #region Methods

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(EnterpriseName, 200, "EnterpriseName", "O nome da empresa deve conter no máximo 200 caracteres.")
                    .HasMinLen(EnterpriseName, 2, "EnterpriseName", "O nome da empresa deve conter no mínimo 2 caracteres")
                    .IsNotNull(BeginDate, "BeginDate", "O campo 'Begin Date' não pode estar vazio.")
                    .IsNotNull(JobTitle, "Phone", "O campo 'Phone' não pode estar vazio.")
                    .HasMaxLen(ProjectDescription, 500, "ProjectDescription", "O nome da empresa deve conter no máximo 500 caracteres.")
                    .HasMinLen(ProjectDescription, 50, "ProjectDescription", "O a descrição do projeto deve conter no mínimo 50 caracteres")
                    .HasMaxLen(ProjectResponsabilities, 1000, "ProjectDescription", "O nome da empresa deve conter no máximo 1000 caracteres.")
                    .HasMinLen(ProjectResponsabilities, 10, "ProjectDescription", "O a descrição do projeto deve conter no mínimo 10 caracteres")
                    .IsNotNull(TecnologiesUsed, "TecnologiesUsed", "O campo 'Technologies' não pode estar vazio.")
            );
        }

        #endregion
    }
}
