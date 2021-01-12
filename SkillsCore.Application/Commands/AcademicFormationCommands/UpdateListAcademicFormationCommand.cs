using System;
using System.Collections.Generic;

namespace SkillsCore.Application.Commands.AcademicFormationCommands
{
    public class UpdateListAcademicFormationCommand
    {
        public Guid UserId { get; set; }
        public List <UpdateAcademicFormationCommand> AcademicFormations { get; set; }
    }
}
