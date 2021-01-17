using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SkillsContext _context;
        
        public UserRepository(SkillsContext context) =>
            _context = context;

        public async Task<User> GetUserByFiscalNr(int fiscalNr)
        {
            return await _context.Users.Where(x => x.FiscalNr == fiscalNr).FirstAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Insert(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
