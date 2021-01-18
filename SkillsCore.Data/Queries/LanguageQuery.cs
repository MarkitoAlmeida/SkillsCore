using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.LanguageViewModels;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class LanguageQuery : ILanguageQuery
    {
        #region Properties

        private readonly SkillsContext _context;
        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public LanguageQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

        #endregion

        #region Queries

        private string QueryGetAllLanguagesByUser() =>
            @"
                SELECT
                    *
                FROM
                    Language
                WHERE
                    IdUser = @userId
            ";

        #endregion

        #region Methods

        public async Task<IEnumerable<LanguageViewModel>> GetAllLanguagesByUser(Guid userId) =>
            await sqlConnection.QueryAsync<LanguageViewModel>(QueryGetAllLanguagesByUser(), new { userId });

        #endregion
    }
}
