using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Jobs;
using TMS.Library.Entities.Jobs;


namespace TMS.DataObjects.Jobs
{
    public class JobApplicationDAL : DBGenerics, IJobApplicationDAL
    {
        public long Jobs_Application_Create(JobApplication jobApplication)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Job_InsertJobApplication", parameters,
                ParamBuilder.Par("@JobID", jobApplication.JobRequirementApplicationID),
                ParamBuilder.Par("@JoiningDate", jobApplication.JoiningDate),
                ParamBuilder.Par("@ExpectedSalary", jobApplication.ExpectedSalary),
                ParamBuilder.Par("@OrganizationID", jobApplication.OrganizationID)                
                );
        }
        public long Jobs_ApplicationPersonMapping_Create_DAL(long JobApplicationID, long PersonID)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Job_InsertApplicationPersonMapping", parameters,
                ParamBuilder.Par("@JobID",JobApplicationID),
                ParamBuilder.Par("@PersonID",PersonID)
                );
        }
        public long Jobs_Referance_Create_DAL(JobReferance jobReferance)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Job_ApplicationReferance", parameters,
                ParamBuilder.Par("@PersonID", jobReferance.PersonID),
                ParamBuilder.Par("@ReferName", jobReferance.ReferName),
                ParamBuilder.Par("@JobTitle", jobReferance.JobTitle),                
                ParamBuilder.Par("@PhoneNumber", jobReferance.PhoneNumber),
                ParamBuilder.Par("@Company", jobReferance.Company),
                ParamBuilder.Par("@Relation", jobReferance.Relation)
                );
        }

    }
}
