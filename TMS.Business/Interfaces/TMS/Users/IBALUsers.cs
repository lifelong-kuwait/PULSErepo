// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IBALUsers.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS.Persons;
using TMS.Library.Users;
using TMS.Library.Entities.CRM;
namespace TMS.Business.Interfaces.TMS
{
    /// <summary>
    /// Interface IBALUsers
    /// </summary>
    public interface IBALUsers
    {
        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        Users LoginUserBAL(string Email);
        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        List<Users> LoginUserListBAL(string Email);
        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        Users LoginUserBALForTrainer(string Email,long CompanyId);
        
        /// <summary>
        /// Updates the login user themes dal.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <param name="UserId">The user identifier.</param>
        void UpdateLoginUserThemesDAL(string theme, long UserId);


        void Create_UserHistoryBAL(UserHistory userlogin);
        void Update_UserHistoryBAL(UserHistory userlogin);


        /// <summary>
        /// Updates the user locked out bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        int UpdateUserLockedOutBAL(string Email, long UserID, int LockedOutAttempt, bool IsLockedOut);
        /// <summary>
        /// Updates the user locked out bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        int LogInsert(string Dates, string Threads,string Levels, string Loggers,string Messages,string Exceptions,long UserID, string Controllers, string  Action, string Params, long companyID);
        /// <summary>
        /// TMSs the users get all assigned security groups bal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsBAL(long UserID);
        #region"User CURD"
        IList<LoginUsers> LoginUsers_GetAllBAL(string culture);
        IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture, string ID);


        IList<LoginUsers> LoginUsers_GetAllBAL(string culture,string SearchText);
        IList<LoginUsers> LoginLockedUsers_GetAllBAL(string culture, string SearchText); 
         IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture, string ID, string SearchText);
        IList<LoginUsers> LoginLockedUsersOrganization_GetAllBAL(string culture, string ID, string SearchText);
        IList<CRM_UserLog> LogOrganization_GetAllBAL(ref int Total,   string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize);
        IList<CRM_UserLog> ErrorLogOrganization_GetAllBAL(ref int Total, string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize);
        int ErrorLogOrganization_GetAllBAL(CRM_UserLog objLog,long companyID,long ID);

        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<LoginUsers> LoginUsers_GetAllBAL(string culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Logins the users by organization get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="culture">The Company.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture,string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Logins the users create bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int64.</returns>
        long LoginUsers_CreateBAL(ref LoginUsers _objUsers);

        /// <summary>
        /// Logins the users update bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdateBAL(LoginUsers _objUsers);

        /// <summary>
        /// Logins the users delete bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_DeleteBAL(LoginUsers _objUsers);
        /// <summary>
        /// Logins the users delete bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UnlockBAL(LoginUsers _objUsers);
        /// <summary>
        /// Logins the users update password bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdatePasswordBAL(LoginUsers _objUsers);
        //object LoginUsersOrganization_GetAllBAL(string currentCulture, string v);

        /// <summary>
        /// Logins the users duplication check bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_DuplicationCheckBAL(LoginUsers _objUsers);
        int LoginUsersAsTrainer_DuplicationCheckBAL(LoginUsers _objUsers);

        int LoginUsers_DuplicationCheckUpdateBAL(LoginUsers _objUsers);
        int LoginPerson_DuplicationCheckBAL(Person person);
        int LoginPerson_DuplicationCheckUpdateBAL(Person person);
        /// <summary>
        /// Logins the users update profile image bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        int LoginUsers_UpdateProfileImageBAL(LoginUsers _objUsers);
        #endregion

        #region Trainer CURD

        /// <summary>
        /// Trainer get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        /// 
        IList<LoginUsers> TrainerUsers_GetAllBAL(string culture);
        int DeletePerson_CheckBAL(ClassTrainerMapping classTrainerMapping);
        string Person_AllAssignPersonClassesBAL(ClassTrainerMapping classTrainerMapping);
        #endregion
    }
}