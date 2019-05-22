// ***********************************************************************
// Assembly         : TMS.Web
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 09-14-2016
// ***********************************************************************
// <copyright file="RouteConfig.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMS.Web
{
    /// <summary>
    /// Class RouteConfig.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*robotstxt}", new { robotstxt = @"(.*/)?robots.txt(/.*)?" });
            //ASP.NET Web API Route Config
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                constraints: new { controller = @"[^\.]*" }                          // Parameter constraints
            );
        }
    }
}
