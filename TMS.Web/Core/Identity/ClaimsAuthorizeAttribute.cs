using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMS.Web
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] claimValue;
        public ClaimsAuthorizeAttribute(params string[] roles)
        {
            this.claimValue = roles;
        }
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var user = filterContext.HttpContext.User as ClaimsPrincipal;

                if (user != null && filterContext.HttpContext.User.CheckAccess(claimValue))
                {
                    base.OnAuthorization(filterContext);
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        base.HandleUnauthorizedRequest(filterContext);
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Main", returnUrl = filterContext.HttpContext.Request.FilePath }));                               
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login", returnUrl = filterContext.HttpContext.Request.FilePath }));                           
            }
        }        
    }
    public class ContentAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                    return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "UnAuthenticated"}));                           
            }
        }

    }
    public class ActivityAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "UnAuthorized" }));
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login", returnUrl = filterContext.HttpContext.Request.FilePath }));                           
                }
            }
        }

    }
    public static class PrincipalExtensions
    {
        public static bool IsInAllRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.All(r => principal.IsInRole(r));
        }

        public static bool IsInAnyRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(r => principal.IsInRole(r));
        }

        internal static bool CheckAccess(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(r => principal.IsInRole(r));
        }
    }
}