using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class AcademicFormationRepository : IAcademicFormationRepository
    {
        private readonly SkillsContext _context;

        public AcademicFormationRepository(SkillsContext context) =>
            _context = context;

        public async Task<AcademicFormation> Get(Guid id)
        {
            return await _context.AcademicFormations.FindAsync(id);
        }

        public async Task Insert(AcademicFormation academicFormation)
        {
            _context.Add(academicFormation);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AcademicFormation academicFormation)
        {
            _context.Entry(academicFormation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(AcademicFormation academicFormation)
        {
            _context.AcademicFormations.Remove(academicFormation);
            await _context.SaveChangesAsync();
        }
    }
}
