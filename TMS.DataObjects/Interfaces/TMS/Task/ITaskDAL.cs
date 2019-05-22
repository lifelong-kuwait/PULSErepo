using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.CRM;
using TMS.Library.Task;

namespace TMS.DataObjects.Interfaces
{
    public interface ITaskDAL
    {
        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<Sls_Task> Task_GetAllDAL(string culture, long? UserID);

        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<Sls_Task> Task_GetAllDALbyOrganization(string culture,string Oid, long? userid);

        int ChangeStatus_DoneBAL(Sls_Task _objTask);

        int ChangeStatus_UnderwayBAL(Sls_Task _objTask);

        int ChangeStatus_RescheduleBAL(Sls_Task _objTask);

        long Task_CreateDAL(Sls_Task _objTasks);

        int Tasks_DeleteDAL(Sls_Task _objTasks);


        int Tasks_UpdateDAL(Sls_Task _objTasks);

        IList<CRM_TaskHistory> Task_GetAllByIdDAL(long ID);
    }
}
