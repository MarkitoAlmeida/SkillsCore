using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        #region Properties

        private readonly SkillsContext _context;

        #endregion

        #region Constructor

        public LanguageRepository(SkillsContext context) =>
            _context = context;

        #endregion

        #region Methods

        public async Task<Language> Get(Guid id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task Insert(Language language)
        {
            _context.Add(language);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Language language)
        {
            _context.Entry(language).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Language language)
        {
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
