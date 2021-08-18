using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.JobExperienceViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
					[dbo].[User] AS u
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

			var userInfo = await _sqlConnection.QueryAsync(
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
						af.Id AS AcademicFormation_Id,
						af.InstituitionName AS AcademicFormation_InstituitionName,
						af.ConclusionDate AS AcademicFormation_ConclusionDate,
						af.CourseTitle AS AcademicFormation_CourseTitle,
						af.FinalPaperTitle AS AcademicFormation_FinalPaperTitle,
						l.Id AS Language_Id,
						l.LanguageName AS Language_LanguageName,
						l.LanguageWriting AS Language_LanguageWriting,
						l.LanguageUnderstanding AS Language_LanguageUnderstanding,
						l.LanguageSpeaking AS Language_LanguageSpeaking,
						je.Id AS JobExperience_Id,
						je.EnterpriseName AS JobExperience_EnterpriseName,
						je.JobTitle AS JobExperience_JobTitle, 
						je.BeginDate AS JobExperience_BeginDate,
						je.FinalDate AS JobExperience_FinalDate,
						je.ProjectDescription AS JobExperience_ProjectDescription,
						je.ProjectResponsabilities AS JobExperience_ProjectResponsabilities,
						je.TecnologiesUsed AS JobExperience_TecnologiesUsed,
						c.Id AS Competence_Id,
						c.CompetenceName AS Competence_CompetenceName,
						c.CompetenceExperienceTime AS Competence_CompetenceExperienceTime,
						c.TimeType AS Competence_TimeType
					FROM
						[dbo].[User] AS u
					left JOIN
						AcademicFormation AS af ON af.IdUser = u.Id
					left JOIN
						[dbo].[Language] AS l ON l.IdUser = u.Id
					left JOIN
						JobExperience AS je ON je.IdUser = u.Id
					left JOIN
						Competences AS c ON c.IdUser = u.Id
					WHERE
						u.Id = @idUser
					ORDER BY af.ConclusionDate, je.FinalDate DESC 
                ", queryArgs);

			Slapper.AutoMapper.Configuration.AddIdentifier(typeof(UserSkillsDossierViewModel), "Id");
			
			IEnumerable<UserSkillsDossierViewModel> dadosSlapper = Slapper.AutoMapper.MapDynamic<UserSkillsDossierViewModel>(userInfo);

			return dadosSlapper.ToList().FirstOrDefault();
        }

        public async Task<EnterpriseViewModel> GetUserResquestEnterpise(Guid idEnterprise) =>
            await _sqlConnection.QueryFirstOrDefaultAsync<EnterpriseViewModel>(QueryGetEnterpriseById(), new { idEnterprise });

        public async Task<int> GetCountCreatedDossier(Guid idUser) =>
            await _sqlConnection.QuerySingleAsync<int>(QueryCountCreatedDossier(), new { idUser } );

        #endregion
    }
}
