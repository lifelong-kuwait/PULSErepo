using Abp.Web.Mvc.Controllers;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading;
using System.Web;
using TMS.Web.Core;



namespace TMS.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    /// 
    /// [ExceptionHandlerAttribute]
    [ExceptionHandlerAttribute]
    public abstract class TMSControllerBase : AbpController
    {
        protected TMSControllerBase()
        {
            LocalizationSourceName = TMSConsts.LocalizationSourceName;
        }

        protected TMSUser CurrentUser
        {
            get
            {
                return new TMSUser(this.User as ClaimsPrincipal);
            }
        }
        //public  long CompanyID(long id)
        //{
        //    return id = CurrentUser.CompanyID;
        //}
        protected string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }

      
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_cultureTMS"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = TMSHelper.PrimaryLanguageCode().ToLower();
            //Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }


    }
}