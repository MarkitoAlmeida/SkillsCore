
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByFiscalNr(int fiscalNr);
        Task<User> Get(Guid id);
        Task Insert(User user);
        Task Update(User user);
    }
}
