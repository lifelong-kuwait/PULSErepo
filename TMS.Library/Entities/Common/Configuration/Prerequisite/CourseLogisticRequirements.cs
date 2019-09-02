// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 01-27-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-28-2018
// ***********************************************************************
// <copyright file="CourseLogisticRequirements.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;


namespace TMS.Library.Entities.Common.Configuration
{
    /// <summary>
    /// Class CourseLogisticRequirements.
    /// </summary>
    public class CourseLogisticRequirements 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the primary requirement.
        /// </summary>
        /// <value>The name of the primary requirement.</value>
        [Display(Name = "CourseLogisticRequirementsPrimaryRequirementName", ResourceType = typeof(lr))]
        public string PrimaryRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary requirement.
        /// </summary>
        /// <value>The name of the secondary requirement.</value>
        [Display(Name = "CourseLogisticRequirementsSecondaryRequirementName", ResourceType = typeof(lr))]
        public string SecondaryRequirementName { get; set; }


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        

        //public void MapProperties(DbDataReader dr)
        //{
        //    ID = dr.GetInt64("ID");
        //    PrimaryRequirementName = dr.GetString("PrimaryRequirementName");
        //    SecondaryRequirementName = dr.GetString("SecondaryRequirementName");
        //    CreatedBy = dr.GetInt64("CreatedBy");
        //    CreatedDate = dr.GetDateTime("CreatedDate");
        //    UpdatedBy = dr.GetInt64("UpdatedBy");
        //    UpdatedDate = dr.GetDateTime("UpdatedDate");
        //    IsDeleted = dr.GetBoolean("IsDeleted");
        //    IsActive = dr.GetBoolean("IsActive");
        //    AddedByAlias = dr.GetString("AddedByAlias");
        //}

    }

    public class CourseLogisticRequirementsMapping
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public long CourseID { get; set; }

        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
         [Display(Name = "CourseLogisticRequirementID", ResourceType = typeof(lr))]
        public long CourseLogisticRequirementID { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "PrimaryRequirementName", ResourceType = typeof(lr))]
        public string PrimaryRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>The person.</value>
        public string UpdatedByAlias { get; set; }
        /// 

    }
}
//