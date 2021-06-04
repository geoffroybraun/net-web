using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GB.NetWeb.Application.WebPortal
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureLogging((builder) =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            })
            .ConfigureWebHostDefaults((builder) => builder.UseStartup<Startup>());
    }
}
