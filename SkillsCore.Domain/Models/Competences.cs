using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System.Collections.Generic;

namespace SkillsCore.Domain.Models
{
    public class Competences : Entity
    {
        #region Constructor

        public Competences() { }

        #endregion

        #region Properties

        public string CompetenceName { get; private set; }
        public int CompetenceExperienceTime { get; private set; }
        public ETimeType TimeType { get; private set; }

        public virtual IEnumerable<User> Users { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
