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
    public partial class UCVenueDetailUtilizationReport : System.Web.UI.UserControl
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
                BindDropDowns();
            }
        }

        private void BindDropDowns()
        {
            try
            {

                DropDownUtil.FillDropDown(ddlVenue, ddl.VenueDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Venue");
                ddlVenue.Items.Insert(1, new ListItem("Common", "0"));
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void TxtStartDate_OnTextChanged(object sender, EventArgs e)
        {
            LoadClassDetailReport();
        }

        protected void BtnView_OnClick(object sender, EventArgs e)
        {
            LoadClassDetailReport();
        }

        private void LoadClassDetailReport()
        {
            DateTime Startday = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Endday = Convert.ToDateTime(TxtEndDate.Text);
            long venueid = Convert.ToInt64(ddlVenue.SelectedValue);
            DataTable dt = _PersonBAL.DailyVenueUtalizationReports(Startday, Endday, venueid);
            ReportViewerMasterReport.ProcessingMode = ProcessingMode.Local;
            ReportViewerMasterReport.LocalReport.ReportPath = Server.MapPath("~/Report/WeeklyUtilizationReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("WeeklyUtilizationDataSet", dt);
            ReportViewerMasterReport.LocalReport.DataSources.Clear();
            ReportViewerMasterReport.LocalReport.DataSources.Add(datasource);
            ReportViewerMasterReport.LocalReport.Refresh();

        }
    }
}