// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-16-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IOffice365UsersBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Users;

namespace TMS.Business.Interfaces.TMS
{
    /// <summary>
    /// Interface IOffice365UsersBAL
    /// </summary>
    public interface IOffice365UsersBAL
    {
        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        Users LoginUserBAL(string Email);
        /// <summary>
        /// TMSs the users get all assigned security groups bal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsBAL(long UserID);
        /// <summary>
        /// TMSs the setting get office365 bal.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_Setting_GetOffice365BAL();
        /// <summary>
        /// TMSs the setting get office365 update bal.
        /// </summary>
        /// <param name="Office365">if set to <c>true</c> [office365].</param>
        /// <returns>System.Int32.</returns>
        int TMS_Setting_GetOffice365_UpdateBAL(bool Office365);
    }
}
