using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Jobs;

namespace TMS.DataObjects.Interfaces.Jobs
{
    public interface IJobApplicationDAL
    {
        long Jobs_Application_Create(JobApplication jobApplication);
        long Jobs_ApplicationPersonMapping_Create_DAL(long JobApplicationID,long PersonID);
        long Jobs_Referance_Create_DAL(JobReferance jobReferance);


    }
}
