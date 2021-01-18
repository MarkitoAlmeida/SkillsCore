using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<Language> Get(Guid id);
        Task Insert(Language language);
        Task Update(Language language);
        Task Delete(Language language);
    }
}
