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
    public class JobsRequirementBAL : IJobsBAL
    {
        private readonly IJobsDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public JobsRequirementBAL()
        {
            DAL = new JobsRequirementDAL();
        }
        public long Jobs_Requirement_Create(JobsRequirement jobsRequirement)
        {
           return DAL.Jobs_Requirement_Create(jobsRequirement);
        }
        public long Jobs_Requirement_Update(JobsRequirement jobsRequirement)
        {
            return DAL.Jobs_Requirement_Update(jobsRequirement);
        }

        public long Jobs_Requirement_Active(long JobID, long updateBy)
        {
            return DAL.Jobs_Requirement_Active(JobID,updateBy);
        }
        public long Jobs_Requirement_InActive(long JobID, long updateBy)
        {
            return DAL.Jobs_Requirement_InActive(JobID, updateBy);
        }
        public long Jobs_Requirement_Destroy(JobsRequirement jobsRequirement)
        {
            return DAL.Jobs_Requirement_Destroy(jobsRequirement);
        }
        
        public List<JobsRequirement> read_AllJobsRequiredBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            return DAL.read_AllJobsRequiredDAL(ref Total, culture, SearchText, SortExpression, StartRowIndex, page, PageSize, CompanyID);
        }
        public List<JobApplicationPerson> read_AllJobsApplicationPersonBAL(long JobID, ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            return DAL.read_AllJobsApplicationPersonDAL(JobID,ref Total, culture, SearchText, SortExpression, StartRowIndex, page, PageSize, CompanyID);

        }
        public List<JobsRequirement> Jobs_Requirement_For_EndUser(long CompanyID)
        {
            return DAL.Jobs_Requirement_For_EndUserDAL(CompanyID);
        }
    }
}
