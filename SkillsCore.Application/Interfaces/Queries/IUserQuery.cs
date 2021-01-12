using SkillsCore.Application.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IUserQuery
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUserByFiscalNr(int fiscalNr);
        UserViewModel GetUserById(Guid id);
    }
}
