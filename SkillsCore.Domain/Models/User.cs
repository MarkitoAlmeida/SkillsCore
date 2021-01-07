using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class User : Entity
    {
        #region Constructor

        public User() { }

        public User(string name, string lastName, string fiscalNr, string email, string password, DateTime bithDay, EGender gender,
            string phote, string street, string stateProvice, string city, string country, string cityOfBirth, string experienceTime,
            string summary, EAdministrationType administrationType)
        {
            Name = name;
            LastName = lastName;
            FiscalNr = fiscalNr;
            Email = email;
            Password = password;
            BithDay = bithDay;
            Gender = gender;
            Phote = phote;
            Street = street;
            StateProvice = stateProvice;
            City = city;
            Country = country;
            CityOfBirth = cityOfBirth;
            ExperienceTime = experienceTime;
            Summary = summary;
            AdministrationType = administrationType;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string FiscalNr { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BithDay { get; private set; }
        public EGender Gender { get; private set; }
        public string Phote { get; private set; }
        public string Street { get; private set; }
        public string StateProvice { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string CityOfBirth { get; private set; }
        public string ExperienceTime { get; private set; }
        public string Summary { get; private set; }
        public EAdministrationType AdministrationType { get; private set; }

        

    #endregion

    #region Methods



    #endregion
}
}
