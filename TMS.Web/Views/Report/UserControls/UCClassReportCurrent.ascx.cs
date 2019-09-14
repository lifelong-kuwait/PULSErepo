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
    public partial class UCClassReportCurrent : System.Web.UI.UserControl
    {
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        public long CurrentCourseCategoryID { get; set; }
        public DateTime ClassReportStartDateFrom;
        public DateTime ClassReportStartDateTo;
        public bool ShowFutureClasses = false;
        public int ClassTypeID { get; set; }
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
                DdlAddMonts_SelectedIndexChanged(null, null);
            }
        }



        protected void TxtFromYear_OnTextChanged(object _Sender, EventArgs _E)
        {
            try
            {
                DdlAddMonts_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {

            }
        }

        protected void TxtToYear_OnTextChanged(object _Sender, EventArgs _E)
        {
            try
            {
                ClassesGetByCourseID();
            }
            catch (Exception ex)
            {

            }
        }


        protected void DdlAddMonts_SelectedIndexChanged(object Sender, EventArgs e)
        {
            try
            {
                if (TxtFromYear.Text.Length > 0)// && TxtToYear.Text.Length > 0)
                {
                    DateTime selectedFromMonth = UtilityFunctions.MapValue<DateTime>(TxtFromYear.Text, typeof(DateTime));
                    //if (DdlAddMonths.SelectedIndex > 0)
                    {
                        selectedFromMonth = selectedFromMonth.AddMonths(UtilityFunctions.MapValue<int>(DdlAddMonths.SelectedValue, typeof(int)));
                        TxtToYear.Text = selectedFromMonth.ToString("MM/dd/yyyy");
                    }
                    ClassesGetByCourseID();
                }
            }
            catch (Exception ex)
            {

            }

        }
        protected void DdlCourseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClassesGetByCourseID();
            }
            catch (Exception ex)
            {

            }


        }

        protected void DdlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //generateCalander();

                //ShowHideControlsForPrinter();
            }
            catch (Exception Ex)
            {

            }

        }

        /// <summary>
        /// <para>Description:
        /// This Method will get Classes of Course by CourseID and Rebind Class DropDown</para> 
        /// <para>Created By: M.Ishaq </para> 
        /// <para>Created Date: 2/26/2019 </para> 
        private void ClassesGetByCourseID()
        {
            try
            {
                if (DdlCourseCategory.SelectedIndex > 0 && TxtFromYear.Text.Length > 0 && TxtToYear.Text.Length > 0)
                {
                    DateTime Fromyear = UtilityFunctions.MapValue<DateTime>(TxtFromYear.Text, typeof(DateTime));
                    DateTime Toyear = UtilityFunctions.MapValue<DateTime>(TxtToYear.Text, typeof(DateTime));
                    long CompanyId = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);

                    CurrentCourseCategoryID = UtilityFunctions.MapValue<long>(DdlCourseCategory.SelectedValue, typeof(long));
                    ClassReportStartDateFrom = Fromyear;// new DateTime(Fromyear, UtilityFunctions.MapValue<int>(TxtFromYear, typeof(int)), 1);
                    ClassReportStartDateTo = Toyear;// new DateTime(Toyear, UtilityFunctions.MapValue<int>(TxtFromYear, typeof(int)), 1);
                    ShowFutureClasses = false;
                    DataTable dt = _PersonBAL.ClassFutureReport(CurrentCourseCategoryID, ClassReportStartDateFrom, ClassReportStartDateTo, ShowFutureClasses, ClassTypeID, CompanyId);
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_ClassReport.rdlc");
                    //  DataSet ds = GetTrainerDetailsForReports;
                    ReportDataSource datasource = new ReportDataSource("DS_ClassReportByCourseCategoryID", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {
                    //BindDropDowns();
                    //   UCReport.ClearReport();
                }
            }
            catch (Exception Ex)
            {

            }
        }

        /// <summary>
        /// <para>Description:
        /// This Method will Bind all DropDowns of Control</para> 
        /// <para>Created By: M.Ishaq </para> 
        /// <para>Created Date: 2/26/2019 </para> 
        /// </summary>
        private void BindDropDowns()
        {
            try
            {
                //UIUtilities.FillDropDownWithYears(DdlFromYear, 5, 5, true);
                //UIUtilities.FillDropDownWithYears(DdlToYear, 5, 5, true);
                //UIUtilities.GetMyMonthList(DdlFrom, true);
                //UIUtilities.GetMyMonthList(DdlTo, false);
                //DdlTo.SelectedIndex = DdlTo.Items.IndexOf(DdlTo.Items.FindByValue(DateTime.Now.AddMonths(3).Month.ToString()));
                DropDownUtil.FillDropDown(DdlCourseCategory, ddl.GetAllCourseCategories(CurrentCulture, CompanyID), "Text", "Value", "Course Category");
                DdlCourseCategory.Items.Insert(1, new ListItem(" Select All", "0"));
            }
            catch (Exception Ex)
            {

            }
        }
    }
}