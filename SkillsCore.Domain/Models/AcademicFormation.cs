using SkillsCore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Domain.Models
{
    public class AcademicFormation : Entity
    {
        #region Constructor

        AcademicFormation() { }

        public AcademicFormation(string instituitionName, DateTime conclusionDate, string courseTitle, string finalPaperTitle)
        {
            InstituitionName = instituitionName;
            ConclusionDate = conclusionDate;
            CourseTitle = courseTitle;
            FinalPaperTitle = finalPaperTitle;
        }

        #endregion

        #region Properties

        public string InstituitionName { get; private set; }
        public DateTime ConclusionDate { get; private set; }
        public string CourseTitle { get; private set; }
        public string FinalPaperTitle { get; private set; }

        public virtual IEnumerable<User> Skills { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
