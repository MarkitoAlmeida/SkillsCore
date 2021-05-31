using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Threading.Tasks;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using System.IO;
using NPOI.XWPF.UserModel;

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

                //var pdfBytes = CreatePDF(userCreated, userEnterprise);
                var wordDocument = CreateWordFile(userCreated, userEnterprise);

                SkillsDossier skillsDossier = new SkillsDossier(userCreated.Id, userCreated.CompleteName, userRequest.Id, String.Concat(userRequest.Name, " " , userRequest.LastName), userEnterprise.Id, userEnterprise.Name, count, DateTime.UtcNow);
                await _skillsDossierRepository.Insert(skillsDossier);

                var result = skillsDossier;

                return new ResponseApi(true, "Skills Dossier created sucessfuly.", wordDocument);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public byte[] CreateWordFile(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise)
        {
            XWPFDocument doc = new XWPFDocument();

            byte[] teste;

            //using (var fs = new FileStream(userCreated.CompleteName + ".docx", FileMode.Create, FileAccess.Write))
            //{
            //    var p0 = doc.CreateParagraph();
            //    p0.Alignment = ParagraphAlignment.CENTER;
            //    XWPFRun r0 = p0.CreateRun();
            //    r0.FontFamily = "Arial";
            //    r0.FontSize = 12;
            //    r0.IsBold = false;
            //    r0.SetText("Teste");

            //    doc.Write(fs);
            //}

            return teste = null;
        }

        #endregion

        //public byte[] CreatePDF(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise)
        //{
        //    var htmlSkillsDossier = new StringBuilder();

        //    //Início do Header

        //    htmlSkillsDossier.Append("<html> <header>");

        //    htmlSkillsDossier.Append("<div>" + userEnterprise.Name + "</div>");
        //    htmlSkillsDossier.Append("<div> Dossier de Competência - " + " " + userCreated.CompleteName + "</div>");
        //    htmlSkillsDossier.Append("<div>" + userCreated.CarrerTitle + "</div>");

        //    htmlSkillsDossier.Append("</header>");

        //    //Fim do Header

        //    //Início do Body

        //    htmlSkillsDossier.Append("<bod>");

        //    //Div Professional Information
        //    htmlSkillsDossier.Append("<div>");

        //    htmlSkillsDossier.Append("<p> Summary </p>");

        //    htmlSkillsDossier.Append("<p>" + userCreated.Summary + "</p>");

        //    htmlSkillsDossier.Append("</div>");

        //    htmlSkillsDossier.Append("<div>");

        //    htmlSkillsDossier.Append("<p> Work Experience </p>");

        //    foreach (var job in userCreated.JobExperience)
        //    {
        //        htmlSkillsDossier.Append("<p>" + job.EnterpriseName + " - " + job.JobTitle + "</p>");
        //        htmlSkillsDossier.Append("<p>" + job.BeginDate + " - " + job.FinalDate + "</p>");
        //        htmlSkillsDossier.Append("<p>" + job.ProjectDescription + "</p>");
        //        htmlSkillsDossier.Append("<p>" + job.ProjectResponsabilities + "</p>");
        //        htmlSkillsDossier.Append("<p>" + job.TecnologiesUsed + "</p>");
        //    }

        //    htmlSkillsDossier.Append("</div>");

        //    //htmlSkillsDossier.Append("<div>");

        //    //htmlSkillsDossier.Append("<p> Work Experience </p>");

        //    //htmlSkillsDossier.Append("</div>");

        //    htmlSkillsDossier.Append("</body");

        //    //Fim do Body

        //    //Início do Footer



        //    //Fim do Footer

        //    //var htmlToPdf = new HtmlToPdfConverter();
        //    var pdfBytes = htmlToPdf.GeneratePdf(htmlSkillsDossier.ToString());

        //    return pdfBytes;
        //}
    }
}
