using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Application.ViewModels.UserViewModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int FiscalNr { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public EGender Gender { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CityOfBirth { get; set; }
        public string CarrerTitle { get; set; }
        public int ExperienceTime { get; set; }
        public string Summary { get; set; }
        public Guid? IdEnterprise { get; set; }
        public bool Active { get; set; }
        public bool Excluded { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
