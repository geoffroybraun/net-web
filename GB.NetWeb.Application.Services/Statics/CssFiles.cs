using System;

namespace GB.NetWeb.Application.Services.Statics
{
    /// <summary>
    /// Retrieve all available CSS files for the application
    /// </summary>
    public static class CssFiles
    {
        public static readonly Tuple<string, string> BootstrapBundle = new("https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.6.0/css/bootstrap.min.css", "sha512-P5MgMn1jBN01asBgU0z60Qk4QxiXo86+wlFahKrsQf37c9cro517WzVSPPV1tDKzhku2iJ2FVgL67wG03SGnNA==");

        public static readonly Tuple<string, string> Datatables = new("https://cdn.datatables.net/v/bs4/dt-1.10.24/datatables.min.css", null);

        public static readonly Tuple<string, string> BootstrapDatePicker = new("https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css", "sha512-mSYUmp1HYZDFaVKK//63EcZq4iFWFjxSL+Z3T/aCt4IO9Cejm03q3NKKYN6pFQzY0SBOr8h+eCIAZHPXcpZaNw==");

        public static readonly Tuple<string, string> FontAwesome = new("https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.9.0/css/all.min.css", "sha512-q3eWabyZPc1XTCmF+8/LuE1ozpg5xxn7iO89yfSOd5/oKvyqLngoNGsx8jq92Y8eXJ/IRxQbEC+FGSYxtk2oiw==");
    }
}
