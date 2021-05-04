using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.Jobs
{
    public class JobApplication : IDataMapper
    {
        //[ID]
        public long ID { get; set; }
        //,[JobRequirementApplicationID]
        public long JobRequirementApplicationID { get; set; }

        //,[JoiningDate]
        public DateTime JoiningDate { get; set; }

        //,[ApplicationStatus]
        public int ApplicationStatus { get; set; }
        //,[ExpectedSalary]
        public decimal ExpectedSalary { get; set; }
        //,[OrganizationID]
        public long OrganizationID { get; set; }
        // ,[CreatedBy]
        public long CreatedBy { get; set; }
        // ,[CreatedOn]
        public DateTime CreatedOn { get; set; }
        // ,[UpdatedBy]
        public long UpdatedBy { get; set; }
        // ,[UpdatedOn]
        public DateTime UpdatedOn { get; set; }
        // ,[IsActive]
        public bool IsActive { get; set; }
        // ,[IsDeleted]
        public bool IsDeleted { get; set; }
        // ,[Flex1]
        public string Flex1 { get; set; }
        // ,[Flex2]
        public string Flex2 { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            JobRequirementApplicationID = dr.GetLong("JobRequirementApplicationID");
            JoiningDate = dr.GetDateTime("JoiningDate");
            ApplicationStatus = dr.GetInt32("ApplicationStatus");
            ExpectedSalary = dr.GetDecimal("ExpectedSalary");
            OrganizationID = dr.GetLong("OrganizationID");           
            OrganizationID = dr.GetLong("OrganizationID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDelete");
            CreatedBy = dr.GetLong("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetLong("UpdateBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
        }
    }
}
