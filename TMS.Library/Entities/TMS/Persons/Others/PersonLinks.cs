// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 03-11-2017
// ***********************************************************************
// <copyright file="PersonLinks.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Persons.Others
{
    /// <summary>
    /// Class PersonLinks.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonLinks : IDataMapper
    {
        /// <summary>
        /// Gets or sets the display name of the relation.
        /// </summary>
        /// <value>The display name of the relation.</value>
        [Display(Name = "PersonP_DisplayName", ResourceType = typeof(lr))]
        public string RelationDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the relation identifier.
        /// </summary>
        /// <value>The relation identifier.</value>
        public long RelationID { get; set; }

        /// <summary>
        /// Gets or sets the relation from.
        /// </summary>
        /// <value>The relation from.</value>
        public long? RelationFrom { get; set; }

        /// <summary>
        /// Gets or sets the relation two.
        /// </summary>
        /// <value>The relation two.</value>
        [Display(Name = "PersonRelationTo", ResourceType = typeof(lr))]
        public long? RelationTwo { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

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
        /// <value><c>null</c> if [is deleted] contains no value, <c>true</c> if [is deleted]; otherwise, <c>false</c>.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the created by alias.
        /// </summary>
        /// <value>The created by alias.</value>
        public string CreatedByAlias { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            RelationID = dr.GetInt64("RelationID");
            RelationFrom = dr.GetInt64("RelationFrom");
            RelationTwo = dr.GetInt64("RelationTwo");
            CreatedDate = dr.GetDateTime("CreatedDate");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            CreatedByAlias = dr.GetString("AddedByAlias");
        }
    }
}