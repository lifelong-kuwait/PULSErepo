using System.Web;
using System.Web.Mvc;

namespace TMS.Web.Core
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
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
        }
    }
}