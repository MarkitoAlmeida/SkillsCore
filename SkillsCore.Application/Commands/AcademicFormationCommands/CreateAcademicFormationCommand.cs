using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace SkillsCore.Application.Commands.AcademicFormationCommands
{
    public class CreateAcademicFormationCommand : Notifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string InstituitionName { get; set; }
        public DateTime ConclusionDate { get; set; }
        public string CourseTitle { get; set; }
        public string FinalPaperTitle { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(InstituitionName, 300, "InstituitionName", "O nome da instituição deve conter no máximo 300 caracteres.")
                    .HasMinLen(InstituitionName, 1, "Nome", "O nome do usuário deve conter no mínimo 1 caracter")
                    .IsNotNull(ConclusionDate, "ConclusionDate", "O campo  'data de conclusão' não pode estar vazio.")
                    .HasMaxLen(CourseTitle, 300, "CourseTitle", "O título da formação deve conter no máximo 300 caracteres.")
                    .HasMinLen(CourseTitle, 1, "CourseTitle", "O título da formação deve conter no mínimo 1 caracter.")
                    .HasMaxLen(FinalPaperTitle, 300, "FinalPaperTitle", "O título do projeto deve conter no máximo 300 caracteres.")
                    .HasMinLen(FinalPaperTitle, 1, "FinalPaperTitle", "O título do projeto deve conter no mínimo 1 caracter.")
            );
        }
    }
}
