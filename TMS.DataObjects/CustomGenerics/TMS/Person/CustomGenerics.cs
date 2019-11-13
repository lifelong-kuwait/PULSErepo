// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="CustomGenerics.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Trainer;

namespace TMS.DataObjects.CustomGenerics
{
    /// <summary>
    /// Class CustomGenerics.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    public class CustomGenerics : DBGenerics
    {
        /// <summary>
        /// Inserts the record person return object.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public Library.TMS.Persons.PersonResponse InsertRecordPersonReturnObject(Person _objPerson, string clientType,long RoleID)
        {
            Library.TMS.Persons.PersonResponse _Response = new Library.TMS.Persons.PersonResponse();

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_Trainer_Create", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", _objPerson.ID);
                cmd.Parameters.AddWithValue("Alias", _objPerson.Alias);
                cmd.Parameters.AddWithValue("SalutationID", _objPerson.SalutationID);
                cmd.Parameters.AddWithValue("P_FirstName", _objPerson.P_FirstName);
                cmd.Parameters.AddWithValue("P_LastName", _objPerson.P_LastName);
                cmd.Parameters.AddWithValue("P_MiddleName", _objPerson.P_MiddleName);
                cmd.Parameters.AddWithValue("P_DisplayName", _objPerson.P_DisplayName);
                cmd.Parameters.AddWithValue("S_FirstName", _objPerson.S_FirstName);
                cmd.Parameters.AddWithValue("S_LastName", _objPerson.S_LastName);
                cmd.Parameters.AddWithValue("S_MiddleName", _objPerson.S_MiddleName);
                cmd.Parameters.AddWithValue("S_DisplayName", _objPerson.S_DisplayName);
                cmd.Parameters.AddWithValue("EngagementStatusId", _objPerson.EngagementStatusId);
                cmd.Parameters.AddWithValue("OrganizationID", _objPerson.OrganizationID);
                cmd.Parameters.AddWithValue("DepartmentID", _objPerson.DepartmentID);
                cmd.Parameters.AddWithValue("Notes", _objPerson.Notes);
                cmd.Parameters.AddWithValue("NationalIdentity", _objPerson.NationalIdentity);
                cmd.Parameters.AddWithValue("OfficialIdentificationTypeID", _objPerson.OfficialIdentificationTypeID);
                cmd.Parameters.AddWithValue("OfficialIDNumber", _objPerson.OfficialIDNumber);
                cmd.Parameters.AddWithValue("DateOfBirth", _objPerson.DateOfBirth);
                cmd.Parameters.AddWithValue("AvailabilityFrom", _objPerson.AvailabilityFrom);
                cmd.Parameters.AddWithValue("AvailabilityTo", _objPerson.AvailabilityTo);
                cmd.Parameters.AddWithValue("LoyaltyPoint", _objPerson.LoyaltyPoint);
                cmd.Parameters.AddWithValue("LoyaltyPointRedeemed", _objPerson.LoyaltyPointRedeemed);
                cmd.Parameters.AddWithValue("Designation", _objPerson.Designation);
                cmd.Parameters.AddWithValue("Password", _objPerson.Password);
                cmd.Parameters.AddWithValue("Gender", _objPerson.Gender);
                cmd.Parameters.AddWithValue("Nationality", 0);
                cmd.Parameters.AddWithValue("Type", _objPerson.Type);
                cmd.Parameters.AddWithValue("IsCoordinator", _objPerson.IsCoordinator);
                cmd.Parameters.AddWithValue("Rating", _objPerson.Rating);
                cmd.Parameters.AddWithValue("ClientType", _objPerson.ClientType);
                cmd.Parameters.AddWithValue("CrmClientType", _objPerson.CrmClientType);
                cmd.Parameters.AddWithValue("CreatedBy", _objPerson.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _objPerson.CreatedDate);
                cmd.Parameters.AddWithValue("UserID", _objPerson.UserID);
                cmd.Parameters.AddWithValue("AdditionalComments", _objPerson.AdditionalComments);
                cmd.Parameters.AddWithValue("IsOnline", _objPerson.IsOnline);
                cmd.Parameters.AddWithValue("MaritalStatus", _objPerson.MaritalStatus);
                cmd.Parameters.AddWithValue("VendorID", _objPerson.VendorID);
                cmd.Parameters.AddWithValue("ClientTypeString", clientType);
                cmd.Parameters.AddWithValue("NickName", _objPerson.NickName);
                cmd.Parameters.AddWithValue("RoleID", RoleID);

                cmd.Parameters["ID"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PersonRegCode", SqlDbType.NVarChar, 50);
                cmd.Parameters["PersonRegCode"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                //read the return value (i.e status) from the stored procedure
                _Response.PersonRegCode = cmd.Parameters["PersonRegCode"].Value.ToString();
                _Response.ID = Convert.ToInt64(cmd.Parameters["ID"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return _Response;
        }


        public Library.TMS.Persons.PersonResponse InsertRecordProspectReturnObject(Person _objPerson, string clientType, long RoleID)
        {
            Library.TMS.Persons.PersonResponse _Response = new Library.TMS.Persons.PersonResponse();

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_Trainer_Create", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", _objPerson.ID);
                cmd.Parameters.AddWithValue("SalutationID", _objPerson.SalutationID);
                cmd.Parameters.AddWithValue("P_FirstName", _objPerson.P_FirstName);
                cmd.Parameters.AddWithValue("P_LastName", _objPerson.P_LastName);
                cmd.Parameters.AddWithValue("P_MiddleName", _objPerson.P_MiddleName);
                cmd.Parameters.AddWithValue("P_DisplayName", _objPerson.P_DisplayName);
                cmd.Parameters.AddWithValue("S_FirstName", _objPerson.S_FirstName);
                cmd.Parameters.AddWithValue("S_LastName", _objPerson.S_LastName);
                cmd.Parameters.AddWithValue("S_MiddleName", _objPerson.S_MiddleName);
                cmd.Parameters.AddWithValue("S_DisplayName", _objPerson.S_DisplayName);
                cmd.Parameters.AddWithValue("EngagementStatusId", _objPerson.EngagementStatusId);
                cmd.Parameters.AddWithValue("OrganizationID", _objPerson.OrganizationID);
                cmd.Parameters.AddWithValue("DepartmentID", _objPerson.DepartmentID);
                cmd.Parameters.AddWithValue("Notes", _objPerson.Notes);
                cmd.Parameters.AddWithValue("NationalIdentity", _objPerson.NationalIdentity);
                cmd.Parameters.AddWithValue("OfficialIdentificationTypeID", _objPerson.OfficialIdentificationTypeID);
                cmd.Parameters.AddWithValue("OfficialIDNumber", _objPerson.OfficialIDNumber);
                cmd.Parameters.AddWithValue("DateOfBirth", _objPerson.DateOfBirth);
                cmd.Parameters.AddWithValue("AvailabilityFrom", _objPerson.AvailabilityFrom);
                cmd.Parameters.AddWithValue("AvailabilityTo", _objPerson.AvailabilityTo);
                cmd.Parameters.AddWithValue("LoyaltyPoint", _objPerson.LoyaltyPoint);
                cmd.Parameters.AddWithValue("LoyaltyPointRedeemed", _objPerson.LoyaltyPointRedeemed);
                cmd.Parameters.AddWithValue("Designation", _objPerson.Designation);
                cmd.Parameters.AddWithValue("Password", _objPerson.Password);
                cmd.Parameters.AddWithValue("CrmClientType", _objPerson.CrmClientType);
                cmd.Parameters.AddWithValue("Gender", _objPerson.Gender);
                cmd.Parameters.AddWithValue("Nationality", 0);
                cmd.Parameters.AddWithValue("Type", _objPerson.Type);
                cmd.Parameters.AddWithValue("IsCoordinator", _objPerson.IsCoordinator);
                cmd.Parameters.AddWithValue("Rating", _objPerson.Rating);
                cmd.Parameters.AddWithValue("ClientType", _objPerson.CrmClientType);
                cmd.Parameters.AddWithValue("CreatedBy", _objPerson.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _objPerson.CreatedDate);
                cmd.Parameters.AddWithValue("UserID", _objPerson.UserID);
                cmd.Parameters.AddWithValue("AdditionalComments", _objPerson.AdditionalComments);
                cmd.Parameters.AddWithValue("IsOnline", _objPerson.IsOnline);
                cmd.Parameters.AddWithValue("MaritalStatus", _objPerson.MaritalStatus);
                cmd.Parameters.AddWithValue("VendorID", _objPerson.VendorID);
                cmd.Parameters.AddWithValue("ClientTypeString", clientType);
                cmd.Parameters.AddWithValue("NickName", _objPerson.NickName);
                cmd.Parameters.AddWithValue("RoleID", RoleID);

                cmd.Parameters["ID"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PersonRegCode", SqlDbType.NVarChar, 50);
                cmd.Parameters["PersonRegCode"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                //read the return value (i.e status) from the stored procedure
                _Response.PersonRegCode = cmd.Parameters["PersonRegCode"].Value.ToString();
                _Response.ID = Convert.ToInt64(cmd.Parameters["ID"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return _Response;
        }





        
        /// <summary>
        /// Inserts the record person return object.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public Library.TMS.Trainer.PersonResponse InsertRecordTrainerReturnObject(Trainer _objTrainer, string clientType,long RoleID)
        {
            Library.TMS.Trainer.PersonResponse _Response = new Library.TMS.Trainer.PersonResponse();

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_Trainer_Create", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", _objTrainer.ID);
                cmd.Parameters.AddWithValue("SalutationID", _objTrainer.SalutationID);
                cmd.Parameters.AddWithValue("P_FirstName", _objTrainer.P_FirstName);
                cmd.Parameters.AddWithValue("P_LastName", _objTrainer.P_LastName);
                cmd.Parameters.AddWithValue("P_MiddleName", _objTrainer.P_MiddleName);
                cmd.Parameters.AddWithValue("P_DisplayName", _objTrainer.P_DisplayName);
                cmd.Parameters.AddWithValue("S_FirstName", _objTrainer.S_FirstName);
                cmd.Parameters.AddWithValue("S_LastName", _objTrainer.S_LastName);
                cmd.Parameters.AddWithValue("S_MiddleName", _objTrainer.S_MiddleName);
                cmd.Parameters.AddWithValue("S_DisplayName", _objTrainer.S_DisplayName);
                cmd.Parameters.AddWithValue("EngagementStatusId", _objTrainer.EngagementStatusId);
                cmd.Parameters.AddWithValue("OrganizationID", _objTrainer.OrganizationID);
                cmd.Parameters.AddWithValue("DepartmentID", _objTrainer.DepartmentID);
                cmd.Parameters.AddWithValue("Notes", _objTrainer.Notes);
                cmd.Parameters.AddWithValue("NationalIdentity", _objTrainer.NationalIdentity);
                cmd.Parameters.AddWithValue("OfficialIdentificationTypeID", _objTrainer.OfficialIdentificationTypeID);
                cmd.Parameters.AddWithValue("OfficialIDNumber", _objTrainer.OfficialIDNumber);
                cmd.Parameters.AddWithValue("DateOfBirth", _objTrainer.DateOfBirth);
                cmd.Parameters.AddWithValue("AvailabilityFrom", _objTrainer.AvailabilityFrom);
                cmd.Parameters.AddWithValue("AvailabilityTo", _objTrainer.AvailabilityTo);
                cmd.Parameters.AddWithValue("LoyaltyPoint", _objTrainer.LoyaltyPoint);
                cmd.Parameters.AddWithValue("LoyaltyPointRedeemed", _objTrainer.LoyaltyPointRedeemed);
                cmd.Parameters.AddWithValue("Designation", _objTrainer.Designation);
                cmd.Parameters.AddWithValue("Password", _objTrainer.Password);
                cmd.Parameters.AddWithValue("Gender", _objTrainer.Gender);
                cmd.Parameters.AddWithValue("Nationality", 0);
                cmd.Parameters.AddWithValue("Type", _objTrainer.Type);
                cmd.Parameters.AddWithValue("IsCoordinator", _objTrainer.IsCoordinator);
                cmd.Parameters.AddWithValue("Rating", _objTrainer.Rating);
                cmd.Parameters.AddWithValue("ClientType", _objTrainer.ClientType);
                cmd.Parameters.AddWithValue("CreatedBy", _objTrainer.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _objTrainer.CreatedDate);
                cmd.Parameters.AddWithValue("UserID", _objTrainer.UserID);
                cmd.Parameters.AddWithValue("AdditionalComments", _objTrainer.AdditionalComments);
                cmd.Parameters.AddWithValue("IsOnline", _objTrainer.IsOnline);
                cmd.Parameters.AddWithValue("MaritalStatus", _objTrainer.MaritalStatus);
                cmd.Parameters.AddWithValue("VendorID", _objTrainer.VendorID);
                cmd.Parameters.AddWithValue("ClientTypeString", clientType);
                cmd.Parameters.AddWithValue("NickName", _objTrainer.NickName);
                cmd.Parameters.AddWithValue("RoleID", RoleID);

                cmd.Parameters["ID"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PersonRegCode", SqlDbType.NVarChar, 50);
                cmd.Parameters["PersonRegCode"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                //read the return value (i.e status) from the stored procedure
                _Response.PersonRegCode = cmd.Parameters["PersonRegCode"].Value.ToString();
                _Response.ID = Convert.ToInt64(cmd.Parameters["ID"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return _Response;
        }
    }
}