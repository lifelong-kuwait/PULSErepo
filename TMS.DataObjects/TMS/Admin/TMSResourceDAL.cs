// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-04-2017
// ***********************************************************************
// <copyright file="TMSResourceDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.CustomGenerics.Admin;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Admin;
using TMS.Library.Admin;
using Dapper;
using DapperExtensions;
using System.Data.SqlClient;
using System.Linq;
namespace TMS.DataObjects.TMS.Admin
{
    /// <summary>
    /// Class TMSResourceDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.Admin.ITMSResourceDAL" />
    public class TMSResourceDAL : DBGenerics, ITMSResourceDAL
    {
        /// <summary>
        /// Gets the TMS resource dal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        public IList<TMSResource> GetTMSResourceDAL(int Page, int PageSize, ref int Total, string SearchText,string Oids)
        {
            //return ExecuteListSp<TMSResource>("TMS_Admin_GetResourcesIndex");

            List<TMSResource> Users = new List<TMSResource>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Page = Page, PageSize = PageSize,  SearchText= SearchText,Oid = Oids });
                using (var multi = conn.QueryMultiple("TMS_Admin_GetResourcesIndex", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Users = multi.Read<TMSResource>().AsList<TMSResource>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }
               
                conn.Close();
            }
            return Users.ToList();


        }
        //public ResourceCreationDual InsertOrgResourceDAL(TMSResource _obj)
        //{
        //    DbCustomAdminGenerics db = new DbCustomAdminGenerics();
        //    return db.InsertRecordResourceOrg(_obj);
        //}
        public int ResourceExistCountDAL(string Name)
        {
            return ExecuteScalarInt32("Select Count(*) From Resources where Name=@name", ParamBuilder.Par("name", Name));
        }



        public int LanguageExistCountDAL(long CompnayID)
        {
            return ExecuteScalarInt32("Select Count(*) From CoreLanguages where OrganizationID=@OrganizationID", ParamBuilder.Par("OrganizationID", CompnayID));
        }
        /// <summary>
        /// Gets the TMS resource dal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        public IList<TMSResource> GetTMSResourceDALbyOrganization(int Page, int PageSize, ref int Total, string Oid, string SearchText)
        {
            //return ExecuteListSp<TMSResource>("TMS_Admin_GetResourcesIndex");

            List<TMSResource> Users = new List<TMSResource>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Page = Page, PageSize = PageSize, Oid = Oid, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_Admin_GetResourcesIndexbyOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Users = multi.Read<TMSResource>().AsList<TMSResource>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Users;


        }

        /// <summary>
        /// Inserts the dual TMS resource dal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>ResourceCreationDual.</returns>
        public ResourceCreationDual InsertDualTMSResourceDAL(TMSResource _obj)
        {
            DbCustomAdminGenerics db = new DbCustomAdminGenerics();
            return db.InsertRecordResourceTMSCustomReturnObject(_obj);
        }

        /// <summary>
        /// Updates the dual TMS resource dal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        public ResourceCreationDual InsertOrgResourceDAL(TMSResource _obj)
        {
            DbCustomAdminGenerics db = new DbCustomAdminGenerics();
            return db.InsertRecordResourceOrg(_obj);
        }
        /// <summary>
        /// Updates the dual TMS resource dal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateDualTMSResourceDAL(TMSResource _obj)
        {
            DbCustomAdminGenerics db = new DbCustomAdminGenerics();
            return db.UpdateRecordResourceTMSCustomReturnInt(_obj);
        }

        /// <summary>
        /// Resources the exist count dal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        //public int ResourceExistCountDAL(string Name)
        //{
        //    return ExecuteScalarInt32("Select Count(*) From Resources where Name=@name", ParamBuilder.Par("name", Name));
        //}
    }
}