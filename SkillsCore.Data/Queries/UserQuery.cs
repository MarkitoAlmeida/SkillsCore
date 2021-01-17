using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SkillsCore.Data.Queries
{
    public class UserQuery : IUserQuery
    {
        #region Properties

        private readonly SkillsContext _context;
        private readonly SqlConnection _sqlConnection;

        #endregion

        #region Constructor

        public UserQuery(SkillsContext context)
        {
            _sqlConnection = new SqlConnection(context.Database.GetConnectionString());
            _context = context;
        }


        #endregion

        #region Queries

        private string QueryGetAllUsers() =>
            @"
                SELECT
                    *
                FROM
                    [dbo].[User]
            ";

        private string QueryGetUserByFiscalNr() =>
            @"
                SELECT
                    *
                FROM
                    [dbo].[User]
                WHERE
                    FiscalNr = @FiscalNr
            ";

        public string QuertGetUserById() =>
            @"
                SELECT
                    *
                FROM
                    [dbo].[User]
                WHERE
                    UserId = @id
            ";

        #endregion

        #region Methods

        public async Task<IEnumerable<UserViewModel>> GetAllUsers() =>
            await _sqlConnection.QueryAsync<UserViewModel>(QueryGetAllUsers());

        public async Task<UserViewModel> GetUserByFiscalNr(int fiscalNr) =>
            await _sqlConnection.QueryFirstOrDefaultAsync<UserViewModel>(QueryGetUserByFiscalNr(), new { fiscalNr });

        public async Task<UserViewModel> GetUserById(Guid id) =>
            await _sqlConnection.QueryFirstOrDefaultAsync<UserViewModel>(QuertGetUserById(), new { id });

        #endregion
    }
}
