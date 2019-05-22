using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Common.DDL;
using TMS.Business.TMS;
using TMS.Library;
using TMS.Library.Entities.TMS.Program;
using static TMS.UtilityFunctions;

namespace TMS.Web.Views.Report.UserControls
{
    public partial class UCViewClassTimeTable : System.Web.UI.UserControl
    {
        private bool isPermitted = false;
        private List<Color> _Color;
        private Color randomColor;
        public List<Color> myColors
        {
            get { return _Color ?? (_Color = new List<Color>()); }
            set { _Color = value; }
        }
        private MyColorLists _myColorList;
        public MyColorLists MyColorList
        {
            get { return _myColorList ?? (_myColorList = new MyColorLists()); }
            set { _myColorList = value; }
        }
        public  Classes CurrentClass;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _PersonBAL = new PersonBAL();

        long CompanyID = 0;
        public string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);

                BindDropDowns();
               
            }
        }


        protected void DdlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generateCalander();

                ShowHideControlsForPrinter();
            }
            catch (Exception Ex)
            {
              //  ExceptionHandler.HandleTrainingException(Ex, "DdlMonth_SelectedIndexChanged", false);
            }

        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LblClassDuration.Text = string.Empty;
              //  AppContext.TimeTableClassID = null;
              //  AppContext.TimeTableCourseID = UtilityFunctions.MapValue<Int64>(DdlCourse.SelectedValue, typeof(long)); ;
                ClassesGetByCourseID();
                generateCalander();

                ShowHideControlsForPrinter();
            }
            catch (Exception Ex)
            {
              //  ExceptionHandler.HandleTrainingException(Ex, "DdlCourse_SelectedIndexChanged", false);
            }

        }
        protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlClass.SelectedIndex > 0)
                    ClassDuration(UtilityFunctions.MapValue<Int64>(DdlClass.SelectedValue, typeof(long)));
              //  AppContext.TimeTableClassID = UtilityFunctions.MapValue<Int64>(DdlClass.SelectedValue, typeof(long));
              //  AppContext.TimeTableCourseID = null;
                generateCalander();

                ShowHideControlsForPrinter();
            }
            catch (Exception Ex)
            {
             //   ExceptionHandler.HandleTrainingException(Ex, "DdlClass_SelectedIndexChanged", false);
            }

        }




        private void ShowHideControlsForPrinter()
        {
            try
            {
                if (DdlClass.SelectedIndex > 0)
                {
                    LblClassName.Text = DdlClass.SelectedItem.Text;
                    LblClassName.Visible = DdlClass.SelectedIndex > 0;
                }
                if (DdlCourse.SelectedIndex > 0)
                {
                    LblCourseName.Text = DdlCourse.SelectedItem.Text;
                    LblCourseName.Visible = DdlCourse.SelectedIndex > 0;
                }
                LblCalenderSpan.Text = DdlYear.SelectedItem.Text + " - " + DdlMonth.SelectedItem.Text;
            }
            catch (Exception Ex)
            {
              //  ExceptionHandler.HandleTrainingException(Ex, "ShowHideControlsForPrinter", false);
            }
        }
        private void BindDropDowns()
        {
            try
            {

               
            
                DropDownUtil.FillDropDown(DdlCourse, ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
                DropDownUtil.FillDropDown(DdlClass, ddl.ClassDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Class");
                UtilityFunctions.FillDropDownWithYears(DdlYear, 5, 20, false);
                UtilityFunctions.FillDropDownListFromEnumCollection(DdlMonth, EnumManager.GetEnumCollection(typeof(Month)), true, "Month");
                DdlYear.SelectedValue = DdlYear.Items.FindByText(UtilityFunctions.GetCurrentDateTime().Year.ToString()).ToString();
                DdlMonth.SelectedValue = UtilityFunctions.GetCurrentDateTime().Month.ToString();
                generateCalander();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// <para>Description:
        /// This Method will get Classes of Course by CourseID and Rebind Class DropDown</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/26/2013 </para> 
        /// </summary>
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

        /// <summary>
        /// <para>Description:
        /// This Method will Bind Timetable of Sessions</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/26/2013 </para> 
        /// </summary>
        protected void generateCalander()
        {
            CalendarContainer.Controls.Clear();
            try
            {
                long? ClassID = 0;
                long? CourseID = 0;
                if (DdlClass.SelectedIndex <= 0)
                {
                    ClassID = 0;
                }
                else
                {
                    ClassID= Convert.ToInt64(DdlClass.SelectedValue);
                }

                if (DdlCourse.SelectedIndex <= 0)
                {
                    CourseID = 0;
                }
                else
                {
                    CourseID = Convert.ToInt64(DdlCourse.SelectedValue);
                }
                    
               
                DataTable list = _PersonBAL.SessionsByCourseAndClassID(ClassID,CourseID,CompanyID );
                Table tb = new Table();

                TableHeaderCell thSunday = new TableHeaderCell();
                thSunday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Sunday);
                thSunday.Width = 137;

                TableHeaderCell thMonday = new TableHeaderCell();
                thMonday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Monday);
                thMonday.Width = 137;

                TableHeaderCell thTuesday = new TableHeaderCell();
                thTuesday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Tuesday);
                thTuesday.Width = 137;

                TableHeaderCell thWednesday = new TableHeaderCell();
                thWednesday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Wednesday);
                thWednesday.Width = 137;

                TableHeaderCell thThursday = new TableHeaderCell();
                thThursday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Thursday);
                thThursday.Width = 137;

                TableHeaderCell thFriday = new TableHeaderCell();
                thFriday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Friday);
                thFriday.Width = 137;

                TableHeaderCell thSaturday = new TableHeaderCell();
                thSaturday.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Days), Days.Days_Saturday);
                thSaturday.Width = 137;

                TableHeaderRow th = new TableHeaderRow();
                th.Cells.Add(thSunday);
                th.Cells.Add(thMonday);
                th.Cells.Add(thTuesday);
                th.Cells.Add(thWednesday);
                th.Cells.Add(thThursday);
                th.Cells.Add(thFriday);
                th.Cells.Add(thSaturday);
                tb.Rows.Add(th);

                for (int i = 0; i < 6; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < 7; j++)
                    {
                        TableCell tc1 = new TableCell();
                        tc1.Height = 137;
                        tr.Cells.Add(tc1);

                    }
                    tr.Height = 60;
                    tb.GridLines = GridLines.Both;
                    tb.CssClass = "timetable";
                    tb.Rows.Add(tr);

                }
                CalendarContainer.Controls.Add(tb);
                //***********************************************

                DateTime dt = new DateTime(Convert.ToInt32(DdlYear.SelectedValue), Convert.ToInt32(DdlMonth.SelectedValue), 1);
                //int fDay = (int)dt.DayOfWeek + 1;
                int fDay = (int)dt.DayOfWeek;
                int totalDaysInMonth = DateTime.DaysInMonth(Convert.ToInt32(DdlYear.SelectedValue), Convert.ToInt32(DdlMonth.SelectedValue));
                int day = 0;
                int indexOfCalender = 0;
                int nextMontDays = 0;
                int TotalDaysInlastMonth = 0;
                int month = int.Parse(DdlMonth.SelectedValue);
                int year = int.Parse(DdlYear.SelectedValue);
                int LnkBtnID = 0;
                if (Convert.ToInt32(DdlMonth.SelectedValue) == 1)
                {
                    TotalDaysInlastMonth = DateTime.DaysInMonth(Convert.ToInt32(DdlYear.SelectedValue) - 1, 12);
                }
                else
                {
                    TotalDaysInlastMonth = DateTime.DaysInMonth(Convert.ToInt32(DdlYear.SelectedValue), Convert.ToInt32(DdlMonth.SelectedValue) - 1);
                }
                int count = tb.Rows.Count * tb.Rows[0].Cells.Count;

                for (int dayOfWeek = 1; dayOfWeek < 7; dayOfWeek++)
                {
                    for (int weekOfMonth = 0; weekOfMonth < 7; weekOfMonth++)
                    {
                        ++indexOfCalender;

                        if (indexOfCalender == (DateTime.Now.Day + fDay) && (DdlMonth.SelectedValue.ToString() == DateTime.Now.Month.ToString()) && (DdlYear.SelectedValue.ToString() == DateTime.Now.Year.ToString()))
                            tb.Rows[dayOfWeek].Cells[weekOfMonth].Style.Add("background-color", "LimeGreen");// = System.Drawing.Color.LimeGreen;
                       

                        if (indexOfCalender <= fDay && day < totalDaysInMonth)
                        {
                            LinkButton linkbutton = new LinkButton();
                            TotalDaysInlastMonth++;
                            linkbutton.Text = (TotalDaysInlastMonth - fDay).ToString() + "<br/>";
                            tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(linkbutton);
                            linkbutton.Enabled = false;
                            int TempYear = month == 1 ? (year - 1) : year;
                            int TempMonth = month == 1 ? 12 : month - 1;
                            int TempDay = (TotalDaysInlastMonth - fDay);
                            SetControlsInCells(list, indexOfCalender, TempYear, TempMonth, TempDay, linkbutton, LnkBtnID, tb, dayOfWeek, weekOfMonth);

                        }
                        else if (indexOfCalender > fDay && day < totalDaysInMonth)
                        {
                            ++day;
                            LinkButton linkbutton = new LinkButton();
                            if (indexOfCalender - 1 == fDay)
                                linkbutton.Text = DdlMonth.SelectedItem.Text.ToString() + "<br/> " + day.ToString() + "<br/>";
                            else
                                linkbutton.Text = day.ToString() + "<br/>";

                            tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(linkbutton);
                            linkbutton.Enabled = false;

                            SetControlsInCells(list, indexOfCalender, year, month, day, linkbutton, LnkBtnID, tb, dayOfWeek, weekOfMonth);
                        }
                        else if (indexOfCalender > totalDaysInMonth)
                        {
                            ++nextMontDays;
                            LinkButton linkbutton = new LinkButton();
                            if (nextMontDays == 1)
                            {
                                if (DdlMonth.SelectedValue == "12")
                                    linkbutton.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Month), Month.Month_January) + "<br/>" + nextMontDays.ToString() + "<br/>";
                                else
                                {
                                    if (DdlMonth.Items.Count > DdlMonth.SelectedIndex + 1)
                                        linkbutton.Text = DdlMonth.Items[DdlMonth.SelectedIndex + 1].Text + "<br/>" + nextMontDays.ToString() + "<br/>";
                                    else
                                        linkbutton.Text = UtilityFunctions.GetEnumDescrptionFromObjectValue(typeof(Month), Month.Month_January) + "<br/>" + nextMontDays.ToString() + "<br/>";
                                }
                            }
                            else
                            {
                                linkbutton.Text = nextMontDays.ToString() + "<br/>";
                            }

                            tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(linkbutton);
                            linkbutton.Enabled = false;
                            int TempYear = month == 12 ? (year + 1) : year;
                            int TempMonth = month == 12 ? 1 : month + 1;
                            int TempDay = nextMontDays;

                            SetControlsInCells(list, indexOfCalender, TempYear, TempMonth, TempDay, linkbutton, LnkBtnID, tb, dayOfWeek, weekOfMonth);
                        }
                    }
                }

                if (Convert.ToInt32(DdlMonth.SelectedValue) == 1)
                    TotalDaysInlastMonth = DateTime.DaysInMonth(Convert.ToInt32(DdlYear.SelectedValue) - 1, 12);
                else
                    TotalDaysInlastMonth = DateTime.DaysInMonth(Convert.ToInt32(DdlYear.SelectedValue), Convert.ToInt32(DdlMonth.SelectedValue) - 1);

                //DateTime d1;//
                //if (month == 1)
                //    d1 = new DateTime(year - 1, 12, TotalDaysInlastMonth - fDay + 1);
                //else
                //    d1 = new DateTime(year, month - 1, TotalDaysInlastMonth - fDay + 1);

                //DateTime d2;// = new DateTime(2012, 6, 8);
                //if (month == 12)
                //    d2 = new DateTime(year + 1, 1, indexOfCalender - totalDaysInMonth - 1);
                //else
                //    d2 = new DateTime(year, month + 1, indexOfCalender - totalDaysInMonth - 1);


                foreach (var item in MyColorList)
                {
                    item.Name = item.Name.Replace("#*#", string.Empty);
                    item.Name = item.Name.Replace("<br>", ", ");

                }

                rptColors.DataSource = MyColorList;
                rptColors.DataBind();

                rptColors.Visible = rptColors.Items.Count > 0;
                //*******************************************
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        private void SetControlsInCells(DataTable list, int indexOfCalender, int year, int month, int day, LinkButton linkbutton, int LnkBtnID, Table tb, int dayOfWeek, int weekOfMonth)
        {
            var classes = from obj in list.AsEnumerable()
                          where Convert.ToDateTime((DateTime)obj["ScheduleDate"]).Year == year && Convert.ToDateTime((DateTime)obj["ScheduleDate"]).Month == month && Convert.ToDateTime((DateTime)obj["ScheduleDate"]).Day == day
                          select new
                          {
                              ID = obj["ID"],
                              SessionName = obj["SessionName"],
                              ScheduleDate = obj["ScheduleDate"],
                              StartTime = obj["StartTime"],
                              EndTime = obj["EndTime"],
                              VenueName = obj["VenueName"],
                              ClassName = obj["ClassTitle"],
                              TrainerID = obj["TrainerID"],
                              VenueID = obj["VenueID"],
                              ClassID = obj["ClassID"],
                              FullName = obj["FullName"],
                              StartDate = obj["StartDate"],
                              EndDate = obj["EndDate"],
                              CourseName = obj["CourseName"]
                          };

            foreach (var clss in classes)
            {
                Label lbl = new Label();
                LinkButton LnkClass = new LinkButton();
                LinkButton LnkTrainer = new LinkButton();
                LinkButton LnkVenue = new LinkButton();
                LnkClass.ID = "Lnk_" + indexOfCalender.ToString() + clss.ClassID.ToString() + "_" + clss.ID.ToString() + (LnkBtnID++).ToString();
                LnkTrainer.ID = "Lnk_" + indexOfCalender.ToString() + "_" + clss.TrainerID.ToString() + "_" + clss.ID.ToString() + (LnkBtnID++).ToString();
                LnkVenue.ID = "Lnk_" + indexOfCalender.ToString() + "_" + clss.VenueID.ToString() + "_" + clss.ID.ToString() + (LnkBtnID++).ToString();
                //LnkClass.Text = clss.ClassName.ToString() + "<br/>";
                //LnkTrainer.Text = clss.FullName.ToString() + "<br/>";
                //LnkVenue.Text = clss.SessionName.ToString() + "<br/>";
                //string PageUrl = UtilityFunctions.GetPageUrl("Page_Class_ClassDetailView");
                //LnkClass.PostBackUrl = UtilityFunctions.AddQuerystringVar(PageUrl, "clid", clss.ClassID.ToString());
                //PageUrl = UtilityFunctions.GetPageUrl("Page_Person_PersonDetailView");
                //PageUrl = UtilityFunctions.AddQuerystringVar(PageUrl, "pid", clss.TrainerID.ToString());
                //LnkTrainer.PostBackUrl = UtilityFunctions.AddQuerystringVar(PageUrl, "pt", "2");
                //PageUrl = UtilityFunctions.GetPageUrl("Page_Session_SessionDetailView");
                //LnkVenue.PostBackUrl = UtilityFunctions.AddQuerystringVar(PageUrl, "sid", clss.ID.ToString());

                //LnkClass.ToolTip = TrainingResourceManager.GetLabel("Timetable_ViewClassDetails");
                //LnkTrainer.ToolTip = TrainingResourceManager.GetLabel("Timetable_ViewTrainerDetails");
                //LnkVenue.ToolTip = TrainingResourceManager.GetLabel("Timetable_ViewSessionDetails");

                //if (Convert.ToDateTime(clss.ScheduleDate) < DateTime.Now.Date)
                //    lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#75A041");
                //else if (Convert.ToDateTime(clss.ScheduleDate) == DateTime.Now.Date)
                //    lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3E499");
                //else
                //    lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#A3FF85");

                lbl.ToolTip = clss.ClassName.ToString();
                lbl.Text = Convert.ToDateTime(clss.StartTime).ToShortTimeString() + " - " + Convert.ToDateTime(clss.EndTime).ToShortTimeString() + " <br /> ";
                //lbl.Text = Convert.ToDateTime(clss.ScheduleDate).ToShortDateString() + "<br/>" + Convert.ToDateTime(clss.StartTime).TimeOfDay.ToString() + " - " + Convert.ToDateTime(clss.EndTime).TimeOfDay.ToString().ToString() + "<br/>";
                //lbl.ForeColor = System.Drawing.Color.Black;
                if (MyColorList.Count(c => c.Name == clss.ClassName.ToString()) <= 0)
                {
                    randomColor = UtilityFunctions.GetRandomColor(myColors);
                    myColors.Add(randomColor);
                    string _Name = string.Empty;
                    _Name = clss.CourseName + "  ";
                    _Name += " <br /> " + UtilityFunctions.GetShortDateString(Convert.ToDateTime(clss.StartDate)) + " - " + UtilityFunctions.GetShortDateString(Convert.ToDateTime(clss.EndDate));

                    //_Name += UtilityFunctions.GetShortDateString(Convert.ToDateTime(clss.ScheduleDate)) + " " + Convert.ToDateTime(clss.StartTime).TimeOfDay.ToString() + " - " + Convert.ToDateTime(clss.EndTime).TimeOfDay.ToString().ToString() + " <br /> ";


                    //var Trainers = from obj in list.AsEnumerable()
                    //               where Convert.ToInt64(obj["ClassID"]) == Convert.ToInt64(clss.ClassID)
                    //                        && Convert.ToDateTime((DateTime)obj["ScheduleDate"]).Year == year && Convert.ToDateTime((DateTime)obj["ScheduleDate"]).Month == month
                    //               select new
                    //               {
                    //                   FullName = obj["FullName"],
                    //               };

                    //string[] _TrainersOfClass = (from t in Trainers select t.FullName.ToString()).Distinct().ToArray();
                    long _ClssID = (long)clss.ClassID;
                    string[] _TrainersOfClass = (from c in classes where Convert.ToInt64(c.ClassID) == _ClssID select c.FullName.ToString()).Distinct().ToArray();
                    foreach (string _S in _TrainersOfClass)
                    {
                        //_Name += " <br /> " + (Array.IndexOf(_TrainersOfClass, _S) + 1) + ") " + _S;
                        _Name += " <br /> " + _S;
                    }
                    //_Name += " <br /> ";

                    MyColorList.Add(new MyColor() { Name = clss.ClassName.ToString(), DisplayName = _Name, Color = ColorTranslator.ToHtml(randomColor) });
                }
                else
                {
                    randomColor = ColorTranslator.FromHtml(MyColorList.FirstOrDefault(c => c.Name == clss.ClassName.ToString()).Color);

                    MyColor myColor = MyColorList.FirstOrDefault(c => c.Name == clss.ClassName.ToString());
                    if (myColor != null && myColor.Name != null && myColor.Name != string.Empty)
                    {
                        string _TrainerName = string.Empty;
                        long _ClssID = (long)clss.ClassID;
                        string[] _TrainersOfClass = (from c in classes where Convert.ToInt64(c.ClassID) == _ClssID select c.FullName.ToString()).Distinct().ToArray();
                        foreach (string _S in _TrainersOfClass)
                        {
                            _TrainerName = _TrainerName.Replace(" <br /> " + _S, "");
                            myColor.DisplayName = myColor.DisplayName.Replace(" <br /> " + _S, "");
                            _TrainerName += " <br /> " + _S;
                        }
                        //_TrainerName += " <br /> ";
                        myColor.DisplayName += _TrainerName;
                    }
                }

                lbl.BackColor = randomColor;
                lbl.CssClass = "ScheduleSessionName";
                LnkClass.BackColor = randomColor;

                tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(lbl);
                //tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(LnkVenue);
                //tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(LnkClass);
                //tb.Rows[dayOfWeek].Cells[weekOfMonth].Controls.Add(LnkTrainer);

                linkbutton.ID = "Lnk_" + indexOfCalender.ToString() + "_" + clss.ID.ToString() + "_" + clss.ClassID.ToString();
                linkbutton.Enabled = false;
                LnkClass.Enabled = true;
                LnkTrainer.Enabled = true;
                LnkVenue.Enabled = true;
            }
        }

        /// <summary>
        /// <para>Description:
        /// This Method will Bind Duration of class</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/26/2013 </para> 
        /// </summary>
        /// <param name="ClassID"></param>
        private void ClassDuration(long ClassID)
        {
            // AppContext.CurrentClassID = ClassID;
            // AppContext.CurrentClassDetailMapping = null;
            //if (!_PersonBAL.ClassGetByID(ClassID))
            //{
            //    return;
            //}
          long  CurrentClassID = UtilityFunctions.MapValue<Int64>(DdlClass.SelectedValue, typeof(Int64));
            CurrentClass = _PersonBAL.ClassGetByID(CurrentClassID);
            LblClassDuration.Text = string.Empty;
       //     if (AppContext.CurrentClass != null)
                LblClassDuration.Text = "ClassDuration" + Convert.ToDateTime(CurrentClass.StartDate).ToShortDateString() + " - " + Convert.ToDateTime(CurrentClass.EndDate).ToShortDateString(); ;

        }






    }



   public  class MyColor
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }

    /// <summary>
    /// <para>Description:
    /// Collection of MyColor Class</para> 
    /// <para>Created By: Tanweer </para> 
    /// <para>Created Date: 9/23/2013 </para> 
    /// </summary>
    public class MyColorLists : List<MyColor>
    {

    }
}