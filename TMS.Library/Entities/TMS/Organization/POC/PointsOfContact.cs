// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 03-01-2017
// ***********************************************************************
// <copyright file="PointsOfContact.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Organization.POC
{
    /// <summary>
    /// Class PointsOfContact.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PointsOfContact : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>The organization identifier.</value>
        public long? OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        [Display(Name = "PointofContactPerson", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PointofContactPersonRequired")]
        public long PersonID { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>The name of the person.</value>
        [Display(Name = "PointofContactPerson", ResourceType = typeof(lr))]
        public string PersonName { get; set; }

        /// <summary>
        /// Gets or sets the relation identifier.
        /// </summary>
        /// <value>The relation identifier.</value>
        [Display(Name = "PointofContactPurpose", ResourceType = typeof(lr))]
        public long RelationID { get; set; }

        /// <summary>
        /// Gets or sets the name of the relation.
        /// </summary>
        /// <value>The name of the relation.</value>
        [Display(Name = "PointofContactPurpose", ResourceType = typeof(lr))]
        public string RelationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is primary.
        /// </summary>
        /// <value><c>true</c> if this instance is primary; otherwise, <c>false</c>.</value>
        [Display(Name = "GridIsPrimary", ResourceType = typeof(lr))]
        public bool IsPrimary { get; set; }

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
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>null</c> if [is active] contains no value, <c>true</c> if [is active]; otherwise, <c>false</c>.</value>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>null</c> if [is deleted] contains no value, <c>true</c> if [is deleted]; otherwise, <c>false</c>.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            OrganizationID = dr.GetInt64("OrganizationID");
            PersonID = dr.GetInt64("PersonID");
            RelationID = dr.GetInt64("RelationID");
            IsPrimary = dr.GetBoolean("IsPrimary");
            CreatedDate = dr.GetDateTime("CreatedDate");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
            RelationName = dr.GetString("RelationName");
            PersonName = dr.GetString("PersonName");
        }
    }
}