// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IUserDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.Users;

namespace TMS.DataObjects.Interfaces
{
    /// <summary>
    /// Interface IUserDAL
    /// </summary>
    public interface IUserDAL
    {
        /// <summary>
        /// Logins the user dal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        Users LoginUserDAL(string Email);

        /// <summary>
        /// Updates the login user themes.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <param name="UserId">The user identifier.</param>
        void UpdateLoginUserThemes(string theme, long UserId);
         void Create_UserHistoryDAL(UserHistory userlogin);

        void Update_UserHistoryDAL(UserHistory userlogin);
        /// <summary>
        /// Updates the user locked out.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        int UpdateUserLockedOut(string Email, long UserID, int LockedOutAttempt, bool IsLockedOut);
        /// <summary>
        /// TMSs the users get all assigned security groups dal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsDAL(long UserID);

        #region"User CURD"
        IList<LoginUsers> LoginUsers_GetAllDAL(string culture);
        IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string culture, string ID);

        // With Search
        IList<LoginUsers> LoginUsers_GetAllDAL(string culture,string SearchText);
        IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string culture, string ID, string SearchText);
        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<LoginUsers> LoginUsers_GetAllDAL(string culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Logins the users by Organization get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="culture">The Company.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string culture,string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Logins the users create dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int64.</returns>
        long LoginUsers_CreateDAL(LoginUsers _objUsers);

        /// <summary>
        /// Logins the users update dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdateDAL(LoginUsers _objUsers);

        /// <summary>
        /// Logins the users delete dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_DeleteDAL(LoginUsers _objUsers);

        /// <summary>
        /// Logins the users update password dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdatePasswordDAL(LoginUsers _objUsers);

        /// <summary>
        /// Logins the users duplication check dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_DuplicationCheckDAL(LoginUsers _objUsers); 
        int LoginUsers_DuplicationCheckUpdateDAL(LoginUsers _objUsers);
        int LoginPerson_DuplicationCheckDAL(Library.TMS.Persons.Person objperson);
        int LoginPerson_DuplicationCheckUpdateDAL(Library.TMS.Persons.Person objperson);
        
        /// <summary>
        /// Logins the users update profile image dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdateProfileImageDAL(LoginUsers _objUsers);

        #endregion


        #region"Trainer CURD"

        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<LoginUsers> TrainerUsers_GetAllDAL(string culture);
        int DeletePerson_CheckDAL(ClassTrainerMapping classTrainerMapping);
        string Person_AllAssignPersonClassesDAL(ClassTrainerMapping classTrainerMapping);
        #endregion
    }
}