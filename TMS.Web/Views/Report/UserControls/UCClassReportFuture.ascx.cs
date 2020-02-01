
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
using TMS.Library;
using static TMS.UtilityFunctions;

namespace TMS.Web.Views.Report.UserControls
{
    public partial class UCClassReportFuture : System.Web.UI.UserControl
    {
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        public  long CurrentCourseCategoryID { get; set; }
        public  DateTime ClassReportStartDateFrom;
        public  DateTime ClassReportStartDateTo;
        public  bool ShowFutureClasses = false;
        public  int ClassTypeID { get; set; }
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

        protected void DdlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //generateCalander();

                //ShowHideControlsForPrinter();
            }
            catch (Exception Ex)
            {
                //ExceptionHandler.HandleTrainingException(Ex, "DdlMonth_SelectedIndexChanged", false);
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
                //ExceptionHandler.HandleTrainingException(ex, "DdlCourseCategory_SelectedIndexChanged", false);
                //UtilityFunctions.ShowMessage(UCMessage, Common.Message.EnumMessageType.Error, "MESSAGE_ERROR_OCCURED");
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
                DropDownUtil.FillDropDown(DdlCourseCategory, ddl.GetAllCourseCategories(CurrentCulture, CompanyID), "Text", "Value", "Course Category");
                DdlCourseCategory.Items.Insert(1, new ListItem(" Select All", "0"));
                UtilityFunctions.FillDropDownListFromEnumCollection(ddlClassType, EnumManager.GetEnumCollection(typeof(ClassType)), true, "Type");
                
            }
            catch (Exception Ex)
            {
                
            }
        }
        private void ClassesGetByCourseID()
        {
            try
            {
                if (DdlCourseCategory.SelectedIndex > 0 && TxtToYear.Text.Length > 0)
                {
                    DateTime Fromyear = UtilityFunctions.MapValue<DateTime>(TxtFromYear.Text, typeof(DateTime));
                    DateTime Toyear = new DateTime(2099, 12, 31);// UtilityFunctions.MapValue<DateTime>(TxtToYear.Text, typeof(DateTime));

                      CurrentCourseCategoryID = UtilityFunctions.MapValue<long>(DdlCourseCategory.SelectedValue, typeof(long));
                     ClassReportStartDateFrom = Fromyear;// new DateTime(Fromyear, UtilityFunctions.MapValue<int>(TxtFromYear, typeof(int)), 1);
                     ClassReportStartDateTo = Toyear;// new DateTime(Toyear, UtilityFunctions.MapValue<int>(TxtFromYear, typeof(int)), 1);
                     ShowFutureClasses = true;
                      ClassTypeID = Convert.ToInt32(ddlClassType.SelectedValue);

                    long CompanyId = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);



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
                  //  UCReport.ClearReport();
                }
            }
            catch (Exception Ex)
            {
               
            }
        }

    }
}