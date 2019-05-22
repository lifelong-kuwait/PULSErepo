// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-04-2016
// ***********************************************************************
// <copyright file="PersonDegrees.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Education
{
    /// <summary>
    /// Class PersonDegrees.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonDegrees : IDataMapper
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
        /// Gets or sets the p title.
        /// </summary>
        /// <value>The p title.</value>
        [Display(Name = "PersonEducationDegreeTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeTitleRequired")]
        public string P_Title { get; set; }

        /// <summary>
        /// Gets or sets the s title.
        /// </summary>
        /// <value>The s title.</value>
        [Display(Name = "PersonEducationDegreeTitleSecondaryLanguage", ResourceType = typeof(lr))]
        public string S_Title { get; set; }

        /// <summary>
        /// Gets or sets the university.
        /// </summary>
        /// <value>The university.</value>
        [Display(Name = "PersonEducationDegreeUniversityInstitute", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeUniversityInstituteRequired")]
        public string University { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [Display(Name = "PersonEducationDegreeCGPAPercentageResult", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeCGPAPercentageResultRequired")]
        [Range(0.01, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeResultTypeRange")]
        public double Result { get; set; }

        /// <summary>
        /// Gets or sets the result type identifier.
        /// </summary>
        /// <value>The result type identifier.</value>
        [Display(Name = "PersonEducationDegreeCGPAPercentageResultType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeCGPAPercentageResultTypeRequired")]
        public ResultType ResultTypeID { get; set; }

        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        /// <value>The session.</value>
        [Display(Name = "PersonEducationDegreeSession", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeSessionRequired")]
        public string Session { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        [Display(Name = "PersonEducationDegreeDurationYear", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeDurationYearRequired")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the major.
        /// </summary>
        /// <value>The major.</value>
        [Display(Name = "PersonEducationDegreeMajors", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationDegreeMajorsRequired")]
        public string Major { get; set; }

        /// <summary>
        /// Gets or sets the degree status.
        /// </summary>
        /// <value>The degree status.</value>
        [Display(Name = "PersonEducationDegreeStatus")]
        public DegreeStatus DegreeStatus { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "Description", ResourceType = typeof(lr))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long? CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long? UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
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
            P_Title = dr.GetString("P_Title");
            S_Title = dr.GetString("S_Title");
            University = dr.GetString("University");
            Result = dr.GetDouble("Result");
            ResultTypeID = (ResultType)dr.GetInt32("ResultTypeID");
            Session = dr.GetString("Session");
            Duration = dr.GetInt32("Duration");
            Major = dr.GetString("Major");
            DegreeStatus = (DegreeStatus)dr.GetInt32("DegreeStatus");
            Description = dr.GetString("Description");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}