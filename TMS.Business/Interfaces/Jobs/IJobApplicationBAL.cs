using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Jobs;

namespace TMS.Business.Interfaces.Jobs
{
    public interface IJobApplicationBAL
    {
        long Jobs_Application_Create(JobApplication jobApplication);
        long Jobs_ApplicationPersonMapping_Create(long JobApplicationID,long PersonID);
        long Jobs_Referance_Create_BAL(JobReferance jobReferance);
    }
}
