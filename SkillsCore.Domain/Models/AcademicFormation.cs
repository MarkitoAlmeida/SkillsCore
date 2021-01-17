using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class AcademicFormation : Entity
    {
        #region Constructor

        AcademicFormation() { }

        public AcademicFormation(string instituitionName, DateTime conclusionDate, string courseTitle, string finalPaperTitle,
            Guid idUser)
        {
            InstituitionName = instituitionName;
            ConclusionDate = conclusionDate;
            CourseTitle = courseTitle;
            FinalPaperTitle = finalPaperTitle;
            IdUser = idUser;
        }

        #endregion

        #region Properties

        public string InstituitionName { get; private set; }
        public DateTime ConclusionDate { get; private set; }
        public string CourseTitle { get; private set; }
        public string FinalPaperTitle { get; private set; }
        public Guid IdUser { get; private set; }

        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void UpdateFields(AcademicFormation fields) 
        {
            InstituitionName = fields.InstituitionName;
            ConclusionDate = fields.ConclusionDate;
            CourseTitle = fields.CourseTitle;
            FinalPaperTitle = fields.FinalPaperTitle;
            LastUpdate = DateTime.UtcNow;
        }

        #endregion
    }
}
