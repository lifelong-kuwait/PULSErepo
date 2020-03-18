using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Interfaces;
using TMS.Library.Entities.CRM;
using TMS.Library.Task;

namespace TMS.Business.TMS
{
    public class BALTask : IBALTask
    {
        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        /// <value>The dal.</value>
        public ITaskDAL _DAL { get; set; }
        public IUserDAL DAL { get; set; }

        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<Sls_Task> Task_GetAllBAL(string culture, long? UserID)
        {

            return _DAL.Task_GetAllDAL(culture,UserID);
        }

        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<Sls_Task> Task_GetAllBALbyOrganization(string culture,string Oid, long? userid)
        {
            return _DAL.Task_GetAllDALbyOrganization(culture, Oid, userid);
        }
        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<Sls_Task> Task_GetBALbyOrganization(string culture, string Oid, long? userid,long ID)
        {
            return _DAL.Task_GetDALbyOrganization(culture, Oid, userid,ID);
        }
        
        public int ChangeStatus_DoneBAL(Sls_Task _objTask)
        {
            return _DAL.ChangeStatus_DoneBAL(_objTask);
        }

        public int ChangeStatus_UnderwayBAL(Sls_Task _objTask)
        {
            return _DAL.ChangeStatus_UnderwayBAL(_objTask);
        }

        public int ChangeStatus_RescheduleBAL(Sls_Task _objTask)
        {
            return _DAL.ChangeStatus_RescheduleBAL(_objTask);
        }

        public long Task_CreateBAL(Sls_Task _objTasks)
        {
            return _DAL.Task_CreateDAL(_objTasks);
        }

        public int Tasks_DeleteBAL(Sls_Task _objTasks)
        {
            return _DAL.Tasks_DeleteDAL(_objTasks);
        }

        public int Tasks_UpdateBAL(Sls_Task _objTasks)
        {
            return _DAL.Tasks_UpdateDAL(_objTasks);
        }

        public IList<CRM_TaskHistory> Task_GetAllByIdBAL(long ID)
        {
            return _DAL.Task_GetAllByIdDAL(ID);
        }
       
    }
}
