using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.Business.Interfaces.TMS.Program
{
   public interface IAttendanceBAL
    {


        List<Attendance> ManageSessionAttendanceBAL(long companyID,long SessionID);

        List<Schedule> ManageScheduleBAL(long companyID, long? CourseID, long? ClassID);

        List<Course> CourseGetAllBAL(string Culture, long CompanyID);
        long MarkTraineesAttendanceBAL(Attendance _Attendance, int Atttype);

    }
}
