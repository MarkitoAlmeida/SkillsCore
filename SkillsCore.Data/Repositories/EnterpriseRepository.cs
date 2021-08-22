using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        #region Properties

        private readonly SkillsContext _context;

        #endregion

        #region Constructor

        public EnterpriseRepository(SkillsContext context) =>
            _context = context;

        #endregion

        #region Methods

        public async Task<Enterprise> Get(Guid id)
        {
            return await _context.Enterprises.FindAsync(id);
        }
        
        public async Task<Enterprise> GetEnterpriseByFiscalNr(int fiscalNr)
        {   
            return await _context.Enterprises.FirstOrDefaultAsync(x => x.FiscalNr == fiscalNr);
        }

        public async Task Insert(Enterprise enterprise)
        {
            _context.Add(enterprise);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Enterprise enterprise)
        {
            _context.Entry(enterprise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
