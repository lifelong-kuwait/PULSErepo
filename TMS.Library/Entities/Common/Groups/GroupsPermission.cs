// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-19-2017
// ***********************************************************************
// <copyright file="GroupsPermission.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Common;
using TMS.Library.ModelMapper;

namespace TMS.Library.Common.Groups
{
    /// <summary>
    /// Class SecurityGroupsPermission.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class SecurityGroupsPermission : IDataMapper
    {
        /// <summary>
        /// Gets or sets the name of the permission.
        /// </summary>
        /// <value>The name of the permission.</value>
        public string PermissionName { get; set; }
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }
        /// <summary>
        /// Gets or sets the group permission identifier.
        /// </summary>
        /// <value>The group permission identifier.</value>
        public long GroupPermissionId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [new checked].
        /// </summary>
        /// <value><c>true</c> if [new checked]; otherwise, <c>false</c>.</value>
        public bool NewChecked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        public bool IsChecked { get; set; }
        /// <summary>
        /// Gets or sets the group permission code.
        /// </summary>
        /// <value>The group permission code.</value>
        public string GroupPermissionCode { get; set; }
        /// <summary>
        /// Gets or sets the category label resource.
        /// </summary>
        /// <value>The category label resource.</value>
        public string CategoryLabelResource { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
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
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the permission name identifier.
        /// </summary>
        /// <value>The permission name identifier.</value>
        public long PermissionNameId { get; set; }
        /// <summary>
        /// Gets or sets the group permission code.
        /// </summary>
        /// <value>The group permission code.</value>
        public string PermissionGroupType { get; set; }
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            PermissionName = dr.GetString("PermissionName");
            GroupId = dr.GetInt64("GroupId");
            GroupPermissionId = dr.GetInt64("GroupPermissionId");
            GroupPermissionCode = dr.GetString("GroupPermissionCode");
            CategoryLabelResource = dr.GetString("CategoryLabelResource");
            OrganizationID = dr.GetInt64("OrganizationID");
            IsChecked = System.Convert.ToBoolean(dr.GetInt32("IsChecked"));
            NewChecked = System.Convert.ToBoolean(dr.GetInt32("IsChecked"));
            PermissionNameId = dr.GetInt64("GroupPermissionNameId");
        }
    }

    /// <summary>
    /// Class GroupsPermission.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class GroupsPermission : IDataMapper
    {
        #region"Notes"
        /// <summary>
        /// Gets or sets a value indicating whether this instance can view notes.
        /// </summary>
        /// <value><c>true</c> if this instance can view notes; otherwise, <c>false</c>.</value>
        public bool CanViewNotes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can add edit notes.
        /// </summary>
        /// <value><c>true</c> if this instance can add edit notes; otherwise, <c>false</c>.</value>
        public bool CanAddEditNotes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can delete notes.
        /// </summary>
        /// <value><c>true</c> if this instance can delete notes; otherwise, <c>false</c>.</value>
        public bool CanDeleteNotes { get; set; }
        #endregion"Notes"

        #region"Attachments"
        /// <summary>
        /// Gets or sets a value indicating whether this instance can view attachments.
        /// </summary>
        /// <value><c>true</c> if this instance can view attachments; otherwise, <c>false</c>.</value>
        public bool CanViewAttachments { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can add edit attachments.
        /// </summary>
        /// <value><c>true</c> if this instance can add edit attachments; otherwise, <c>false</c>.</value>
        public bool CanAddEditAttachments { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can delete attachments.
        /// </summary>
        /// <value><c>true</c> if this instance can delete attachments; otherwise, <c>false</c>.</value>
        public bool CanDeleteAttachments { get; set; }
        #endregion"Attachments"

        #region"Email"
        /// <summary>
        /// Gets or sets a value indicating whether this instance can view email.
        /// </summary>
        /// <value><c>true</c> if this instance can view email; otherwise, <c>false</c>.</value>
        public bool CanViewEmail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can add edit email.
        /// </summary>
        /// <value><c>true</c> if this instance can add edit email; otherwise, <c>false</c>.</value>
        public bool CanAddEditEmail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can delete email.
        /// </summary>
        /// <value><c>true</c> if this instance can delete email; otherwise, <c>false</c>.</value>
        public bool CanDeleteEmail { get; set; }
        #endregion"Email"

        #region"SuggestedTraining"
        /// <summary>
        /// Gets or sets a value indicating whether this instance can view suggested training.
        /// </summary>
        /// <value><c>true</c> if this instance can view suggested training; otherwise, <c>false</c>.</value>
        public bool CanViewSuggestedTraining { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can add edit suggested training.
        /// </summary>
        /// <value><c>true</c> if this instance can add edit suggested training; otherwise, <c>false</c>.</value>
        public bool CanAddEditSuggestedTraining { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance can delete suggested training.
        /// </summary>
        /// <value><c>true</c> if this instance can delete suggested training; otherwise, <c>false</c>.</value>
        public bool CanDeleteSuggestedTraining { get; set; }
        #endregion"SuggestedTraining"

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            #region"Notes"
            CanViewNotes = dr.GetBoolean("CanViewNotes");
            CanAddEditNotes = dr.GetBoolean("CanAddEditNotes");
            CanDeleteNotes = dr.GetBoolean("CanDeleteNotes");
            #endregion"Notes"

            #region"Attachments"
            CanViewAttachments = dr.GetBoolean("CanViewAttachments");
            CanAddEditAttachments = dr.GetBoolean("CanAddEditAttachments");
            CanDeleteAttachments = dr.GetBoolean("CanDeleteAttachments");
            #endregion"Attachments"

            #region"Email"
            CanViewEmail = dr.GetBoolean("CanViewEmail");
            CanAddEditEmail = dr.GetBoolean("CanAddEditEmail");
            CanDeleteEmail = dr.GetBoolean("CanDeleteEmail");
            #endregion"Email"

            #region"SuggestedTraining"
            CanViewSuggestedTraining = dr.GetBoolean("CanViewSuggestedTraining");
            CanAddEditSuggestedTraining = dr.GetBoolean("CanAddEditSuggestedTraining");
            CanDeleteSuggestedTraining = dr.GetBoolean("CanDeleteSuggestedTraining");
            #endregion"SuggestedTraining"
        }
    }
}