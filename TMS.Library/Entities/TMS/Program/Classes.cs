//// ***********************************************************************
//// Assembly         : TMS.Library
//// Author           : Almas Shabbir
//// Created          : 12-17-2017
////
//// Last Modified By : Almas Shabbir
//// Last Modified On : 01-07-2018
//// ***********************************************************************
//// <copyright file="Classes.cs" company="LifeLong www.lifelongkuwait.com">
////     Copyright ©  2016
//// </copyright>
//// <summary></summary>
//// ***********************************************************************
//using System;
//using System.ComponentModel.DataAnnotations;
//using TMS.Library.Core.Validation.Kendo;
//using TMS.Library.TMS.Persons;
//using lr = Resources.Resources;

//namespace TMS.Library.Entities.TMS.Program
//{
//    /// <summary>
//    /// Class Classes.
//    /// </summary>
//    public class Classes
//    {
//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long ID { get; set; }

//        /// <summary>
//        /// Gets or sets the primary class title.
//        /// </summary>
//        /// <value>The primary class title.</value>
//        [Display(Name = "ClassPrimaryTitle", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassPrimaryTitleRequired")]
//        public string PrimaryClassTitle { get; set; }

//        /// <summary>
//        /// Gets or sets the secondary class title.
//        /// </summary>
//        /// <value>The secondary class title.</value>
//        [Display(Name = "ClassSecondaryTitle", ResourceType = typeof(lr))]
//        public string SecondaryClassTitle { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the class.
//        /// </summary>
//        /// <value>The name of the class.</value>
//        [Display(Name = "ClassName", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassNameRequired")]
//        public string ClassName { get; set; }

//        /// <summary>
//        /// Gets or sets the course identifier.
//        /// </summary>
//        /// <value>The course identifier.</value>
//        [Display(Name = "ClassCourse", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassCourseRequired")]
//        public long CourseID { get; set; }

//        /// <summary>
//        /// Gets or sets the language identifier.
//        /// </summary>
//        /// <value>The language identifier.</value>
//        [Display(Name = "ClassLanguage", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassLanguageRequired")]
//        public int LanguageID { get; set; }

//        /// <summary>
//        /// Gets or sets the class type identifier.
//        /// </summary>
//        /// <value>The class type identifier.</value>
//        [Display(Name = "ClassType", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassTypeRequired")]
//        public ClassType ClassTypeID { get; set; }


//        public long OrganizationID { get; set; }

//        /// <summary>
//        /// Gets or sets the duration of the class.
//        /// </summary>
//        /// <value>The duration of the class.</value>
//        [Display(Name = "ClassDuration", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDurationRequired")]
//        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
//        public int ClassDuration { get; set; }

//        /// <summary>
//        /// Gets or sets the type of the class duration.
//        /// </summary>
//        /// <value>The type of the class duration.</value>
//        [Display(Name = "CourseDurationType", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDurationTypeRequired")]
//        public CourseDurationType ClassDurationType { get; set; }

//        /// <summary>
//        /// Gets or sets the start date.
//        /// </summary>
//        /// <value>The start date.</value>
//        [Display(Name = "ClassStartDate", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassStartDateRequired")]
//        public DateTime StartDate { get; set; }

//        /// <summary>
//        /// Gets or sets the end date.
//        /// </summary>
//        /// <value>The end date.</value>
//        [Display(Name = "ClassEndDate", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassEndDateRequired")]
//        [GreaterDate(EarlierDateField = "StartDate", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "EndDateShouldBeGreaterThanStartDate")]
//        public DateTime EndDate { get; set; }

//        /// <summary>
//        /// Gets or sets the start time.
//        /// </summary>
//        /// <value>The start time.</value>
//        [Display(Name = "SessionStartTime", ResourceType = typeof(lr))]
//        public DateTime StartTime { get; set; }

//        /// <summary>
//        /// Gets or sets the start time string.
//        /// </summary>
//        /// <value>The start time string.</value>
//        [Display(Name = "SessionStartTime", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionStartTimeRequired")]
//        public string StartTimeString { get; set; }

//        /// <summary>
//        /// Gets or sets the end time.
//        /// </summary>
//        /// <value>The end time.</value>
//        [Display(Name = "SessionEndTime", ResourceType = typeof(lr))]
//        public DateTime EndTime { get; set; }

//        /// <summary>
//        /// Gets or sets the end time string.
//        /// </summary>
//        /// <value>The end time string.</value>
//        [Display(Name = "SessionEndTime", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionEndTimeRequired")]
//        [GreaterDate(EarlierDateField = "StartTimeString", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "EndDateShouldBeGreaterThanStartDate")]
//        public string EndTimeString { get; set; }

