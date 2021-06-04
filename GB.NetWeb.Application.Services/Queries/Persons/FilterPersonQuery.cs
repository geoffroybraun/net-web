using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.Queries.Persons
{
    /// <summary>
    /// Represents a query xwhich filters <see cref="PersonDto"/>
    /// </summary>
    [Serializable]
    public sealed record FilterPersonQuery : IQuery<IEnumerable<PersonDto>>
    {
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        public int BirthYear { get; set; }

        public int BirthMonth { get; set; }

        public int BirthDay { get; set; }
    }
}
