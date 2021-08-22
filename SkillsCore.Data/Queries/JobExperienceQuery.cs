using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.JobExperienceViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class JobExperienceQuery : IJobExperienceQuery
    {
        #region Properties

        private readonly SkillsContext _context;
        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public JobExperienceQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

        #endregion

        #region Queries

        private string QueryGetAllJobExperiencesByUser() =>
            @"
                SELECT
                    *
                FROM
                    JobExperience
                WHERE
                    IdUser = @userId
            ";

        #endregion

        #region Methods

        public async Task<IEnumerable<JobExperienceViewModel>> GetAllJobExperiencesByUser(Guid userId) =>
            await sqlConnection.QueryAsync<JobExperienceViewModel>(QueryGetAllJobExperiencesByUser(), new { userId });

        #endregion
    }
}
