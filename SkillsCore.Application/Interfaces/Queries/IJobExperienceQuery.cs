using SkillsCore.Application.ViewModels.JobExperienceViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IJobExperienceQuery
    {
        Task<IEnumerable<JobExperienceViewModel>> GetAllJobExperiencesByUser(Guid userId);
    }
}
