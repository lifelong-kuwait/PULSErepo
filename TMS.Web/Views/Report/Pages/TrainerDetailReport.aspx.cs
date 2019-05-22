using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.Interfaces.TMS;
using TMS.Web.Controllers;

namespace TMS.Web.Views.Report.Pages
{

    public partial class TrainerDetailReport : System.Web.UI.Page
    {
        //TMSControllerBase CurrentUser = new TMSControllerBase();
        //public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
        //private readonly IPersonBAL _PersonBAL;
        //private static DataSet _GetTrainerDetailsForReports;

        protected void Page_Load(object sender, EventArgs e)
        {
           // BindDropDowns();
        }

        //public TrainerDetailReport(IDDLBAL ObjDDLBAL, IPersonBAL person)
        //{
            
        //    _objIDDLBAL = ObjDDLBAL;
        //    _PersonBAL = person;
           
        //}

        //private void BindDropDowns()
        //{
        //    try
        //    {
        //       // _objIDDLBAL.TrainerDDLBAL(CurrentCulture,CurrentUser.CompanyID);
        //       // _objIDDLBAL.ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID);
        //      //  _objIDDLBAL.CourseDDLBAL(CurrentCulture, CurrentUser.CompanyID);
        //        //  UtilityFunctions.FillDropDown(DdlClass, AppContext.TranClasses, "ClassTitle", "ID", "Class");
        //      //  UtilityFunctions.FillDropDown(DdlCourse, AppContext.CoursesAll, "Name", "ID", "Course");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClassesGetByCourseID();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    // AppContext.TimeTableClassID = null;
        //    // AppContext.TimeTableCourseID = UtilityFunctions.MapValue<Int64>(DdlCourse.SelectedValue, typeof(long)); ;

        //    // LoadClassDetailReport();

        //}
        //protected void DdlClass_SelectedIndexChanged(object Sender, EventArgs e)
        //{
        //    try
        //    {
        //        TrainerGetbyClassID();
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}

        //protected void DdlTrainer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (DdlTrainer.SelectedIndex > 0)
        //        { LoadTraineeDetailReport(); }
        //        else if (DdlClass.SelectedIndex > 0)
        //        { LoadTraineeDetailReport(); }
        //        else
        //        {
        //            //ReportViewer1.ClearReport();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}
        //private void ClassesGetByCourseID()
        //{
        //    try
        //    {
        //        if (DdlCourse.SelectedIndex > 0)
        //        {
        //         //   _objIDDLBAL.Course_ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(DdlCourse.SelectedValue));
        //        }
        //        else
        //        {
        //            BindDropDowns();
        //           // UCReport.ClearReport();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        //public  DataSet GetTrainerDetailsForReports
        //{
        //    get
        //    {
        //        return _GetTrainerDetailsForReports ??
        //               (_GetTrainerDetailsForReports =_PersonBAL.GetTrainerDetailsForReports(Convert.ToInt64(DdlClass.SelectedValue),
        //                       Convert.ToInt64(DdlTrainer.SelectedValue)));
        //    }
        //    set { _GetTrainerDetailsForReports = value; }
        //}
        //private void LoadTraineeDetailReport()
        //{
        //    try
        //    {
        //        //  btnPrint.Visible = true;
        //        DataSet ds = new DataSet();
        //         ds = GetTrainerDetailsForReports;
        //        //ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //        //     ds= "Tran_Person_GetTrainerDetailReport";
        //        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Tran_TrainerDetailReport.rdlc");
        //        //ReportDataSource datasource = new ReportDataSource("");
        //        //ReportViewer1.LocalReport.DataSources.Clear();
        //        //ReportViewer1.LocalReport.DataSources.Add(datasource);


        //      //  DataTable dtReportData = "yourdata source"

        //       ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportDataSource RDS1 = new ReportDataSource("Tran_Person_GetTrainerDetailReport", ds);
        //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //        ReportViewer1.LocalReport.EnableExternalImages = true;
        //        ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Report/Tran_TrainerDetailReport.rdlc";
        //        ReportViewer1.LocalReport.DataSources.Add(RDS1);

        //        //check for Print option
        //        //  UCReport.IsPrintable = canPrint;

        //        //ReportViewer1.DynamicReportDataSource = ds;

        //        //UCReport.DynamicDataSetName = "Tran_Person_GetTrainerDetailReport";
        //        //UCReport.DynamicReportPath = "~/Reports/Tran_TrainerDetailReport.rdlc";
        //        //UCReport.LoadReport();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// <para>Description:
        ///// This Method will get Trainer of Class by ClassID and Rebind Venues DropDown</para> 
        ///// <para>Created By: Majid ali </para> 
        ///// <para>Created Date: 9/26/2013 </para> 
        ///// </summary>
        //private void TrainerGetbyClassID()
        //{
        //    if (DdlClass.SelectedIndex > 0)
        //    {
        //      //  _objIDDLBAL.Class_TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(DdlClass.SelectedValue));
        //        LoadTraineeDetailReport();
        //    }
        //    else
        //    {
        //        BindDropDowns();
        //        //UCReport.ClearReport();
        //    }
        //}
    }
}