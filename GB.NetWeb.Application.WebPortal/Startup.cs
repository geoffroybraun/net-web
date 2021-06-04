using GB.NetWeb.Application.Services.Handlers;
using GB.NetWeb.Application.WebPortal.Extensions;
using GB.NetWeb.Application.WebPortal.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GB.NetWeb.Application.WebPortal
{
    public sealed class Startup
    {
        #region Fields

        private readonly IConfiguration Configuration;

        #endregion

        public Startup(IConfiguration configuration) => Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.ConfigureWebPortal(Configuration);
            services.AddMediatR(typeof(BaseQueryHandler<,>));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization(RequestLocalizationMiddleware.Handle);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages(StatusCodePagesMiddleware.Handle);
            app.UseHttpsRedirection();
            app.UseCookiePolicy(new() { HttpOnly = HttpOnlyPolicy.Always, Secure = CookieSecurePolicy.Always });
            app.UseRouting();
            app.UseCors();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions() { OnPrepareResponse = StaticFilesMiddleware.Handle });
            app.UseAuthentication();
            app.UseAuthorization();
            app.Use(ResponseHeadersMiddleware.Handle);
            app.UseEndpoints((builder) => builder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
