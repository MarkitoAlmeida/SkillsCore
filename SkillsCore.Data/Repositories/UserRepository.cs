using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;

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

        public void Insert(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
