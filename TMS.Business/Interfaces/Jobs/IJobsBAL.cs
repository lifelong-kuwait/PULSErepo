using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Jobs;

namespace TMS.Business.Interfaces.Jobs
{
    public interface IJobsBAL
    {
        long Jobs_Requirement_Create(JobsRequirement jobsRequirement);
        long Jobs_Requirement_Update(JobsRequirement jobsRequirement);
        long Jobs_Requirement_Destroy(JobsRequirement jobsRequirement); 
        long Jobs_Requirement_Active(long JobID, long updateBy); 
        long Jobs_Requirement_InActive(long JobID, long updateBy);
        List<JobsRequirement> read_AllJobsRequiredBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        List<JobApplicationPerson> read_AllJobsApplicationPersonBAL(long JobID,ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        List<JobsRequirement> Jobs_Requirement_For_EndUser(long CompanyID);

    }
}
