// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-10-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-10-2018
// ***********************************************************************
// <copyright file="ConfigurationDALVendor.cs" company="LifeLong www.lifelongkuwait.com">
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
using TMS.Library.Entities.Common.Configuration.Vendor;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region Add Edit Delete GetAll GetByID for the Vendors

        /// <summary>
        /// Vendors the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        public List<Vendors> Vendors_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Vendors> Venue = new List<Vendors>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_CourseVendors_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Venue = multi.Read<Vendors>().AsList<Vendors>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Venue.ToList();
        }

        /// <summary>
        /// Vendors the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        public List<Vendors> Vendors_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<Vendors> Venue = new List<Vendors>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid=Oid });
                using (var multi = conn.QueryMultiple("TMS_CourseVendors_GetAllbyOrg", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Venue = multi.Read<Vendors>().AsList<Vendors>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Venue.ToList();
        }

        /// <summary>
        /// Vendors the create dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int64.</returns>
        public long Vendors_CreateDAL(Vendors _Vendors)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseVendors_Create", parameters,
                        ParamBuilder.Par("PrimaryVendor", _Vendors.PrimaryVendor),
                        ParamBuilder.Par("SecondaryVendor", _Vendors.SecondaryVendor),
                        ParamBuilder.Par("PrimaryDetails", _Vendors.PrimaryDetails),
                        ParamBuilder.Par("SecondaryDetails", _Vendors.SecondaryDetails),
                        ParamBuilder.Par("OrganizationID", _Vendors.OrganizationID),
                        ParamBuilder.Par("Code", _Vendors.Code),
                        ParamBuilder.Par("CreatedBy", _Vendors.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _Vendors.CreatedDate)
);
        }

        /// <summary>
        /// Vendors the update dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_UpdateDAL(Vendors _Vendors)
        {
            return ExecuteScalarInt32Sp("TMS_CourseVendors_Update",
                       ParamBuilder.Par("ID", _Vendors.ID),
                        ParamBuilder.Par("PrimaryVendor", _Vendors.PrimaryVendor),
                        ParamBuilder.Par("SecondaryVendor", _Vendors.SecondaryVendor),
                        ParamBuilder.Par("PrimaryDetails", _Vendors.PrimaryDetails),
                        ParamBuilder.Par("SecondaryDetails", _Vendors.SecondaryDetails),
                        ParamBuilder.Par("Code", _Vendors.Code),
                        ParamBuilder.Par("UpdatedBy", _Vendors.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Vendors.UpdatedDate)
            );
        }

        /// <summary>
        /// Vendors the delete dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_DeleteDAL(Vendors _Vendors)
        {
            return ExecuteScalarInt32Sp("TMS_CourseVendors_Delete",
                        ParamBuilder.Par("ID", _Vendors.ID),
                        ParamBuilder.Par("UpdatedBy", _Vendors.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Vendors.UpdatedDate)

            );
        }

        /// <summary>
        /// Vendors the duplication check dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_DuplicationCheckDAL(Vendors _Vendors)
        {
            return ExecuteScalarInt32Sp("TMS_CourseVendors_DuplicationCheck",
                        ParamBuilder.Par("ID", _Vendors.ID),
                        ParamBuilder.Par("Code", _Vendors.Code)

            );
        }

        #endregion Add Edit Delete GetAll GetByID for the Vendors
    }
}