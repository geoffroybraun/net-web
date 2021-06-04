using GB.NetWeb.Application.Services.Interfaces.CQRS;
using System;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.Commands.Persons
{
    /// <summary>
    /// Represents a command which deletes a <see cref="DTOs.PersonDto"/>
    /// </summary>
    [Serializable]
    public sealed record DeletePersonCommand : ICommand<bool>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public bool RunCommand { get; set; }
    }
}
