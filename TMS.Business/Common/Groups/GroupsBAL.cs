// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-08-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="GroupsBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Common.Groups;
using TMS.DataObjects.Interfaces.Common.Groups;
using TMS.Library.Common.Groups;
using TMS.Library.Users;

namespace TMS.Business.Common.Groups
{
    /// <summary>
    /// Class GroupsBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.Groups.IGroupsBAL" />
    public class GroupsBAL : IGroupsBAL
    {
        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        /// <value>The dal.</value>
        private IGroupsDAL _DAL { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsBAL" /> class.
        /// </summary>
        /// <param name="GroupDal">The group dal.</param>
        public GroupsBAL(IGroupsDAL GroupDal)
        {
            _DAL = GroupDal;
        }

        #region "Groups"

        public int IsDeletedAllow(SecurityGroups _ObjTMS_Groups)
        {
            return _DAL.IsDeletedAllowDAL(_ObjTMS_Groups);
        }
        /// <summary>
        /// TMSs the groups getby group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        public SecurityGroups TMS_Groups_GetbyGroupIdBAL(string Culture, long GroupId)
        {
            return _DAL.TMS_Groups_GetbyGroupIdDAL(Culture, GroupId);
        }
        /// <summary>
        /// TMSs the groups getby group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>SecurityGroups.</returns>
        public SecurityGroups TMS_Groups_GetbyGroupIdBALbyOrg(string Culture, long GroupId,string Oid)
        {
            return _DAL.TMS_Groups_GetbyGroupIdDALbyOrg(Culture, GroupId,Oid);
        }
        /// <summary>
        /// TMSs the groups get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        public IList<SecurityGroups> TMS_Groups_GetAllBAL(int page,string Culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _DAL.TMS_Groups_GetAllDAL(page,Culture, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// TMSs the groups get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <returns>IList&lt;SecurityGroups&gt;.</returns>
        public IList<SecurityGroups> TMS_GroupsByOrganization_GetAllBAL(int page,string Culture, string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _DAL.TMS_GroupsByOrganization_GetAllDAL(page,Culture,Oid, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// TMSs the groups create bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Groups_CreateBAL(SecurityGroups _ObjTMS_Groups)
        {
            return _DAL.TMS_Groups_CreateDAL(_ObjTMS_Groups);
        }

        /// <summary>
        /// TMSs the groups update bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Groups_UpdateBAL(SecurityGroups _ObjTMS_Groups)
        {
            return _DAL.TMS_Groups_UpdateDAL(_ObjTMS_Groups);
        }

        /// <summary>
        /// TMSs the groups delete bal.
        /// </summary>
        /// <param name="_ObjTMS_Groups">The object TMS groups.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Groups_DeleteBAL(SecurityGroups _ObjTMS_Groups)
        {
            return _DAL.TTMS_Groups_DeleteDAL(_ObjTMS_Groups);
        }

        /// <summary>
        /// TMSs the groups get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUserAddGroups&gt;.</returns>
        public IList<LoginUserAddGroups> TMS_Groups_GetAllByCultureBAL(string culture)
        {
            return _DAL.TMS_Groups_GetAllByCultureDAL(culture);
        }
        public IList<LoginUserAddGroups> TMS_Groups_GetAllByOrganizationCultureBAL(string culture, long CompnayID)
        {
            return _DAL.TMS_Groups_GetAllByOrganizationCultureDAL(culture, CompnayID);
        }
        #endregion "Groups"
        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdBAL(string Culture, long GroupId, long organizationID, long userid)
        {
            return _DAL.SecurityGroupsPermission_GetAllByGroupId(Culture, GroupId, organizationID, userid);
        }

        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermissions_GetAllByGroupIdBAL(string Culture, long GroupId, long userid, string companyID)
        {
            return _DAL.SecurityGroupsPermissions_GetAllByGroupId(Culture, GroupId,userid,companyID);
        }

        /// <summary>
        /// Securities the groups permission get all by group identifier bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>IList&lt;SecurityGroupsPermission&gt;.</returns>
        public IList<SecurityGroupsPermission> SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(string Culture, long GroupId,string Oid)
        {
            return _DAL.SecurityGroupsPermission_GetAllByGroupIdbyOrg(Culture, GroupId,Oid);
        }

        /// <summary>
        /// TMSs the group permissions create dal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_GroupPermissions_CreateDAL(SecurityGroupsPermission _objTMS_GroupPermissions)
        {
            return _DAL.TMS_GroupPermissions_CreateDAL(_objTMS_GroupPermissions);
        }

        /// <summary>
        /// TMSs the group permissions update bal.
        /// </summary>
        /// <param name="_objTMS_GroupPermissions">The object TMS group permissions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_GroupPermissions_UpdateBAL(SecurityGroupsPermission _objTMS_GroupPermissions)
        {
            return _DAL.TMS_GroupPermissions_UpdateDAL(_objTMS_GroupPermissions);
        }

    }
}