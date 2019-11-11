using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.TMS;
using TMS.Library.TMS.Organization;
namespace TMS.Web.Views.Report.SpLReports
{
    public partial class TraineeDetailReport : ReportBasePage
    {
        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
                                                   // private readonly IPersonBAL _PersonBAL;
        private static DataSet _GetTrainerDetailsForReports;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string classid = Request.QueryString["ClassID"];
                string courseid = Request.QueryString["courseId"];
                string trainer = Request.QueryString["trainer"];
                RenderReportModels(this.ReportDataObj, classid, courseid, trainer);
            }
        }

        private void RenderReportModels(ReportData reportData, string courseid, string classid, string trainer)
        {
            long ClassID = Convert.ToInt64(classid);
            long CourseID = Convert.ToInt64(courseid);
            long TrainerID = Convert.ToInt64(trainer);


            // Reset report properties.
            ReportViewerRSFReports.Height = Unit.Parse("100%");
            ReportViewerRSFReports.Width = Unit.Parse("100%");
            ReportViewerRSFReports.CssClass = "table";
            var rptPath = Server.MapPath(@"../../../Report/" + reportData.ReportName + ".rdlc");
            this.ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
            DataTable dt = _PersonBAL.GetTraineeDetailsForReports(CourseID, TrainerID);
            ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ReportViewerRSFReports.LocalReport.EnableExternalImages = true;
            List<OrganizationModel> logoPath = _PersonBAL.GetOrganizationLogo(Convert.ToInt64(HttpContext.Current.Session["CompanyID"]));
            ReportParameter paramLogo = new ReportParameter();
            paramLogo.Name = "Path";
            string imagePath = new Uri(Server.MapPath(@"~/" + logoPath.FirstOrDefault().Logo)).AbsoluteUri;
            paramLogo.Values.Add(imagePath);
            ReportViewerRSFReports.LocalReport.SetParameters(paramLogo);
            ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
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