//        /// <summary>
//        /// Gets or sets the evaluation link.
//        /// </summary>
//        /// <value>The evaluation link.</value>
//        [Display(Name = "ClassEvaluationLink", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassEvalutionlinkRequired")]
//        public string EvaluationLink { get; set; }

//        /// <summary>
//        /// Gets or sets the follow up.
//        /// </summary>
//        /// <value>The follow up.</value>
//        [Display(Name = "ClassFollowUp", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassFollowUpRequired")]
//        public string FollowUp { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether [follow up completed].
//        /// </summary>
//        /// <value><c>true</c> if [follow up completed]; otherwise, <c>false</c>.</value>
//        [Display(Name = "ClassFollowUpCompleted", ResourceType = typeof(lr))]
//        public bool FollowUpCompleted { get; set; }

//        /// <summary>
//        /// Gets or sets the minimum attendance requirement.
//        /// </summary>
//        /// <value>The minimum attendance requirement.</value>
//        [Display(Name = "ClassMinimumAttendanceRequirement", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMinimumAttendanceRequirementRequired")]
//        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroLessThanHundredRange")]
//        public int MinimumAttendanceRequirement { get; set; }

//        /// <summary>
//        /// Gets or sets the maximum session per day.
//        /// </summary>
//        /// <value>The maximum session per day.</value>
//        [Display(Name = "ClassMaximumSessionPerDay", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMaximumSessionPerDayRequired")]
//        [Range(0.01, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
//        public int MaximumSessionPerDay { get; set; }

//        /// <summary>
//        /// Gets or sets the minimum trainee.
//        /// </summary>
//        /// <value>The minimum trainee.</value>
//        [Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMinimumTraineeRequired")]
//        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
//        public int MinimumTrainee { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether [send emails].
//        /// </summary>
//        /// <value><c>true</c> if [send emails]; otherwise, <c>false</c>.</value>
//        [Display(Name = "ClassSendEmail", ResourceType = typeof(lr))]
//        public bool SendEmails { get; set; }

//        /// <summary>
//        /// Gets or sets the class fee.
//        /// </summary>
//        /// <value>The class fee.</value>
//        [Display(Name = "ClassFee", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassFeeRequired")]
//        [Range(0.01, float.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
//        public float ClassFee { get; set; }

//        /// <summary>
//        /// Gets or sets the fee currency.
//        /// </summary>
//        /// <value>The fee currency.</value>
//        [Display(Name = "CourseFeeCurrency", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseFeeCurrencyRequired")]
//        public int FeeCurrency { get; set; }

//        //
//        /// <summary>
//        /// Gets or sets the discount.
//        /// </summary>
//        /// <value>The discount.</value>
//        [Display(Name = "ClassDiscount", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDiscountRequired")]
//        [Range(0.01, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroLessThanHundredRange")]
//        public float Discount { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether [default discount].
//        /// </summary>
//        /// <value><c>true</c> if [default discount]; otherwise, <c>false</c>.</value>
//        [Display(Name = "ClassDefaultDiscount", ResourceType = typeof(lr))]
//        public bool DefaultDiscount { get; set; }

//        /// <summary>
//        /// Gets or sets the translation required identifier.
//        /// </summary>
//        /// <value>The translation required identifier.</value>
//        [Display(Name = "ClassTranslationRequired", ResourceType = typeof(lr))]
//        public long TranslationRequiredID { get; set; }

//        /// <summary>
//        /// Gets or sets the vendor identifier.
//        /// </summary>
//        /// <value>The vendor identifier.</value>
//        public long VendorID { get; set; }

//        /// <summary>
//        /// Gets or sets the created by.
//        /// </summary>
//        /// <value>The created by.</value>
//        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
//        public long CreatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the created date.
//        /// </summary>
//        /// <value>The created date.</value>
//        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
//        public DateTime CreatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated by.
//        /// </summary>
//        /// <value>The updated by.</value>
//        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
//        public long UpdatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the updated date.
//        /// </summary>
//        /// <value>The updated date.</value>
//        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
//        public DateTime UpdatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is deleted.
//        /// </summary>
//        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
//        public bool IsDeleted { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is active.
//        /// </summary>
//        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
//        [Display(Name = "IsActive", ResourceType = typeof(lr))]
//        public bool IsActive { get; set; }

