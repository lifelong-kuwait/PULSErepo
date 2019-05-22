// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="WorkExperiences.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Persons.Education
{
    /// <summary>
    /// Class WorkExperiences.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class WorkExperiences : IDataMapper
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
        public long PersonID { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [Display(Name = "PersonEducationWorkExperiencesCompanyName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesCompanyNameRequired")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>The organization identifier.</value>
        [Display(Name = "PersonEducationWorkExperiencesCompanyName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesCompanyNameRequired")]
        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the p title.
        /// </summary>
        /// <value>The p title.</value>
        [Display(Name = "PersonEducationWorkExperiencesPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesPrimaryTitleRequired")]
        public string P_Title { get; set; }

        /// <summary>
        /// Gets or sets the s title.
        /// </summary>
        /// <value>The s title.</value>
        [Display(Name = "PersonEducationWorkExperiencesSecondaryTitle", ResourceType = typeof(lr))]
        public string S_Title { get; set; }

        /// <summary>
        /// Gets or sets the job status.
        /// </summary>
        /// <value>The job status.</value>
        [Display(Name = "PersonEducationWorkExperiencesJobStatus", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesJobStatusRequired")]
        public PersonJobStatus JobStatus { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Display(Name = "PersonEducationWorkExperiencesLocation", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesLocationRequired")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the start time period.
        /// </summary>
        /// <value>The start time period.</value>
        [Display(Name = "PersonEducationWorkExperiencesFrom", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesTimeFromRequired")]
        public DateTime StartTimePeriod { get; set; }

        /// <summary>
        /// Gets or sets the end time period.
        /// </summary>
        /// <value>The end time period.</value>
        [Display(Name = "PersonEducationWorkExperiencesTo", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationWorkExperiencesTimeToRequired")]
        public DateTime EndTimePeriod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is current.
        /// </summary>
        /// <value><c>true</c> if this instance is current; otherwise, <c>false</c>.</value>
        [Display(Name = "PersonEducationWorkExperiencesPresent", ResourceType = typeof(lr))]
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference.
        /// </summary>
        /// <value>The name of the reference.</value>
        [Display(Name = "PersonEducationWorkExperiencesReferenceName", ResourceType = typeof(lr))]
        public string ReferenceName { get; set; }

        /// <summary>
        /// Gets or sets the reference email.
        /// </summary>
        /// <value>The reference email.</value>
        [Display(Name = "PersonEducationWorkExperiencesReferenceEmail", ResourceType = typeof(lr))]
        public string ReferenceEmail { get; set; }

        /// <summary>
        /// Gets or sets the reference phone.
        /// </summary>
        /// <value>The reference phone.</value>
        [Display(Name = "PersonEducationWorkExperiencesReferencePhone", ResourceType = typeof(lr))]
        public string ReferencePhone { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "PersonEducationWorkExperiencesDescription", ResourceType = typeof(lr))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the relation.
        /// </summary>
        /// <value>The type of the relation.</value>
        [Display(Name = "PersonWorkExperienceRelationToOrganization", ResourceType = typeof(lr))]
        public PersonWorkExperienceRelationToOrganization RelationType { get; set; }

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
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            PersonID = dr.GetInt64("PersonID");
            CompanyName = dr.GetString("CompanyName");
            OrganizationID = dr.GetInt64("OrganizationID");
            P_Title = dr.GetString("P_Title");
            S_Title = dr.GetString("S_Title");
            JobStatus = (PersonJobStatus)dr.GetInt32("JobStatus");
            RelationType = (PersonWorkExperienceRelationToOrganization)dr.GetInt32("RelationType");
            Location = dr.GetString("Location");
            StartTimePeriod = dr.GetDateTime("StartTimePeriod");
            EndTimePeriod = dr.GetDateTime("EndTimePeriod");
            IsCurrent = dr.GetBoolean("IsCurrent");
            ReferenceName = dr.GetString("ReferenceName");
            ReferenceEmail = dr.GetString("ReferenceEmail");
            ReferencePhone = dr.GetString("ReferencePhone");
            Description = dr.GetString("Description");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}