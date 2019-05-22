// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-16-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-16-2017
// ***********************************************************************
// <copyright file="Office365UsersDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Users;

namespace TMS.DataObjects.TMS
{
    /// <summary>
    /// Class Office365UsersDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.IOffice365UsersDAL" />
    public class Office365UsersDAL : DBGenerics, IOffice365UsersDAL
    {
        /// <summary>
        /// Logins the user dal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        public Users LoginUserDAL(string Email)
        {
            var parameters = new[] { new SqlParameter() { ParameterName = "@Email", Value = Email } };
            return ExecuteSinglewithSP<Users>("TMS_Users_LoginUser", parameters);
        }

        /// <summary>
        /// TMSs the users get all assigned security groups dal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        public IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsDAL(long UserID)
        {
            List<UserGroupsList> LoginUserAddGroups = new List<UserGroupsList>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Users_GetAllAssignedSecurityGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", UserID);
                LoginUserAddGroups = conn.Query<UserGroupsList>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<UserGroupsList>();
                conn.Close();
            }
            return LoginUserAddGroups;
        }

        /// <summary>
        /// TMSs the setting get office365 dal.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_Setting_GetOffice365DAL()
        {
            bool IsOffice365Enabled = false;
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Setting_GetOffice365";

                IsOffice365Enabled = conn.QueryFirst<bool>(qry.ToString(), commandType: System.Data.CommandType.StoredProcedure);
                conn.Close();
            }
            return IsOffice365Enabled;
        }

        /// <summary>
        /// TMSs the setting get office365 update dal.
        /// </summary>
        /// <param name="Office365">if set to <c>true</c> [office365].</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Setting_GetOffice365_UpdateDAL(bool Office365)
        {
            int IsOffice365Enabled = -1;
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Setting_GetOffice365Update";
                IsOffice365Enabled = conn.Execute(qry.ToString(), new
                {
                    Office365
                   
                }, commandType: System.Data.CommandType.StoredProcedure);
                conn.Close();
            }
            return IsOffice365Enabled;

            //return ExecuteScalarSP("TMS_Setting_GetOffice365", System.Data.CommandType.StoredProcedure,
            //    ParamBuilder.Par("Office365", Office365)
            //    );
        }
    }
}