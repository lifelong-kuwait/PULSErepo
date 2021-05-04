using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Jobs
{
    public class JobsRequirement: IDataMapper
    {

        public long ID { get; set; }
        [Display(Name = "JobTitle", ResourceType = typeof(lr))]
        public string JobTitle { get; set; }
        //  [ID]
        //,[JobTitle]
        //,[Description]
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(lr))]
        public string Description { get; set; }

        //,[SkillSet]
        [Display(Name = "SkillSet", ResourceType = typeof(lr))]
        public string SkillSet { get; set; }

        //,[Location]
        [Display(Name = "Location", ResourceType = typeof(lr))]

        public string Location { get; set; }

        //,[CareerLevel]
        [Display(Name = "CareerLevel", ResourceType = typeof(lr))]

        public CareerLevel CareerLevel { get; set; }

        //,[SalaryRangeFrom]
        [Display(Name = "SalaryRangeFrom", ResourceType = typeof(lr))]

        public decimal SalaryRangeFrom { get; set; }

        //,[SalaryRangeTo]
        [Display(Name = "SalaryRangeTo", ResourceType = typeof(lr))]
        public decimal SalaryRangeTo { get; set; }


        //,[FunctionalArea]
        [Display(Name = "FunctionalArea", ResourceType = typeof(lr))]

        public string FunctionalArea { get; set; }

        //,[Type]
        [Display(Name = "Type", ResourceType = typeof(lr))]

        public JobType Type { get; set; }


        //,[Timing]
        [Display(Name = "Timing", ResourceType = typeof(lr))]

        public string Timing { get; set; }


        //,[NoOfPositions]
        [Display(Name = "NoOfPositions", ResourceType = typeof(lr))]

        public int NoOfPositions { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(lr))]
        //,[Gender]
        public string Gender { get; set; }

        [Display(Name = "LastDateToApply", ResourceType = typeof(lr))]
        //,[LastDateToApply]
        public DateTime LastDateToApply { get; set; }

        //,[EducationRequired]
        [Display(Name = "EducationRequired", ResourceType = typeof(lr))]

        public string EducationRequired { get; set; }
        [Display(Name = "MinExperiance", ResourceType = typeof(lr))]

        //,[MinExperiance]
        public string MinExperiance { get; set; }
        [Display(Name = "MaxExperiance", ResourceType = typeof(lr))]

        //,[MaxExperiance]
        public string MaxExperiance { get; set; }

        [Display(Name = "Allowance", ResourceType = typeof(lr))]
        //,[Allowance]
        public string Allowance { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        //,[IsActive]
        public bool IsActive { get; set; }

        //,[IsDelete]
        public bool IsDelete { get; set; }
        public long OrganizationID { get; set; }
        //,[CreatedBy]
        public long CreatedBy { get; set; }

        //,[CareateOn]
        public DateTime CreatedOn { get; set; }

        //,[UpdateBy]
        public long UpdateBy { get; set; }

        //,[UpdatedOn]
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
                 ID=dr.GetLong("ID");
                 JobTitle=dr.GetString("JobTitle");
                 Description=dr.GetString("Description");
                 SkillSet=dr.GetString("SkillSet");
                 Location=dr.GetString("Location");
                 CareerLevel=(CareerLevel)dr.GetByte("CareerLevel");
                 SalaryRangeFrom=dr.GetDecimal("SalaryRangeFrom");
                 SalaryRangeTo=dr.GetDecimal("SalaryRangeTo");
                 FunctionalArea=dr.GetString("FunctionalArea");
                 Type=(JobType)dr.GetByte("Type");
                 Timing=dr.GetString("Timing");
                 NoOfPositions=dr.GetInt32("NoOfPositions");
                 Gender=dr.GetString("Gender");
                 LastDateToApply=dr.GetDateTime("LastDateToApply");
                 EducationRequired=dr.GetString("EducationRequired");
                 MinExperiance=dr.GetString("MinExperiance");
                 MaxExperiance=dr.GetString("MaxExperiance");
                 Allowance=dr.GetString("Allowance");
                 OrganizationID=dr.GetLong("OrganizationID");
                 IsActive =dr.GetBoolean("IsActive");
                 IsDelete=dr.GetBoolean("IsDelete");
                 CreatedBy=dr.GetLong("CreatedBy");
                 CreatedOn=dr.GetDateTime("CreatedOn");
                 UpdateBy=dr.GetLong("UpdateBy");
                 UpdatedOn=dr.GetDateTime("UpdatedOn");
    }

    }
    public enum CareerLevel
    {
        [Display(Name = "Entrylevel", ResourceType = typeof(lr))]
        Entrylevel,
        [Display(Name = "Intermediate", ResourceType = typeof(lr))]
        Intermediate,
        [Display(Name = "Midlevel", ResourceType = typeof(lr))]
        Midlevel,
        [Display(Name = "executivelevel", ResourceType = typeof(lr))]
        executivelevel
    }
    public enum JobType
    {        
        [Display(Name = "InternShip", ResourceType = typeof(lr))]
        InternShip,
        [Display(Name = "Permanent", ResourceType = typeof(lr))]
        Permanent,
        [Display(Name = "PartTime", ResourceType = typeof(lr))]
        PartTime
    }
}
