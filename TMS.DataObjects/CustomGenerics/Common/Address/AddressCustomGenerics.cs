// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="AddressCustomGenerics.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.Library;

namespace TMS.DataObjects.CustomGenerics.Common.Address
{
    /// <summary>
    /// Class AddressCustomGenerics.
    /// </summary>
    public class AddressCustomGenerics
    {
        /// <summary>
        /// TMSs the person addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_PersonAddresses_DeleteDAL(Addresses _objAddresses, long personId)
        {
            bool _Response = false;

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_PersonAddresses_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AddressID", _objAddresses.ID);
                cmd.Parameters.AddWithValue("PersonID", personId);
                cmd.Parameters.AddWithValue("UpdatedDate", _objAddresses.UpdatedDate);
                cmd.Parameters.AddWithValue("UpdatedBy", _objAddresses.UpdatedBy);
                cmd.Parameters.AddWithValue("IsDeleted", _objAddresses.IsDeleted);
                cmd.Parameters["IsDeleted"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                _Response = Convert.ToBoolean(cmd.Parameters["IsDeleted"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return _Response;
        }


        /// <summary>
        /// TMSs the organization addresses delete dal.
        /// </summary>
        /// <param name="_objAddresses">The object addresses.</param>
        /// <param name="OrganizationID">The organization identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TMS_OrganizationAddresses_DeleteDAL(Addresses _objAddresses, long OrganizationID)
        {
            bool _Response = false;

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_OrganizationAddresses_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AddressID", _objAddresses.ID);
                cmd.Parameters.AddWithValue("OrganizationID", OrganizationID);
                cmd.Parameters.AddWithValue("UpdatedDate", _objAddresses.UpdatedDate);
                cmd.Parameters.AddWithValue("UpdatedBy", _objAddresses.UpdatedBy);
                cmd.Parameters.AddWithValue("IsDeleted", _objAddresses.IsDeleted);
                cmd.Parameters["IsDeleted"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                _Response = Convert.ToBoolean(cmd.Parameters["IsDeleted"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return _Response;
        }
    }
}