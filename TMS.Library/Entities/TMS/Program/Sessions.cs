// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-25-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="Sessions.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.Entities.TMS.Program
{
    /// <summary>
    /// Class Sessions.
    /// </summary>
    public class Sessions
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the session.
        /// </summary>
        /// <value>The name of the session.</value>
        [Display(Name = "SessionName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionNameRequired")]
        public string SessionName { get; set; }

        //

        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        [Display(Name = "SessionClass", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionClassRequired")]
        public long ClassID { get; set; }

        /// <summary>
        /// Gets or sets the language identifier.
        /// </summary>
        /// <value>The language identifier.</value>
        [Display(Name = "ClassLanguage", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassLanguageRequired")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Gets or sets the schedule date.
        /// </summary>
        /// <value>The schedule date.</value>
        [Display(Name = "SessionScheduleDate", ResourceType = typeof(lr))]
        public DateTime ScheduleDate { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        [Display(Name = "SessionStartTime", ResourceType = typeof(lr))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the start time string.
        /// </summary>
        /// <value>The start time string.</value>
        [Display(Name = "SessionStartTime", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionStartTimeRequired")]
        public string StartTimeString { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        [Display(Name = "SessionEndTime", ResourceType = typeof(lr))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the end time string.
        /// </summary>
        /// <value>The end time string.</value>
        [Display(Name = "SessionEndTime", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionEndTimeRequired")]
        public string EndTimeString { get; set; }

        /// <summary>
        /// Gets or sets the trainer identifier.
        /// </summary>
        /// <value>The trainer identifier.</value>
        [Display(Name = "Trainer", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "TrainerRequired")]
        [Range(1, long.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "TrainerRequired")]
        public long TrainerID { get; set; }

        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is last session.
        /// </summary>
        /// <value><c>true</c> if this instance is last session; otherwise, <c>false</c>.</value>
        [Display(Name = "SessionIsLastSession", ResourceType = typeof(lr))]
        public bool IsLastSession { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lecture conducted].
        /// </summary>
        /// <value><c>true</c> if [lecture conducted]; otherwise, <c>false</c>.</value>
        [Display(Name = "SessionLectureConducted", ResourceType = typeof(lr))]
        public bool LectureConducted { get; set; }

        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>The venue identifier.</value>
        [Display(Name = "VenueName", ResourceType = typeof(lr))]
     //   [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueOpenTypeRequired")]
        public long VenueID { get; set; }

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
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }

        public string UpdatedByAlias { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the name of the trainer.
        /// </summary>
        /// <value>The name of the trainer.</value>
        public string TrainerName { get; set; }
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>The name of the course.</value>
        public string CourseName { get; set; }
        /// <summary>
        /// Gets or sets the name of the venue.
        /// </summary>
        /// <value>The name of the venue.</value>
        public string VenueName { get; set; }

        public bool? IsAttendanceMarked { get; set; }
    }
}