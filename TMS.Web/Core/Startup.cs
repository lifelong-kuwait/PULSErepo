using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//[assembly: OwinStartup(typeof(TMS.Web.Core.Startup))]
namespace TMS.Web.Core
{
    public  partial class Startup
    {
        //private ICurrentUserClaims IUserClaims { get; set; }
        //public Startup(ICurrentUserClaims UserClaims)
        //{
        //   this.IUserClaims = UserClaims;
        //}

        public void Configuration(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            //{
            //    AuthenticationType = "mainTms",
            //    LoginPath = new Microsoft.Owin.PathString("/Home/Login")
            //});

            ConfigureAuth(app);
        }
       
    }

}