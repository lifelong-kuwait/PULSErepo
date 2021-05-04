using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.Jobs;
using TMS.DataObjects.Interfaces.Jobs;
using TMS.DataObjects.Jobs;
using TMS.Library.Entities.Jobs;

namespace TMS.Business.Jobs
{
    public class Job_Application_BAL : IJobApplicationBAL
    {
        private readonly IJobApplicationDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public Job_Application_BAL()
        {
            DAL = new JobApplicationDAL();
        }
        public long Jobs_Application_Create(JobApplication jobApplication)
        {
           return DAL.Jobs_Application_Create(jobApplication);
        }
        public long Jobs_ApplicationPersonMapping_Create(long JobApplicationID, long PersonID)
        {
          
            return DAL.Jobs_ApplicationPersonMapping_Create_DAL(JobApplicationID,PersonID);
        }
        public long Jobs_Referance_Create_BAL(JobReferance jobReferance)
        {
            return DAL.Jobs_Referance_Create_DAL(jobReferance);
        }
    }
}
