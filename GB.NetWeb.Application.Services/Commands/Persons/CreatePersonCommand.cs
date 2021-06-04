using GB.NetWeb.Application.Services.Interfaces.CQRS;
using System;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.Commands.Persons
{
    /// <summary>
    /// Represents a command which creates a <see cref="DTOs.PersonDto"/>
    /// </summary>
    [Serializable]
    public sealed record CreatePersonCommand : ICommand<bool>
    {
        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; } = DateTime.UtcNow;
    }
}
