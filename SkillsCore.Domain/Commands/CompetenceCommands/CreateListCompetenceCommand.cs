using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Domain.Commands.CompetenceCommands
{
    public class CreateListCompetenceCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<CreateCompetenceCommand> Competences { get; set; }
    }
}
