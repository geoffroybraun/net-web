using GB.NetWeb.Application.Services.DTOs;
using System.Collections.Generic;

namespace GB.NetWeb.Application.WebPortal.ViewModels.Persons
{
    /// <summary>
    /// Represents a view model for the <see cref="Controllers.PersonController.Index"/> controller action
    /// </summary>
    public sealed record ListPersonViewModel
    {
        public IEnumerable<PersonDto> Persons { get; set; }
    }
}
