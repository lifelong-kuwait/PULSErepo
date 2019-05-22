// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 03-05-2017
// ***********************************************************************
// <copyright file="AddressDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.CustomGenerics.Common.Address;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Address;
using TMS.Library;

namespace TMS.DataObjects.Common.Address
{
    /// <summary>
    /// Class AddressDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Address.IAddressDAL" />
    public class AddressDAL : DBGenerics, IAddressDAL
    {
        public int Address_DuplicationCheckDAL(Addresses _objAddresses)
        {
            return ExecuteScalarSPInt32("TMS_Address_DuplicationCheck",
             ParamBuilder.Par("AddressLine1", _objAddresses.AddressLine1),
             ParamBuilder.Par("AddressType", _objAddresses.AddressType),
             ParamBuilder.Par("CountryID", _objAddresses.CountryID),
             ParamBuilder.Par("StateID", _objAddresses.StateID)
                  );
        }
        /// <summary>
        /// TMSs the person addresses update dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonAddresses_UpdateDAL(Addresses _objAddresses)
        {
            return ExecuteScalarInt32Sp("TMS_Addresses_Update",
                    ParamBuilder.Par("ID", _objAddresses.ID),
                    ParamBuilder.Par("AddressLine1", _objAddresses.AddressLine1),
                    ParamBuilder.Par("AddressLine2", _objAddresses.AddressLine2),
                    ParamBuilder.Par("ZipCode", _objAddresses.ZipCode),
                    ParamBuilder.Par("CityID", _objAddresses.CityID),
                    ParamBuilder.Par("StateID", _objAddresses.StateID),
                    ParamBuilder.Par("IsBillingAddress", _objAddresses.IsBillingAddress),
                    ParamBuilder.Par("CountryID", _objAddresses.CountryID),
                    ParamBuilder.Par("AddressType", _objAddresses.AddressType),
                    ParamBuilder.Par("UpdatedDate", _objAddresses.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _objAddresses.UpdatedBy)
                 );
        }

        #region "Person Addresses"

        /// <summary>
        /// TMSs the person addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_PersonAddresses_DeleteDAL(Addresses _objAddresses, long personId)
        {
            AddressCustomGenerics _custom = new AddressCustomGenerics();
            return _custom.TMS_PersonAddresses_DeleteDAL(_objAddresses, personId);
        }

        /// <summary>
        /// TMSs the person addresses create dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonAddresses_CreateDAL(Addresses _objAddresses, long personId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonAddresses_Create", parameters,
                   ParamBuilder.Par("PersonID", personId),
                    ParamBuilder.Par("AddressLine1", _objAddresses.AddressLine1),
                    ParamBuilder.Par("AddressLine2", _objAddresses.AddressLine2),
                    ParamBuilder.Par("ZipCode", _objAddresses.ZipCode),
                    ParamBuilder.Par("CityID", _objAddresses.CityID),
                    ParamBuilder.Par("StateID", _objAddresses.StateID),
                    ParamBuilder.Par("IsBillingAddress", _objAddresses.IsBillingAddress),
                    ParamBuilder.Par("CountryID", _objAddresses.CountryID),
                    ParamBuilder.Par("AddressType", _objAddresses.AddressType),
                    ParamBuilder.Par("CreatedDate", _objAddresses.CreatedDate),
                    ParamBuilder.Par("CreatedBy", _objAddresses.CreatedBy)
                 );
        }

        /// <summary>
        /// TMSs the person addresses getby person identifier dal.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        public IList<Addresses> TMS_PersonAddresses_GetbyPersonIdDAL(string personId)
        {
            return ExecuteListSp<Addresses>("TMS_PersonAddresses_GetbyPersonId", ParamBuilder.Par("PersonID", personId));
        }

        #endregion "Person Addresses"

        #region "Organization Addresses"

        /// <summary>
        /// TMSs the organization addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_OrganizationAddresses_DeleteDAL(Addresses _objAddresses, long OrganizationId)
        {
            AddressCustomGenerics _custom = new AddressCustomGenerics();
            return _custom.TMS_OrganizationAddresses_DeleteDAL(_objAddresses, OrganizationId);
        }

        /// <summary>
        /// TMSs the organization addresses create dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_OrganizationAddresses_CreateDAL(Addresses _objAddresses, long OrganizationId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_OrganizationAddresses_Create", parameters,
                   ParamBuilder.Par("OrganizationID", OrganizationId),
                    ParamBuilder.Par("AddressLine1", _objAddresses.AddressLine1),
                    ParamBuilder.Par("AddressLine2", _objAddresses.AddressLine2),
                    ParamBuilder.Par("ZipCode", _objAddresses.ZipCode),
                    ParamBuilder.Par("CityID", _objAddresses.CityID),
                    ParamBuilder.Par("StateID", _objAddresses.StateID),
                    ParamBuilder.Par("IsBillingAddress", _objAddresses.IsBillingAddress),
                    ParamBuilder.Par("CountryID", _objAddresses.CountryID),
                    ParamBuilder.Par("AddressType", _objAddresses.AddressType),
                    ParamBuilder.Par("CreatedDate", _objAddresses.CreatedDate),
                    ParamBuilder.Par("CreatedBy", _objAddresses.CreatedBy)
                 );
        }

        /// <summary>
        /// TMSs the organization addresses getby organization identifier dal.
        /// </summary>
        /// <param name="OrganizationId">The organization identifier.</param>
        /// <returns>IList&lt;Addresses&gt;.</returns>
        public IList<Addresses> TMS_OrganizationAddresses_GetbyOrganizationIdDAL(string OrganizationId)
        {
            return ExecuteListSp<Addresses>("TMS_OrganizationAddresses_GetbyOrganizationId", ParamBuilder.Par("OrganizationID", OrganizationId));
        }

        #endregion "Organization Addresses"
    }
}