using SkillsCore.Application.ViewModels.CompetenceViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsCore.Application.Interfaces.Queries
{
    public interface ICompetenceQuery
    {
        Task<IEnumerable<CompetenceViewModel>> GetAllCompetencesByUser(Guid userId);
    }
}
