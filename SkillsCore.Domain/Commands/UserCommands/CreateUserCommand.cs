using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Interfaces;
using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Domain.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable, IValidatable, ICommand
    {
        #region Properties

        public string Name { get;  set; }
        public string LastName { get;  set; }
        public int FiscalNr { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public DateTime BirthDay { get;  set; }
        public EGender Gender { get;  set; }
        public string Phone { get;  set; }
        public string Street { get;  set; }
        public string StateProvince { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string CityOfBirth { get;  set; }
        public int ExperienceTime { get;  set; }
        public string Summary { get;  set; }
        public Guid IdAdministrationType { get;  set; }
        public Guid IdEnterprise { get;  set; }

        #endregion

        #region Methods

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(Name, 150, "Nome", "O nome do usuário deve conter no máximo 150 caracteres.")
                    .HasMinLen(Name, 1, "Nome", "O nome do usuário deve conter no mínimo 1 caracter")
                    .HasMaxLen(LastName, 300, "LastName", "O sobrenome do usuário deve conter no máximo 300 caracteres.")
                    .HasMinLen(LastName, 1, "LastName", "O sobrenome do usuário deve conter no mínimo 1 caracter.")
                    .IsNotNull(FiscalNr, "FiscalNr", "O campo 'Fiscal Number' não pode estar vazio.")
                    .IsNotNull(Email, "Email", "O campo 'Email' não pode estar vazio.")
                    .IsNotNull(Password, "Password", "O campo 'Password' não pode estar vazio.")
                    .IsNotNull(BirthDay, "BirthDay", "O campo  'Aniversário' não pode estar vazio.")
                    .IsNotNull(Phone, "Phone", "O campo 'Phone' não pode estar vazio.")
                    .IsNotNull(Street, "Street", "O campo 'Street' não pode estar vazio.")
                    .IsNotNull(StateProvince, "StateProvince", "O campo 'StateProvice' não pode estar vazio.")
                    .IsNotNull(City, "City", "O campo 'City' não pode estar vazio.")
                    .IsNotNull(Country, "Country", "O campo 'Country' não pode estar vazio.")
                    .IsNotNull(CityOfBirth, "CityOfBirth", "O campo 'CityOfBirth' não pode estar vazio.")
                    .IsNotNull(ExperienceTime, "ExperienceTime", "O campo 'ExperienceTime' não pode estar vazio.")
                    .IsNotNull(Summary, "Summary", "O campo 'Summary' não pode estar vazio.")
                    .IsNotNull(IdAdministrationType, "AdministrationType", "O campo 'AdministrationType' não pode estar vazio.")
                    .IsNotNull(IdEnterprise, "Enterprise", "O campo 'Enterprise' não pode estar vazio.")
            );
        }

        #endregion
    }
}
