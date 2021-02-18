using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class SkillsDossier : Entity
    {
        #region Constructor

        public SkillsDossier() { }

        public SkillsDossier(Guid idUserCreated, string userCreatedName, Guid idUserResquest, string userResquestName, Guid idEnterprise,
            string enterpriseName, int creationNr, DateTime creationDate)
        {
            IdUserCreated = idUserCreated;
            UserCreatedName = userCreatedName;
            IdUserResquest = idUserResquest;
            UserResquestName = userResquestName;
            IdEnterprise = idEnterprise;
            EnterpriseName = enterpriseName;
            CreationNr = creationNr;
            CreationDate = creationDate;
        }

        #endregion

        #region Properties

        public Guid IdUserCreated { get; private set; }
        public string UserCreatedName { get; private set; }
        public Guid IdUserResquest { get; private set; }
        public string UserResquestName { get; private set; }
        public Guid IdEnterprise { get; private set; }
        public string EnterpriseName { get; private set; }
        public int CreationNr { get; private set; }

        #endregion
    }
}
