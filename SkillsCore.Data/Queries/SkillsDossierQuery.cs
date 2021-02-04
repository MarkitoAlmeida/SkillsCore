using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
	public class SkillsDossierQuery : ISkillsDossierQuery
	{
		#region Properties

		private readonly SkillsContext _context;
		private readonly SqlConnection _sqlConnection;

		#endregion

		#region Constructor

		public SkillsDossierQuery(SkillsContext context) =>
			_sqlConnection = new SqlConnection(context.Database.GetConnectionString());

		#endregion

		#region Queries

        private string QueryGetUserById() =>
            @"
                SELECT
					*
				FROM
					[dbo].[User]
                WHERE
	                u.Id = @idUser
            ";

        private string QueryGetEnterpriseById() =>
            @"
                SELECT
                    *
                FROM
                    Enterprise
                WHERE
                    Id = @idEnterprise
            ";

        private string QueryCountCreatedDossier() =>
            @"
                SELECT
                    COUNT(CreationNr)
                FROM
                    SkillsDossier
                WHERE
                    IdUserCreated = @idUser
            ";

		#endregion

		#region Methods

		public async Task<UserViewModel> GetUserById(Guid idUser) =>
			await _sqlConnection.QueryFirstOrDefaultAsync<UserViewModel>(QueryGetUserById(), new { idUser });

        public async Task<UserSkillsDossierViewModel> GetUserCompleteInformationById(Guid idUser)
        {
			var queryArgs = new DynamicParameters();
			queryArgs.Add("idUser", idUser);

			var userInfo = await _sqlConnection.QueryFirstOrDefaultAsync(
				@"
                    SELECT
	                u.Id,
	                CONCAT(u.Name,' ', u.LastName) AS CompleteName,
	                u.BirthDay,
					u.CarrerTitle,
	                u.Gender,
	                u.City,
	                u.Country,
	                u.ExperienceTime,
	                u.Summary,
	                af.InstituitionName AS AcademicFormation_InstituitionName,
	                af.ConclusionDate AS AcademicFormation_ConclusionDate,
	                af.CourseTitle AS AcademicFormation_CourseTitle,
	                af.FinalPaperTitle AS AcademicFormation_FinalPaperTitle,
	                l.LanguageName AS Language_LanguageName,
	                l.LanguageWriting AS Language_LanguageWriting,
	                l.LanguageUnderstanding AS Language_LanguageUnderstanding,
	                l.LanguageSpeaking AS Language_LanguageSpeaking,
	                je.EnterpriseName AS JobExperience_,
	                je.JobTitle AS JobExperience_JobTitle, 
	                je.BeginDate AS JobExperience_BeginDate,
	                je.FinalDate AS JobExperience_FinalDate,
	                je.ProjectDescription AS JobExperience_ProjectDescription,
	                je.ProjectResponsabilities AS JobExperience_ProjectResponsabilities,
	                je.TecnologiesUsed AS JobExperience_TecnologiesUsed,
	                c.CompetenceName AS Competence_CompetenceName,
	                c.CompetenceExperienceTime AS Competence_CompetenceExperienceTime,
	                c.TimeType AS Competence_TimeType
                FROM
	                [dbo].[User] AS u
                INNER JOIN
	                AcademicFormation AS af ON af.IdUser = u.Id
                INNER JOIN
	                [dbo].[Language] AS l ON l.IdUser = u.Id
                INNER JOIN
	                JobExperience AS je ON je.IdUser = u.Id
                INNER JOIN
	                Competences AS c ON c.IdUser = u.Id
                WHERE
	                u.Id = @idUser
                ", queryArgs);

			Slapper.AutoMapper.Configuration.AddIdentifier(typeof(UserSkillsDossierViewModel), "Id");

			UserSkillsDossierViewModel dadosSlapper = Slapper.AutoMapper.MapDynamic<UserSkillsDossierViewModel>(userInfo);

			return dadosSlapper;
        }

        public async Task<EnterpriseViewModel> GetUserResquestEnterpise(Guid idEnterprise) =>
            await _sqlConnection.QueryFirstOrDefaultAsync<EnterpriseViewModel>(QueryGetEnterpriseById(), new { idEnterprise });

        public async Task<int> GetCountCreatedDossier(Guid idUser) =>
            await _sqlConnection.QuerySingleAsync<int>(QueryCountCreatedDossier(), new { idUser } );

        #endregion
    }
}
