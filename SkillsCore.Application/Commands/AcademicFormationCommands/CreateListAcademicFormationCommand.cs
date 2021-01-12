using System;
using System.Collections.Generic;

namespace SkillsCore.Application.Commands.AcademicFormationCommands
{ 
    public class CreateListAcademicFormationCommand
    {
        public Guid IdUser { get; set; }
        public List<CreateAcademicFormationCommand> AcademicFormations { get; set; }
    }
}