//        /// <summary>
//        /// Gets or sets the added by alias.
//        /// </summary>
//        /// <value>The added by alias.</value>
//        public string AddedByAlias { get; set; }
//        /// <summary>
//        /// Gets or sets the name of the course.
//        /// </summary>
//        /// <value>The name of the course.</value>
//        public string CourseName { get; set; }
//    }

//    /// <summary>
//    /// Class SessionCreationRules.
//    /// </summary>
//    public class SessionCreationRules
//    {
//        /// <summary>
//        /// Gets or sets a value indicating whether [minimum trainee not added].
//        /// </summary>
//        /// <value><c>true</c> if [minimum trainee not added]; otherwise, <c>false</c>.</value>
//        public bool MinTraineeNotAdded { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is last session exist.
//        /// </summary>
//        /// <value><c>true</c> if this instance is last session exist; otherwise, <c>false</c>.</value>
//        public bool IsLastSessionExist { get; set; }
//        /// <summary>
//        /// Gets or sets the start time string.
//        /// </summary>
//        /// <value>The start time string.</value>
//        public string StartTimeString { get; set; }
//        /// <summary>
//        /// Gets or sets the end time string.
//        /// </summary>
//        /// <value>The end time string.</value>
//        public string EndTimeString { get; set; }
//        /// <summary>
//        /// Gets or sets the name of the class.
//        /// </summary>
//        /// <value>The name of the class.</value>
//        public string ClassName { get; set; }
//        /// <summary>
//        /// Gets or sets the count.
//        /// </summary>
//        /// <value>The count.</value>
//        public int Count { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether [maximum session limit reached].
//        /// </summary>
//        /// <value><c>true</c> if [maximum session limit reached]; otherwise, <c>false</c>.</value>
//        public bool MaximumSessionLimitReached { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is valid session date time.
//        /// </summary>
//        /// <value><c>true</c> if this instance is valid session date time; otherwise, <c>false</c>.</value>
//        public bool IsValidSessionDateTime { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is valid schedule date.
//        /// </summary>
//        /// <value><c>true</c> if this instance is valid schedule date; otherwise, <c>false</c>.</value>
//        public bool IsValidScheduleDate { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is valid trainer time.
//        /// </summary>
//        /// <value><c>true</c> if this instance is valid trainer time; otherwise, <c>false</c>.</value>
//        public bool IsValidTrainerTime { get; set; }
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is valid venue time.
//        /// </summary>
//        /// <value><c>true</c> if this instance is valid venue time; otherwise, <c>false</c>.</value>
//        public bool IsValidVenueTime { get; set; }

//        /// <summary>
//        /// Gets or sets the conflict names.
//        /// </summary>
//        /// <value>The conflict names.</value>
//        public string ConflictNames { get; set; }
//    }

//    /// <summary>
//    /// Class ClassTraineeMapping.
//    /// </summary>
//    public class ClassTraineeMapping
//    {
//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long ID { get; set; }

//        /// <summary>
//        /// Gets or sets the person identifier.
//        /// </summary>
//        /// <value>The person identifier.</value>
//        public long PersonID { get; set; }

//        /// <summary>
//        /// Gets or sets the class identifier.
//        /// </summary>
//        /// <value>The class identifier.</value>
//        public long ClassID { get; set; }

//        /// <summary>
//        /// Gets or sets the created by.
//        /// </summary>
//        /// <value>The created by.</value>
//        public long CreatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the created date.
//        /// </summary>
//        /// <value>The created date.</value>
//        public DateTime CreatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated date.
//        /// </summary>
//        /// <value>The updated date.</value>
//        public DateTime? UpdatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated by.
//        /// </summary>
//        /// <value>The updated by.</value>
//        public long? UpdatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is deleted.
//        /// </summary>
//        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
//        public bool IsDeleted { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is active.
//        /// </summary>
//        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
//        public bool IsActive { get; set; }
//        /// <summary>
//        /// Gets or sets the added by alias.
//        /// </summary>
//        /// <value>The added by alias.</value>
//        public string AddedByAlias { get; set; }
//        /// <summary>
//        /// Gets or sets the person.
//        /// </summary>
//        /// <value>The person.</value>
//        public Person Person { get; set; }
//    }


//    /// <summary>
//    /// Class ClassTrainerMapping.
//    /// </summary>
//    public class ClassTrainerMapping
//    {
//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long ID { get; set; }

//        /// <summary>
//        /// Gets or sets the person identifier.
//        /// </summary>
//        /// <value>The person identifier.</value>
//        public long PersonID { get; set; }

