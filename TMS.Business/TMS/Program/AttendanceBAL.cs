using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS.Program;
using TMS.DataObjects.Interfaces.TMS.Program;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.Business.TMS.Program
{
   public class AttendanceBAL:IAttendanceBAL
    {
        private readonly IAttendanceDAL _AttendanceDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationBAL"/> class.
        /// </summary>
        /// <param name="_IConfigurationDAL">The i configuration dal.</param>
        public AttendanceBAL(IAttendanceDAL _IAttendanceDAL)
        {
            _AttendanceDAL = _IAttendanceDAL;
        }

       // public List<Attendance> ManageSessionAttendanceBAL(long oid) 

        public List<Attendance> ManageSessionAttendanceBAL(long companyID, long SessionID) => _AttendanceDAL.ManageSessionAttendanceDAL(companyID,SessionID);
        //{
        //    throw new NotImplementedException();
        //}
        public List<Schedule> ManageScheduleBAL(long companyID, long? CourseID,long? ClassID) => _AttendanceDAL.ManageScheduleDAL(companyID,CourseID,ClassID);

        public List<Course> CourseGetAllBAL(string Culture, long CompanyID) => _AttendanceDAL.CourseGetAllDAL(Culture,CompanyID);
        public long MarkTraineesAttendanceBAL(Attendance _Attendance, int Atttype) => _AttendanceDAL.MarkTraineesAttendanceDAL(_Attendance,Atttype);
    }
}
