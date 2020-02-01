using System;
using Abp.Web;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using TMS.Web.Custom;
using Resources;
using Telerik.Reporting.Services.WebApi;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TMS.Web
{
    public class MvcApplication : AbpWebApplication<TMSWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            //AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
            //    f => f.UseAbpLog4Net().WithConfig("log4net.config")
            //);

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Resources";
            DefaultModelBinder.ResourceClassKey = "Resources";
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier =
            System.Security.Claims.ClaimTypes.NameIdentifier;
            ReportsControllerConfiguration.RegisterRoutes(GlobalConfiguration.Configuration);
            log4net.Config.XmlConfigurator.Configure();
            base.Application_Start(sender, e);
        }
     //   public override void OnActionExecuting(HttpActionContext actionContext)
     //   {
     //       var userName = HttpContext.Current.User.Identity.Name;
     //       var IpAddress= HttpContext.Current.Request.UserHostAddress;
     //       var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
     //       var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
     //       var actionName = actionContext.ActionDescriptor.ActionName;

     ////   Logger.Log(string.Format("user: {0}, date: {1}, controller {2}, action {3}", userName, time, controllerName, actionName));
     //   }
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if ("culture".Equals(custom))
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("_cultureTMS");
                var culture = cookie != null
                                  ? CultureInfo.CreateSpecificCulture(cookie.Value).Name
                                  : Guid.NewGuid().ToString();  // if culture cookie doesn't exist, do not rely 
                // on cache - generate random guid to bypass it
                return culture;
            }
            return base.GetVaryByCustomString(context, custom);
        }

    }
}
