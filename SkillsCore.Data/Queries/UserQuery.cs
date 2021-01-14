using Dapper;
using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;

namespace SkillsCore.Data.Queries
{
    public class UserQuery : IUserQuery
    {
        #region Properties

        private readonly SkillsContext _context;

        #endregion

        #region Constructor

        public UserQuery(SkillsContext context) =>
            _context = context;

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

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            using IDbConnection conn = _context.Database.GetDbConnection();
            return conn.Query<UserViewModel>(QueryGetAllUsers());
        }

        public UserViewModel GetUserByFiscalNr(int fiscalNr)
        {
            using IDbConnection conn = _context.Database.GetDbConnection();
            return conn.QueryFirstOrDefault<UserViewModel>(QueryGetUserByFiscalNr(), new { fiscalNr });
        }

        public UserViewModel GetUserById(Guid id)
        {
            using IDbConnection conn = _context.Database.GetDbConnection();
            return conn.QueryFirstOrDefault<UserViewModel>(QuertGetUserById(), new { id });
        }

        #endregion
    }
}
