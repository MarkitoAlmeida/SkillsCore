using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Commands.LanguageCommands
{
    public class CreateListLanguagesCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<CreateLanguageCommand> Languages { get; set; }
    }
}
