// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 06-12-2017
// ***********************************************************************
// <copyright file="TMSResource.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Admin
{
    /// <summary>
    /// Class TMSResource.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class TMSResource : IDataMapper
    {
        /// <summary>
        /// Gets or sets the p resourceid.
        /// </summary>
        /// <value>The p resourceid.</value>
        public long P_Resourceid { get; set; }
        /// <summary>
        /// Gets or sets the s resourceid.
        /// </summary>
        /// <value>The s resourceid.</value>
        public long S_Resourceid { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "ResourceName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ResourceNameRequired")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the p resourceid.
        /// </summary>
        /// <value>The p resourceid.</value>
        public long OrganizationID { get; set; }

       //[Display(Name = "OrganizationTitle", ResourceType = typeof(lr))]
       // public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the p value.
        /// </summary>
        /// <value>The p value.</value>
        [Display(Name = "PrimaryLanguageResource", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                  ErrorMessageResourceName = "PrimaryResourceRequired")]
        public string P_Value { get; set; }

        /// <summary>
        /// Gets or sets the s value.
        /// </summary>
        /// <value>The s value.</value>
        [Display(Name = "SecondaryLanguageResource", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr),
                  ErrorMessageResourceName = "SecondaryResourceRequired")]
        public string S_Value { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        public string Culture { get; set; }

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
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        public string P_FirstName { get; set; }
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            P_Resourceid = dr.GetInt64("P_Resourceid");
            S_Resourceid = dr.GetInt64("S_Resourceid");
            Name = dr.GetString("Name");
            P_Value = dr.GetString("P_Value");
            S_Value = dr.GetString("S_Value");
          //  OrganizationName = dr.GetString("OrganizationName");
            Culture = dr.GetString("Culture");
            CreatedDate = dr.GetDateTimeNullable("CreatedDate");
            UpdatedDate = dr.GetDateTimeNullable("UpdatedDate");
            CreatedBy = dr.GetInt64Nullable("CreatedBy");
            UpdatedBy = dr.GetInt64Nullable("UpdatedBy");
            P_FirstName = dr.GetString("P_FirstName");
        }
    }

    /// <summary>
    /// Class ResourceCreationDual.
    /// </summary>
    public class ResourceCreationDual
    {
        /// <summary>
        /// Gets or sets the p resourceid.
        /// </summary>
        /// <value>The p resourceid.</value>
        public long P_Resourceid { get; set; }
        /// <summary>
        /// Gets or sets the s resourceid.
        /// </summary>
        /// <value>The s resourceid.</value>
        public long S_Resourceid { get; set; }
    }
}