using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(MeuMedico.Startup))]

namespace MeuMedico
{
    public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "ApplicationCookie",
                    LoginPath = new PathString("/Home/Login")
                });

                AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
            }
        }
}