﻿using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Application.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace SkillsCore.Application.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetUsers();
        UserViewModel GetUserByFiscalNr(int fiscalNr);
        ResultViewModel CreateUser(CreateUserViewModel createUser);
        ResultViewModel UpdateUser(UpdateUserViewModel updateUser);
    }
}
