// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IOrganizationBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Address;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;

namespace TMS.Business.Interfaces.TMS.Organization
{
    /// <summary>
    /// Interface IOrganizationBAL
    /// </summary>
    public interface IOrganizationBAL
    {
        /// <summary>
        /// Organizations the allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationAllbyCultureBAL(string culture);
        /// <summary>
        /// Organizations the allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CertificatesByOiDBAL(long Oid);
        /// <summary>
        /// Gets all organization bal.
        /// </summary>
        /// <returns>IList&lt;OrganizationModel&gt;.</returns>
        IList<OrganizationModel> GetAllOrganizationBAL(string SearchText);

        /// <summary>
        /// Gets all organization by ID bal.
        /// </summary>
        /// <param name="culture">The Organization ID.</param>
        /// <returns>IList&lt;OrganizationModel&gt;.</returns>
        IList<OrganizationModel> GetAllOrganizationbyIDBAL(string ID,  string SearchText);
        IList<OrganizationModel> GetAllOrganizationbypicBAL(long ID);

        /// <summary>
        /// Gets the organization by identifier bal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>OrganizationModel.</returns>
        OrganizationModel GetOrganizationByIdBAL(long Id);

        /// <summary>
        /// Organizations the create bal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int64.</returns>
        long Organizations_CreateBAL(OrganizationModel _Organization);
        int Org_UpdateProfileImageBAL(OrganizationModel _Organization);

        /// <summary>
        /// Organizationses the update bal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int32.</returns>
        int Organizations_UpdateBAL(OrganizationModel _Organization);

        /// <summary>
        /// Organizationses the delete bal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int32.</returns>
        int Organizations_DeleteBAL(OrganizationModel _Organization);

        #region "Point of Contact"

        /// <summary>
        /// Gets the point of contact by organization identifier bal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>IList&lt;PointsOfContact&gt;.</returns>
        IList<PointsOfContact> GetPointOfContactByOrganizationIdBAL(long Id);

        /// <summary>
        /// Points the of contact create bal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int64.</returns>
        long PointOfContact_CreateBAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact update bal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_UpdateBAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact delete bal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_DeleteBAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact duplication check bal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_DuplicationCheckBAL(PointsOfContact _OrganizationRelation);

        #endregion "Point of Contact"

        #region"Organization Links"

        /// <summary>
        /// Organizations the links getby organization identifier bal.
        /// </summary>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        IList<Links> OrganizationLinks_GetbyOrganizationIdBAL(long OrganizationId);

        /// <summary>
        /// Organizations the links create bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>System.Int64.</returns>
        long OrganizationLinks_CreateBAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links update bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_UpdateBAL(Links _objLinks);

        /// <summary>
        /// Organizations the links delete bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool OrganizationLinks_DeleteBAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links duplication check bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_DuplicationCheckBAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links get count by organization idbal.
        /// </summary>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_GetCountByOrganizationIDBAL(long OrganizationId);

        #endregion"Links"
    }
}