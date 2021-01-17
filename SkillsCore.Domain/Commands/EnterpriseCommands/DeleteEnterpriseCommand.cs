using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.EnterpriseCommands
{
    public class DeleteEnterpriseCommand : ICommand
    {
        public Guid IdEnterprise { get; set; }
    }
}
