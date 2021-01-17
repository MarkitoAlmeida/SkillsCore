using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Commands.AcademicFormationCommands
{
    public class UpdateListAcademicFormationCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<UpdateAcademicFormationCommand> AcademicFormations { get; set; }
    }
}
