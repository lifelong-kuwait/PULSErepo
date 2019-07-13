using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Common.DDL;

namespace TMS.Web.Controllers
{
    public class SPl_Test_ReportsController : TMSControllerBase
    {
        DDLBAL ddl = new DDLBAL();
        // GET: SPl_Test_Reports
        [ClaimsAuthorize("CanViewAttendance")]
        [DontWrapResult]
        public ActionResult ReportViewer()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ViewCourseAttendanceReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Trainer_Detail_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_TrainerDetailReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Trainee_Detail_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_TraineeDetailReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Class_Detail_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ClassDetailReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Venue_Detail_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_VenueDetailReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Venue_Ocupancy_Detail_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_VenueOccupancyReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        [HttpPost]
        public ActionResult ClassTrainer(string ClassID)
        {
            long ClassId = Convert.ToInt64(ClassID);
          var result= Json(ddl.Class_TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID, ClassId), JsonRequestBehavior.AllowGet);
            return Json(result);
        }
    }
}