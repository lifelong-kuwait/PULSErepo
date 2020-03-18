using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.CRM;
using TMS.Library.Task;

namespace TMS.Business.Interfaces.TMS
{
    public interface IBALTask
    {
        /// <summary>
        /// Task get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Tasks&gt;.</returns>
        IList<Sls_Task> Task_GetAllBAL(string culture, long? UserID);

        /// <summary>
        /// Task get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Tasks&gt;.</returns>
        IList<Sls_Task> Task_GetAllBALbyOrganization(string culture,string Oid, long? userid);
        IList<Sls_Task> Task_GetBALbyOrganization(string culture,string Oid, long? userid,long ID);

        IList<CRM_TaskHistory> Task_GetAllByIdBAL(long ID);
        
        int ChangeStatus_DoneBAL(Sls_Task _objTask);

        int ChangeStatus_UnderwayBAL(Sls_Task _objTask);

        int ChangeStatus_RescheduleBAL(Sls_Task _objTask);

        long Task_CreateBAL(Sls_Task _objTasks);
        
        int Tasks_DeleteBAL(Sls_Task _objTasks);

        int Tasks_UpdateBAL(Sls_Task _objTasks);


    }
}
