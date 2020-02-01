// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 05-01-2017
// ***********************************************************************
// <copyright file="IOrganizationDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Address;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;

namespace TMS.DataObjects.Interfaces.TMS.Organization
{
    /// <summary>
    /// Interface IOrganizationDAL
    /// </summary>
    public interface IOrganizationDAL
    {
        /// <summary>
        /// Organization the allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationAllbyCultureDAL(string culture);
        /// <summary>
        /// Organization the allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationAllForTrainerbyCultureDAL(string culture, string email);
        /// <summary>
        /// Organization the allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CertificatesByOiDDAL(long Oid);
        
        /// <summary>
        /// Gets all organization dal.
        /// </summary>
        /// <returns>IList&lt;OrganizationModel&gt;.</returns>
        IList<OrganizationModel> GetAllOrganizationDAL( string SearchText);

        /// <summary>
        /// Gets all organization dal.
        /// </summary>
        /// <returns>IList&lt;OrganizationModel&gt;.</returns>
        IList<OrganizationModel> GetAllOrganizationbyIDDAL(string ID, string SearchText);
        IList<OrganizationModel> GetAllOrganizationbypicIDDAL(long ID);

        /// <summary>
        /// Gets the organization by identifier dal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>OrganizationModel.</returns>
        OrganizationModel GetOrganizationByIdDAL(long Id);

        /// <summary>
        /// Organization the create dal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int64.</returns>
        long Organizations_CreateDAL(OrganizationModel _Organization);

        int Org_UpdateProfileImageDAL(OrganizationModel _Organization);

        /// Organization the update dal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int32.</returns>
        int Organizations_UpdateDAL(OrganizationModel _Organization);

        /// <summary>
        /// Organization the delete dal.
        /// </summary>
        /// <param name="_Organization">The organization.</param>
        /// <returns>System.Int32.</returns>
        int Organizations_DeleteDAL(OrganizationModel _Organization);


        #region "Point of Contact"

        /// <summary>
        /// Gets the point of contact by organization identifier dal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>IList&lt;PointsOfContact&gt;.</returns>
        IList<PointsOfContact> GetPointOfContactByOrganizationIdDAL(long Id);

        /// <summary>
        /// Points the of contact create dal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int64.</returns>
        long PointOfContact_CreateDAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact update dal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_UpdateDAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact delete dal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_DeleteDAL(PointsOfContact _OrganizationRelation);

        /// <summary>
        /// Points the of contact duplication check dal.
        /// </summary>
        /// <param name="_OrganizationRelation">The organization relation.</param>
        /// <returns>System.Int32.</returns>
        int PointOfContact_DuplicationCheckDAL(PointsOfContact _OrganizationRelation);

        #endregion "Point of Contact"


        #region "Link"

        /// <summary>
        /// Organizations the links getby organization identifier.
        /// </summary>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        IList<Links> OrganizationLinks_GetbyOrganizationId(long OrganizationId);

        /// <summary>
        /// Organizations the links create dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns>System.Int64.</returns>
        long OrganizationLinks_CreateDAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links update dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_UpdateDAL(Links _objLinks);

        /// <summary>
        /// Organizations the links delete dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool OrganizationLinks_DeleteDAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links duplication check dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_DuplicationCheckDAL(Links _objLinks, long OrganizationId);

        /// <summary>
        /// Organizations the links get count by organization iddal.
        /// </summary>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns>System.Int32.</returns>
        int OrganizationLinks_GetCountByOrganizationIDDAL(long OrganizationId);
        #endregion "Link"
    }
}