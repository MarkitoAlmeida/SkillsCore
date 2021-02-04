using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Threading.Tasks;
using NReco.PdfGenerator;
using System.Text;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;

namespace SkillsCore.Application.Services
{
    public class SkillsDossierService : ISkillsDossierService
    {
        #region Properties

        private readonly ISkillsDossierRepository _skillsDossierRepository;
        private readonly ISkillsDossierQuery _skillsDossierQuery;

        #endregion

        #region Constructor

        public SkillsDossierService(ISkillsDossierRepository skilssDossierRepository, ISkillsDossierQuery skillsDossierQuery)
        {
            _skillsDossierRepository = skilssDossierRepository;
            _skillsDossierQuery = skillsDossierQuery;
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

                var pdfBytes = CreatePDF(userCreated, userEnterprise);

                SkillsDossier skillsDossier = new SkillsDossier(userCreated.Id, userCreated.CompleteName, userRequest.Id, String.Concat(userRequest.Name, " " , userRequest.LastName), userEnterprise.Id, userEnterprise.Name, count, DateTime.UtcNow);
                await _skillsDossierRepository.Insert(skillsDossier);

                var result = skillsDossier;

                return new ResponseApi(true, "Skills Dossier created sucessfuly.", pdfBytes);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public byte[] CreatePDF(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise)
        {
            StringBuilder htmlSkillsDossier = new StringBuilder();

            //Início do Header

            htmlSkillsDossier.Append("<html> <header>");

            htmlSkillsDossier.Append("<div>" + userEnterprise.Name + "</div>");
            htmlSkillsDossier.Append("<div> Dossier de Competência - " + " " + userCreated.CompleteName + "</div>");
            htmlSkillsDossier.Append("<div>" + userCreated.CarrerTitle + "</div>");

            htmlSkillsDossier.Append("</header>");

            //Fim do Header

            //Início do Body

            htmlSkillsDossier.Append("<bod>");

            //Div Professional Information
            htmlSkillsDossier.Append("<div>");

            htmlSkillsDossier.Append("<p> Summary </p>");

            htmlSkillsDossier.Append("<p>" + userCreated.Summary + "</p>");

            htmlSkillsDossier.Append("</div>");

            htmlSkillsDossier.Append("<div>");

            htmlSkillsDossier.Append("<p> Work Experience </p>");

            htmlSkillsDossier.Append("<div>");

            
            htmlSkillsDossier.Append("<p> Work Experience </p>");


            htmlSkillsDossier.Append("</div>");

            htmlSkillsDossier.Append("</body");

            //Fim do Body

            //Início do Footer



            //Fim do Footer

            var htmlToPdf = new HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlSkillsDossier.ToString());

            return pdfBytes;
        }

        #endregion

    }
}
