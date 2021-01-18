using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Commands.LanguageCommands
{
    public class UpdateListLanguagesCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<UpdateLanguageCommand> Languages { get; set; }
    }
}
