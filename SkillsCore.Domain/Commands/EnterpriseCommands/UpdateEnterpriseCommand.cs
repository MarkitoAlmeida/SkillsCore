using Flunt.Notifications;
using Flunt.Validations;
using SkillsCore.Domain.Interfaces;
using System;

namespace SkillsCore.Application.Commands.EnterpriseCommands
{
    public class UpdateEnterpriseCommand : Notifiable, IValidatable, ICommand
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string StateProvice { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        #endregion

        #region Methods

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(Name, 150, "Nome", "O nome do usuário deve conter no máximo 150 caracteres.")
                    .HasMinLen(Name, 1, "Nome", "O nome do usuário deve conter no mínimo 1 caracter")
                    .IsNotNull(Email, "Email", "O campo 'Email' não pode estar vazio.")
                    .IsNotNull(Phone, "Phone", "O campo 'Phone' não pode estar vazio.")
                    .IsNotNull(Street, "Street", "O campo 'Street' não pode estar vazio.")
                    .IsNotNull(StateProvice, "StateProvice", "O campo 'StateProvice' não pode estar vazio.")
                    .IsNotNull(City, "StateProvice", "O campo 'City' não pode estar vazio.")
            );
        }

        #endregion
    }
}
