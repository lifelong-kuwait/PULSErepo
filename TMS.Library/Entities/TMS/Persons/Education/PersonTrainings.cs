// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-05-2016
// ***********************************************************************
// <copyright file="PersonTrainings.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

/// <summary>
/// The Education namespace.
/// </summary>
namespace TMS.Library.TMS.Persons.Education
{
    /// <summary>
    /// Class PersonTrainings.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonTrainings : IDataMapper
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
        /// Gets or sets the training p title.
        /// </summary>
        /// <value>The training p title.</value>
        [Display(Name = "PersonEducationTrainingPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingPrimaryTitleRequired")]
        public string TrainingP_Title { get; set; }

        /// <summary>
        /// Gets or sets the training s title.
        /// </summary>
        /// <value>The training s title.</value>
        [Display(Name = "PersonEducationTrainingSecondaryTitle", ResourceType = typeof(lr))]
        public string TrainingS_Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the training.
        /// </summary>
        /// <value>The type of the training.</value>
        public TrainingType TrainingType { get; set; }

        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>The type of the duration.</value>
        [Display(Name = "PersonEducationTrainingDuration", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingDurationOptionalLabel")]
        public CourseDurationType DurationType { get; set; }

        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        [Display(Name = "PersonEducationTrainingDuration", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingDurationRequired")]
        [Range(1, 1000, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingDurationRange")]
        public int CourseDuration { get; set; }

        /// <summary>
        /// Gets or sets the course outline.
        /// </summary>
        /// <value>The course outline.</value>
        public string CourseOutline { get; set; }

        /// <summary>
        /// Gets or sets the learning objective.
        /// </summary>
        /// <value>The learning objective.</value>
        [Display(Name = "PersonEducationTrainingLearningObjective", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingLearningObjectiveRequired")]
        public string LearningObjective { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>The name of the client.</value>
        [Display(Name = "PersonEducationTrainingClientName", ResourceType = typeof(lr))]
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the name of the client reference Persons.
        /// </summary>
        /// <value>The name of the client reference Persons.</value>
        [Display(Name = "PersonEducationTrainingReferenceName", ResourceType = typeof(lr))]
        public string ClientReferencePersonsName { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons title.
        /// </summary>
        /// <value>The client reference Persons title.</value>
        [Display(Name = "PersonEducationTrainingReferenceTitle", ResourceType = typeof(lr))]
        public string ClientReferencePersonsTitle { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons phone.
        /// </summary>
        /// <value>The client reference Persons phone.</value>
        [Display(Name = "PersonEducationTrainingReferencePhone", ResourceType = typeof(lr))]
        public string ClientReferencePersonsPhone { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons email.
        /// </summary>
        /// <value>The client reference Persons email.</value>
        [Display(Name = "PersonEducationTrainingReferenceEmail", ResourceType = typeof(lr))]
        public string ClientReferencePersonsEmail { get; set; }

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
            TrainingP_Title = dr.GetString("TrainingP_Title");
            TrainingS_Title = dr.GetString("TrainingS_Title");
            TrainingType = (TrainingType)dr.GetInt32("TrainingType");
            DurationType = (CourseDurationType)dr.GetInt32("DurationType");
            CourseDuration = dr.GetInt32("CourseDuration");
            CourseOutline = dr.GetString("CourseOutline");
            LearningObjective = dr.GetString("LearningObjective");
            ClientName = dr.GetString("ClientName");
            ClientReferencePersonsName = dr.GetString("ClientReferencePersonsName");
            ClientReferencePersonsTitle = dr.GetString("ClientReferencePersonsTitle");
            ClientReferencePersonsPhone = dr.GetString("ClientReferencePersonsPhone");
            ClientReferencePersonsEmail = dr.GetString("ClientReferencePersonsEmail");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }

    /// <summary>
    /// Class PersonSuggestedTrainings.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonSuggestedTrainings : IDataMapper
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
        /// Gets or sets the training p title.
        /// </summary>
        /// <value>The training p title.</value>
        [Display(Name = "PersonEducationTrainingPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingPrimaryTitleRequired")]
        public string TrainingP_Title { get; set; }

        /// <summary>
        /// Gets or sets the training s title.
        /// </summary>
        /// <value>The training s title.</value>
        [Display(Name = "PersonEducationTrainingSecondaryTitle", ResourceType = typeof(lr))]
        public string TrainingS_Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the training.
        /// </summary>
        /// <value>The type of the training.</value>
        public TrainingType TrainingType { get; set; }

        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>The type of the duration.</value>
        [Display(Name = "PersonEducationTrainingDuration", ResourceType = typeof(lr))]
        
        public CourseDurationType DurationType { get; set; }

        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        [Display(Name = "PersonEducationTrainingDuration", ResourceType = typeof(lr))]
       
        public int CourseDuration { get; set; }

        /// <summary>
        /// Gets or sets the course outline.
        /// </summary>
        /// <value>The course outline.</value>
        [Display(Name = "PersonEducationTrainingCourseOutline", ResourceType = typeof(lr))]
          [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingCourseOutlineRequired")]
        public string CourseOutline { get; set; }

        /// <summary>
        /// Gets or sets the learning objective.
        /// </summary>
        /// <value>The learning objective.</value>
        [Display(Name = "PersonEducationTrainingLearningObjective", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonEducationTrainingLearningObjectiveRequired")]
        public string LearningObjective { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>The name of the client.</value>
        [Display(Name = "PersonEducationTrainingClientName", ResourceType = typeof(lr))]
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the name of the client reference Persons.
        /// </summary>
        /// <value>The name of the client reference Persons.</value>
        [Display(Name = "PersonEducationTrainingReferenceName", ResourceType = typeof(lr))]
        public string ClientReferencePersonsName { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons title.
        /// </summary>
        /// <value>The client reference Persons title.</value>
        [Display(Name = "PersonEducationTrainingReferenceTitle", ResourceType = typeof(lr))]
        public string ClientReferencePersonsTitle { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons phone.
        /// </summary>
        /// <value>The client reference Persons phone.</value>
        [Display(Name = "PersonEducationTrainingReferencePhone", ResourceType = typeof(lr))]
        public string ClientReferencePersonsPhone { get; set; }

        /// <summary>
        /// Gets or sets the client reference Persons email.
        /// </summary>
        /// <value>The client reference Persons email.</value>
        [Display(Name = "PersonEducationTrainingReferenceEmail", ResourceType = typeof(lr))]
        public string ClientReferencePersonsEmail { get; set; }

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
            TrainingP_Title = dr.GetString("TrainingP_Title");
            TrainingS_Title = dr.GetString("TrainingS_Title");
            TrainingType = (TrainingType)dr.GetInt32("TrainingType");
            DurationType = (CourseDurationType)dr.GetInt32("DurationType");
            CourseDuration = dr.GetInt32("CourseDuration");
            CourseOutline = dr.GetString("CourseOutline");
            LearningObjective = dr.GetString("LearningObjective");
            ClientName = dr.GetString("ClientName");
            ClientReferencePersonsName = dr.GetString("ClientReferencePersonsName");
            ClientReferencePersonsTitle = dr.GetString("ClientReferencePersonsTitle");
            ClientReferencePersonsPhone = dr.GetString("ClientReferencePersonsPhone");
            ClientReferencePersonsEmail = dr.GetString("ClientReferencePersonsEmail");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}