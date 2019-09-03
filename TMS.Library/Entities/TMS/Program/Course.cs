// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-14-2018
// ***********************************************************************
// <copyright file="Course.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.TMS
{
    /// <summary>
    /// Class Course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }


        /// <summary>
        /// Gets or sets the name of the primary.
        /// </summary>
        /// <value>The name of the primary.</value>
        [Display(Name = "PrimaryCourseName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PrimaryCourseNameRequired")]
        public string PrimaryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "SecondaryCourseName", ResourceType = typeof(lr))]
        public string SecondaryName { get; set; }

        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        [Display(Name = "CourseCategory", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public long CourseCategoryId { get; set; }
        public string CourseCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        [Display(Name = "CourseDuration", ResourceType = typeof(lr))]
        public int CourseDuration { get; set; }

        /// <summary>
        /// Gets or sets the type of the course duration.
        /// </summary>
        /// <value>The type of the course duration.</value>
        [Display(Name = "CourseDurationType", ResourceType = typeof(lr))]
        public CourseDurationType CourseDurationType { get; set; }

        /// <summary>
        /// Gets or sets the course vendor identifier.
        /// </summary>
        /// <value>The course vendor identifier.</value>
        [Display(Name = "CourseVendor", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseVendorRequired")]
        public long CourseVendorID { get; set; }


        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(Name = "CourseNotes", ResourceType = typeof(lr))]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        [Display(Name = "CourseMinimumAttendanceRequirement", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        [Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public float MinimumAttendanceRequirement { get; set; }

        /// <summary>
        /// Gets or sets the minimum trainee.
        /// </summary>
        /// <value>The minimum trainee.</value>
        [Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
        public int MinimumTrainee { get; set; }

        /// <summary>
        /// Gets or sets the course fee.
        /// </summary>
        /// <value>The course fee.</value>
        [Display(Name = "CourseFee", ResourceType = typeof(lr))]
        public float? CourseFee { get; set; }

        /// <summary>
        /// Gets or sets the fee currency.
        /// </summary>
        /// <value>The fee currency.</value>
        public long? FeeCurrency { get; set; }

        /// <summary>
        /// Gets or sets the course code.
        /// </summary>
        /// <value>The course code.</value>
        [Display(Name = "CourseCode", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCodeRequired")]
        public string CourseCode { get; set; }

        /// <summary>
        /// Gets or sets the sales commission.
        /// </summary>
        /// <value>The sales commission.</value>
        //  [Display(Name = "CourseSalesCommission", ResourceType = typeof(lr))]
        [Display(Name = "CourseSalesCommission", ResourceType = typeof(lr))]
        [Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public string SalesCommission { get; set; }

        /// <summary>
        /// Gets or sets the PreRequisites.
        /// </summary>
        /// <value>The  PreRequisites.</value>
        [Display(Name = "CoursePreRequisites", ResourceType = typeof(lr))]
        public string PreRequisites { get; set; }

        /// <summary>
        /// Gets or sets the feedback form identifier.
        /// </summary>
        /// <value>The feedback form identifier.</value>
        public long FeedbackFormID { get; set; }

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
        public Course Course { get; set; }
    }




}