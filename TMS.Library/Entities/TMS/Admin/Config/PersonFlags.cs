// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-02-2017
// ***********************************************************************
// <copyright file="PersonFlags.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;
namespace TMS.Library.TMS.Admin.Config
{
    /// <summary>
    /// Class PersonFlags.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonFlags : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the p flag.
        /// </summary>
        /// <value>The name of the p flag.</value>
        [Display(Name = "Flags", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "FlagRequired")]
        public string P_FlagName { get; set; }

        /// <summary>
        /// Gets or sets the name of the s flag.
        /// </summary>
        /// <value>The name of the s flag.</value>
        public string S_FlagName { get; set; }
        /// <summary>
        /// Gets or sets the color of the flag.
        /// </summary>
        /// <value>The color of the flag.</value>
        [Display(Name = "FlagColor", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "FlagRequired")]
        public string FlagColor { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long OrganizationID { get; set; }

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
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? UpdatedBy { get; set; }

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
            P_FlagName = dr.GetString("P_FlagName");
            S_FlagName = dr.GetString("S_FlagName");
            FlagColor = dr.GetString("FlagColor");
            OrganizationID = dr.GetInt64("OrganizationID");
            CreatedDate = dr.GetDateTime("CreatedDate");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }

    /// <summary>
    /// Class PersonFlagsNested.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonFlagsNested : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the p flag.
        /// </summary>
        /// <value>The name of the p flag.</value>
        [Display(Name = "Flags", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "FlagRequired")]
        public string P_FlagName { get; set; }

        /// <summary>
        /// Gets or sets the name of the s flag.
        /// </summary>
        /// <value>The name of the s flag.</value>
        public string S_FlagName { get; set; }
        /// <summary>
        /// Gets or sets the color of the flag.
        /// </summary>
        /// <value>The color of the flag.</value>
        [Display(Name = "FlagColor", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "FlagRequired")]
        public string FlagColor { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is exist.
        /// </summary>
        /// <value><c>true</c> if this instance is exist; otherwise, <c>false</c>.</value>
        public bool IsExist { get; set; }
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            P_FlagName = dr.GetString("P_FlagName");
            S_FlagName = dr.GetString("S_FlagName");
            FlagColor = dr.GetString("FlagColor");
            IsExist = true;
        }
    }

    /// <summary>
    /// Class PersonFlagsDDL.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonFlagsDDL : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the p flag.
        /// </summary>
        /// <value>The name of the p flag.</value>
        public string P_FlagName { get; set; }

        /// <summary>
        /// Gets or sets the name of the s flag.
        /// </summary>
        /// <value>The name of the s flag.</value>
        public string S_FlagName { get; set; }

        /// <summary>
        /// Gets or sets the color of the flag.
        /// </summary>
        /// <value>The color of the flag.</value>
        public string FlagColor { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is exist.
        /// </summary>
        /// <value><c>true</c> if this instance is exist; otherwise, <c>false</c>.</value>
        public bool IsExist { get; set; }
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            P_FlagName = dr.GetString("P_FlagName");
            S_FlagName = dr.GetString("S_FlagName");
            FlagColor = dr.GetString("FlagColor");
            IsExist = false;
        }
    }

}