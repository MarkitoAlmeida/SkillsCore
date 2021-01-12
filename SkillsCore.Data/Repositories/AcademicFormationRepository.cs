using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;

namespace SkillsCore.Data.Repositories
{
    public class AcademicFormationRepository : IAcademicFormationRepository
    {
        private readonly SkillsContext _context;

        public AcademicFormationRepository(SkillsContext context) =>
            _context = context;

        public void Insert(AcademicFormation academicFormation)
        {
            _context.Add(academicFormation);
            _context.SaveChanges();
        }

        public void Update(AcademicFormation academicFormation)
        {
            _context.Entry(academicFormation).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
