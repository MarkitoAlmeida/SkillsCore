using SkillsCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Commands.JobExperienceCommands
{
    public class UpdateListJobExperiencesCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public List<UpdateJobExperienceCommand> JobExperiences { get; set; }
    }
}
