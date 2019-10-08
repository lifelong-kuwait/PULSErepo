// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="IGroupsBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Groups;
using TMS.Library.Users;

namespace TMS.Business.Interfaces.Common.Groups
{
    /// <summary>
    /// Interface IGroupsBAL
    /// </summary>
    public interface IGroupsBAL
    {
        #region "Groups"

        int IsDeletedAllow(SecurityGroups _ObjTMS_Groups);
        /// <summary>
        /// TMSs the groups getby group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        SecurityGroups TMS_Groups_GetbyGroupIdBAL(string Culture, long GroupId);

       
        /// <summary>
        /// TMSs the groups getby group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        SecurityGroups TMS_Groups_GetbyGroupIdBALbyOrg(string Culture, long GroupId,string Oid);
        /// <summary>
        /// TMSs the groups get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        IList<SecurityGroups> TMS_Groups_GetAllBAL(string Culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the groups get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        IList<SecurityGroups> TMS_GroupsByOrganization_GetAllBAL(string Culture,string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the groups create bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Groups_CreateBAL(SecurityGroups _ObjTMS_Groups);

        /// <summary>
        /// TMSs the groups update bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Groups_UpdateBAL(SecurityGroups _ObjTMS_Groups);

        /// <summary>
        /// TMSs the groups delete bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Groups_DeleteBAL(SecurityGroups _ObjTMS_Groups);
        /// <summary>
        /// TMSs the groups get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUserAddGroups&gt;.</returns>
        IList<LoginUserAddGroups> TMS_Groups_GetAllByCultureBAL(string culture);
        IList<LoginUserAddGroups> TMS_Groups_GetAllByOrganizationCultureBAL(string culture,long CompnayID);

        #endregion "Groups"

        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdBAL(string Culture, long GroupId, long organizationID, long userid);

        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermissions_GetAllByGroupIdBAL(string Culture, long GroupId);

        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(string Culture, long GroupId,string Oid);

        /// <summary>
        /// TMSs the group permissions create dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int64.</returns>
        long TMS_GroupPermissions_CreateDAL(SecurityGroupsPermission _objTMS_GroupPermissions);

        /// <summary>
        /// TMSs the group permissions update bal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_GroupPermissions_UpdateBAL(SecurityGroupsPermission _objTMS_GroupPermissions);
    }
}