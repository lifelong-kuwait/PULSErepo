// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 03-05-2017
// ***********************************************************************
// <copyright file="IAddressDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library;

namespace TMS.DataObjects.Interfaces.Common.Address
{
    /// <summary>
    /// Interface IAddressDAL
    /// </summary>
    public interface IAddressDAL
    {
        int Address_DuplicationCheckDAL(Addresses _objAddresses);
        /// <summary>
        /// TMSs the person addresses update dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonAddresses_UpdateDAL(Addresses _objAddresses);

        /// <summary>
        /// TMSs the person addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_PersonAddresses_DeleteDAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the person addresses create dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonAddresses_CreateDAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the person addresses getby person identifier dal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        IList<Addresses> TMS_PersonAddresses_GetbyPersonIdDAL(string personId);

        #region "Organization Addresses"

        /// <summary>
        /// TMSs the organization addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_OrganizationAddresses_DeleteDAL(Addresses _objAddresses, long OrganizationId);

        /// <summary>
        /// TMSs the organization addresses create dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>System.Int64.</returns>
        long TMS_OrganizationAddresses_CreateDAL(Addresses _objAddresses, long OrganizationId);

        /// <summary>
        /// TMSs the organization addresses getby organization identifier dal.
        /// </summary>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        IList<Addresses> TMS_OrganizationAddresses_GetbyOrganizationIdDAL(string OrganizationId);

        #endregion "Organization Addresses"
    }
}