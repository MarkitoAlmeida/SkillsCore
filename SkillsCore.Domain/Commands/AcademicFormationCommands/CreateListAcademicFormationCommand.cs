using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Commands.AcademicFormationCommands
{ 
    public class CreateListAcademicFormationCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<CreateAcademicFormationCommand> AcademicFormations { get; set; }
    }
}
