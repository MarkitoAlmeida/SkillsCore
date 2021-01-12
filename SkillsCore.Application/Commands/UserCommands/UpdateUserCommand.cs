using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Enums;
using System;

namespace SkillsCore.Application.Commands.UserCommands
{
    public class UpdateUserCommand : Notifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EGender Gender { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string StateProvice { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ExperienceTime { get; set; }
        public string Summary { get; set; }

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
                    .IsNotNull(Email, "Email", "O campo 'Email' não pode estar vazio.")
                    .IsNotNull(Phone, "Phone", "O campo 'Phone' não pode estar vazio.")
                    .IsNotNull(Street, "Street", "O campo 'Street' não pode estar vazio.")
                    .IsNotNull(StateProvice, "StateProvice", "O campo 'StateProvice' não pode estar vazio.")
                    .IsNotNull(City, "StateProvice", "O campo 'City' não pode estar vazio.")
                    .IsNotNull(ExperienceTime, "ExperienceTime", "O campo 'ExperienceTime' não pode estar vazio.")
                    .IsNotNull(Summary, "ExperienceTime", "O campo 'Summary' não pode estar vazio.")
            );
        }

        #endregion
    }
}
