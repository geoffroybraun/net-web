namespace GB.NetWeb.Application.WebPortal.ViewModels.Shared
{
    /// <summary>
    /// Represents a view modal which is used to the "_Success' partial view
    /// </summary>
    public sealed record SuccessViewModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string OnModalClose { get; set; }
    }
}
