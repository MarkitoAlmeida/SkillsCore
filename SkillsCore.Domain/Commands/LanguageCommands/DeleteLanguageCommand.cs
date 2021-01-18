using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.LanguageCommands
{
    public class DeleteLanguageCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public Guid IdLanguage { get; set; }
    }
}
