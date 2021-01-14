using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;

namespace SkillsCore.Data.Queries
{
    public class UserQuery : IUserQuery
    {
        #region Properties

        private readonly SqlConnection sqlConnection;

        #endregion

        #region Constructor

        public UserQuery(SkillsContext context) =>
            sqlConnection = new SqlConnection(context.Database.GetConnectionString());

        #endregion

        #region Queries

        private string QueryGetAllUsers() =>
            @"
                SELECT
                    *
                FROM
                    User
            ";

        private string QueryGetUserByFiscalNr() =>
            @"
                SELECT
                    *
                FROM
                    User
                WHERE
                    FicalNr = @FiscalNr
            ";

        public string QuertGetUserById() =>
            @"
                SELECT
                    *
                FROM
                    User
                WHERE
                    UserId = @id
            ";

        #endregion

        #region Methods

        public IEnumerable<UserViewModel> GetAllUsers() =>
            sqlConnection.Query<UserViewModel>(QueryGetAllUsers());

        public UserViewModel GetUserByFiscalNr(int fiscalNr) =>
            sqlConnection.QueryFirstOrDefault<UserViewModel>(QueryGetUserByFiscalNr(), new { fiscalNr });

        public UserViewModel GetUserById(Guid id) =>
            sqlConnection.QueryFirstOrDefault<UserViewModel>(QuertGetUserById(), new { id });


        #endregion
    }
}
