using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class CompetenceRepository : ICompetenceRepository
    {
        #region Properties

        private readonly SkillsContext _context;

        #endregion

        #region Constructor

        public CompetenceRepository(SkillsContext context) =>
            _context = context;

        #endregion

        #region Methods

        public async Task<Competences> Get(Guid id)
        {
            return await _context.Competences.FindAsync(id);
        }

        //public async Task<Competences> GetCompetenceByFiscalNr(int fiscalNr)
        //{
        //    return await _context.Competences.Where(x => x.FiscalNr == fiscalNr).FirstAsync();
        //}

        public async Task Insert(Competences competence)
        {
            _context.Add(competence);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Competences competence)
        {
            _context.Entry(competence).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Competences competence)
        {
            _context.Competences.Remove(competence);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
