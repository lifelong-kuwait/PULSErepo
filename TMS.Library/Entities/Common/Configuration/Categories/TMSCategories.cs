// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 01-14-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-20-2018
// ***********************************************************************
// <copyright file="TMSCategories.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Common.Configuration.Categories
{

    //CategoryCodeDuplicate

    /// <summary>
    /// Class TMSCategories.
    /// </summary>
    public class TMSCategories
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the primary category.
        /// </summary>
        /// <value>The name of the primary category.</value>
        [Display(Name = "CategoryPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CategoryPrimaryNameRequired")]
        public string PrimaryCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary category.
        /// </summary>
        /// <value>The name of the secondary category.</value>
        [Display(Name = "CategorySecondaryName", ResourceType = typeof(lr))]
        public string SecondaryCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the primary description.
        /// </summary>
        /// <value>The primary description.</value>
        [Display(Name = "CategoryPrimaryDescription", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CategoryPrimaryDescriptionRequired")]
        public string PrimaryDescription { get; set; }
        /// <summary>
        /// Gets or sets the secondary description.
        /// </summary>
        /// <value>The secondary description.</value>
        [Display(Name = "CategorySecondaryDescription", ResourceType = typeof(lr))]
        public string SecondaryDescription { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Display(Name = "CategoryCode", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CategoryCodeRequired")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The OrganizationID.</value>
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
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        public long CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the type of the category.
        /// </summary>
        /// <value>The type of the category.</value>
        [Display(Name = "CategoryType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CategoryTypeRequired")]
        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }

        public string UpdatedByAlias { get; set; }

        

    }

}
