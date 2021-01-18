using System;

namespace SkillsCore.Application.ViewModels.EnterpriseViewModels
{
    public class EnterpriseViewModel
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get;  set; }
        public int FiscalNr { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public string Street { get;  set; }
        public string StateProvince { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
