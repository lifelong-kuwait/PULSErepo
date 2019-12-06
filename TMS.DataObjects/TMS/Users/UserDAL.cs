// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="UserDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces;
using TMS.Library.Users;
using System.Linq;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.Entities.CRM;

namespace TMS.DataObjects
{
    /// <summary>
    /// Class UserDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.IUserDAL" />
    public class UserDAL : DBGenerics, IUserDAL
    {
        /// <summary>
        /// Logins the user dal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        public Users LoginUserDAL(string Email)
        {
            DBGenerics db = new DBGenerics();

            var parameters = new[]{
            new SqlParameter(){ ParameterName="@Email", Value=Email }
            //new SqlParameter(){ ParameterName="@Password", Value=Password }
        };

            return ExecuteSinglewithSP<Users>("TMS_Users_LoginUser", parameters);
        }

        /// <summary>
        /// Updates the user locked out.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserLockedOut(string Email, long UserID, int LockedOutAttempt, bool IsLockedOut)
        {
            return ExecuteScalarSP("TMS_Users_LockedOut", System.Data.CommandType.StoredProcedure,
                ParamBuilder.Par("UserID", UserID),
                ParamBuilder.Par("Email", Email),
                ParamBuilder.Par("LockedOutAttempt", LockedOutAttempt),
                ParamBuilder.Par("IsLockedOut", IsLockedOut),
                ParamBuilder.Par("LockedOutDate", System.DateTime.Now)
                );
        }
        /// <summary>
        /// Updates the user locked out.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        public int LogInsert(string Dates, string Threads, string Levels, string Loggers, string Messages, string Exceptions, long UserID, string Controllers, string Action,string Prarams,long companyID)
        {
            return ExecuteScalarSP("UserLogInsert", System.Data.CommandType.StoredProcedure,
                ParamBuilder.Par("Dates", Dates),
                ParamBuilder.Par("Levels", Levels),
                ParamBuilder.Par("Loggers", Loggers),
                ParamBuilder.Par("Messages", Messages),
                ParamBuilder.Par("Exceptions", Exceptions),
                ParamBuilder.Par("UserIDs", UserID),
                ParamBuilder.Par("Controllers", Controllers),
                ParamBuilder.Par("Actions", Action)  ,              
                ParamBuilder.Par("parameter", Prarams),
                ParamBuilder.Par("organization", companyID)
                );
        }
        /// <summary>
        /// Updates the login user themes.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <param name="UserId">The user identifier.</param>
        public void UpdateLoginUserThemes(string theme, long UserId)
        {
            ExecuteScalarSP("TMS_UserConfigurations_CreateUpdate", System.Data.CommandType.StoredProcedure,
                ParamBuilder.Par("UserID", UserId),
                ParamBuilder.Par("Theme", theme),
                ParamBuilder.Par("CreatedDate", System.DateTime.Now),
                ParamBuilder.Par("CreatedBy", UserId)
                );
        }
        public void Create_UserHistoryDAL(UserHistory userlogin)
        {
            ExecuteScalarSP("UserHistory_Create", System.Data.CommandType.StoredProcedure,
               ParamBuilder.Par("UserID", userlogin.UserID),
               ParamBuilder.Par("LoginDateTime", userlogin.LoginDateTime)
              
               );
        }

