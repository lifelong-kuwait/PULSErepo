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
using TMS.Library.TMS.Trainer;

namespace TMS.DataObjects.Jobs
{
    public class JobsRequirementDAL: DBGenerics, IJobsDAL
    {       
        public long Jobs_Requirement_Create(JobsRequirement jobsRequirement)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Job_InsertJobRequirement", parameters,
                ParamBuilder.Par("@JobTitle", jobsRequirement.JobTitle),
                ParamBuilder.Par("@Description", jobsRequirement.Description),
                ParamBuilder.Par("@SkillSet", jobsRequirement.SkillSet),
                ParamBuilder.Par("@Location", jobsRequirement.Location),
                ParamBuilder.Par("@CareerLevel", jobsRequirement.CareerLevel),
                ParamBuilder.Par("@SalaryRangeFrom", jobsRequirement.SalaryRangeFrom),
                ParamBuilder.Par("@SalaryRangeTo", jobsRequirement.SalaryRangeTo),
                ParamBuilder.Par("@FunctionalArea", jobsRequirement.FunctionalArea),
                ParamBuilder.Par("@Type", jobsRequirement.Type),
                ParamBuilder.Par("@Timing", jobsRequirement.Timing),
                ParamBuilder.Par("@NoOfPositions", jobsRequirement.NoOfPositions),
                ParamBuilder.Par("@Gender", jobsRequirement.Gender),
                ParamBuilder.Par("@LastDateToApply", jobsRequirement.LastDateToApply),
                ParamBuilder.Par("@EducationRequired", jobsRequirement.EducationRequired),
                ParamBuilder.Par("@MinExperiance", jobsRequirement.MinExperiance),
                ParamBuilder.Par("@MaxExperiance", jobsRequirement.MaxExperiance),
                ParamBuilder.Par("@Allowance", jobsRequirement.Allowance),
                ParamBuilder.Par("@OrganizationID", jobsRequirement.OrganizationID),
                ParamBuilder.Par("@CreatedBy", jobsRequirement.CreatedBy)
                );
        }
        public long Jobs_Requirement_Update(JobsRequirement jobsRequirement)
        {
          
            return ExecuteScalarInt32Sp("Job_UpdateJobRequirement", 
                ParamBuilder.Par("@ID", jobsRequirement.ID),
                ParamBuilder.Par("@JobTitle", jobsRequirement.JobTitle),
                ParamBuilder.Par("@Description", jobsRequirement.Description),
                ParamBuilder.Par("@SkillSet", jobsRequirement.SkillSet),
                ParamBuilder.Par("@Location", jobsRequirement.Location),
                ParamBuilder.Par("@CareerLevel", jobsRequirement.CareerLevel),
                ParamBuilder.Par("@SalaryRangeFrom", jobsRequirement.SalaryRangeFrom),
                ParamBuilder.Par("@SalaryRangeTo", jobsRequirement.SalaryRangeTo),
                ParamBuilder.Par("@FunctionalArea", jobsRequirement.FunctionalArea),
                ParamBuilder.Par("@Type", jobsRequirement.Type),
                ParamBuilder.Par("@Timing", jobsRequirement.Timing),
                ParamBuilder.Par("@NoOfPositions", jobsRequirement.NoOfPositions),
                ParamBuilder.Par("@Gender", jobsRequirement.Gender),
                ParamBuilder.Par("@LastDateToApply", jobsRequirement.LastDateToApply),
                ParamBuilder.Par("@EducationRequired", jobsRequirement.EducationRequired),
                ParamBuilder.Par("@MinExperiance", jobsRequirement.MinExperiance),
                ParamBuilder.Par("@MaxExperiance", jobsRequirement.MaxExperiance),
                ParamBuilder.Par("@Allowance", jobsRequirement.Allowance),
                ParamBuilder.Par("@OrganizationID", jobsRequirement.OrganizationID),
                ParamBuilder.Par("@UpdatedBy", jobsRequirement.UpdateBy), 
                ParamBuilder.Par("@IsActive", jobsRequirement.IsActive)
                );
        }
        public long Jobs_Requirement_Active(long JobID, long updateBy)
        {
                return ExecuteScalarInt32Sp("Job_ActiveJobRequirement",
                    ParamBuilder.Par("@ID", JobID),
                    ParamBuilder.Par("@UpdatedBy", updateBy)
                    );
            
        }
        public long Jobs_Requirement_InActive(long JobID,long updateBy)
        {
            return ExecuteScalarInt32Sp("Job_InActiveJobRequirement",
                ParamBuilder.Par("@ID", JobID),
                ParamBuilder.Par("@UpdatedBy", updateBy)
                );

        }

        public long Jobs_Requirement_Destroy(JobsRequirement jobsRequirement)
        {

            return ExecuteScalarInt32Sp("Job_DeleteJobRequirement",
                ParamBuilder.Par("@ID", jobsRequirement.ID),                
                ParamBuilder.Par("@UpdatedBy", jobsRequirement.UpdateBy)
                );
        }
        
        public List<JobsRequirement> read_AllJobsRequiredDAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            List<JobsRequirement> _JobRequirementData = new List<JobsRequirement>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { SearchText = SearchText, culture = culture, SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize, CompanyID = CompanyID });
                using (var multi = conn.QueryMultiple("Jobs_Get_All_JobRequirment_Read", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _JobRequirementData = multi.Read<JobsRequirement>().AsList<JobsRequirement>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }
                conn.Close();
            }            
            return _JobRequirementData.ToList();
        }
        public List<JobApplicationPerson> read_AllJobsApplicationPersonDAL(long JobID, ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            List<JobApplicationPerson> _JobRequirementData = new List<JobApplicationPerson>();
            JobApplication jobApplication = new JobApplication();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { JobID= JobID,SearchText = SearchText, culture = culture, SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize, ID = CompanyID });
                using (var multi = conn.QueryMultiple("Job_ApplicationsAgainstJob", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    
                    _JobRequirementData = multi.Read<JobApplicationPerson>().AsList<JobApplicationPerson>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }
                conn.Close();
            }
            return _JobRequirementData.ToList();
        }
        public List<JobsRequirement> Jobs_Requirement_For_EndUserDAL(long CompanyID)
        {
            List<JobsRequirement> _JobRequirementData = new List<JobsRequirement>();            
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CompanyID = CompanyID });
                using (var multi = conn.QueryMultiple("Jobs_Get_All_JobRequirment", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _JobRequirementData = multi.Read<JobsRequirement>().AsList<JobsRequirement>();                   
                }
                conn.Close();
            }
            return _JobRequirementData.ToList();
        }
    }
}
