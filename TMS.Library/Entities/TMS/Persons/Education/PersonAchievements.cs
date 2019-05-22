// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-05-2016
// ***********************************************************************
// <copyright file="PersonAchievements.cs" company="LifeLong www.lifelongkuwait.com">
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
    /// Class PersonAchievements.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonAchievements : IDataMapper
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
        [Display(Name = "PersonEducationAchievementPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationAchievementPrimaryTitleRequired", ErrorMessageResourceType = typeof(lr))]
        public string P_Title { get; set; }

        /// <summary>
        /// Gets or sets the s title.
        /// </summary>
        /// <value>The s title.</value>
        [Display(Name = "PersonEducationAchievementSecondaryTitle", ResourceType = typeof(lr))]
        public string S_Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Display(Name = "PersonEducationAchievementType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationAchievementTypeRequired", ErrorMessageResourceType = typeof(lr))]
        public AchievementType Type { get; set; }

        /// <summary>
        /// Gets or sets the announced date.
        /// </summary>
        /// <value>The announced date.</value>
        [Display(Name = "PersonEducationAchievementAnnouncedDate", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationAchievementAnnouncedDateRequired", ErrorMessageResourceType = typeof(lr))]
        public DateTime AnnouncedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "PersonEducationAchievementDescription", ResourceType = typeof(lr))]
        public string Description { get; set; }

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
            P_Title = dr.GetString("P_Title");
            S_Title = dr.GetString("S_Title");
            Type = (AchievementType)dr.GetInt32("Type");
            AnnouncedDate = dr.GetDateTime("AnnouncedDate");
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