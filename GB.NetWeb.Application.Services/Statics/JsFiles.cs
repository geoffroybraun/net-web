using System;

namespace GB.NetWeb.Application.Services.Statics
{
    /// <summary>
    /// Retrieve all available JS files for the application
    /// </summary>
    public static class JsFiles
    {
        public static readonly Tuple<string, string> JQuery = new("https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js", "sha512-bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg==");

        public static readonly Tuple<string, string> BootstrapBundle = new("https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.6.0/js/bootstrap.bundle.min.js", "sha512-wV7Yj1alIZDqZFCUQJy85VN+qvEIly93fIQAN7iqDFCPEucLCeNFz4r35FCo9s6WrpdDQPi80xbljXB8Bjtvcg==");

        public static readonly Tuple<string, string> DataTables = new("https://cdn.datatables.net/v/bs4/dt-1.10.24/datatables.min.js", null);

        public static readonly Tuple<string, string> DataTablesFrenchPlugin = new("https://cdn.datatables.net/plug-ins/1.10.24/i18n/French.json", null);

        public static readonly Tuple<string, string> BootstrapDatePicker = new("https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js", "sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ==");
    }
}
