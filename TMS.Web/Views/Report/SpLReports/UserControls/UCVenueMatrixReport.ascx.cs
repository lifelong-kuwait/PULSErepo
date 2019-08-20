using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Common.Configuration;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.TMS;
using TMS.Library.Entities.Common.Configuration.Venues;
using TMS.Web.Core;
using System.Security.Principal;
using System.Web.Mvc;
using TMS.Web.Views.Report.UserControls;
using Abp.Extensions;

namespace TMS.Web.Views.Report.SpLReports.UserControls
{
    public partial class UCVenueMatrixReport : System.Web.UI.UserControl
    {

        #region Members

       // private VenueMatrixPresenter _VenuePresenter;
        private long _CurrentVenueID = 0;
        private bool isPermitted;
        private MyColorList _myColorList;
        private List<Color> _Color;
        private long ClassID = 0;
        private bool isNewClass = false;
        private int sessionCount = 0;
        private int totalClass = 0;
        private string sessionName = string.Empty;
        Color randomColor;// = new Color();
        private int rows = 0;
        private static Venues _VenuesGetByID;
        #endregion

        #region Properties

      
        public string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }
        //TMSUser user = new TMSUser();

        //protected TMSUser CurrentUser
        //{
        //    get
        //    {
        //        return new TMSUser(this.User as ClaimsPrincipal);
        //    }
        //}
        public long CurrentVenueID
        {
            get { return _CurrentVenueID; }
            set { _CurrentVenueID = value; }
        }

        public MyColorList MyColorList
        {
            get { return _myColorList ?? (_myColorList = new MyColorList()); }
            set { _myColorList = value; }
        }
      

        public List<Color> myColors
        {
            get { return _Color ?? (_Color = new List<Color>()); }
            set { _Color = value; }
        }

        public static string venueId { get; internal set; }
        public static string startDate { get; internal set; }

        long CompanyID =  Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
        #endregion

        #region Events

        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
                                                   // private readonly IPersonBAL _PersonBAL;
        private static DataSet _GetTrainerDetailsForReports;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
                CurrentVenueID = Convert.ToInt64(venueId);
                // CompanyID = user.CompanyID;
                // BindDropDownlists();
                String str = startDate;
                var words = str.Split(@"/");
               
                if (CurrentVenueID != 0)
                {
                    BindRecords(Convert.ToInt32(words[1]), Convert.ToInt32(words[0]));
                    pnlNoData.Visible = false;
                    pnlReport.Visible = true;
                }
                else
                {
                    pnlNoData.Visible = true;
                    pnlReport.Visible = false;
                }
            }
        }
        protected void gvEvents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[0].Width = 100;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    CreateExtraHeaders(e);
                }
            }
            catch (Exception _Ex)
            {
               // ExceptionHandler.HandleTrainingException(_Ex, "gvEvents_RowDataBound", false);
            }


        }

