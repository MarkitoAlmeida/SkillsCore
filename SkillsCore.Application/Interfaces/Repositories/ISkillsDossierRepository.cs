using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface ISkillsDossierRepository
    {
        Task Insert(SkillsDossier skillsDossier);
        Task GetUserResquestEnterpise(Guid idUser);
    }
}
