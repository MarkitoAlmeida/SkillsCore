using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class Competences : Entity
    {
        #region Constructor

        public Competences() { }

        public Competences(string competenceName, int competenceExperienceTime, ETimeType timeType, ECompetenceType competenceType, Guid idUser)
        {
            CompetenceName = competenceName;
            CompetenceExperienceTime = competenceExperienceTime;
            TimeType = timeType;
            CompetenceType = competenceType;
            IdUser = idUser;
        }

        #endregion

        #region Properties

        public string CompetenceName { get; private set; }
        public int CompetenceExperienceTime { get; private set; }
        public ETimeType TimeType { get; private set; }
        public ECompetenceType CompetenceType { get; private set; }
        public Guid IdUser { get; private set; }

        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void UpdateFields(Competences fields)
        {
            CompetenceName = fields.CompetenceName;
            CompetenceExperienceTime = fields.CompetenceExperienceTime;
            TimeType = fields.TimeType;
            CompetenceType = fields.CompetenceType;
            LastUpdate = DateTime.UtcNow;
        }

        #endregion
    }
}
