using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class JobExperience : Entity
    {
        #region Constructor

        public JobExperience() { }

        public JobExperience(string enterpriseName, DateTime beginDate, DateTime finalDate, string jobTitle, string projectDescription,
            string projectResponsabilities, string tecnologiesUsed, Guid idUser)
        {
            EnterpriseName = enterpriseName;
            BeginDate = beginDate;
            FinalDate = finalDate;
            JobTitle = jobTitle;
            ProjectDescription = projectDescription;
            ProjectResponsabilities = projectResponsabilities;
            TecnologiesUsed = tecnologiesUsed;
            IdUser = idUser;
        }

        #endregion

        #region Properties

        public string EnterpriseName {get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        public string JobTitle { get; private set; }
        public string ProjectDescription { get; private set; }
        public string ProjectResponsabilities { get; private set; }
        public string TecnologiesUsed { get; private set; }
        public Guid IdUser { get; private set; }

        public virtual User User { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
