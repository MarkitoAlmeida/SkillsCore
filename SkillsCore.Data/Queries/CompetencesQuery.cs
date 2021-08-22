using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.CompetenceViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class CompetencesQuery : ICompetenceQuery
    {
        #region Properties

        private readonly SkillsContext _context;
        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public CompetencesQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

        #endregion

        #region Queries

        private string QueryGetAllCompetencesByUser() =>
            @"
                SELECT
                    Id,
                    CompetenceName,
                    CompetenceExperienceTime,
                    TimeType,
                    CompetenceType,
                    IdUser,
                    CreationDate,
                    LastUpdate,
                    Active,
                    Excluded
                FROM
                    Competences
                WHERE
                    IdUser = @userId
            ";

        #endregion

        #region Methods

        public async Task<IEnumerable<CompetenceViewModel>> GetAllCompetencesByUser(Guid userId) =>
            await sqlConnection.QueryAsync<CompetenceViewModel>(QueryGetAllCompetencesByUser(), new { userId });

        #endregion
    }
}
