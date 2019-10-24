using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.TMS;

namespace TMS.Web.Views.Report.SpLReports
{
    public partial class ClassFutureReport : ReportBasePage
    {
        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
                                                   // private readonly IPersonBAL _PersonBAL;
        private static DataSet _GetTrainerDetailsForReports;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        ReportData reportDataG = new ReportData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string classid = Request.QueryString["ClassID"];
                string courseid = Request.QueryString["courseId"]; 
                string startDate = Request.QueryString["StartDate"]; 
                RenderReportModels(this.ReportDataObj, courseid, classid, startDate);
            }
        }
        //protected void JpegPng(object sender, EventArgs e)
        //{
        //    ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
        //    ReportViewerRSFReports.LocalReport.ReportPath = Server.MapPath(@"../../../Report/Tran_ClassReport.rdlc");
        //    string reportType = "Image";
        //    string outputFormat = (sender as Button).Text.ToLower();
        //    byte[] renderedBytes;
        //    if (outputFormat == "jpg")
        //    {
        //        renderedBytes = ReportViewerRSFReports.LocalReport.Render(reportType, "<DeviceInfo><OutputFormat>JPG</OutputFormat></DeviceInfo>");
        //    }
        //    else
        //    {
        //        renderedBytes = ReportViewerRSFReports.LocalReport.Render(reportType, "<DeviceInfo><OutputFormat>PNG</OutputFormat></DeviceInfo>");
        //    }

        //    Response.Buffer = true;
        //    Response.Clear();
        //    Response.ContentType = "image/jpeg";
        //    Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + outputFormat);
        //    Response.BinaryWrite(renderedBytes);
        //    Response.Flush();
        //}
        private void RenderReportModels(ReportData reportData, string courseid, string classid,string startDate)
        {
            reportDataG = reportData;
            long CompanyId = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);

            int ClassID = Convert.ToInt32(classid);
            long CourseID = Convert.ToInt64(courseid);
            DateTime Toyear = new DateTime(2099, 12, 31);
            DateTime startdatet = DateTime.ParseExact(startDate, "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture);
            bool ShowFutureClasses = true;
            // Reset report properties.
            ReportViewerRSFReports.Height = Unit.Parse("100%");
            ReportViewerRSFReports.Width = Unit.Parse("100%");
            ReportViewerRSFReports.CssClass = "table";
            var rptPath = Server.MapPath(@"../../../Report/" + reportData.ReportName + ".rdlc");
            this.ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
            //DataTable dt = _PersonBAL.GetClassDetailReportData(Convert.ToInt64(classid), Convert.ToInt64(courseid));
           DataTable dt = _PersonBAL.ClassFutureReport(CourseID, startdatet, Toyear, ShowFutureClasses, ClassID, CompanyId);
            ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DS_ClassReportByCourseCategoryID", dt));
            ReportViewerRSFReports.LocalReport.Refresh();
            //ReportViewerRSFReports.RefreshReport();
            //// Clear out any previous datasources.
            //this.ReportViewerRSFReports.LocalReport.DataSources.Clear();

            //// Set report mode for local processing.
            //ReportViewerRSFReports.ProcessingMode = ProcessingMode.Remote;

            //// Validate report source.
            //var rptPath = Server.MapPath(@"../../../Report/" + reportData.ReportName + ".rdlc");

            ////@"E:\RSFERP_SourceCode\RASolarERP\RASolarERP\Reports\Report\" + reportData.ReportName + ".rdlc";
            ////Server.MapPath(@"./Report/ClosingInventory.rdlc");

            //if (!File.Exists(rptPath))
            //    return;

            //// Set report path.
            //this.ReportViewerRSFReports.LocalReport.ReportPath = rptPath;

            //// Set report parameters.
            //var rpPms = ReportViewerRSFReports.LocalReport.GetParameters();
            //foreach (var rpm in rpPms)
            //{
            //    var p = reportData.ReportParameters.SingleOrDefault(o => o.ParameterName.ToLower() == rpm.Name.ToLower());
            //    if (p != null)
            //    {
            //        ReportParameter rp = new ReportParameter(rpm.Name, p.Value);
            //        ReportViewerRSFReports.LocalReport.SetParameters(rp);
            //    }
            //}

            //////Set data paramater for report SP execution
            ////objClosingInventory = dal.ClosingInventoryReport(this.ReportDataObj.DataParameters[0].Value);

            ////// Load the dataSource.
            //// ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ////var dsmems = ReportViewerRSFReports.LocalReport.GetDataSourceNames();
            //// ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", objClosingInventory));
            //// ReportViewerRSFReports.RefreshReport();
            //// Refresh the ReportViewer.
            //DataTable dt = _CourseBAL.GetCourseReportData(ClassID, CourseID);
            //ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ////ReportViewerRSFReports.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_ViewCourseAttendanceReport.rdlc");
            ////  DataSet ds = GetTrainerDetailsForReports;
            //ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ////ReportViewerRSFReports.Reset();
            //ReportDataSource datasource = new ReportDataSource("VewCourseAttendanceReportDataSet", dt);
            //ReportViewerRSFReports.LocalReport.DataSources.Add(datasource);


            //this.ReportViewerRSFReports.LocalReport.Refresh();
        }
    }
}