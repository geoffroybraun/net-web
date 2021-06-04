using GB.NetWeb.Application.Services.Interfaces.CQRS;
using System;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.Commands.Persons
{
    /// <summary>
    /// Represents a command to update an existing <see cref="DTOs.PersonDto"/>
    /// </summary>
    [Serializable]
    public sealed record UpdatePersonCommand : ICommand<bool>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        public bool RunCommand { get; set; }
    }
}
