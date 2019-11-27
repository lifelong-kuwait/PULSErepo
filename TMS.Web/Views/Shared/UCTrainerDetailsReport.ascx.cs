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
using TMS.Library.Entities.TMS.Program;

namespace TMS.Web.Views.Shared
{
    public partial class UCTrainerDetailsReport :  System.Web.UI.UserControl
    {
        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
       // private readonly IPersonBAL _PersonBAL;
        private static DataSet _GetTrainerDetailsForReports;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        public string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }
        long CompanyID = 0;// Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);

                BindDropDowns();
            }
        }
       
        public long ClassID { get; set; }
        public long TrainerID { get; set; }

        private void BindDropDowns()
        {
            try
            {
                DropDownUtil.FillDropDown(DdlTrainer,ddl.TrainerDDLBAL(CurrentCulture,CompanyID), "Text", "Value", "Trainer");
           //     ddl.ClassDDLBAL(CurrentCulture, CompanyID);
                DropDownUtil.FillDropDown(DdlCourse,ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
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

        protected void DdlTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTraineeDetailReport();
            //  try
          //   {
          //if (DdlTrainer.SelectedIndex > 0)
          //{ LoadTraineeDetailReport(); }
          //else if (DdlClass.SelectedIndex > 0)
          //{ LoadTraineeDetailReport(); }
          //else
          //{
          //    //ReportViewer1.ClearReport();
          //}
          // }
          //catch (Exception)
          //{
          //}

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
        //public DataSet GetTrainerDetailsForReports
        //{
        //    //get
        //    //{
        //    //    return _GetTrainerDetailsForReports ??
        //    //           (_GetTrainerDetailsForReports = _PersonBAL.GetTrainerDetailsForReports(Convert.ToInt64(DdlClass.SelectedValue),
        //    //                   Convert.ToInt64(DdlTrainer.SelectedValue)));
        //    //}
        //    //set { _GetTrainerDetailsForReports = value; }
        //}
        private void LoadTraineeDetailReport()
        {
            TrainerID = Convert.ToInt64(DdlTrainer.SelectedValue);
            ClassID = Convert.ToInt64(DdlClass.SelectedValue);
          
            DataTable dt = _PersonBAL.GetTrainerDetailsForReports(ClassID,TrainerID );
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_TrainerDetailReport.rdlc");
            //  DataSet ds = GetTrainerDetailsForReports;
            ReportDataSource datasource = new ReportDataSource("Tran_Person_GetTrainerDetailReport", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();


            //ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportDataSource RDS1 = new ReportDataSource("Tran_Person_GetTrainerDetailReport", ds.Tables[0]);
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //    ReportViewer1.LocalReport.EnableExternalImages = true;
            //    ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Report/Tran_TrainerDetailReport.rdlc";
            //   ReportViewer1.LocalReport.DataSources.Clear();
            //   ReportViewer1.LocalReport.DataSources.Add(RDS1);

               
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
                DropDownUtil.FillDropDown(DdlTrainer, ddl.Class_TrainerDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlClass.SelectedValue)), "Text", "Value", "Trainer");

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