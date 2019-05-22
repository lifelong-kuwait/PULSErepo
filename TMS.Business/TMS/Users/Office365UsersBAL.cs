// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-16-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="Office365UsersBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Users;

namespace TMS.Business.TMS
{
    /// <summary>
    /// Class Office365UsersBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.IOffice365UsersBAL" />
    public class Office365UsersBAL : IOffice365UsersBAL
    {
        private IOffice365UsersDAL _Office365UsersBAL;
        /// <summary>
        /// Initializes a new instance of the <see cref="Office365UsersBAL"/> class.
        /// </summary>
        /// <param name="__Office365UsersBAL">The office365 users bal.</param>
        public Office365UsersBAL(IOffice365UsersDAL __Office365UsersBAL)
        {
            this._Office365UsersBAL = __Office365UsersBAL;
        }


        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        public Users LoginUserBAL(string Email)
        {
            return _Office365UsersBAL.LoginUserDAL(Email);
        }

        /// <summary>
        /// TMSs the users get all assigned security groups bal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        public IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsBAL(long UserID)
        {
            return _Office365UsersBAL.TMS_Users_GetAllAssignedSecurityGroupsDAL(UserID);
        }

        /// <summary>
        /// TMSs the setting get office365 bal.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_Setting_GetOffice365BAL()
        {
            return _Office365UsersBAL.TMS_Setting_GetOffice365DAL();
        }

        /// <summary>
        /// TMSs the setting get office365 update bal.
        /// </summary>
        /// <param name="Office365">if set to <c>true</c> [office365].</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Setting_GetOffice365_UpdateBAL(bool Office365)
        {
            return _Office365UsersBAL.TMS_Setting_GetOffice365_UpdateDAL(Office365);
        }

        
    }
}