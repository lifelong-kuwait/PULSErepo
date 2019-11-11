using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.TMS;
using TMS.Library.TMS.Organization;

namespace TMS.Web.Views.Report.SpLReports
{
    public partial class CertificatePrinting : ReportBasePage
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
                string PersonID = Request.QueryString["PersonID"];
                RenderReportModels(this.ReportDataObj, PersonID, classid);
            }
        }

        private void RenderReportModels(ReportData reportData, string PersonID, string classid)
        {
            long ClassID = Convert.ToInt64(classid);
            //long personID = PersonID;
            // Reset report properties.
            ReportViewerRSFReports.Height = Unit.Parse("100%");
            ReportViewerRSFReports.Width = Unit.Parse("100%");
            ReportViewerRSFReports.CssClass = "table";
            var rptPath = Server.MapPath(@"../../../Report/" + reportData.ReportName + ".rdlc");
            this.ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
            long cID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
            DataTable dt = _PersonBAL.GetCertificateReports(PersonID, Convert.ToInt64(classid),cID , "en-us", Convert.ToInt64(HttpContext.Current.Session["NameIdentifierInt64"]));
            ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ReportViewerRSFReports.LocalReport.DataSources.Clear();
            //ReportViewerRSFReports.LocalReport.EnableExternalImages = true;
            //List<OrganizationModel> logoPath = _PersonBAL.GetOrganizationLogo(Convert.ToInt64(HttpContext.Current.Session["CompanyID"]));
            //ReportParameter paramLogo = new ReportParameter();
            //paramLogo.Name = "Path";
            //string imagePath = new Uri(Server.MapPath(@"~/" + logoPath.FirstOrDefault().Logo)).AbsoluteUri;
            //paramLogo.Values.Add(imagePath);
            //ReportViewerRSFReports.LocalReport.SetParameters(paramLogo);
            ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewerRSFReports.LocalReport.Refresh();

        }
    }
}