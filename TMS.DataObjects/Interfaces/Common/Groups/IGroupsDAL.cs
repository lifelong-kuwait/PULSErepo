// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="IGroupsDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Groups;
using TMS.Library.Users;

namespace TMS.DataObjects.Interfaces.Common.Groups
{
    /// <summary>
    /// Interface IGroupsDAL
    /// </summary>
    public interface IGroupsDAL
    {
        #region "Groups"

        int IsDeletedAllowDAL(SecurityGroups _ObjTMS_Groups);
        /// <summary>
        /// TMSs the groups getby group identifier dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        SecurityGroups TMS_Groups_GetbyGroupIdDAL(string Culture, long GroupId);

        /// <summary>
        /// TMSs the groups getby group identifier dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        SecurityGroups TMS_Groups_GetbyGroupIdDALbyOrg(string Culture, long GroupId,string Oid);

        /// <summary>
        /// TMSs the groups get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        IList<SecurityGroups> TMS_Groups_GetAllDAL(string Culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the groups get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        IList<SecurityGroups> TMS_GroupsByOrganization_GetAllDAL(string Culture, string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the groups create dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Groups_CreateDAL(SecurityGroups _ObjTMS_Groups);

        /// <summary>
        /// TMSs the groups update dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Groups_UpdateDAL(SecurityGroups _ObjTMS_Groups);

        /// <summary>
        /// TTMSs the groups delete dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        int TTMS_Groups_DeleteDAL(SecurityGroups _ObjTMS_Groups);

        /// <summary>
        /// TMSs the groups get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUserAddGroups&gt;.</returns>
        IList<LoginUserAddGroups> TMS_Groups_GetAllByCultureDAL(string culture);
        /// <summary>
        /// TMSs the users TMS groups mapping create dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <param name="CreatedBy">The created by.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Users_TMS_GroupsMapping_CreateDAL(LoginUserGroups _ObjTMS_Groups, long CreatedBy);
        /// <summary>
        /// TMSs the users TMS groups mapping delete dal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <param name="UpdatedBy">The updated by.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Users_TMS_GroupsMapping_DeleteDAL(LoginUserGroups _ObjTMS_Groups, long UpdatedBy);
        #endregion "Groups"

        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupId(string Culture, long GroupId);

        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermissions_GetAllByGroupId(string Culture, long GroupId);
        IList<LoginUserAddGroups> TMS_Groups_GetAllByOrganizationCultureDAL(string culture, long CompnayID);

        /// <summary>
        /// Securities the groups permission get all by group identifier.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdbyOrg(string Culture, long GroupId,string Oid);

        /// <summary>
        /// TMSs the group permissions create dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int64.</returns>
        long TMS_GroupPermissions_CreateDAL(SecurityGroupsPermission _objTMS_GroupPermissions);

        /// <summary>
        /// TMSs the group permissions update dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_GroupPermissions_UpdateDAL(SecurityGroupsPermission _objTMS_GroupPermissions);
    }
}