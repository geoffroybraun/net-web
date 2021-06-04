using GB.NetWeb.Application.Services.Commands.Persons;

namespace GB.NetWeb.Application.WebPortal.ViewModels.Persons
{
    /// <summary>
    /// Represents a view model for the <see cref="Controllers.PersonController.Create"/> controller action
    /// </summary>
    public sealed record CreatePersonViewModel
    {
        public CreatePersonCommand Command { get; set; }
    }
}
