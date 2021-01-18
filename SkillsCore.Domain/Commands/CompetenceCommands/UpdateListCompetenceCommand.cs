using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Domain.Commands.CompetenceCommands
{
    public class UpdateListCompetenceCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<UpdateCompetenceCommand> Competences { get; set; }
    }
}
