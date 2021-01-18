using SkillsCore.Application.ViewModels.LanguageViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface ILanguageQuery
    {
        Task<IEnumerable<LanguageViewModel>> GetAllLanguagesByUser(Guid userId);
    }
}
