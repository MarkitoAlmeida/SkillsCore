using SkillsCore.Shared.Models;
using System.Collections.Generic;

namespace SkillsCore.Domain.Models
{
    public class AdministrationType : Entity
    {
        #region Constructor

        public AdministrationType() { }

        public AdministrationType(string admType)
        {
            AdmType = admType;
        }

        #endregion

        #region Properties

        public string AdmType { get; private set; }

        public virtual IEnumerable<User> Users { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
