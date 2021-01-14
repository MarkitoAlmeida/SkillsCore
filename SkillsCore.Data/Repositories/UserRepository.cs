using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SkillsContext _context;
        
        public UserRepository(SkillsContext context) =>
            _context = context;

        public User Get(int fiscalNr)
        {
            return _context.Users.Find(fiscalNr);
        }

        public async Task Insert(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
