using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Web.Controllers
{
    public class SPl_Test_ReportsController : TMSControllerBase
    {
        // GET: SPl_Test_Reports
        [ClaimsAuthorize("CanViewAttendance")]
        [DontWrapResult]
        public ActionResult ReportViewer()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ViewCourseAttendanceReport/";

            return View();
        }
    }
}