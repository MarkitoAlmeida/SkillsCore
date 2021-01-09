using SkillsCore.Domain.Enums;
using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Domain.Models
{
    public class User : Entity
    {
        #region Constructor

        public User() { }

        public User(string name, string lastName, int fiscalNr, string email, string password, DateTime birthDay, EGender gender,
            string phone, string street, string stateProvince, string city, string country, string cityOfBirth, string experienceTime,
            string summary, EAdministrationType administrationType)
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
            AdministrationType = administrationType;
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
        public EAdministrationType AdministrationType { get; private set; }
        public Guid IdEnterprise { get; private set; }

        public virtual AcademicFormation AcademicFormation { get; set; }
        public virtual Language Language { get; set; }
        public virtual Competences Competences { get; set; }
        public virtual JobExperience JobExperience { get; set; }

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
