using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Data.Repositories
{
    public class SkillsDossierRepository : ISkillsDossierRepository
    {
        private readonly SkillsContext _context;

        public SkillsDossierRepository(SkillsContext context)
        {
            _context = context;
        }

        public Task GetUserResquestEnterpise(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(SkillsDossier skillsDossier)
        {
            _context.Add(skillsDossier);
            await _context.SaveChangesAsync();
        }
    }
}
