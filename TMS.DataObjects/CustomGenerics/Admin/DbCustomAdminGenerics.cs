// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 05-14-2017
// ***********************************************************************
// <copyright file="DbCustomAdminGenerics.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.Library.Admin;

namespace TMS.DataObjects.CustomGenerics.Admin
{
    /// <summary>
    /// Class DbCustomAdminGenerics.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    public class DbCustomAdminGenerics :DBGenerics
    {

        /// <summary>
        /// Inserts the record resources TMS custom return object.
        /// </summary>
        /// <param name="_objTMSResource">The object TMS resource.</param>
        /// <returns>ResourceCreationDual.</returns>
        public ResourceCreationDual InsertRecordResourceTMSCustomReturnObject(TMSResource _objTMSResource)
       {
           ResourceCreationDual _Response= new ResourceCreationDual();

           try{
           SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
           SqlCommand cmd = new SqlCommand("TMS_Admin_InsertResourceDataDual", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@P_ResourceId", _objTMSResource.P_Resourceid);
           cmd.Parameters.Add("@S_ResourceId", _objTMSResource.S_Resourceid);
           cmd.Parameters.AddWithValue("@Name", _objTMSResource.Name);
                cmd.Parameters.AddWithValue("@OrganizationID", _objTMSResource.OrganizationID);
                cmd.Parameters.Add("@P_Value", _objTMSResource.P_Value);
           cmd.Parameters.Add("@S_Value", _objTMSResource.S_Value);
           cmd.Parameters.Add("@CreatedBy", _objTMSResource.CreatedBy);
           
           //SqlParameter parameter = new SqlParameter();
           //parameter.Direction = ParameterDirection.Output;
           //parameter.ParameterName = "@DeliveryCharges";
           //parameter.SqlDbType = SqlDbType.Decimal;
           //parameter.Precision = 18;
           //parameter.Scale = 3;
           //cmd.Parameters.Add(parameter);
           cmd.Parameters["@P_ResourceId"].Direction = ParameterDirection.Output;
           cmd.Parameters["@S_ResourceId"].Direction = ParameterDirection.Output;
           con.Open();
           cmd.ExecuteNonQuery();
           cmd.Dispose();
           con.Close();
           //read the return value (i.e status) from the stored procedure
           _Response.P_Resourceid = Convert.ToInt64(cmd.Parameters["@P_ResourceId"].Value);
           _Response.S_Resourceid = Convert.ToInt64(cmd.Parameters["@S_ResourceId"].Value);
           }
           catch (Exception Ex)
           {
               return null;
           }
           return _Response;
       }

        /// <summary>
        /// Inserts the record resources TMS custom return object.
        /// </summary>
        /// <param name="_objTMSResource">The object TMS resource.</param>
        /// <returns>ResourceCreationDual.</returns>
        /// 
        public ResourceCreationDual InsertRecordResourceOrg(TMSResource _objTMSResource)
        {
            ResourceCreationDual _Response = new ResourceCreationDual();

            try
            {
                SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand("TMS_Admin_InsertResourceDataOrganization", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganizationID", _objTMSResource.OrganizationID);
                cmd.Parameters.Add("@CreatedBy", _objTMSResource.CreatedBy);

                //SqlParameter parameter = new SqlParameter();
                //parameter.Direction = ParameterDirection.Output;
                //parameter.ParameterName = "@DeliveryCharges";
                //parameter.SqlDbType = SqlDbType.Decimal;
                //parameter.Precision = 18;
                //parameter.Scale = 3;
                //cmd.Parameters.Add(parameter);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                //read the return value (i.e status) from the stored procedure
            }
            catch (Exception Ex)
            {
                return null;
            }
            return _Response;
        }
        /// <summary>
        /// Updates the record Resource TMS custom return int.
        /// </summary>
        /// <param name="_objTMSResource">The object TMS resource.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateRecordResourceTMSCustomReturnInt(TMSResource _objTMSResource)
       {
           try
           {
               SqlConnection con = new SqlConnection(DBHelper.ConnectionString);
               SqlCommand cmd = new SqlCommand("TMS_Admin_UpdateResourceDataDual", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@P_ResourceId", _objTMSResource.P_Resourceid);
               cmd.Parameters.AddWithValue("@S_ResourceId", _objTMSResource.S_Resourceid);
               cmd.Parameters.AddWithValue("@P_Value", _objTMSResource.P_Value);
               cmd.Parameters.AddWithValue("@S_Value", _objTMSResource.S_Value);
               cmd.Parameters.AddWithValue("@UpdatedBy", _objTMSResource.UpdatedBy);
               cmd.Parameters.AddWithValue("@result", SqlDbType.Int);
               cmd.Parameters["@result"].Direction = ParameterDirection.Output;
         
               con.Open();
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               //read the return value (i.e status) from the stored procedure
               return Convert.ToInt32(cmd.Parameters["@result"].Value);
               
           }
           catch (Exception)
           {
               return -1;
           }
       }

    }
}
