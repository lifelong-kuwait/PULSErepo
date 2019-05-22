// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-24-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ConfigurationDALFlags.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.Library.TMS.Admin.Config;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region"Flags"
        public IList<PersonFlags> PersonFlags_GetALL()
        {
            //List<PersonFlags> flag = new List<PersonFlags>();
            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
            //    using (var multi = conn.QueryMultiple("TMS_PersonFlags_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        flag = multi.Read<PersonFlags>().AsList<PersonFlags>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();
            //    }

            //    conn.Close();
            //}
            //return flag.ToList();
            return ExecuteListSp<PersonFlags>("TMS_PersonFlags_GetAll");
        }
        public IList<PersonFlags> PersonFlagsbyOrganization_GetALL(string Oid)
        {
            //List<PersonFlags> flag = new List<PersonFlags>();
            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    dbParam.AddDynamicParams(new { Oid = Oid, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
            //    using (var multi = conn.QueryMultiple("TMS_PersonFlags_GetAllbyOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        flag = multi.Read<PersonFlags>().AsList<PersonFlags>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();
            //    }

            //    conn.Close();
            //}
            //return flag.ToList();
            return ExecuteListSp<PersonFlags>("TMS_PersonFlags_GetAllbyOrganization", ParamBuilder.Par("Oid",Oid));
        }
        /// <summary>
        /// Persons the flags get all.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        public IList<PersonFlags> PersonFlags_GetALL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<PersonFlags> flag = new List<PersonFlags>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_PersonFlags_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    flag = multi.Read<PersonFlags>().AsList<PersonFlags>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return flag.ToList();
            // return ExecuteListSp<PersonFlags>("TMS_PersonFlags_GetAll");
        }

        /// <summary>
        /// Persons the flags get all.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        public IList<PersonFlags> PersonFlagsbyOrganization_GetALL(string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<PersonFlags> flag = new List<PersonFlags>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new {Oid=Oid, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_PersonFlags_GetAllbyOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    flag = multi.Read<PersonFlags>().AsList<PersonFlags>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return flag.ToList();
            // return ExecuteListSp<PersonFlags>("TMS_PersonFlags_GetAllbyOrganization", ParamBuilder.Par("Oid",Oid));
        }

        /// <summary>
        /// Persons the flags create dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int64.</returns>
        public long PersonFlags_CreateDAL(PersonFlags _objPersonFlags)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonFlags_Create", parameters,
                                ParamBuilder.Par("P_FlagName", _objPersonFlags.P_FlagName),
                                ParamBuilder.Par("S_FlagName", _objPersonFlags.S_FlagName),
                                ParamBuilder.Par("FlagColor", _objPersonFlags.FlagColor),
                                ParamBuilder.Par("OrganizationID", _objPersonFlags.OrganizationID),
                                ParamBuilder.Par("CreatedDate", _objPersonFlags.CreatedDate),
                                ParamBuilder.Par("CreatedBy", _objPersonFlags.CreatedBy));
        }

        /// <summary>
        /// Persons the flags update dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_UpdateDAL(PersonFlags _objPersonFlags)
        {
            return ExecuteScalarInt32Sp("TMS_PersonFlags_Update",
                                ParamBuilder.Par("ID", _objPersonFlags.ID),
                                ParamBuilder.Par("P_FlagName", _objPersonFlags.P_FlagName),
                                ParamBuilder.Par("S_FlagName", _objPersonFlags.S_FlagName),
                                ParamBuilder.Par("FlagColor", _objPersonFlags.FlagColor),
                                ParamBuilder.Par("UpdatedDate", _objPersonFlags.UpdatedDate),
                                ParamBuilder.Par("UpdatedBy", _objPersonFlags.UpdatedBy));
        }

        /// <summary>
        /// Persons the flags delete dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonFlags_DeleteDAL(PersonFlags _objPersonFlags)
        {
            var parameters = new[] { ParamBuilder.Par("IsDeleted", false) };
            return ExecuteBoolwithOutPutparameterSp("TMS_PersonFlags_Delete", parameters,
                                ParamBuilder.Par("ID", _objPersonFlags.ID),
                                ParamBuilder.Par("UpdatedDate", _objPersonFlags.UpdatedDate),
                                ParamBuilder.Par("UpdatedBy", _objPersonFlags.UpdatedBy));
        }

        /// <summary>
        /// Persons the flags duplication check dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_DuplicationCheckDAL(PersonFlags _objPersonFlags,long CompanyID)
        {
            return ExecuteScalarSPInt32("TMS_PersonFlags_DuplicationCheck",
                    ParamBuilder.Par("ID", _objPersonFlags.ID),
                                ParamBuilder.Par("P_FlagName", _objPersonFlags.P_FlagName),
                                  ParamBuilder.Par("OrganizationID", CompanyID)
                                );
        }

        /// <summary>
        /// Persons the flags get count by person id dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_GetCountByPersonIDDAL(PersonFlags _objPersonFlags, string PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonEmailAddresses_GetCountByPersonID",
                    ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the flags get all culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;PersonFlagsDDL&gt;.</returns>
        public IList<PersonFlagsDDL> PersonFlags_GetAllCultureDAL(string culture, long CompanyID)
        {
            return ExecuteListSp<PersonFlagsDDL>("TMS_PersonFlags_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("OrganizationID", CompanyID));
        }


        public IList<PersonFlagsDDL> PersonFlag_GetAllCultureDAL(string culture)
        {
            return ExecuteListSp<PersonFlagsDDL>("TMS_PersonFlag_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }


        /// <summary>
        /// Persons the flags insert by person identifier.
        /// </summary>
        /// <param name="flagID">The flag identifier.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="CreatedBy">The created by.</param>
        /// <returns>System.Int64.</returns>
        public long PersonFlags_InsertByPersonID(long flagID, string PersonId, long? CreatedBy)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonFlagsMapping_Create", parameters,
                                ParamBuilder.Par("FlagsID", flagID),
                                ParamBuilder.Par("PersonID", PersonId),
                                ParamBuilder.Par("CreatedDate", DateTime.Now),
                                ParamBuilder.Par("CreatedBy", CreatedBy));
        }

        /// <summary>
        /// Persons the flags delete by person identifier.
        /// </summary>
        /// <param name="flagID">The flag identifier.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="UpdatedBy">The updated by.</param>
        /// <returns>System.Int64.</returns>
        public long PersonFlags_DeleteByPersonID(long flagID, string PersonId, long? UpdatedBy)
        {
            return ExecuteScalarSPInt32("TMS_PersonFlagsMapping_Delete",
                                ParamBuilder.Par("FlagsID", flagID),
                                ParamBuilder.Par("PersonID", PersonId),
                                ParamBuilder.Par("UpdatedDate", DateTime.Now),
                                ParamBuilder.Par("UpdatedBy", UpdatedBy));
        }

        #endregion
    }
}