// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-08-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="AddressBAL.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Common.Address;
using TMS.DataObjects.Common.Address;
using TMS.DataObjects.Interfaces.Common.Address;
using TMS.Library;

namespace TMS.Business.Common.Address
{
    /// <summary>
    /// Class AddressBAL. Business logic class for address
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.Address.IAddressBAL" />
    public class AddressBAL : IAddressBAL
    {
        /// <summary>
        /// The dal
        /// </summary>
        private readonly IAddressDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBAL" /> class.
        /// </summary>
        public AddressBAL()
        {
            DAL = new AddressDAL();
        }
        public int Address_DuplicationCheckBAL(Addresses _objAddresses)
        {
            return DAL.Address_DuplicationCheckDAL(_objAddresses);
        }
        /// <summary>
        /// TMSs the person addresses update bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonAddresses_UpdateBAL(Addresses _objAddresses)
        {
            return DAL.TMS_PersonAddresses_UpdateDAL(_objAddresses);
        }

        /// <summary>
        /// TMSs the person addresses delete bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_PersonAddresses_DeleteBAL(Addresses _objAddresses, long personId)
        {
            return DAL.TMS_PersonAddresses_DeleteDAL(_objAddresses, personId);
        }

        /// <summary>
        /// TMSs the person addresses create bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonAddresses_CreateBAL(Addresses _objAddresses, long personId)
        {
            return DAL.TMS_PersonAddresses_CreateDAL(_objAddresses, personId);
        }

        /// <summary>
        /// TMSs the person addresses getby person identifier bal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        public IList<Addresses> TMS_PersonAddresses_GetbyPersonIdBAL(string personId)
        {
            return DAL.TMS_PersonAddresses_GetbyPersonIdDAL(personId);
        }

        /// <summary>
        /// TMSs the organization addresses delete bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_OrganizationAddresses_DeleteBAL(Addresses _objAddresses, long personId)
        {
            return DAL.TMS_OrganizationAddresses_DeleteDAL(_objAddresses, personId);
        }

        /// <summary>
        /// TMSs the organization addresses create bal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_OrganizationAddresses_CreateBAL(Addresses _objAddresses, long personId)
        {
            return DAL.TMS_OrganizationAddresses_CreateDAL(_objAddresses, personId);
        }

        /// <summary>
        /// TMSs the organization addresses getby organization identifier bal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        public IList<Addresses> TMS_OrganizationAddresses_GetbyOrganizationIdBAL(string personId)
        {
            return DAL.TMS_OrganizationAddresses_GetbyOrganizationIdDAL(personId);
        }
    }
}