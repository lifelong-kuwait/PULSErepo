using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces;
using TMS.Library.Entities.CRM;
using TMS.Library.Task;

namespace TMS.DataObjects.TMS.Task
{
    public class TaskDAL : DBGenerics, ITaskDAL
    {

        public IList<Sls_Task> Task_GetAllDAL(string Culture, long? UserID)
        {
            List<Sls_Task> TaskList = new List<Sls_Task>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Task_GetAll";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@UserID", UserID);
                TaskList = conn.Query<Sls_Task>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Sls_Task>();
                conn.Close();
            }
            return TaskList;
        }

        public IList<Sls_Task> Task_GetAllDALbyOrganization(string Culture,string Oid , long? UserID)
        {
            List<Sls_Task> TaskList = new List<Sls_Task>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Task_GetAllbyOrganization";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@Oid", Oid);
                param.Add("@UserID", UserID);
                TaskList = conn.Query<Sls_Task>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Sls_Task>();
                conn.Close();
            }
            return TaskList;
        }
        public IList<Sls_Task> Task_GetDALbyOrganization(string Culture, string Oid, long? UserID,long id)
        {
            List<Sls_Task> TaskList = new List<Sls_Task>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Task_GetSingleByIDAndOrganization";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@Oid", Oid);
                param.Add("@UserID", UserID); 
                param.Add("@TaskdID", id); 
                 TaskList = conn.Query<Sls_Task>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Sls_Task>();
                conn.Close();
            }
            return TaskList;
        }

        /// <summary>
        /// Logins the users delete dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int ChangeStatus_DoneBAL(Sls_Task _objTask)
        {
            return ExecuteScalarInt32Sp("TMS_Task_Update",
                ParamBuilder.Par("ID", _objTask.ID),
                ParamBuilder.Par("Status", 1),
                       ParamBuilder.Par("ModifiedBy", _objTask.ModifiedBy),
                       ParamBuilder.Par("ModifiedOn", _objTask.ModifiedOn));
        }

        public int ChangeStatus_UnderwayBAL(Sls_Task _objTask)
        {
            return ExecuteScalarInt32Sp("TMS_Task_Update",
                ParamBuilder.Par("ID", _objTask.ID),
                ParamBuilder.Par("Status", 3),
                       ParamBuilder.Par("ModifiedBy", _objTask.ModifiedBy),
                       ParamBuilder.Par("ModifiedOn", _objTask.ModifiedOn));
        }

        public int ChangeStatus_RescheduleBAL(Sls_Task _objTask)
        {
            return ExecuteScalarInt32Sp("TMS_Task_ReScheduled",
                ParamBuilder.Par("ID", _objTask.ID),
                ParamBuilder.Par("Status", 2),
                 ParamBuilder.Par("DueDate", _objTask.DueDate),
                       ParamBuilder.Par("ModifiedBy", _objTask.ModifiedBy),
                       ParamBuilder.Par("ModifiedOn", _objTask.ModifiedOn));
        }

        public long Task_CreateDAL(Sls_Task _objTasks)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Task_Create", parameters,
                ParamBuilder.Par("LeadID", _objTasks.LeadID),
                ParamBuilder.Par("OrganizationID",_objTasks.OrganizationID),
                ParamBuilder.Par("Status", 3),
                ParamBuilder.Par("DueDate", _objTasks.DueDate),
                ParamBuilder.Par("Description", _objTasks.Description),
                ParamBuilder.Par("TaskType", _objTasks.TaskType),
                ParamBuilder.Par("CompletionTime", _objTasks.CompletionTime),
                ParamBuilder.Par("IsDeleted", _objTasks.IsDeleted),
                ParamBuilder.Par("IsActive", _objTasks.IsActive),
                ParamBuilder.Par("AssignedBy", _objTasks.AssignedBy),
                ParamBuilder.Par("AssignedTo", _objTasks.AssignedTo),
                ParamBuilder.Par("CreatedBy", _objTasks.CreatedBy),
                ParamBuilder.Par("CreatedOn", _objTasks.CreatedOn),
                ParamBuilder.Par("ModifiedBy", _objTasks.ModifiedBy),
                ParamBuilder.Par("ModifiedOn", _objTasks.ModifiedOn));
        }

        public int Tasks_DeleteDAL(Sls_Task _objTasks)
        {
            return ExecuteScalarInt32Sp("CRM_Task_Delete",
                        ParamBuilder.Par("ID", _objTasks.ID),
                        ParamBuilder.Par("ModifiedBy", _objTasks.ModifiedBy),
                        ParamBuilder.Par("ModifiedDate", _objTasks.ModifiedOn));
        }

        public int Tasks_UpdateDAL(Sls_Task _objTasks)
        {
            return ExecuteScalarInt32Sp("CRM_Task_Update",
                        ParamBuilder.Par("ID", _objTasks.ID),                    
                          ParamBuilder.Par("LeadID", _objTasks.LeadID),
                        ParamBuilder.Par("ModifiedBy", _objTasks.ModifiedBy),
                        ParamBuilder.Par("TaskType", _objTasks.TaskType),
                        ParamBuilder.Par("DueDate", _objTasks.DueDate),
                        ParamBuilder.Par("Description", _objTasks.Description),
                        ParamBuilder.Par("AssignedBy", _objTasks.AssignedBy),
                         // ParamBuilder.Par("DueDate", _objTasks.DueDate),
                        ParamBuilder.Par("AssignedTo", _objTasks.AssignedTo),
                        ParamBuilder.Par("ModifiedDate", _objTasks.ModifiedOn));
        }

        public IList<CRM_TaskHistory> Task_GetAllByIdDAL(long ID)
        {

            List<CRM_TaskHistory> Venue = new List<CRM_TaskHistory>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { TaskID = ID });
                Venue = conn.Query<CRM_TaskHistory>("CRM_Task_GetByID", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_TaskHistory>();
                conn.Close();
            }
            return Venue.ToList();
            //  var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            //var _PersonData = ExecuteSinglewithSP<CRM_TaskHistory>("CRM_Task_GetByID", ParamBuilder.Par("TaskID", ID));         
            //return _PersonData;
        }
    }
}
