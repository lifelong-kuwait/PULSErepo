using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using TMS.Library.TMS.Persons;

namespace TMS.Library.Entities.TMS.Program
{
    public class Attendance: IDataMapper
    {

        #region Constructors

        /// <summary>
        /// <para>Description:
        /// Initializes a new object of Attendance</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/25/2013 </para> 
        /// </summary>
        public Attendance()
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

        public long ClassTraineesID { get; set; }


        public long SessionID { get; set; }


        public long OrganizationID { get; set; }


        public string TraineeName { get; set; }

        public string RollNo { get; set; }
        public DateTime Date { get; set; }

        public Boolean IsMarked { get; set; }


        public AttendanceType AttendanceType { get; set; }


        public long? CreatedBy { get; set; }


        public long? UpdatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }


        public Boolean IsDeleted { get; set; }


        public Boolean IsActive { get; set; }


        #region Child

        //public Sessions ObjSession { get; set; }


        //public Person ObjTrainee { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            this.ID = Convert.ToInt64(dr["ID"]);
            this.ClassTraineesID = Convert.ToInt64(dr["RollNo"]);
            this.SessionID = Convert.ToInt64(dr["SessionID"]);
            this.OrganizationID = Convert.ToInt64(dr["OrganizationID"]);
            this.TraineeName = Convert.ToString(dr["TraineeName"]); 
            this.Date = Convert.ToDateTime(dr["Date"]);
            this.IsMarked = Convert.ToBoolean(dr["IsMarked"]);
            this.AttendanceType = (AttendanceType)Convert.ToInt32(dr["AttendanceType"]);
            this.CreatedBy = Convert.ToInt64(dr["CreatedBy"]);
            this.UpdatedBy = Convert.ToInt64(dr["UpdateddBy"]);
            this.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            this.UpdatedOn = Convert.ToDateTime(dr["UpdatededOn"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.IsActive = Convert.ToBoolean(dr["IsActive"]);
            this.RollNo = Convert.ToString(dr["RollNo"]);
        }
        #endregion


        #endregion

    }
}
