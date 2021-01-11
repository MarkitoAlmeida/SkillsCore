using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;

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

        public Enterprise Get(int fiscalNr)
        {
            return _context.Enterprises.Find(fiscalNr);
        }

        public void Insert(Enterprise enterprise)
        {
            _context.Add(enterprise);
            _context.SaveChanges();
        }

        public void Update(Enterprise enterprise)
        {
            _context.Entry(enterprise).State = EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion
    }
}
