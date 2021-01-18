using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface ICompetenceRepository
    {
        Task<Competences> Get(Guid id);
        Task Insert(Competences competence);
        Task Update(Competences competence);
        Task Delete(Competences competence);
    }
}
