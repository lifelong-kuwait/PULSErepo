using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.DataObjects.Interfaces.TMS.Program
{
   public interface IAttendanceDAL
    {

        List<Attendance> ManageSessionAttendanceDAL(long companyID, long SessionID);

        List<Schedule> ManageScheduleDAL(long companyID, long? CourseID, long? ClassID);

        List<Course> CourseGetAllDAL(string Culture, long CompanyID);
        long MarkTraineesAttendanceDAL(Attendance _Attendance, int Atttype);
    }
}
