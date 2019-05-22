// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-16-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-16-2017
// ***********************************************************************
// <copyright file="IOffice365UsersDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Users;

namespace TMS.DataObjects.Interfaces.TMS
{
    /// <summary>
    /// Interface IOffice365UsersDAL
    /// </summary>
    public interface IOffice365UsersDAL
    {
        /// <summary>
        /// Logins the user dal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        Users LoginUserDAL(string Email);

        /// <summary>
        /// TMSs the users get all assigned security groups dal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsDAL(long UserID);

        /// <summary>
        /// TMSs the setting get office365 dal.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_Setting_GetOffice365DAL();

        /// <summary>
        /// TMSs the setting get office365 update dal.
        /// </summary>
        /// <param name="Office365">if set to <c>true</c> [office365].</param>
        /// <returns>System.Int32.</returns>
        int TMS_Setting_GetOffice365_UpdateDAL(bool Office365);
    }
}