using log4net;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects;
using TMS.Library;
using TMS.Web.Controllers;

namespace TMS.Web.Core
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        private new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly UserDAL BALUsers=new UserDAL();
        public void OnException(ExceptionContext filterContext)

        {
           
            if (filterContext.Exception != null)
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
                // BLL.ErrorLogManager.AddErrorByException(filterContext.Exception, BO.ErrorLog.OriginType.EFB);
            }
            //if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    return;
            //}

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                 filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Redirect("~/Home/PageNotFound");
            }
            string date = DateTime.Now.ToString();
            string logger = "10";
            int level = (int) Logs.Error;
            string machine = System.Environment.MachineName;
            string message = filterContext.Exception.Message.ToString();
            string stacktrack = filterContext.Exception.StackTrace.ToString();
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();
            string username = "";
            long id=0;
            long Companyid=0;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                username = filterContext.HttpContext.User.Identity.Name;
            }
            if (filterContext.HttpContext.Session != null)
            {
                id = Convert.ToInt64(filterContext.HttpContext.Session["UserId"]);
            }
            if (filterContext.HttpContext.Session != null)
            {
                Companyid = Convert.ToInt64(filterContext.HttpContext.Session["CompanyID"]);
            }
            var httpContext = filterContext.RequestContext.HttpContext;
            var request = httpContext.Request;
            var param = request.Params;
            var json2 = new JavaScriptSerializer().Serialize(param);
            BALUsers.LogInsert(date,logger, Logs.Error.ToString(), machine ,message, stacktrack, id, controller, action, param.ToString(), Companyid);
            Logger.Error(filterContext.Exception.Message.ToString());
        }
    }
}