using SkillsCore.Shared.Models;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Models
{
    public class Enterprise : Entity
    {
        #region Constructor

        public Enterprise() { }

        public Enterprise(string name, int fiscalNr, string email, string phone, string street,
            string stateProvince, string city, string country)
        {
            Name = name;
            FiscalNr = fiscalNr;
            Email = email;
            Phone = phone;
            Street = street;
            StateProvince = stateProvince;
            City = city;
            Country = country;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public int FiscalNr { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Street { get; private set; }
        public string StateProvince { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public virtual IEnumerable<User> Users { get; set; }

        #endregion

        #region Methods

        public void UpdateFields(Enterprise fields)
        {
            Name = fields.Name;
            Email = fields.Email;
            Phone = fields.Phone;
            Street = fields.Street;
            StateProvince = fields.StateProvince;
            City = fields.City;
            Country = fields.Country;
            LastUpdate = DateTime.UtcNow;
        }

        public void Delete()
        {
            Active = false;
            Excluded = true;
            LastUpdate = DateTime.UtcNow;
        }

        #endregion
    }
}
