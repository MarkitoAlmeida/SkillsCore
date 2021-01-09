using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IUserQuery
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUserByFiscalNr(int fiscalNr);
        UpdateUserViewModel GetUserById(Guid id);
    }
}
