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
using TMS.Business.TMS;

namespace TMS.Web.Views.Report.UserControls
{
    public partial class UCDailyUtilizationReport : System.Web.UI.UserControl
    {
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        public string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }
        long CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
              //  BindDropDowns();
            }
        }


        protected void BtnView_OnClick(object sender, EventArgs e)
        {
            LoadClassDetailReport();
        }

        private void LoadClassDetailReport()
        {
            CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
            DateTime day = Convert.ToDateTime(TxtStartDate.Text);
            int VenueType = Convert.ToInt32(ddlVenueType.SelectedValue);
            DataTable dt = _PersonBAL.DailyUtilizationReport(day, VenueType, CompanyID);
            ReportViewerMasterReport.ProcessingMode = ProcessingMode.Local;
            ReportViewerMasterReport.LocalReport.ReportPath = Server.MapPath("~/Report/DailyUtilizationReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("DailyUtilizationReport", dt);
            ReportViewerMasterReport.LocalReport.DataSources.Clear();
            ReportViewerMasterReport.LocalReport.DataSources.Add(datasource);
            ReportViewerMasterReport.LocalReport.Refresh();

        }
    }
}