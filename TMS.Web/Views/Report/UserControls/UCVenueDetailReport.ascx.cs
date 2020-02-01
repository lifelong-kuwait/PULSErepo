using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.Interfaces.TMS;
using TMS.Web.Controllers;
using Microsoft.Reporting.WebForms;
using Castle.MicroKernel;
using TMS.Business.Common.DDL;
using TMS.Business.TMS;
using System.Globalization;
using TMS.Web.Core;


namespace TMS.Web.Views.Report.UserControls
{
    public partial class UCVenueDetailReport : System.Web.UI.UserControl 
    {
        

        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
                                                   // private readonly IPersonBAL _PersonBAL;
        private static DataTable _GetTrainerDetailsForReports;
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
                DropDownUtil.FillDropDown(DdlVenue, ddl.VenueDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Venue");
                DropDownUtil.FillDropDown(DdlCourse, ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
                DropDownUtil.FillDropDown(DdlClass, ddl.ClassDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Class");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClassesGetByCourseID();
            }
            catch (Exception)
            {
            }
            // AppContext.TimeTableClassID = null;
            // AppContext.TimeTableCourseID = UtilityFunctions.MapValue<Int64>(DdlCourse.SelectedValue, typeof(long)); ;

            // LoadClassDetailReport();

        }
        protected void DdlClass_SelectedIndexChanged(object Sender, EventArgs e)
        {
            try
            {
                TrainerGetbyClassID();
            }
            catch (Exception)
            {
            }

        }

        protected void DdlVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlVenue.SelectedIndex > 0)
                { LoadTraineeDetailReport(); }
                else if (DdlClass.SelectedIndex > 0)
                { LoadTraineeDetailReport(); }
                else
                {
                 //   ReportViewer1.ClearReport();
                }
            }
            catch (Exception)
            {
            }

        }
        private void ClassesGetByCourseID()
        {
            try
            {
                if (DdlCourse.SelectedIndex > 0)
                {
                    DropDownUtil.FillDropDown(DdlClass, ddl.Course_ClassDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlCourse.SelectedValue),0), "Text", "Value", "Class");
                    //_objIDDLBAL.Course_ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(DdlCourse.SelectedValue));
                }
                else
                {
                    BindDropDowns();
                    // UCReport.ClearReport();
                }
            }
            catch (Exception)
            {

            }
        }
     
        private void LoadTraineeDetailReport()
        {
            long ClassID = Convert.ToInt64(DdlClass.SelectedValue);
            long VenueID = Convert.ToInt64(DdlVenue.SelectedValue);

            DataTable dt = _PersonBAL.GetVenueDetailsForReports(ClassID, VenueID);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_VenueDetailReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("Tran_Venues_GetVenueDetailsForReport", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();



        }
        /// <summary>
        /// <para>Description:
        /// This Method will get Trainer of Class by ClassID and Rebind Venues DropDown</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/26/2013 </para> 
        /// </summary>
        private void TrainerGetbyClassID()
        {
            if (DdlClass.SelectedIndex > 0)
            {
                DropDownUtil.FillDropDown(DdlVenue, ddl.Class_VenueDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlClass.SelectedValue)), "Text", "Value", "Venue");

                // _objIDDLBAL.Class_TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(DdlClass.SelectedValue));
                //  LoadTraineeDetailReport();
            }
            else
            {
                BindDropDowns();
                //UCReport.ClearReport();
            }
        }
    }
}