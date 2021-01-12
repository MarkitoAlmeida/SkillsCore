using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;
using System.Collections.Generic;

namespace SkillsCore.Domain.Models
{
    public class User : Entity
    {
        #region Constructor

        public User() { }

        public User(string name, string lastName, int fiscalNr, string email, string password, DateTime birthDay, EGender gender,
            string phone, string street, string stateProvince, string city, string country, string cityOfBirth, string experienceTime,
            string summary, Guid idAdministrationType, Guid idEnterprise)
        {
            Name = name;
            LastName = lastName;
            FiscalNr = fiscalNr;
            Email = email;
            Password = password;
            BirthDay = birthDay;
            Gender = gender;
            Phone = phone;
            Street = street;
            StateProvince = stateProvince;
            City = city;
            Country = country;
            CityOfBirth = cityOfBirth;
            ExperienceTime = experienceTime;
            Summary = summary;
            IdAdministrationType = idAdministrationType;
            IdEnterprise = idEnterprise;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int FiscalNr { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDay { get; private set; }
        public EGender Gender { get; private set; }
        public string Phone { get; private set; }
        public string Street { get; private set; }
        public string StateProvince { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string CityOfBirth { get; private set; }
        public string ExperienceTime { get; private set; }
        public string Summary { get; private set; }
        public Guid IdAdministrationType { get; private set; }
        public Guid IdEnterprise { get; private set; }

        public virtual AdministrationType AdministrationType { get; private set; }
        public virtual Enterprise Enterprise { get; set; }

        public virtual IEnumerable<AcademicFormation> AcademicFormations { get; set; }
        public virtual IEnumerable<Language> Languages { get; set; }
        public virtual IEnumerable<Competences> Competences { get; set; }
        public virtual IEnumerable<JobExperience> JobExperiences { get; set; }

        #endregion

        #region Methods

        public void UpdateFields(User fields)
        {
            Name = fields.Name;
            LastName = fields.LastName;
            Email = fields.Email;
            Gender = fields.Gender;
            Phone = fields.Phone;
            Street = fields.Street;
            StateProvince = fields.StateProvince;
            City = fields.City;
            Country = fields.Country;
            ExperienceTime = fields.ExperienceTime;
            Summary = fields.Summary;
            LastUpdate = DateTime.UtcNow;
        }

        #endregion
    }
}
