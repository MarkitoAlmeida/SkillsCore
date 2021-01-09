using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Application.ViewModels
{
    public class CreateUserViewModel : Notifiable, IValidatable
    {
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public int FiscalNr { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public DateTime BirthDay { get;  set; }
        public EGender Gender { get;  set; }
        public string Phone { get;  set; }
        public string Street { get;  set; }
        public string StateProvice { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string CityOfBirth { get;  set; }
        public string ExperienceTime { get;  set; }
        public string Summary { get;  set; }
        public EAdministrationType AdministrationType { get;  set; }

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
                    .IsNotNull(AdministrationType, "AdministrationType", "O campo 'Perfil' não pode estar vazio.")
                    .IsNotNull(Street, "Street", "O campo 'Street' não pode estar vazio.")
                    .IsNotNull(StateProvice, "StateProvice", "O campo 'StateProvice' não pode estar vazio.")
                    .IsNotNull(City, "StateProvice", "O campo 'City' não pode estar vazio.")
                    .IsNotNull(CityOfBirth, "CityOfBirth", "O campo 'CityOfBirth' não pode estar vazio.")
                    .IsNotNull(ExperienceTime, "ExperienceTime", "O campo 'ExperienceTime' não pode estar vazio.")
                    .IsNotNull(Summary, "ExperienceTime", "O campo 'Summary' não pode estar vazio.")
                    .IsNotNull(AdministrationType, "AdministrationType", "O campo 'AdministrationType' não pode estar vazio.")
            );
        }

        #endregion
    }
}
