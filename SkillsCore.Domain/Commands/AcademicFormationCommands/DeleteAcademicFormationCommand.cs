using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.AcademicFormationCommands
{
    public class DeleteAcademicFormationCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public Guid IdAcademicFormation { get; set; }
    }
}
