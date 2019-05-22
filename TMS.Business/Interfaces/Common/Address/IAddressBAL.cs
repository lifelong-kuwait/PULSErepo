// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 03-05-2017
// ***********************************************************************
// <copyright file="IAddressBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library;

namespace TMS.Business.Interfaces.Common.Address
{
    /// <summary>
    /// Interface IAddressBAL
    /// </summary>
    public interface IAddressBAL
    {
        int Address_DuplicationCheckBAL(Addresses _objAddresses);
        /// <summary>
        /// TMSs the person addresses update bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonAddresses_UpdateBAL(Addresses _objAddresses);

        /// <summary>
        /// TMSs the person addresses delete bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_PersonAddresses_DeleteBAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the person addresses create bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonAddresses_CreateBAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the person addresses getby person identifier bal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        IList<Addresses> TMS_PersonAddresses_GetbyPersonIdBAL(string personId);

        /// <summary>
        /// TMSs the organization addresses delete bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TMS_OrganizationAddresses_DeleteBAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the organization addresses create bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long TMS_OrganizationAddresses_CreateBAL(Addresses _objAddresses, long personId);

        /// <summary>
        /// TMSs the organization addresses getby organization identifier bal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        IList<Addresses> TMS_OrganizationAddresses_GetbyOrganizationIdBAL(string personId);
    }
}