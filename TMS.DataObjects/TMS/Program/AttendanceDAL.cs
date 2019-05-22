using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Program;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.DataObjects.TMS.Program
{
   public class AttendanceDAL : DBGenerics, IAttendanceDAL
    {
       

        public List<Schedule> ManageScheduleDAL(long companyID, long? CourseID,long? ClassID)
        {
            List<Schedule> sch = new List<Schedule>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = companyID, CourseID= CourseID, ClassID= ClassID });
                sch = conn.Query<Schedule>("TMS_Session_GetByCourseAndClassID", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<Schedule>();
                conn.Close();
            }
            return sch.ToList();
        }




        
        public List<Attendance> ManageSessionAttendanceDAL(long companyID, long SessionID)
        {
           
            List<Attendance> att = new List<Attendance>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = companyID, SessionID= SessionID });
                att = conn.Query<Attendance>("Tran_Attendances_GetSessionAttendance", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<Attendance>();
                conn.Close();
            }
            return att.ToList();


        
    }

    
        public long MarkTraineesAttendanceDAL(Attendance ObjAttendance, int Atttype)
        {
            //try
            //{
               // AddOutParameter(command, "ReturnID", DbType.Int64, int.MaxValue);
                var parameters = new[] { ParamBuilder.Par("ReturnID", int.MaxValue) };

                return ExecuteInt64withOutPutparameterSp("Tran_Attendances_MarkTraineesAttendance", parameters,
                               ParamBuilder.Par("ID", ObjAttendance.ID),
                                ParamBuilder.Par("ClassTraineesID", ObjAttendance.ClassTraineesID),
                                ParamBuilder.Par("SessionID", ObjAttendance.SessionID),
                                ParamBuilder.Par("Date", ObjAttendance.Date),
                                ParamBuilder.Par("IsMarked", ObjAttendance.IsMarked),
                                
                                ParamBuilder.Par("AttendanceType", Atttype),                              
                                ParamBuilder.Par("OrganizationID", ObjAttendance.OrganizationID),
                                ParamBuilder.Par("CreatedOn", ObjAttendance.CreatedOn),
                                ParamBuilder.Par("ModifiedBy", ObjAttendance.UpdatedBy),
                                ParamBuilder.Par("ModifiedOn", ObjAttendance.UpdatedOn),
                                ParamBuilder.Par("CreatedBy", ObjAttendance.CreatedBy));
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public List<Course> CourseGetAllDAL(string Culture, long CompanyID)
        {
            List<Course> sch = new List<Course>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { Culture = Culture, OrganizationID = CompanyID });
                sch = conn.Query<Course>("TMS_CoursesDDL_GetAllByCulture", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<Course>();
                conn.Close();
            }
            return sch.ToList();
        }
    }
}
