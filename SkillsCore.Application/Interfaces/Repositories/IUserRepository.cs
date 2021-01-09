
using SkillsCore.Domain.Models;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Get(int fiscalNr);
        void Insert(User user);
        void Update(User user);
    }
}
