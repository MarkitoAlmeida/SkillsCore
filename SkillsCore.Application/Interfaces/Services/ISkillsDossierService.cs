using SkillsCore.Domain.Models.Response;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface ISkillsDossierService
    {
        Task<ResponseApi> CreateDossier(Guid idUserRequested, Guid idUserCreated);
    }
}
