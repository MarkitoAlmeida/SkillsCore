using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkillsCore.Application.Services
{
    public class SkillsDossierService : ISkillsDossierService
    {
        #region Properties

        private readonly ISkillsDossierRepository _skillsDossierRepository;
        private readonly ISkillsDossierQuery _skillsDossierQuery;
        private readonly IFileFactory _fileFactory;

        #endregion

        #region Constructor

        public SkillsDossierService(ISkillsDossierRepository skilssDossierRepository, ISkillsDossierQuery skillsDossierQuery,
            IFileFactory fileFactory)
        {
            _skillsDossierRepository = skilssDossierRepository;
            _skillsDossierQuery = skillsDossierQuery;
            _fileFactory = fileFactory;
        }

        #endregion

        #region Methods

        public async Task<(byte[] archieveData, string fileType, string archiveName)> CreateDossier(Guid idUserRequested, Guid idUserCreated)
        {
            try
            {
                var userCreated = await _skillsDossierQuery.GetUserCompleteInformationById(idUserCreated);
                var userRequest = await _skillsDossierQuery.GetUserById(idUserRequested);
                var userEnterprise = await _skillsDossierQuery.GetUserResquestEnterpise((Guid)userRequest.IdEnterprise);
                var count = await _skillsDossierQuery.GetCountCreatedDossier(idUserCreated);

                var (archiveData, fileType, archiveName) = _fileFactory.CreateWordFile(userCreated, userEnterprise);

                SkillsDossier skillsDossier = new SkillsDossier(userCreated.Id, userCreated.CompleteName, userRequest.Id, String.Concat(userRequest.Name, " ", userRequest.LastName), userEnterprise.Id, userEnterprise.Name, count, DateTime.UtcNow);
                await _skillsDossierRepository.Insert(skillsDossier);
                
                return (archiveData, fileType, archiveName);
            }
            catch (Exception e)
            {
                return (null, "error", "error");
            }
        }

        #endregion
    }
}
