using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.CompetenceCommands
{
    public class DeleteCompetenceCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public Guid IdCompetence { get; set; }
    }
}
