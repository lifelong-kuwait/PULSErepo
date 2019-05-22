// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="EmailTemplates.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Common;
using TMS.Library.ModelMapper;

namespace TMS.Library.Common
{
    /// <summary>
    /// Class EmailTemplate.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class EmailTemplate : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the secondary template subject.
        /// </summary>
        /// <value>The secondary template subject.</value>
        public string SecondaryTemplateSubject { get; set; }

        /// <summary>
        /// Gets or sets the primary template subject.
        /// </summary>
        /// <value>The primary template subject.</value>
        public string PrimaryTemplateSubject { get; set; }

        /// <summary>
        /// Gets or sets the primary template text.
        /// </summary>
        /// <value>The primary template text.</value>
        public string PrimaryTemplateText { get; set; }

        /// <summary>
        /// Gets or sets the secondary template text.
        /// </summary>
        /// <value>The secondary template text.</value>
        public string SecondaryTemplateText { get; set; }

        /// <summary>
        /// Gets or sets the template type identifier.
        /// </summary>
        /// <value>The template type identifier.</value>
        public int TemplateTypeID { get; set; }

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
            Name = dr.GetString("Name");
            Description = dr.GetString("Description");
            PrimaryTemplateSubject = dr.GetString("PrimaryTemplateSubject");
            SecondaryTemplateSubject = dr.GetString("SecondaryTemplateSubject");
            PrimaryTemplateText = dr.GetString("PrimaryTemplateText");
            SecondaryTemplateText = dr.GetString("SecondaryTemplateText");
            TemplateTypeID = dr.GetInt32("TemplateTypeID");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}