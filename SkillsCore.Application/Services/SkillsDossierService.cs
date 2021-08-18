using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Threading.Tasks;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using MariGold.OpenXHTML;
using System.IO;
using DocumentFormat.OpenXml;
using SkillsCore.Application.Factory;

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

        public async Task<ResponseApi> CreateDossier(Guid idUserRequested, Guid idUserCreated)
        {
            try
            {
                var userCreated = await _skillsDossierQuery.GetUserCompleteInformationById(idUserCreated);
                var userRequest = await _skillsDossierQuery.GetUserById(idUserRequested);
                var userEnterprise = await _skillsDossierQuery.GetUserResquestEnterpise((Guid)userRequest.IdEnterprise);
                var count = await _skillsDossierQuery.GetCountCreatedDossier(idUserCreated);

                _fileFactory.CreateWordFile(userCreated, userEnterprise);

                SkillsDossier skillsDossier = new SkillsDossier(userCreated.Id, userCreated.CompleteName, userRequest.Id, String.Concat(userRequest.Name, " ", userRequest.LastName), userEnterprise.Id, userEnterprise.Name, count, DateTime.UtcNow);
                await _skillsDossierRepository.Insert(skillsDossier);

                var result = skillsDossier;
                
                return new ResponseApi(true, "Skills Dossier created sucessfuly.", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}
