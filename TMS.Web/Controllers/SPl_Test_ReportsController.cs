using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.TMS;
using TMS.Business.TMS;
using TMS.Library.Entities.TMS.Program;

namespace TMS.Web.Controllers
{
    public class SPl_Test_ReportsController : TMSControllerBase
    {
        DDLBAL ddl = new DDLBAL();
        private Classes CurrentClass;
        PersonBAL _PersonBAL = new PersonBAL();
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
        public ActionResult Weekly_Attandence_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ViewAttendanceReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Class_Future_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ClassReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Class_Current_Report()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ClassReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult VenueDetailUtilizationReport()
        {
            ViewData["reportUrl"] = "~/Report/WeeklyUtilizationReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult VenueDailyUtilizationReport()
        {
            ViewData["reportUrl"] = "~/Report/WeeklyUtilizationReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        [HttpPost]
        public ActionResult ClassTrainer(string ClassID)
        {
            long ClassId = Convert.ToInt64(ClassID);
          var result= Json(ddl.Course_ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID, ClassId), JsonRequestBehavior.AllowGet);
            return Json(result);
        }
         [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        [HttpPost]
        public ActionResult classStatAndEndDate(string ClassID)
        {
            long classid = Convert.ToInt64(ClassID);
            CurrentClass = _PersonBAL.ClassGetByID(classid);
            string[] arr = { CurrentClass.StartDate.ToString(), CurrentClass.EndDate.ToString() };
            var result = Json(new { StartDate = ""+CurrentClass.StartDate.ToString()+"", EndDate = "" + CurrentClass.EndDate.ToString() + "" }, JsonRequestBehavior.AllowGet);
            return Json(result);
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        [HttpPost]
        public ActionResult addInDate(string date)
        {
            DateTime startDate = Convert.ToDateTime(date);
            string newdate = startDate.AddDays(6).ToShortDateString();
            var result = Json(new { endDate = "" + newdate + "" }, JsonRequestBehavior.AllowGet);
            return Json(result);
        }
    }
}