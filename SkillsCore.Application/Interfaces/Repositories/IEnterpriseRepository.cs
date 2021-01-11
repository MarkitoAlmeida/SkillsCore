using SkillsCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IEnterpriseRepository
    {
        Enterprise Get(int fiscalNr);
        void Insert(Enterprise enterprise);
        void Update(Enterprise enterprise);
    }
}
