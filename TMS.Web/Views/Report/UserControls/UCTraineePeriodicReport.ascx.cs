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
    public partial class UCTraineePeriodicReport : System.Web.UI.UserControl
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

        protected void TxtEndDate_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime StartDate = Convert.ToDateTime(TxtStartDate.Text);
                DateTime EndDate = Convert.ToDateTime(TxtEndDate.Text);
                DataTable ObjCourses = _PersonBAL.GetCourseFromTimeSpan(StartDate, EndDate);
                //AppContext.CoursesAll = null;
                DropDownUtil.FillDropDown(DdlCourseID, ObjCourses, "Text", "Value", "Course");
            }
            catch (Exception ex)
            {
               // ExceptionHandler.HandleTrainingException(ex, "BtnView_Click", false);
            }
        }
        private void BindDropDowns()
        {
            try
            {
              
                DropDownUtil.FillDropDown(DdlCourseID, ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadClassDetailReport();
            }
            catch (Exception ex)
            {
               // ExceptionHandler.HandleTrainingException(ex, "BtnView_Click", false);
            }
        }

        private void LoadClassDetailReport()
        {
          long  CourseID = UtilityFunctions.MapValue<long>(DdlCourseID.SelectedValue, typeof(long));
            DateTime dtStart = UtilityFunctions.MapValue<DateTime>(TxtStartDate.Text, typeof(DateTime));
            DateTime dtEnd = UtilityFunctions.MapValue<DateTime>(TxtEndDate.Text, typeof(DateTime));
            DataTable dt = _PersonBAL.GetTraineePeriodicData(dtStart, dtEnd, CourseID);

           
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_ViewTraineePeriodicReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("TraineePeriodicReport", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();


            ////  DataSet ds = GetTrainerDetailsForReports;

            //  ReportViewer1.LocalReport.DataSources.Clear();
            //  ReportDataSource RDS1 = new ReportDataSource("OccupancyReport", ds.Tables[0]);
            //  ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //  ReportViewer1.LocalReport.EnableExternalImages = true;
            //  ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Report/Tran_VenueOccupancyReport.rdlc";
            //  ReportViewer1.LocalReport.DataSources.Clear();
            //  ReportViewer1.LocalReport.DataSources.Add(RDS1);


        }



    }
}