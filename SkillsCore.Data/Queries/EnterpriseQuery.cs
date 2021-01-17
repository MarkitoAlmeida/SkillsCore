using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class EnterpriseQuery : IEnterpriseQuery
    {
        #region Properties

        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public EnterpriseQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

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

        public async Task<IEnumerable<EnterpriseViewModel>> GetAllEnterprises() =>
            await sqlConnection.QueryAsync<EnterpriseViewModel>(QueryGetAllEnterprises());

        public async Task<EnterpriseViewModel> GetEnterpriseByFiscalNr(int fiscalNr) =>
            await sqlConnection.QueryFirstOrDefaultAsync(QueryGetEnterpriseByFiscalNr(), new { fiscalNr });

        public async Task<EnterpriseViewModel> GetEnterpriseById(Guid enterpriseId) =>
            await sqlConnection.QueryFirstOrDefaultAsync(QueryGetEnterpriseById(), new { enterpriseId });

        #endregion
    }
}
