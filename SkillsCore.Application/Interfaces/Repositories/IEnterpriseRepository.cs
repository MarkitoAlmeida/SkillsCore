using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> Get(Guid id);
        Task<Enterprise> GetEnterpriseByFiscalNr(int fiscalNr);
        Task Insert(Enterprise enterprise);
        Task Update(Enterprise enterprise);
    }
}
