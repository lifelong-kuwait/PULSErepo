// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-20-2016
// ***********************************************************************
// <copyright file="Lookup.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Admin.Lookup
{
    /// <summary>
    /// Class Lookup.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class Lookup : IDataMapper
    {

        /// <summary>
        /// Gets or sets the lookup identifier.
        /// </summary>
        /// <value>The lookup identifier.</value>
        public long LookupID { get; set; }
        /// <summary>
        /// Gets or sets the name of the lookup p.
        /// </summary>
        /// <value>The name of the lookup p.</value>
        [Display(Name = "LookupPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                         ErrorMessageResourceName = "LookupPrimaryNameRequired")]
        public string LookupP_Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the lookup s.
        /// </summary>
        /// <value>The name of the lookup s.</value>
        [Display(Name = "LookupSecondaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                         ErrorMessageResourceName = "LookupSecondaryNameRequired")]
        public string LookupS_Name { get; set; }

        /// <summary>
        /// Gets or sets the lookup identifier.
        /// </summary>
        /// <value>The lookup identifier.</value>
        public long OrganizationID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Display(Name = "GridIsActiveColumnTitle", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the createdby.
        /// </summary>
        /// <value>The createdby.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long? Createdby { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updatedby.
        /// </summary>
        /// <value>The updatedby.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long? Updatedby { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            LookupID = dr.GetInt64("LookupID");
            LookupP_Name = dr.GetString("LookupP_Name");
            LookupS_Name = dr.GetString("LookupS_Name");
            OrganizationID = dr.GetInt64("OrganizationID");
            IsActive = dr.GetBoolean("IsActive");
            CreatedDate = dr.GetDateTimeNullable("CreatedDate");
            UpdatedDate = dr.GetDateTimeNullable("UpdatedDate");
            Createdby = dr.GetInt64Nullable("CreatedBy");
            Updatedby = dr.GetInt64Nullable("UpdatedBy");
        }
    }
}
