
using SkillsCore.Domain.Models;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Get(int fiscalNr);
        Task Insert(User user);
        void Update(User user);
    }
}
