using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.Queries.Persons;
using GB.NetWeb.Application.Services.Resources;
using GB.NetWeb.Application.Services.Statics;
using GB.NetWeb.Application.WebPortal.Authorizations;
using GB.NetWeb.Application.WebPortal.Extensions;
using GB.NetWeb.Application.WebPortal.ViewModels.Persons;
using GB.NetWeb.Application.WebPortal.ViewModels.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Controllers
{
    /// <summary>
    /// Executes an action related to persons
    /// </summary>
    [Permission(Permissions.ReadPerson)]
    public sealed class PersonController : Controller
    {
        #region Fields

        private readonly IMediator Mediator;
        private readonly IStringLocalizer Localizer;

        #endregion

        public PersonController(IMediator mediator, IStringLocalizer localizer)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await Mediator.ExecuteAsync(new FilterPersonQuery(), ModelState).ConfigureAwait(true);

            return PartialView("_List", response.HasSucceed ? response.Result : default);
        }

        [HttpPost]
        [Permission(Permissions.WritePerson)]
        public async Task<IActionResult> Create(CreatePersonCommand command = null)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            if (ModelState.IsValid)
            {
                var response = await Mediator.RunAsync(command, ModelState).ConfigureAwait(true);

                if (response.HasSucceed)
                {
                    var successTitle = Localizer.GetString(Resources.CreateNewPerson);
                    var succcessMessage = Localizer.GetString(Resources.CreatePersonSuccessMessage, command.Firstname, command.Lastname);

                    return PartialSuccessView(successTitle, succcessMessage);
                }
            }

            return PartialView("_Create", new CreatePersonViewModel() { Command = command ?? new() });
        }

        [HttpPost]
        [Permission(Permissions.DeletePerson)]
        public async Task<IActionResult> Delete(DeletePersonCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            if (command.RunCommand)
            {
                var response = await Mediator.RunAsync(command, ModelState).ConfigureAwait(true);

                if (response.HasSucceed)
                {
                    var successTitle = Localizer.GetString(Resources.DeletePersonTitle, command.Firstname, command.Lastname);
                    var successMessage = Localizer.GetString(Resources.DeletePersonSuccessMessage, command.Firstname, command.Lastname);

                    return PartialSuccessView(successTitle, successMessage);
                }
            }

            return PartialView("_Delete", new DeletePersonViewModel() { Command = command });
        }

        [HttpPost]
        [Permission(Permissions.WritePerson)]
        public async Task<IActionResult> Update(UpdatePersonCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            if (command.RunCommand && ModelState.IsValid)
            {
                var response = await Mediator.RunAsync(command, ModelState).ConfigureAwait(true);

                if (response.HasSucceed)
                {
                    var successTitle = Localizer.GetString(Resources.EditPersonTitle, command.Firstname, command.Lastname);
                    var successMessage = Localizer.GetString(Resources.UpdatePersonSuccessMessage, command.Firstname, command.Lastname);

                    return PartialSuccessView(successTitle, successMessage);
                }
            }

            return PartialView("_Update", new UpdatePersonViewModel() { Command = command });
        }

        #region Private methods

        private IActionResult PartialSuccessView(string title, string message)
        {
            var viewModel = new SuccessViewModel()
            {
                Title = title,
                Message = message,
                OnModalClose = "PersonManager.List()"
            };

            return PartialView("~/Views/Shared/_Success.cshtml", viewModel);
        }

        #endregion
    }
}