//        /// <summary>
//        /// Gets or sets the class identifier.
//        /// </summary>
//        /// <value>The class identifier.</value>
//        public long ClassID { get; set; }

//        /// <summary>
//        /// Gets or sets the created by.
//        /// </summary>
//        /// <value>The created by.</value>
//        public long CreatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the created date.
//        /// </summary>
//        /// <value>The created date.</value>
//        public DateTime CreatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated date.
//        /// </summary>
//        /// <value>The updated date.</value>
//        public DateTime? UpdatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated by.
//        /// </summary>
//        /// <value>The updated by.</value>
//        public long? UpdatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is deleted.
//        /// </summary>
//        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
//        public bool IsDeleted { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is active.
//        /// </summary>
//        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
//        public bool IsActive { get; set; }
//        /// <summary>
//        /// Gets or sets the added by alias.
//        /// </summary>
//        /// <value>The added by alias.</value>
//        public string AddedByAlias { get; set; }
//        /// <summary>
//        /// Gets or sets the person.
//        /// </summary>
//        /// <value>The person.</value>
//        public Person Person { get; set; }
//    }
//}

// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-17-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="Classes.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using TMS.Library.Core.Validation.Kendo;
using TMS.Library.TMS.Persons;
using lr = Resources.Resources;

namespace TMS.Library.Entities.TMS.Program
{
    /// <summary>
    /// Class Classes.
    /// </summary>
    public class Classes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the primary class title.
        /// </summary>
        /// <value>The primary class title.</value>
        [Display(Name = "ClassPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassPrimaryTitleRequired")]
        public string PrimaryClassTitle { get; set; }

