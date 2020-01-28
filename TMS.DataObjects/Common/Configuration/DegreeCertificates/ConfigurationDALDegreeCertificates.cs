// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-28-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-28-2018
// ***********************************************************************
// <copyright file="ConfigurationDALDegreeCertificates.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.Library.Entities.Common.Configuration;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region DegreeCertificates

        /// <summary>
        /// Degrees the certificates get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        public List<DegreeCertificates> DegreeCertificates_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<DegreeCertificates> DegreeCertificates = new List<DegreeCertificates>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_DegreeCertificates_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    DegreeCertificates = multi.Read<DegreeCertificates>().AsList<DegreeCertificates>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return DegreeCertificates.ToList();
        }

        /// <summary>
        /// Degrees the certificates get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        public List<DegreeCertificates> DegreeCertificates_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<DegreeCertificates> DegreeCertificates = new List<DegreeCertificates>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid=Oid });
                using (var multi = conn.QueryMultiple("TMS_DegreeCertificates_GetAllbyOrg", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    DegreeCertificates = multi.Read<DegreeCertificates>().AsList<DegreeCertificates>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return DegreeCertificates.ToList();
        }

        /// <summary>
        /// Degrees the certificates create dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int64.</returns>
        public long DegreeCertificates_CreateDAL(DegreeCertificates _objDegreeCertificates)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_DegreeCertificates_Create", parameters,
                   ParamBuilder.Par("PrimaryName", _objDegreeCertificates.PrimaryName),
                   ParamBuilder.Par("SecondaryName", _objDegreeCertificates.SecondaryName),
                   ParamBuilder.Par("PrimaryDescription", _objDegreeCertificates.PrimaryDescription),
                   ParamBuilder.Par("SecondaryDescription", _objDegreeCertificates.SecondaryDescription),
                   ParamBuilder.Par("OrganizationID", _objDegreeCertificates.OrganizationID),
                   ParamBuilder.Par("CreatedBy", _objDegreeCertificates.CreatedBy),
                   ParamBuilder.Par("CreatedDate", _objDegreeCertificates.CreatedDate));
        }

        /// <summary>
        /// Degrees the certificates update dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_UpdateDAL(DegreeCertificates _objDegreeCertificates)
        {
            return ExecuteScalarInt32Sp("TMS_DegreeCertificates_Update",
                   ParamBuilder.Par("ID", _objDegreeCertificates.ID),
                   ParamBuilder.Par("PrimaryName", _objDegreeCertificates.PrimaryName),
                   ParamBuilder.Par("SecondaryName", _objDegreeCertificates.SecondaryName),
                   ParamBuilder.Par("PrimaryDescription", _objDegreeCertificates.PrimaryDescription),
                   ParamBuilder.Par("SecondaryDescription", _objDegreeCertificates.SecondaryDescription),
                   ParamBuilder.Par("UpdatedBy", _objDegreeCertificates.UpdatedBy),
                   ParamBuilder.Par("UpdatedDate", _objDegreeCertificates.UpdatedDate));
        }

        /// <summary>
        /// Degrees the certificates delete dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_DeleteDAL(DegreeCertificates _objDegreeCertificates)
        {
            return ExecuteScalarInt32Sp("TMS_DegreeCertificates_Delete",
                   ParamBuilder.Par("ID", _objDegreeCertificates.ID),
                   ParamBuilder.Par("UpdatedBy", _objDegreeCertificates.UpdatedBy),
                   ParamBuilder.Par("UpdatedDate", _objDegreeCertificates.UpdatedDate));
        }

        /// <summary>
        /// Degrees the certificates duplication check dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_DuplicationCheckDAL(DegreeCertificates _objDegreeCertificates)
        {
            return ExecuteScalarSPInt32("TMS_DegreeCertificates_DuplicationCheck",
                   ParamBuilder.Par("ID", _objDegreeCertificates.ID), 
                   ParamBuilder.Par("OrganizationId", _objDegreeCertificates.OrganizationID),
                   ParamBuilder.Par("PrimaryName", _objDegreeCertificates.PrimaryName));
        }

        #endregion DegreeCertificates
    }
}