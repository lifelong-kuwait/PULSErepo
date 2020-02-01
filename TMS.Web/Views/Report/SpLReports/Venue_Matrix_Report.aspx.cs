using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Web.Views.Report.SpLReports.UserControls;

namespace TMS.Web.Views.Report.SpLReports
{
    public partial class Venue_Matrix_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string venueID = Request.QueryString["Venue"];
            string startDate = Request.QueryString["Date"];
            UserControls.UCVenueMatrixReport.venueId = venueID;
            UserControls.UCVenueMatrixReport.startDate = startDate;
            //VenueMatrixUserControl objTestControl = (VenueMatrixUserControl)Page.FindControl("VenueMatrixUserControl");
            //UserControl com = (UserControl)LoadControl(@"~\Views\Report\SpLReports\UserControls\VenueMatrixUserControl.ascx");
            //  VenueMatrixUserControl.Controls.Add(com);



            //VenueMatrixUserControl.VenueId = venueID;
            //VenueMatrixUserControl.DateMonth = startDate;
            //VenueMatrixUserControl myControl = (VenueMatrixUserControl)Page.LoadControl(@"~\Views\Report\SpLReports\UserControls\VenueMatrixUserControl.ascx");
            //myControl.VenueId = 1;
            //myControl.ItemIndex = 2;
        }
    }
}