using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Common.DDL;
using TMS.Business.TMS;
using TMS.Library.Entities.TMS.Program;

namespace TMS.Web.Views.Report.UserControls
{
    public partial class UCViewAttendanceReport : System.Web.UI.UserControl
    {
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        public static long CurrentClassID { get; set; }
        private  Classes CurrentClass;

        /// <summary>
        ///     <para>Description: Gets or sets the currently manipulated Class</para>
        ///     <para>Created By: Asif </para>
        ///     <para>Created Date: 09/27/2013 </para>
        /// </summary>
        //public static Classes CurrentClass
        //{
        //    get
        //    {
        //        if (_CurrentClass == null && CurrentClassID > 0)
        //        {
        //            _CurrentClass = _PersonBAL.ClassGetByID(CurrentClassID);
        //        }
        //        return _CurrentClass;
        //    }

        //    set { _CurrentClass = value; }
        //}

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

        protected void DdlClass_SelectedIndexChanged(object Sender, EventArgs e)
        {
            try
            {
                if (DdlClass.SelectedIndex <= 0)
                {
                  
                    LblStartDate.Text = string.Empty;
                    LblEndDate.Text = string.Empty;
                }
                else
                {
                   // AppContext.CurrentClass = null;
                     CurrentClassID = UtilityFunctions.MapValue<Int64>(DdlClass.SelectedValue, typeof(Int64));
                     CurrentClass =_PersonBAL.ClassGetByID(CurrentClassID);
                    LblStartDate.Text = UtilityFunctions.GetShortDateString(CurrentClass.StartDate);
                    LblEndDate.Text = UtilityFunctions.GetShortDateString(CurrentClass.EndDate);
                }
            }
            catch (Exception ex)
            {
               
            }


        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LblStartDate.Text = string.Empty;
                LblEndDate.Text = string.Empty;
              //  ResetReport();
                ClassesGetByCourseID();
            }
            catch (Exception ex)
            {
              //  ExceptionHandler.HandleTrainingException(ex, "DdlCourse_SelectedIndexChanged", false);
            }


        }


        protected void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAttendanceReport();
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void TxtWeekStartDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(TxtWeekStartDate.Text);
                TxtWeekEndDate.Text = startDate.AddDays(6).ToShortDateString();
                ParagraphEndDate.Visible = true;
               
            }
            catch (Exception ex)
            {
              
            }
        }

        private void ClassesGetByCourseID()
        {
            try
            {
                if (DdlCourse.SelectedIndex > 0)
                {
                    DropDownUtil.FillDropDown(DdlClass, ddl.Course_ClassDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlCourse.SelectedValue)), "Text", "Value", "Class");
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

        private void BindDropDowns()
        {
            try
            {
               
                DropDownUtil.FillDropDown(DdlCourse, ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
                DropDownUtil.FillDropDown(DdlClass, ddl.ClassDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Class");
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void LoadAttendanceReport()
        {
            long ClassID = Convert.ToInt64(DdlClass.SelectedValue);
            long CourseID = Convert.ToInt64(DdlCourse.SelectedValue);
            DateTime dtStart = UtilityFunctions.MapValue<DateTime>(TxtWeekStartDate.Text, typeof(DateTime));
            DateTime dtEnd = UtilityFunctions.MapValue<DateTime>(TxtWeekEndDate.Text, typeof(DateTime));

            DataTable dt = _PersonBAL.AttendanceReports(CourseID,ClassID, dtStart, dtEnd);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_ViewAttendanceReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("VewTraineeAttendanceReportDataSet", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();



        }
    }
}