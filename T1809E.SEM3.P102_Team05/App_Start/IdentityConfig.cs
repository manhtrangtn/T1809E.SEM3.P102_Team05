using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace T1809E.SEM3.P102_Team05.App_Start
{
    public class IdentityConfig
    {
      public void Configuration(IAppBuilder app)
      {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
          AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
          LoginPath = new PathString("/Home/Login"),
        });
      }
    }
}