        /// <summary>
        /// Gets or sets the secondary class title.
        /// </summary>
        /// <value>The secondary class title.</value>
        [Display(Name = "ClassSecondaryTitle", ResourceType = typeof(lr))]
        public string SecondaryClassTitle { get; set; }

        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        [Display(Name = "ClassName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassNameRequired")]
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>The course identifier.</value>
        [Display(Name = "ClassCourse", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassCourseRequired")]
        public long CourseID { get; set; }

        /// <summary>
        /// Gets or sets the language identifier.
        /// </summary>
        /// <value>The language identifier.</value>
        [Display(Name = "ClassLanguage", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassLanguageRequired")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Gets or sets the class type identifier.
        /// </summary>
        /// <value>The class type identifier.</value>
        [Display(Name = "ClassType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassTypeRequired")]
        public ClassType ClassTypeID { get; set; }


        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the duration of the class.
        /// </summary>
        /// <value>The duration of the class.</value>
        [Display(Name = "ClassDuration", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDurationRequired")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
        public int ClassDuration { get; set; }

        /// <summary>
        /// Gets or sets the type of the class duration.
        /// </summary>
        /// <value>The type of the class duration.</value>
        [Display(Name = "CourseDurationType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDurationTypeRequired")]
        public CourseDurationType ClassDurationType { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Display(Name = "ClassStartDate", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassStartDateRequired")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [Display(Name = "ClassEndDate", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassEndDateRequired")]
        [GreaterDate(EarlierDateField = "StartDate", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "EndDateShouldBeGreaterThanStartDate")]
        public DateTime EndDate { get; set; }

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
        /// Gets or sets the evaluation link.
        /// </summary>
        /// <value>The evaluation link.</value>
        [Display(Name = "ClassEvaluationLink", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassEvalutionlinkRequired")]
        public string EvaluationLink { get; set; }

        /// <summary>
        /// Gets or sets the follow up.
        /// </summary>
        /// <value>The follow up.</value>
        [Display(Name = "ClassFollowUp", ResourceType = typeof(lr))]
      //  [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassFollowUpRequired")]
        public string FollowUp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [follow up completed].
        /// </summary>
        /// <value><c>true</c> if [follow up completed]; otherwise, <c>false</c>.</value>
        [Display(Name = "ClassFollowUpCompleted", ResourceType = typeof(lr))]
        public bool FollowUpCompleted { get; set; }

        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        [Display(Name = "ClassMinimumAttendanceRequirement", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMinimumAttendanceRequirementRequired")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroLessThanHundredRange")]
        public int MinimumAttendanceRequirement { get; set; }

        /// <summary>
        /// Gets or sets the maximum session per day.
        /// </summary>
        /// <value>The maximum session per day.</value>
        [Display(Name = "ClassMaximumSessionPerDay", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMaximumSessionPerDayRequired")]
        [Range(0.01, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
        public int MaximumSessionPerDay { get; set; }

        /// <summary>
        /// Gets or sets the minimum trainee.
        /// </summary>
        /// <value>The minimum trainee.</value>
        [Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassMinimumTraineeRequired")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
        public int MinimumTrainee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [send emails].
        /// </summary>
        /// <value><c>true</c> if [send emails]; otherwise, <c>false</c>.</value>
        [Display(Name = "ClassSendEmail", ResourceType = typeof(lr))]
        public bool SendEmails { get; set; }

        /// <summary>
        /// Gets or sets the class fee.
        /// </summary>
        /// <value>The class fee.</value>
        [Display(Name = "ClassFee", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassFeeRequired")]
        [Range(0.01, float.MaxValue, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroRange")]
        public float ClassFee { get; set; }

        /// <summary>
        /// Gets or sets the fee currency.
        /// </summary>
        /// <value>The fee currency.</value>
        [Display(Name = "CourseFeeCurrency", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseFeeCurrencyRequired")]
        public int FeeCurrency { get; set; }

        //
        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        [Display(Name = "ClassDiscount", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ClassDiscountRequired")]
        [Range(0.0, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GeneralGreaterThanZeroLessThanHundredRange")]
        public float Discount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [default discount].
        /// </summary>
        /// <value><c>true</c> if [default discount]; otherwise, <c>false</c>.</value>
        [Display(Name = "ClassDefaultDiscount", ResourceType = typeof(lr))]
        public bool DefaultDiscount { get; set; }

        /// <summary>
        /// Gets or sets the translation required identifier.
        /// </summary>
        /// <value>The translation required identifier.</value>
        [Display(Name = "ClassTranslationRequired", ResourceType = typeof(lr))]
        public long TranslationRequiredID { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>The vendor identifier.</value>
        public long VendorID { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>The name of the course.</value>
        public string CourseName { get; set; }
        public string UpdatedByAlias { get; set; }
        
    }

    /// <summary>
    /// Class SessionCreationRules.
    /// </summary>
    public class SessionCreationRules
    {
        /// <summary>
        /// Gets or sets a value indicating whether [minimum trainee not added].
        /// </summary>
        /// <value><c>true</c> if [minimum trainee not added]; otherwise, <c>false</c>.</value>
        public bool MinTraineeNotAdded { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is last session exist.
        /// </summary>
        /// <value><c>true</c> if this instance is last session exist; otherwise, <c>false</c>.</value>
        public bool IsLastSessionExist { get; set; }
        /// <summary>
        /// Gets or sets the start time string.
        /// </summary>
        /// <value>The start time string.</value>
        public string StartTimeString { get; set; }
        /// <summary>
        /// Gets or sets the end time string.
        /// </summary>
        /// <value>The end time string.</value>
        public string EndTimeString { get; set; }
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [maximum session limit reached].
        /// </summary>
        /// <value><c>true</c> if [maximum session limit reached]; otherwise, <c>false</c>.</value>
        public bool MaximumSessionLimitReached { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid session date time.
        /// </summary>
        /// <value><c>true</c> if this instance is valid session date time; otherwise, <c>false</c>.</value>
        public bool IsValidSessionDateTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid schedule date.
        /// </summary>
        /// <value><c>true</c> if this instance is valid schedule date; otherwise, <c>false</c>.</value>
        public bool IsValidScheduleDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid trainer time.
        /// </summary>
        /// <value><c>true</c> if this instance is valid trainer time; otherwise, <c>false</c>.</value>
        public bool IsValidTrainerTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid venue time.
        /// </summary>
        /// <value><c>true</c> if this instance is valid venue time; otherwise, <c>false</c>.</value>
        public bool IsValidVenueTime { get; set; }

        /// <summary>
        /// Gets or sets the conflict names.
        /// </summary>
        /// <value>The conflict names.</value>
        public string ConflictNames { get; set; }
        /// <summary>
        /// Gets or sets the conflict names.
        /// </summary>
        /// <value>The conflict names.</value>
        public bool IsValidVenueAvailabilityTime { get; set; }
    }

    /// <summary>
    /// Class ClassTraineeMapping.
    /// </summary>
    public class ClassTraineeMapping
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
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public long ClassID { get; set; }

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
        public DateTime UpdatedDate { get; set; }

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
        public string UpdatedByAlias { get; set; }

        
        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>The person.</value>
        public Person Person { get; set; }
    }


    /// <summary>
    /// Class ClassTrainerMapping.
    /// </summary>
    public class ClassTrainerMapping
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
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public long ClassID { get; set; }

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
        public Person Person { get; set; }
    }
}