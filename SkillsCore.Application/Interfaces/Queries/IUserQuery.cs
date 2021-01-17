using SkillsCore.Application.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface IUserQuery
    {
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<UserViewModel> GetUserByFiscalNr(int fiscalNr);
        Task<UserViewModel> GetUserById(Guid id);
    }
}
