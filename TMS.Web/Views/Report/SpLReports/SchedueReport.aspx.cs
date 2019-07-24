using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMS.Web.Views.Report.SpLReports
{
    public partial class SchedueReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ClassID = Request.QueryString["Class"];
            string CourseID = Request.QueryString["Course"]; 
            string startDate = Request.QueryString["Date"];
            UserControls.UCViewClassTimeTable.ClassIDCall = ClassID;
            UserControls.UCViewClassTimeTable.CourseIDCall = CourseID;
            UserControls.UCViewClassTimeTable.startDate = startDate;
            UserControls.UCViewClassTimeTable.CompanyIDCall = HttpContext.Current.Session["CompanyID"];

        }
    }
}