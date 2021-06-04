using System;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.DTOs
{
    /// <summary>
    /// Represents a person with all required properties
    /// </summary>
    [Serializable]
    public sealed record PersonDto
    {
        public int Id { get; init; }

        [Required]
        [DataType(DataType.Text)]
        public string Firstname { get; init; }

        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; init; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; init; }
    }
}