        public void Update_UserHistoryDAL(UserHistory userlogin)
        {
            ExecuteScalarSP("UserHistory_Update", System.Data.CommandType.StoredProcedure,
               ParamBuilder.Par("UserID", userlogin.UserID),
               ParamBuilder.Par("LogoutDateTime", userlogin.LogoutDateTime)

               );
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
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
         }
        #region"User CURD"
        public IList<LoginUsers> LoginUsers_GetAllDAL(string Culture)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Users_GetAll_WithGroupsOLD";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }
        public IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string Culture, string ID)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_UsersByOrganization_GetAll_WithGroupsOLD";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@oid", ID);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }

        // With Search

        public IList<LoginUsers> LoginUsers_GetAllDAL(string Culture,string SearchText)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Users_GetAll_WithGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@SearchText", SearchText);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            //    List<LoginUsers> LoginUserList = new List<LoginUsers>();
            //    var conString = DBHelper.ConnectionString;
            //    using (var conn = new SqlConnection(conString))
            //    {
            //        conn.Open();
            //        string qry = @"TMS_Users_GetAll_WithGroups";
            //        DynamicParameters param = new DynamicParameters();
            //        param.Add("@Culture", Culture);
            //        param.Add("@SearchText", SearchText);
            //        var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
            //        LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
            //               qry, (loginUsers, Groups) =>
            //               {
            //                   LoginUsers loginUsersEntry;
            //                   if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
            //                   {
            //                       loginUsersEntry = loginUsers;
            //                       loginUsersEntry.UserGroups = new List<LoginUserGroups>();
            //                       LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
            //                   }
            //                   if (Groups != null)
            //                       loginUsersEntry.UserGroups.Add(Groups);
            //                   return loginUsersEntry;
            //               }, param, commandType: System.Data.CommandType.StoredProcedure,
            //               splitOn: "GroupId")
            //           .Distinct()
            //           .ToList();
            //        conn.Close();
            //    }
            //    return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");

        }
        public IList<LoginUsers> LoginLockedUsers_GetAllDAL(string Culture, string SearchText)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Users_GetAllLocked_WithGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@SearchText", SearchText);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;

        }
        public IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string Culture, string ID,string SearchText)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_UsersByOrganization_GetAll_WithGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@ID", ID);
                param.Add("@SearchText", SearchText);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }
        public IList<LoginUsers> LoginLockedUsersOrganization_GetAllDAL(string Culture, string ID, string SearchText)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_UsersLockedUserByOrganization_GetAll_WithGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                param.Add("@ID", ID);
                param.Add("@SearchText", SearchText);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll"); 
        }
       public IList<CRM_UserLog> LogOrganization_GetAllDAL(ref int Total, string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize)
        {
            List<CRM_UserLog> _PersonData = new List<CRM_UserLog>();
            
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { OrganizationID = OrgID, SearchText = SearchText,  SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize});
                using (var multi = conn.QueryMultiple("CRM_UsersLog", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _PersonData = multi.Read<CRM_UserLog>().AsList<CRM_UserLog>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            
            return _PersonData.ToList();
          
        }
       public int ErrorLogOrganization_GetAllBAL(CRM_UserLog objLog, long companyID, long ID)
        {
            return ExecuteScalarInt32Sp("CRM_UsersErrorLogIsResolved",
                        ParamBuilder.Par("@id", objLog.ID),
                        ParamBuilder.Par("@ResolvedBy", objLog.ResolvedBy),
                        ParamBuilder.Par("@ResolvedDate", objLog.ResolvedData),
                        ParamBuilder.Par("@OrganizationID", companyID)


                    );
        }
        public IList<CRM_UserLog> ErrorLogOrganization_GetAllDAL(ref int Total, string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize)
        {
            List<CRM_UserLog> _PersonData = new List<CRM_UserLog>();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { OrganizationID = OrgID, SearchText = SearchText, SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize });
                using (var multi = conn.QueryMultiple("CRM_UsersErrorLog", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _PersonData = multi.Read<CRM_UserLog>().AsList<CRM_UserLog>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }

            return _PersonData.ToList();

        }
        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> LoginUsers_GetAllDAL(string Culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {

            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Culture = Culture, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                string qry = @"TMS_Users_GetAll_WithGroups";
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, dbParam, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                

                conn.Close();
            }
            return LoginUserList;

            //List<LoginUsers> LoginUserList = new List<LoginUsers>();
            //var conString = DBHelper.ConnectionString;
            //using (var conn = new SqlConnection(conString))
            //{
            //    conn.Open();

            //    DynamicParameters dbParam = new DynamicParameters();
            //    dbParam.AddDynamicParams(new { Culture = Culture, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
            //    using (var multi = conn.QueryMultiple("TMS_Users_GetAll_WithGroups", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        LoginUserList = multi.Read<LoginUsers>().AsList<LoginUsers>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();
            //    }


            // string qry = @"TMS_Users_GetAll_WithGroups";
            //DynamicParameters param = new DynamicParameters();
            //param.Add("@Culture", Culture);
            //param.Add("@StartRowIndex", StartRowIndex);
            //param.Add("@PageSize", PageSize);
            //param.Add("@SortExpression", SortExpression);
            //param.Add("@SearchText", SearchText);
            //var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
            // LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
            //        qry, (loginUsers, Groups) =>
            //        {
            //            LoginUsers loginUsersEntry;
            //            if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
            //            {
            //                loginUsersEntry = loginUsers;
            //                loginUsersEntry.UserGroups = new List<LoginUserGroups>();
            //                LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
            //            }
            //            if(Groups!=null)
            //            loginUsersEntry.UserGroups.Add(Groups);
            //            return loginUsersEntry;
            //       },param, commandType:System.Data.CommandType.StoredProcedure,
            //        splitOn: "GroupId")
            //    .Distinct()
            //    .ToList();



            //  conn.Close();
            // }
            //  return LoginUserList.ToList(); ;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }

        /// <summary>
        /// Logins the users Organization get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="Culture">The Company.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> LoginUsersOrganization_GetAllDAL(string Culture,string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {

            List<LoginUsers> Course = new List<LoginUsers>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Culture = Culture,ID=ID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_UsersByOrganization_GetAll_WithGroups", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<LoginUsers>().AsList<LoginUsers>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();

            //List<LoginUsers> LoginUserList = new List<LoginUsers>();
            //var conString = DBHelper.ConnectionString;
            //using (var conn = new SqlConnection(conString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    dbParam.AddDynamicParams(new { Culture= Culture,ID=ID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
            //    using (var multi = conn.QueryMultiple("TMS_UsersByOrganization_GetAll_WithGroups", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        LoginUserList = multi.Read<LoginUsers>().AsList<LoginUsers>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();

            //        //string qry = @"TMS_UsersByOrganization_GetAll_WithGroups";
            //        //DynamicParameters param = new DynamicParameters();
            //        //param.Add("@Culture", Culture);
            //        //param.Add("@oid", ID);


            //        var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
            //        LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
            //               multi.ToString(), (loginUsers, Groups) =>
            //               {
            //                   LoginUsers loginUsersEntry;
            //                   if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
            //                   {
            //                       loginUsersEntry = loginUsers;
            //                       loginUsersEntry.UserGroups = new List<LoginUserGroups>();
            //                       LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
            //                   }
            //                   if (Groups != null)
            //                       loginUsersEntry.UserGroups.Add(Groups);
            //                   return loginUsersEntry;
            //               }, dbParam, commandType: System.Data.CommandType.StoredProcedure,
            //               splitOn: "GroupId")
            //           .Distinct()
            //           .ToList();
            //    }
            //    conn.Close();

            //}
            //return LoginUserList.ToList();
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }

        /// <summary>
        /// Logins the users create dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int64.</returns>
        public long LoginUsers_CreateDAL(LoginUsers _objUsers)
        {
            var parameters = new[] { ParamBuilder.Par("UserID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Users_Create", parameters,
                        ParamBuilder.Par("P_FirstName", _objUsers.P_FirstName),
                        ParamBuilder.Par("P_MiddleName", _objUsers.P_MiddleName),
                        ParamBuilder.Par("P_LastName", _objUsers.P_LastName),
                        ParamBuilder.Par("P_DisplayName", _objUsers.P_DisplayName),
                        ParamBuilder.Par("S_FirstName", _objUsers.S_FirstName),
                        ParamBuilder.Par("S_MiddleName", _objUsers.S_MiddleName),
                        ParamBuilder.Par("S_LastName", _objUsers.S_LastName),
                        ParamBuilder.Par("S_DisplayName", _objUsers.S_DisplayName),
                        ParamBuilder.Par("Password", _objUsers.Password),
                        ParamBuilder.Par("Email", _objUsers.Email),
                        ParamBuilder.Par("UserRole", _objUsers.UserRole),
                        ParamBuilder.Par("ValidationCode", _objUsers.ValidationCode),
                        ParamBuilder.Par("IsActive", _objUsers.IsActive),
                        ParamBuilder.Par("IsCompanyUser", _objUsers.IsCompanyUser),
                        ParamBuilder.Par("CompanyID", _objUsers.CompanyID),
                        ParamBuilder.Par("IsAdmin", _objUsers.IsAdmin),
                        ParamBuilder.Par("DateOfBirth", _objUsers.DateOfBirth),
                        ParamBuilder.Par("HowHeardAboutUs", _objUsers.HowHeardAboutUs),
                        ParamBuilder.Par("CreatedBy", _objUsers.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _objUsers.CreatedDate),
                        ParamBuilder.Par("CultureID", _objUsers.CultureID),
                        ParamBuilder.Par("Parent", _objUsers.Parent),
                        ParamBuilder.Par("NickName", _objUsers.NickName),
                        ParamBuilder.Par("Salutation", _objUsers.Salutation),
                        ParamBuilder.Par("Description", _objUsers.Description),
                        ParamBuilder.Par("DepartmentID", _objUsers.DepartmentID),
                        ParamBuilder.Par("Gender", _objUsers.Gender),
                        ParamBuilder.Par("Education", _objUsers.Education),
                        ParamBuilder.Par("EmployeeStatus", _objUsers.EmployeeStatus),
                        ParamBuilder.Par("MaritalStatus", _objUsers.MaritalStatus),
                        ParamBuilder.Par("NationalIdType", _objUsers.NationalIdType),
                        ParamBuilder.Par("NationalIdentity", _objUsers.NationalIdentity),
                        ParamBuilder.Par("Twitter", _objUsers.Twitter),
                        ParamBuilder.Par("Facebook", _objUsers.Facebook),
                        ParamBuilder.Par("GooglePlus", _objUsers.GooglePlus),
                        ParamBuilder.Par("Skype", _objUsers.Skype),
                        ParamBuilder.Par("Flicker", _objUsers.Flicker),
                        ParamBuilder.Par("MSN", _objUsers.MSN),
                        ParamBuilder.Par("Instagram", _objUsers.Instagram),
                        ParamBuilder.Par("LastLogin", _objUsers.LastLogin),
                        ParamBuilder.Par("UTCOffset", _objUsers.UTCOffset),
                        ParamBuilder.Par("Website", _objUsers.Website),
                        ParamBuilder.Par("Language", _objUsers.Language),
                        ParamBuilder.Par("PulseID", _objUsers.PulseID),
                        ParamBuilder.Par("EmployeeID", _objUsers.EmployeeID),
                        ParamBuilder.Par("ProfileImage", _objUsers.ProfileImage));
        }

        /// <summary>
        /// Logins the users update dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdateDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarInt32Sp("TMS_Users_Update",
                        ParamBuilder.Par("UserID", _objUsers.UserID),
                        ParamBuilder.Par("P_FirstName", _objUsers.P_FirstName),
                        ParamBuilder.Par("P_MiddleName", _objUsers.P_MiddleName),
                        ParamBuilder.Par("P_LastName", _objUsers.P_LastName),
                        ParamBuilder.Par("P_DisplayName", _objUsers.P_DisplayName),
                        ParamBuilder.Par("S_FirstName", _objUsers.S_FirstName),
                        ParamBuilder.Par("S_MiddleName", _objUsers.S_MiddleName),
                        ParamBuilder.Par("S_LastName", _objUsers.S_LastName),
                        ParamBuilder.Par("S_DisplayName", _objUsers.S_DisplayName),
                        ParamBuilder.Par("Email",_objUsers.Email),
                        ParamBuilder.Par("IsActive", _objUsers.IsActive),
                        ParamBuilder.Par("DateOfBirth", _objUsers.DateOfBirth),
                        ParamBuilder.Par("UpdatedBy", _objUsers.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _objUsers.UpdatedDate),
                        ParamBuilder.Par("NickName", _objUsers.NickName),
                        ParamBuilder.Par("Salutation", _objUsers.Salutation),
                        ParamBuilder.Par("Description", _objUsers.Description),
                        ParamBuilder.Par("Gender", _objUsers.Gender)
                //ParamBuilder.Par("ProfileImage", _objUsers.ProfileImage)
                    );
        }

        /// <summary>
        /// Logins the users update password dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdatePasswordDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarInt32Sp("TMS_Users_UpdatePassword",
                       ParamBuilder.Par("UserID", _objUsers.UserID),
                       ParamBuilder.Par("UpdatedBy", _objUsers.UpdatedBy),
                       ParamBuilder.Par("UpdatedDate", _objUsers.UpdatedDate),
                       ParamBuilder.Par("Password", _objUsers.Password)
                    );
        }

        /// <summary>
        /// Logins the users update profile image dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdateProfileImageDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarInt32Sp("TMS_Users_UpdateProfileImage",
                       ParamBuilder.Par("UserID", _objUsers.UserID),
                       ParamBuilder.Par("UpdatedBy", _objUsers.UpdatedBy),
                       ParamBuilder.Par("UpdatedDate", _objUsers.UpdatedDate),
                       ParamBuilder.Par("ProfileImage", _objUsers.ProfileImage)
                    );
        }

        /// <summary>
        /// Logins the users delete dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_DeleteDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarInt32Sp("TMS_Users_Delete",
                ParamBuilder.Par("UserID", _objUsers.UserID),
                       ParamBuilder.Par("UpdatedBy", _objUsers.UpdatedBy),
                       ParamBuilder.Par("UpdatedDate", _objUsers.UpdatedDate));
        }
        /// <summary>
        /// Logins the users delete dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UnlockDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarInt32Sp("TMS_Users_Unlock",
                ParamBuilder.Par("UserID", _objUsers.UserID),
                       ParamBuilder.Par("UpdatedBy", _objUsers.UpdatedBy),
                       ParamBuilder.Par("UpdatedDate", _objUsers.UpdatedDate));
        }
        /// <summary>
        /// Logins the users duplication check dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_DuplicationCheckDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarSPInt32("TMS_Users_DuplicationCheck",
             ParamBuilder.Par("Email", _objUsers.Email)
                  );
        }
        /// <summary>
        /// Logins the users duplication check dal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_DuplicationCheckUpdateDAL(LoginUsers _objUsers)
        {
            return ExecuteScalarSPInt32("TMS_Users_DuplicationCheckUpdate",
             ParamBuilder.Par("Email", _objUsers.Email),
             ParamBuilder.Par("UserID ", _objUsers.UserID)

                  );
        }
        
        public int LoginPerson_DuplicationCheckDAL(Person  objperson)
        {
            return ExecuteScalarSPInt32("TMS_Person_DuplicationCheck",
             ParamBuilder.Par("Email", objperson.Email),
             ParamBuilder.Par("createdBy", objperson.CreatedBy)
                  );
        }
        public int LoginPerson_DuplicationCheckUpdateDAL(Person objperson)
        {
            return ExecuteScalarSPInt32("TMS_Person_DuplicationCheckForUpdate",
             ParamBuilder.Par("Email", objperson.Email),
             ParamBuilder.Par("createdBy", objperson.CreatedBy),
             ParamBuilder.Par("PersonID", objperson.ID)

                  );
        }
        

        public int DeletePerson_CheckDAL(ClassTrainerMapping classTrainerMapping)
        {
            return ExecuteScalarSPInt32("TMS_TrainerClassMapping_GetAll",
             ParamBuilder.Par("PersonID", classTrainerMapping.PersonID)
                  );
        }
        public string Person_AllAssignPersonClassesDAL(ClassTrainerMapping classTrainerMapping)
        {
            return ExecuteScalarNvarchar("TMS_TrainerClassGetMapping_GetAll",
             ParamBuilder.Par("PersonID", classTrainerMapping.PersonID),
              ParamBuilder.Par("StartTime", classTrainerMapping.CreatedDate)
                  );
        }
        

        #endregion

        #region  "Trainer CURD"
        /// <summary>
        /// Logins the users get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> TrainerUsers_GetAllDAL(string Culture)
        {
            List<LoginUsers> LoginUserList = new List<LoginUsers>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Users_GetAllTrainer_WithGroups";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", Culture);
                var LoginUsersDictionary = new Dictionary<long, LoginUsers>();
                LoginUserList = conn.Query<LoginUsers, LoginUserGroups, LoginUsers>(
                       qry, (loginUsers, Groups) =>
                       {
                           LoginUsers loginUsersEntry;
                           if (!LoginUsersDictionary.TryGetValue(loginUsers.UserID, out loginUsersEntry))
                           {
                               loginUsersEntry = loginUsers;
                               loginUsersEntry.UserGroups = new List<LoginUserGroups>();
                               LoginUsersDictionary.Add(loginUsersEntry.UserID, loginUsersEntry);
                           }
                           if (Groups != null)
                               loginUsersEntry.UserGroups.Add(Groups);
                           return loginUsersEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "GroupId")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }
        #endregion
    }
}