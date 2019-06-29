using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Business.TMS;
using TMS.Library.Entities.TMS.Reporting;

namespace TMS.Web.Controllers
{
    public class ReportingController : TMSControllerBase
    {
        private readonly ICourseBAL _CourseBAL;
        private readonly IClassBAL _ClassBAL;
        private readonly ISessionBAL _SessionBAL;
        private readonly IAttendanceBAL _AttendanceBAL;
        private readonly IConfigurationBAL _objConfigurationBAL;


        public ReportingController(ICourseBAL ICourseBAL, IConfigurationBAL _objIConfigurationBAL, IClassBAL IClassBAL, ISessionBAL _ISessionBAL, IAttendanceBAL _IAttendanceBAL)
        {
            _objConfigurationBAL = _objIConfigurationBAL;
            _CourseBAL = ICourseBAL;
            _ClassBAL = IClassBAL;
            _SessionBAL = _ISessionBAL;
            _AttendanceBAL = _IAttendanceBAL;
        }
        // GET: Reporting
        [ClaimsAuthorize("CanViewReports")]
        public ActionResult Index()
        {
            return View();
        }
        [ClaimsAuthorize("CanViewReports")]
        public ActionResult CourseAttendanceReportGenerator(string courseId,string classID)
        {
            PersonBAL _CourseBAL = new PersonBAL();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/SPL_Reports"), "AttendancesCourse_Report.rpt"));

            long ClassID = Convert.ToInt64(classID);
            long CourseID = Convert.ToInt64(courseId);

            DataTable dt = _CourseBAL.GetCourseReportData(ClassID, CourseID);
            rd.SetDataSource(dt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
             try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //var file= FileStreamResult(stream, "application/pdf", "Resource1.pdf");
                var fsResult = new FileStreamResult(stream, "application/pdf");
                return fsResult;
            }
            catch
            {
                throw;
            }
        }
    }
}