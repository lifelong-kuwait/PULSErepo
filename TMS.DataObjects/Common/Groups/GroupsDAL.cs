// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-19-2017
// ***********************************************************************
// <copyright file="GroupsDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Groups;
using TMS.Library.Common.Groups;
using TMS.Library.Users;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace TMS.DataObjects.Common.Groups
{
    /// <summary>
    /// Class GroupsDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Groups.IGroupsDAL" />
    public class GroupsDAL : DBGenerics, IGroupsDAL
    {
        #region "Groups"

        public int IsDeletedAllowDAL(SecurityGroups _ObjTMS_Groups)
        {
            return ExecuteScalarSPInt32("TMS_Groups_IsDeleteAllow",
                    ParamBuilder.Par("GroupId", _ObjTMS_Groups.GroupId));
        }
        /// <summary>
        /// TMSs the groups getby group identifier dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        public SecurityGroups TMS_Groups_GetbyGroupIdDAL(string Culture, long GroupId)
        {
            return ExecuteSinglewithSP<SecurityGroups>("TMS_Groups_GetbyId", ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("GroupId", GroupId));
        }
        /// <summary>
        /// TMSs the groups getby group identifier dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        public SecurityGroups TMS_Groups_GetbyGroupIdDALbyOrg(string Culture, long GroupId,string Oid)
        {
            return ExecuteSinglewithSP<SecurityGroups>("TMS_Groups_GetbyIdOrg", ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("GroupId", GroupId), ParamBuilder.Par("Oid",Oid));
        }
        /// <summary>
        /// TMSs the groups get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        public IList<SecurityGroups> TMS_Groups_GetAllDAL(int page,string Culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {



            List<SecurityGroups> groups = new List<SecurityGroups>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Culture = Culture, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, page=page });
                using (var multi = conn.QueryMultiple("TMS_Groups_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    groups = multi.Read<SecurityGroups>().AsList<SecurityGroups>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return groups.ToList();

            // return ExecuteListSp<SecurityGroups>("TMS_Groups_GetAll", ParamBuilder.Par("Culture", Culture));
        }

        /// <summary>
        /// TMSs the groups get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        public IList<SecurityGroups> TMS_GroupsByOrganization_GetAllDAL(int page,string Culture, string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<SecurityGroups> groups = new List<SecurityGroups>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Culture = Culture,Oid=Oid, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText,page=page});
                using (var multi = conn.QueryMultiple("TMS_Groups_GetAllByOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    groups = multi.Read<SecurityGroups>().AsList<SecurityGroups>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return groups.ToList();
            // return ExecuteListSp<SecurityGroups>("TMS_Groups_GetAllByOrganization", ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("Oid", Oid));
        }

        /// <summary>
        /// TMSs the groups create dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Groups_CreateDAL(SecurityGroups _ObjTMS_Groups)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Groups_Create", parameters,
                    ParamBuilder.Par("PrimaryGroupName", _ObjTMS_Groups.PrimaryGroupName),
                    ParamBuilder.Par("SecondaryGroupName", _ObjTMS_Groups.SecondaryGroupName),
                        ParamBuilder.Par("IsDeleteAllowed", _ObjTMS_Groups.IsDeleteAllowed),
                        ParamBuilder.Par("OrganizationID", _ObjTMS_Groups.OrganizationID),
                    ParamBuilder.Par("CreatedBy", _ObjTMS_Groups.CreatedBy),
                    ParamBuilder.Par("CreatedDate", _ObjTMS_Groups.CreatedDate));
        }

        /// <summary>
        /// TMSs the groups update dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Groups_UpdateDAL(SecurityGroups _ObjTMS_Groups)
        {
            return ExecuteScalarInt32Sp("TMS_Groups_Update",
                    ParamBuilder.Par("GroupId", _ObjTMS_Groups.GroupId),
                    ParamBuilder.Par("PrimaryGroupName", _ObjTMS_Groups.PrimaryGroupName),
                    ParamBuilder.Par("SecondaryGroupName", _ObjTMS_Groups.SecondaryGroupName),
                     ParamBuilder.Par("IsDeleteAllowed", _ObjTMS_Groups.IsDeleteAllowed),
                    ParamBuilder.Par("UpdatedBy", _ObjTMS_Groups.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _ObjTMS_Groups.UpdatedDate));
        }

        /// <summary>
        /// TTMSs the groups delete dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        public int TTMS_Groups_DeleteDAL(SecurityGroups _ObjTMS_Groups)
        {
            return ExecuteScalarInt32Sp("TMS_Groups_Delete",
                    ParamBuilder.Par("GroupId", _ObjTMS_Groups.GroupId),
                    ParamBuilder.Par("UpdatedBy", _ObjTMS_Groups.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _ObjTMS_Groups.UpdatedDate));
        }

        /// <summary>
        /// TMSs the groups get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUserAddGroups&gt;.</returns>
        public IList<LoginUserAddGroups> TMS_Groups_GetAllByCultureDAL(string culture)
        {
            List<LoginUserAddGroups> LoginUserAddGroups = new List<LoginUserAddGroups>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Groups_GetAllByCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                LoginUserAddGroups= conn.Query<LoginUserAddGroups>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<LoginUserAddGroups>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }


        public IList<LoginUserAddGroups> TMS_Groups_GetAllByOrganizationCultureDAL(string culture,long CompnayID)
        {
            List<LoginUserAddGroups> LoginUserAddGroups = new List<LoginUserAddGroups>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Groups_GetAllByOrganizationCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                param.Add("@OrganizationID", CompnayID);
                LoginUserAddGroups = conn.Query<LoginUserAddGroups>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<LoginUserAddGroups>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        /// <summary>
        /// TMSs the users TMS groups mapping delete dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <param name="UpdatedBy">The updated by.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Users_TMS_GroupsMapping_DeleteDAL(LoginUserGroups _ObjTMS_Groups, long UpdatedBy)
        {
            return ExecuteScalarInt32Sp("TMS_Users_TMS_GroupsMapping_Delete",
                    ParamBuilder.Par("GroupId", _ObjTMS_Groups.GroupId),
                    ParamBuilder.Par("MappingId", _ObjTMS_Groups.GroupId),
                    ParamBuilder.Par("UserID", _ObjTMS_Groups.Id),
                    ParamBuilder.Par("UpdatedBy", UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", System.DateTime.UtcNow));
        }

        /// <summary>
        /// TMSs the users TMS groups mapping create dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <param name="CreatedBy">The created by.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Users_TMS_GroupsMapping_CreateDAL(LoginUserGroups _ObjTMS_Groups, long CreatedBy)
        {
            var parameters = new[] { ParamBuilder.Par("MappingId", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Users_TMS_GroupsMapping_Create", parameters,
                  ParamBuilder.Par("GroupId", _ObjTMS_Groups.GroupId),
                    ParamBuilder.Par("UserID", _ObjTMS_Groups.Id),
                    ParamBuilder.Par("CreatedBy", CreatedBy),
                    ParamBuilder.Par("CreatedDate", System.DateTime.UtcNow));
        }
        //
        #endregion "Groups"

        #region "Groups Permission"

        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupId(string Culture, long GroupId,long organizationID, long UserID)
        {
            return ExecuteListSp<SecurityGroupsPermission>("TMS_GroupPermissions_GetAllByGroupId", ParamBuilder.Par("counter", 0) , ParamBuilder.Par("OrganizationID", organizationID),ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("GroupId", GroupId), ParamBuilder.Par("userID", UserID));
        }

        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermissions_GetAllByGroupId(string Culture, long GroupId)
        {
            return ExecuteListSp<SecurityGroupsPermission>("TMS_GroupPermission_GetAllByGroupId", ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("GroupId", GroupId));
        }
        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdbyOrg(string Culture, long GroupId,string Oid)
        {
            return ExecuteListSp<SecurityGroupsPermission>("TMS_GroupPermissions_GetAllByGroupIdOrg", ParamBuilder.Par("Culture", Culture), ParamBuilder.Par("GroupId", GroupId),ParamBuilder.Par("Oid",Oid));
        }

        /// <summary>
        /// TMSs the group permissions create dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_GroupPermissions_CreateDAL(SecurityGroupsPermission _objTMS_GroupPermissions)
        {
            var parameters = new[] { ParamBuilder.Par("GroupPermissionId",0) };
            return ExecuteInt64withOutPutparameterSp("TMS_GroupPermissions_Create", parameters,
                    ParamBuilder.Par("GroupId", _objTMS_GroupPermissions.GroupId),
                    ParamBuilder.Par("IsChecked", _objTMS_GroupPermissions.IsChecked),
                    ParamBuilder.Par("CreatedBy", _objTMS_GroupPermissions.CreatedBy),
                    ParamBuilder.Par("CreatedDate", _objTMS_GroupPermissions.CreatedDate),
                    ParamBuilder.Par("PermissionNameId", _objTMS_GroupPermissions.PermissionNameId));
        }

        /// <summary>
        /// TMSs the group permissions update dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_GroupPermissions_UpdateDAL(SecurityGroupsPermission _objTMS_GroupPermissions)
        {
            return ExecuteScalarInt32Sp("TMS_GroupPermissions_Update",
                    ParamBuilder.Par("GroupPermissionId", _objTMS_GroupPermissions.GroupPermissionId),
                    ParamBuilder.Par("IsChecked", _objTMS_GroupPermissions.IsChecked),
                    ParamBuilder.Par("UpdatedBy", _objTMS_GroupPermissions.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objTMS_GroupPermissions.UpdatedDate));
        }

        #endregion "Groups Permission"


    }
}