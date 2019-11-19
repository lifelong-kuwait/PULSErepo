// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 01-27-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-28-2018
// ***********************************************************************
// <copyright file="DegreeCertificates.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Common.Configuration
{
    /// <summary>
    /// Class DegreeCertificates.
    /// </summary>
    public class DegreeCertificates
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the primary.
        /// </summary>
        /// <value>The name of the primary.</value>
        [Display(Name = "DegreeCertificatesPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "DegreeCertificatesPrimaryNameRequired")]
        public string PrimaryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "DegreeCertificatesSecondaryName", ResourceType = typeof(lr))]
        public string SecondaryName { get; set; }
        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
       // [Display(Name = "OrganizationLogo", ResourceType = typeof(lr))]
        public string Logo { get; set; }
        /// <summary>
        /// Gets or sets the primary description.
        /// </summary>
        /// <value>The primary description.</value>
        [Display(Name = "DegreeCertificatesPrimaryDescription", ResourceType = typeof(lr))]
        public string PrimaryDescription { get; set; }

        /// <summary>
        /// Gets or sets the secondary description.
        /// </summary>
        /// <value>The secondary description.</value>
        [Display(Name = "DegreeCertificatesSecondaryDescription", ResourceType = typeof(lr))]
        public string SecondaryDescription { get; set; }


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