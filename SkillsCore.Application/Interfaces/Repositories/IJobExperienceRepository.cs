using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IJobExperienceRepository
    {
        Task<JobExperience> Get(Guid id);
        Task Insert(JobExperience jobExperience);
        Task Update(JobExperience jobExperience);
        Task Delete(JobExperience jobExperience);
    }
}
