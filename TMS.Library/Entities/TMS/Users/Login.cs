// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-16-2017
// ***********************************************************************
// <copyright file="Login.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Library.Users
{


    public class UserHistory
    {
        public long UserID { get; set; }
        public DateTime LoginDateTime{ get; set; }
        public DateTime LogoutDateTime { get; set; }

    }

    /// <summary>
    /// Class LoginModel.
    /// </summary>
    public class LoginModel
    {

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is persistent.
        /// </summary>
        /// <value><c>true</c> if this instance is persistent; otherwise, <c>false</c>.</value>
        public bool isPersistent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is office365 enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is office365 enabled; otherwise, <c>false</c>.</value>
        public bool isOffice365Enabled { get; set; }
    }

    /// <summary>
    /// Class ChangePasswordModel.
    /// </summary>
    public class ChangePasswordModel
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [Required]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>The uid.</value>
        [Required]
        public long uid { get; set; }
        /// <summary>
        /// Gets or sets the ts.
        /// </summary>
        /// <value>The ts.</value>
        public string ts { get; set; }
    }
    /// <summary>
    /// Class UserGroupsList.
    /// </summary>
    public class UserGroupsList
    {
        /// <summary>
        /// Gets or sets the permission name identifier.
        /// </summary>
        /// <value>The permission name identifier.</value>
        public long PermissionNameId { get; set; }
        /// <summary>
        /// Gets or sets the group permission code.
        /// </summary>
        /// <value>The group permission code.</value>
        public string GroupPermissionCode { get; set; }
    }
}
