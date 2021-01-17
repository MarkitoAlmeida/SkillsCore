using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class AcademicFormationQuery : IAcademicFormationQuery
    {
        #region Properties

        private readonly SkillsContext _context;
        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public AcademicFormationQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

        #endregion

        #region Queries

        private string QueryGetUserFormationById() =>
            @"
                SELECT
                    *
                FROM
                    AcademicFormation
                WHERE
                    IdUser = @userId
            ";

        private string QueryGetAcamicFormationById() =>
            @"
                SELECT
                    *
                FROM
                    AcademicFormation
                WHERE
                    Id = @academicFormationId
            ";

        #endregion

        #region Methods

        public async Task<IEnumerable<AcademicFormationViewModel>> GetUserFormationById(Guid userId) =>
            await sqlConnection.QueryAsync<AcademicFormationViewModel>(QueryGetUserFormationById(), new { userId });

        public async Task<AcademicFormationViewModel> GetAcamicFormationById(Guid academicFormationId) =>
            await sqlConnection.QueryFirstOrDefaultAsync<AcademicFormationViewModel>(QueryGetAcamicFormationById(), new { academicFormationId });

        #endregion
    }
}
