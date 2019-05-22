// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="LookupDetail.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Admin.Lookup
{
    /// <summary>
    /// Class LookupDetail.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class LookupDetail : IDataMapper
    {
        /// <summary>
        /// Gets or sets the lookup identifier.
        /// </summary>
        /// <value>The lookup identifier.</value>
        public long LookupID { get; set; }
        /// <summary>
        /// Gets or sets the lookup detai identifier.
        /// </summary>
        /// <value>The lookup detai identifier.</value>
        public long LookupDetaiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the lookup detail p.
        /// </summary>
        /// <value>The name of the lookup detail p.</value>
        [Display(Name = "LookupDetailPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                         ErrorMessageResourceName = "LookupDetailP_NameRequired")]
        public string LookupDetailP_Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the lookup detail s.
        /// </summary>
        /// <value>The name of the lookup detail s.</value>
        [Display(Name = "LookupDetailSecondaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                         ErrorMessageResourceName = "LookupDetailS_NameRequired")]
        public string LookupDetailS_Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Display(Name = "GridIsActiveColumnTitle", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        [Display(Name = "GridIsSelected", ResourceType = typeof(lr))]
        public bool IsSelected { get; set; }

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
            LookupDetaiId = dr.GetInt64("LookupDetailId");
            LookupDetailP_Name = dr.GetString("LookupDetailP_Name");
            LookupDetailS_Name = dr.GetString("LookupDetailS_Name");
            IsActive = dr.GetBoolean("IsActive");
            IsSelected = dr.GetBoolean("IsSelected");
            CreatedDate = dr.GetDateTimeNullable("CreatedDate");
            UpdatedDate = dr.GetDateTimeNullable("UpdatedDate");
            Createdby = dr.GetInt64Nullable("CreatedBy");
            Updatedby = dr.GetInt64Nullable("UpdatedBy");
        }
    }
}