using Dapper;
using Microsoft.Data.SqlClient;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Data.Queries
{
    public class EnterpriseQuery : IEnterpriseQuery
    {
        #region Properties

        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        EnterpriseQuery() =>
            sqlConnection = new SqlConnection(HelperConnectionString.connectionString);

        #endregion

        #region Queries

        private string QueryGetAllEnterprises() =>
            @"
                SELECT
                    *
                FROM
                    Enterprise
            ";

        private string QueryGetEnterpriseByFiscalNr() =>
            @"
                SELECT
                    *
                FROM
                    Enterprise
                WHERE
                    FiscalNr = @fiscalNr
            ";

        private string QueryGetEnterpriseById() =>
            @"
                SELECT
                    *
                FROM
                    Enterprise
                WHERE
                    Id = @enterpriseId
            ";

        #endregion

        #region Methods

        public IEnumerable<EnterpriseViewModel> GetAllEnterprises() =>
            sqlConnection.Query<EnterpriseViewModel>(QueryGetAllEnterprises());

        public EnterpriseViewModel GetEnterpriseByFiscalNr(int fiscalNr) =>
            sqlConnection.QueryFirstOrDefault(QueryGetEnterpriseByFiscalNr(), new { fiscalNr });

        public EnterpriseViewModel GetEnterpriseByFiscalNr(Guid enterpriseId) =>
            sqlConnection.QueryFirstOrDefault(QueryGetEnterpriseById(), new { enterpriseId });
        #endregion
    }
}
