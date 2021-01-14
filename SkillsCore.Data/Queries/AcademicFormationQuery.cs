using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;

namespace SkillsCore.Data.Queries
{
    public class AcademicFormationQuery : IAcademicFormationQuery
    {
        #region Properties

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
                    UserId = @id
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

        public IEnumerable<AcademicFormationViewModel> GetUserFormationById(Guid id) =>
            sqlConnection.Query<AcademicFormationViewModel>(QueryGetUserFormationById(), new { id });

        public AcademicFormationViewModel GetAcamicFormationById(Guid academicFormationId) =>
            sqlConnection.QueryFirstOrDefault<AcademicFormationViewModel>(QueryGetAcamicFormationById(), new { academicFormationId });

        #endregion
    }
}
