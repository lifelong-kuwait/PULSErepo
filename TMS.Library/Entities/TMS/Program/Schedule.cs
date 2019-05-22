
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.TMS.Program
{
   public class Schedule:IDataMapper
    {

        #region Constructors

        /// <summary>
        /// <para>Description:
        /// Initializes a new object of Attendance</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/25/2013 </para> 
        /// </summary>
        public Schedule()
        {
        }

        /// <summary>
        /// <para>Description:
        /// Initializes a new instance of the Attendance class using the specified IDataReader</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/25/2013 </para> 
        /// </summary>
        /// /// <param name="dr"></param>


        #endregion
        #region " Properties "

        public long ID { get; set; }

        public string SessionName { get; set; }


        public DateTime ScheduleDate { get; set; }


        public long OrganizationID { get; set; }


        public DateTime StartTime { get; set; }


        public string EndTime
        {
            get; set;
        }

        public string VenueName { get; set; }


        public string ClassTitle { get; set; }


        public long? TrainerID { get; set; }


        public long? VenueID { get; set; }

        public long? ClassID { get; set; }
        public long? CourseID { get; set; }

        public string FullName { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }

        public string CourseName { get; set; }

        //public string EndTime
        //{
        //    get
        //    {
        //       return EndTime;
        //    }

        //    set
        //    {
        //         EndTime=value;
        //    }
        //}

        //public string Description
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public bool IsAllDay
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public DateTime Start
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public DateTime End
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string StartTimezone
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string EndTimezone
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string RecurrenceRule
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string RecurrenceException
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}





        #region Child

        // public Sessions ObjSession { get; set; }


        //  public Person ObjTrainee { get; set; }

        public void MapProperties(DbDataReader dr)
        {
         

            this.ID = Convert.ToInt64(dr["ID"]);
            this.SessionName = Convert.ToString(dr["SessionName"]);
            this.ScheduleDate = Convert.ToDateTime(dr["ScheduleDate"]);
            this.OrganizationID = Convert.ToInt64(dr["OrganizationID"]);
            this.StartTime = Convert.ToDateTime(dr["StartTime"]);
            this.EndTime = Convert.ToString(dr["EndTime"]);
            this.VenueName = Convert.ToString(dr["VenueName"]);
            this.TrainerID = Convert.ToInt64(dr["TrainerID"]);
            this.ClassTitle = Convert.ToString(dr["ClassTitle"]);
            this.VenueID = Convert.ToInt64(dr["VenueID"]);
            this.ClassID = Convert.ToInt64(dr["ClassID"]);
            this.FullName = Convert.ToString(dr["FullName"]);
            this.StartDate = Convert.ToDateTime(dr["StartDate"]);
            this.EndDate = Convert.ToDateTime(dr["EndDate"]);
            this.CourseName = Convert.ToString(dr["CourseName"]);
        }
        #endregion


        #endregion
    }
}
