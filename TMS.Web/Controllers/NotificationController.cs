using Abp.Runtime.Validation;
using Abp.Web.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS;
using TMS.Library.Users;
using TMS.Web.Core;
using log4net;
using lr = Resources.Resources;
using System.Configuration;
using System.Web.Script.Serialization;
using TMS.Library;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Library.TMS;
using TMS.Business.Interfaces;
using Kendo.Mvc.UI;

namespace TMS.Web.Controllers
{
    public class NotificationController : TMSControllerBase
    {
        // GET: Notification
        private readonly INotificationBAL BALNotification;
        public NotificationController(INotificationBAL objINotificationBAL)
        {
            this.BALNotification = objINotificationBAL;
        }
        public ActionResult Index()
        {
            Session["LatestNotificationTime"] = null;
            return View();
        }
        
             [DontWrapResult]
        public ActionResult Notification_Read([DataSourceRequest] DataSourceRequest request)
        {
           
            //var Courses = this._CourseBAL.TMS_Courses_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            var Courses = BALNotification.read_AllNotificationsBAL(CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64);


            var result = new DataSourceResult()
            {
                Data = Courses, // Process data (paging and sorting applied)
                //Total = Total // Total number of records
            };


            return Json(result);
        }
        [DisableValidation]
        public JsonResult GetNotifications()
        {
            Session["LatestNotificationTime"] = DateTime.Now;
            var notifications = BALNotification.read_NotificationsBAL(CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64);
            return this.Json(new
            {
                 notifications
            }, JsonRequestBehavior.AllowGet)
            ;
        }
        [DisableValidation]
        public JsonResult GetNotificationsCount()
        {
            Session["LatestNotificationTime"] = DateTime.Now;
            var notifications = BALNotification.read_NotificationsCountBAL(CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64);
            return this.Json(new
            {
                notifications
            }, JsonRequestBehavior.AllowGet)
            ;
        }
        [HttpPost]
        [DisableValidation]
        public ActionResult MarkAsRead(string ID)
        {
            Notifications notif = new Notifications();
            notif.ID =Convert.ToInt64(ID);
            notif.ReadDateTime = DateTime.Now;
            var notifications = BALNotification.Update_NotificationsBAL(notif);
             return null;
        }
        [DisableValidation]
        public JsonResult GetLatestNotificationsResultForUser()
        {
            string _dateTime = System.Web.HttpContext.Current.Session["LatestNotificationTime"].ToString();
            var notifications = BALNotification.read_LatestNotificationsForUserBAL(CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, _dateTime);
            return this.Json(new
            {
                notifications
            }, JsonRequestBehavior.AllowGet)
            ;
        }
    }
}