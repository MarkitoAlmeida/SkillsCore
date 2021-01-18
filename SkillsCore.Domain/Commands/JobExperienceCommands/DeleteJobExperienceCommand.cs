using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Domain.Commands.JobExperienceCommands
{
    public class DeleteJobExperienceCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public Guid IdJobExperience { get; set; }
    }
}
