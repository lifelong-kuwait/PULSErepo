// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 01-10-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-10-2018
// ***********************************************************************
// <copyright file="Vendors.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Common.Configuration.Vendor
{
    /// <summary>
    /// Class Vendors.
    /// </summary>
    public class Vendors
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the primary vendor.
        /// </summary>
        /// <value>The primary vendor.</value>
        [Display(Name = "VendorPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VendorPrimaryNameRequired")]
        public string PrimaryVendor { get; set; }

        /// <summary>
        /// Gets or sets the secondary vendor.
        /// </summary>
        /// <value>The secondary vendor.</value>
        [Display(Name = "VendorSecondaryName", ResourceType = typeof(lr))]
        public string SecondaryVendor { get; set; }

        /// <summary>
        /// Gets or sets the primary details.
        /// </summary>
        /// <value>The primary details.</value>
        [Display(Name = "VendorPrimaryDetails", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VendorPrimaryDetailsRequired")]
        public string PrimaryDetails { get; set; }

        /// <summary>
        /// Gets or sets the secondary details.
        /// </summary>
        /// <value>The secondary details.</value>
        [Display(Name = "VendorSecondaryDetails", ResourceType = typeof(lr))]
        public string SecondaryDetails { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Display(Name = "VendorCode", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VendorCodeRequired")]
        public string Code { get; set; }


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long OrganizationID { get; set; }

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
}