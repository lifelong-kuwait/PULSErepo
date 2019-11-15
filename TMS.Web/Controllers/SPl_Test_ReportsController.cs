using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.TMS;
using TMS.Business.TMS;
using TMS.Library.Entities.TMS.Program;
using System.Globalization;
using TMS.Web.Core;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
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
        public ActionResult WeeklyUtilizationReport()
        {
            ViewData["reportUrl"] = "~/Report/WeeklyUtilizationReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult WeeklyUtilizationReport2()
        {
            ViewData["reportUrl"] = "~/Report/WeeklyUtilizationReport2/";

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
            ViewData["CompanyID"] = CurrentUser.CompanyID;
            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult TraineePeriodicReport()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ViewTraineePeriodicReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult CoursePeriodicReport()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ConductedCoursesReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult WeeklyUtilizationReportModified()
        {
            ViewData["reportUrl"] = "~/Report/WeeklyUtilizatinDynamicColumns/";

            return View();
        }//Schedules
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult Schedules()
        {
          

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult VenueMatrixReport()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ConductedCoursesReport/";

            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        [DontWrapResult]
        public ActionResult VenueMatrixRDLCReport()
        {
            ViewData["reportUrl"] = "~/Report/Tran_ConductedCoursesReport/";

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
        
        [DontWrapResult]
        [HttpPost]
        public ActionResult addInDate(string date)
        {
            DateTime startDate = DateTime.ParseExact(date, "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            string newdate = startDate.AddDays(6).ToString("MM/dd/yyyy");
         
            var result = Json(new { endDate = "" + newdate + "" }, JsonRequestBehavior.AllowGet);
            return Json(result);
        }
       
        [DontWrapResult]
        [HttpPost]
        public JsonResult selectCourseBtTime(string startdate,string enddate)
        {
            DateTime startDate = DateTime.ParseExact(startdate, "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture); 
            DateTime endDate = DateTime.ParseExact(enddate, "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            long id = 0;
            if(CurrentUser.CompanyID==-1)
            { id = -1; }
            else
            {
                id = CurrentUser.NameIdentifierInt64;
            }
            return Json(_PersonBAL.GetCourseFromTimeSpanDALBAL(startDate, endDate,id), JsonRequestBehavior.AllowGet);
        }
      
        [DontWrapResult]
        [HttpPost]
        public JsonResult selectClassBtTime(string startdate, string enddate)
        {
            DateTime startDate = DateTime.ParseExact(startdate, "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(enddate, "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            return Json(_PersonBAL.GetCourseFromTimeSpan(startDate, endDate), JsonRequestBehavior.AllowGet);
        }
       
        [DontWrapResult]
        [HttpPost]
        public JsonResult Class_Trainer(string classId)
        {
           return Json(ddl.Class_TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(classId)), JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        [HttpPost]
        public JsonResult Class_Trainee(string classId)
        {
            IList<DDlList> list = ddl.Class_TraineeDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(classId));
            DDlList obj = new DDlList();
            obj.Text = "Select All";
            obj.Value = -1;
            obj.Selected = true;
            list.Insert(0, obj);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        [HttpPost]
        public JsonResult Course_Class(string course)
        {
            return Json(ddl.Course_ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(course)), JsonRequestBehavior.AllowGet);
        }
        // ddl.Course_ClassDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlCourse.SelectedValue))
    }
}