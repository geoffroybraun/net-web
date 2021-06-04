using GB.NetWeb.Application.Services.Commands.Persons;

namespace GB.NetWeb.Application.WebPortal.ViewModels.Persons
{
    /// <summary>
    /// Represents a view model for the <see cref="Controllers.PersonController.Delete"/> controller action
    /// </summary>
    public sealed record DeletePersonViewModel
    {
        public DeletePersonCommand Command { get; set; }
    }
}
