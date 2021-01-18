using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class JobExperienceRepository : IJobExperienceRepository
    {
        #region Properties

        private readonly SkillsContext _context;

        #endregion

        #region Constructor

        public JobExperienceRepository(SkillsContext context) =>
            _context = context;

        #endregion

        #region Methods

        public async Task<JobExperience> Get(Guid id)
        {
            return await _context.JobExperiences.FindAsync(id);
        }

        public async Task Insert(JobExperience jobExperience)
        {
            _context.Add(jobExperience);
            await _context.SaveChangesAsync();
        }

        public async Task Update(JobExperience jobExperience)
        {
            _context.Entry(jobExperience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(JobExperience jobExperience)
        {
            _context.JobExperiences.Remove(jobExperience);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