//        protected void ddlVenues_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            try
//            {
//                CurrentVenueID = ddlVenues.SelectedValue == string.Empty ? 0 : Convert.ToInt64(ddlVenues.SelectedValue);
//                if (CurrentVenueID != 0)
//                {
//                    BindRecords(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
//                    pnlNoData.Visible = false;
//                    pnlReport.Visible = true;
//                }
//                else
//                {
//                    pnlNoData.Visible = true;
//                    pnlReport.Visible = false;
//                }
//        }
//            catch (Exception ex)
//            {
//               // ExceptionHandler.HandleTrainingException(ex, "ddlVenues_SelectedIndexChanged", false);
//            }
//}
        #endregion

        #region Methods
        /// <summary>
        /// <para>Description:
        /// This method will make the chart structure for the Matrix report, will add days of the current 
        /// months in the headers and add times in the first cell it will add Times</para> 
        /// <para>Created By: Tanweer </para> 
        /// <para>Created Date: 9/23/2013 </para> 
        /// </summary>
        /// <param name="year">Year as Int</param>
        /// <param name="month">Month as Int</param>
        private void BindRecords(int year, int month)
        {
            try
            {
                DataTable DataSource = new DataTable();
                DataRow dataRow;

                DataSource.Columns.Add("Time");

                var start = DateTime.Today;
                var clockQuery = from offset in Enumerable.Range(15, 34)
                                 select start.AddMinutes(30 * offset);
                //adding times in the ist column
                foreach (var time in clockQuery)
                {
                    dataRow = DataSource.NewRow();
                    dataRow["Time"] = time.ToString("hh:mm tt");
                    DataSource.Rows.Add(dataRow);
                }

                int days = DateTime.DaysInMonth(year, month);
                //adding days in ist row as columns
                for (int i = 1; i <= days; i++)
                {
                    DataSource.Columns.Add(i.ToString());
                }
                //bind
                gvEvents.DataSource = DataSource;
                gvEvents.DataBind();

                //Highlight Friday
                for (int i = 1; i < gvEvents.HeaderRow.Cells.Count; i++)
                {
                    String header = gvEvents.HeaderRow.Cells[i].Text;
                    DateTime dtDay = new DateTime(year, month, Convert.ToInt32(header));

                    foreach (GridViewRow row in gvEvents.Rows)
                    {
                        if (dtDay.ToString("ddd").Equals("Fri"))
                        {
                            row.Cells[i].BackColor = ColorTranslator.FromHtml("#DCDCDC");
                        }
                    }
                }

                //load Session details from database and draw on report
                DataTable dtDetails = _PersonBAL.GetDataForVenueMatrix(CurrentVenueID);
                foreach (DataRow dRow in dtDetails.Rows)
                {
                    DateTime dtStart = Convert.ToDateTime(dRow["StartTime"]);
                    DateTime dtEnd = Convert.ToDateTime(dRow["EndTime"]);
                    string name = Convert.ToString(dRow["FullName"]);
                    sessionName = Convert.ToString(dRow["SessionName"]);

                    if (Convert.ToInt64(dRow["ClassID"]) != ClassID)
                    {
                        isNewClass = true;
                        sessionCount = 0;
                        ClassID = Convert.ToInt64(dRow["ClassID"]);
                    }
                    sessionCount++;
                    DrawEvents(year, month, dtStart, dtEnd, name);
                    isNewClass = false;
                }

                //bind the colors
                foreach (var item in MyColorList)
                {
                    item.Name = item.Name.Replace("#*#", string.Empty);
                    item.Name = item.Name.Replace("<br>", ", ");

                }

                rptColors.DataSource = MyColorList;
                rptColors.DataBind();
        }
            catch (Exception ex)
            {
              //  ExceptionHandler.HandleTrainingException(ex, "BindRecords", false);
            }
}

        /// <summary>
        /// <para>Description:
        /// This Method loads Venue details from database and draw the plots on the chart for the selected dated, will draw each plot 
        /// in diffrent colors. On the top of the report it will highlight the colors with details.</para> 
        /// <para>Created By: Tanweer </para> 
        /// <para>Created Date: 9/23/2013 </para> 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="eventName"></param>
        private void DrawEvents(int year, int month, DateTime dtStart, DateTime dtEnd, string eventName)
        {
            int StartRowIndex = 0;
            int EndRowIndex = 0;
            int StartColIndex = 0;
            int EndColIndex = 0;
            DateTime dtTemp;

            //get random color
            if (isNewClass)
            {
                randomColor = UtilityFunctions.GetRandomColor(myColors);
                myColors.Add(randomColor);
            }
            string t = string.Empty;
            try
            {
                foreach (GridViewRow row in gvEvents.Rows)
                {
                    t = row.Cells[0].Text;

                    for (int i = 0; i < gvEvents.HeaderRow.Cells.Count; i++)
                    {
                        string h = gvEvents.HeaderRow.Cells[i].Text;
                        if (i > 0)
                        {
                            string day = h;
                            dtTemp = new DateTime(year, month, Convert.ToInt32(day));
                            string tempStr = dtTemp.ToShortDateString() + " " + t;
                            dtTemp = Convert.ToDateTime(tempStr);

                            if (dtTemp.Date >= dtStart.Date && dtTemp.Date <= dtEnd.Date)
                            {
                                if (dtTemp.TimeOfDay >= dtStart.TimeOfDay && dtTemp.TimeOfDay <= dtEnd.TimeOfDay)
                                {
                                    //add to list
                                    if (isNewClass)
                                    {
                                        if (MyColorList.Where(x => x.Color == ColorTranslator.ToHtml(randomColor)).Count() == 0)
                                        {
                                            MyColorList.Add(new MyColor { Name = eventName + "##", Color = ColorTranslator.ToHtml(randomColor) });
                                            totalClass++;
                                        }
                                    }
                                    MyColorList[totalClass - 1].Name = MyColorList[totalClass - 1].Name.Replace("##", "Total session(s): #*#" + sessionCount);
                                    string temp = MyColorList[totalClass - 1].Name;
                                    temp = temp.Remove(temp.IndexOf("#*#"));
                                    MyColorList[totalClass - 1].Name = temp + "#*#" + sessionCount;

                                    row.Cells[i].BackColor = randomColor;
                                    row.Cells[i].ToolTip = (eventName + "<br>" + sessionName).Replace("<br>", "\n") + "\n(" + dtStart + " to " + dtEnd + ")";
                                    row.Cells[i].Style.Add("cursor", "pointer");

                                    if (StartRowIndex == 0) StartRowIndex = row.RowIndex;
                                    if (StartColIndex == 0) StartColIndex = i;
                                    EndRowIndex = row.RowIndex;
                                    EndColIndex = i;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              //  ExceptionHandler.HandleTrainingException(ex, "DrawEvents", false);
            }
            //colspan and rowspan
            try
            {
                foreach (GridViewRow trow in gvEvents.Rows)
                {
                    if (trow.RowIndex >= StartRowIndex && trow.RowIndex <= EndRowIndex)
                    {
                        for (int i = 0; i < trow.Cells.Count; i++)
                        {
                            if (i >= StartColIndex && i <= EndColIndex)
                            {
                                if (trow.RowIndex == StartRowIndex && i == StartColIndex)
                                {
                                    continue;
                                }
                                trow.Cells[i].Visible = false;
                            }
                        }
                    }
                }
                gvEvents.Rows[StartRowIndex].Cells[StartColIndex].RowSpan = EndRowIndex - StartRowIndex + 1;
                gvEvents.Rows[StartRowIndex].Cells[StartColIndex].ColumnSpan = EndColIndex - StartColIndex + 1;
                // gvEvents.Rows[StartRowIndex].Cells[StartColIndex].Text = eventName;
                //gvEvents.Rows[StartRowIndex].Cells[StartColIndex].HorizontalAlign = HorizontalAlign.Center;
            }
            catch (Exception ex)
            {
              //  ExceptionHandler.HandleTrainingException(ex, "DrawEvents", false);
            }
        }

        /// <summary>
        /// <para>Description:
        /// Loads Venues from database, add Years and Months in the dropdownlist.</para> 
        /// <para>Created By: Tanweer </para> 
        /// <para>Created Date: 9/23/2013 </para> 
        /// </summary>
        //private void BindDropDownlists()
        //{
        //    //try
        //    //{
        //    //  DropDownUtil.FillDropDown(ddlVenues, ddl.VenueDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Venue");
        //        DropDownUtil.FillDropDown(ddlVenues, ddl.VenueDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Venue");

        //        UtilityFunctions.GetMyMonthList(ddlMonth, true);
        //        UtilityFunctions.FillDropDownWithYears(ddlYear, 3, 6, true);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //  //  ExceptionHandler.HandleTrainingException(ex, "BindDropDownlists", false);
        //    //}
        //}


        //public  Venues CurrentVenue
        //{
        //    get
        //    {
        //        if (_VenuesGetByID == null)
        //        {
        //            _VenuesGetByID = _PersonBAL.GetByID(ddlVenues.SelectedValue);
        //        }
        //        return _VenuesGetByID;
        //    }
        //    set { _VenuesGetByID = value; }
        //}


        /// <summary>
        /// <para>Description:
        /// This method creates Weeks and Day Names header for the Matrix</para> 
        /// <para>Created By: Tanweer </para> 
        /// <para>Created Date: 9/23/2013 </para> 
        /// </summary>
        /// <param name="e">GridViewRowEventArgs</param>
        private void CreateExtraHeaders(GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                string VenueCode = string.Empty;

                if (venueId !=null)
                {
                 //   AppContext.CurrentVenue = null;
                 //   AppContext.CurrentVenueID = UtilityFunctions.MapValue<long>(ddlVenues.SelectedValue, typeof(long));
                 //   VenueCode = AppContext.CurrentVenue.VenueCodeID;
                }

                TableCell cell = new TableCell
                {
                    ColumnSpan = 1,
                    HorizontalAlign = HorizontalAlign.Center,
                    Text = "<b>" + VenueCode + "</b>"
                };
                row.Cells.Add(cell);
                String str = startDate;
                var words = str.Split(@"/");
              
                int year = Convert.ToInt32(words[1]);
                int month = Convert.ToInt32(words[0]);

                int days = DateTime.DaysInMonth(year, month);
                for (int i = 1; i <= days; i++)
                {
                    string day = (new DateTime(year, month, i)).ToString("ddd");
                    cell = new TableCell
                    {
                        ColumnSpan = 1,
                        HorizontalAlign = HorizontalAlign.Center,
                        Text = "<b>" + day + "</b>"
                    };
                    row.Cells.Add(cell);
                }
                e.Row.Parent.Controls.AddAt(0, row);

                //*****************

                row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                cell = new TableCell
                {
                    ColumnSpan = 1,
                    HorizontalAlign = HorizontalAlign.Center
                };
                row.Cells.Add(cell);

                cell = new TableCell
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 7,
                    Text = "<b>Week 1</b>"
                };
                row.Cells.Add(cell);

                cell = new TableCell
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 7,
                    Text = "<b>Week 2</b>"
                };
                row.Cells.Add(cell);

                cell = new TableCell
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 7,
                    Text = "<b>Week 3</b>"
                };
                row.Cells.Add(cell);

                cell = new TableCell
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 7,
                    Text = "<b>Week 4</b>"
                };
                row.Cells.Add(cell);

                e.Row.Parent.Controls.AddAt(0, row);
            }
            catch (Exception ex)
            {
              //  ExceptionHandler.HandleTrainingException(ex, "CreateExtraHeaders", false);
            }
        }

        #endregion
    }

    //public class MyColor
    //{
    //    public string Name { get; set; }
    //    public string Color { get; set; }
    //}

    /// <summary>
    /// <para>Description:
    /// Collection of MyColor Class</para> 
    /// <para>Created By: Tanweer </para> 
    /// <para>Created Date: 9/23/2013 </para> 
    /// </summary>
    public class MyColorList : List<MyColor>
    {

    }
}
