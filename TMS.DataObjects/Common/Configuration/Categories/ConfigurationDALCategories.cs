// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-14-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-27-2018
// ***********************************************************************
// <copyright file="ConfigurationDALCategories.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Configuration;
using Dapper;
using System.Data.SqlClient;
using TMS.Library.Entities.Common.Configuration.Categories;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region Add Edit Delete GetAll GetByID for the Categories
        /// <summary>
        /// TMSs the categories get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        public List<TMSCategories> TMSCategories_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<TMSCategories> Categories = new List<TMSCategories>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters DbPrams = new DynamicParameters();
                DbPrams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_Categories_GetAll", DbPrams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Categories = multi.Read<TMSCategories>().AsList<TMSCategories>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Categories.ToList();
        }

        /// <summary>
        /// TMSs the categories get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        public List<TMSCategories> TMSCategoriesbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<TMSCategories> Categories = new List<TMSCategories>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters DbPrams = new DynamicParameters();
                DbPrams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid });
                using (var multi = conn.QueryMultiple("TMS_Categories_GetAllbyOrganization", DbPrams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Categories = multi.Read<TMSCategories>().AsList<TMSCategories>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Categories.ToList();
        }

        /// <summary>
        /// TMSs the categories get by id dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMSCategories.</returns>
        public TMSCategories TMSCategories_GetByIDDAL(long ID)
        {
            TMSCategories Venue = new TMSCategories();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { ID = ID });
                Venue = conn.Query<TMSCategories>("TMS_Categories_GetbyId", dbParams, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<TMSCategories>();
                conn.Close();
            }
            return Venue;
        }

        /// <summary>
        /// TMSs the categories create dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int64.</returns>
        public long TMSCategories_CreateDAL(TMSCategories _categories)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Categories_Create", parameters,
                            ParamBuilder.Par("PrimaryCategoryName", _categories.PrimaryCategoryName),
                            ParamBuilder.Par("SecondaryCategoryName", _categories.SecondaryCategoryName),
                            ParamBuilder.Par("PrimaryDescription", _categories.PrimaryDescription),
                            ParamBuilder.Par("SecondaryDescription", _categories.SecondaryDescription),
                            ParamBuilder.Par("Code", _categories.Code),
                            ParamBuilder.Par("OrganizationID", _categories.OrganizationID),
                            ParamBuilder.Par("CreatedBy", _categories.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _categories.CreatedDate),
                            ParamBuilder.Par("IsActive", _categories.IsActive),
                            ParamBuilder.Par("CategoryType", _categories.CategoryType));
        }

        /// <summary>
        /// TMSs the categories update dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_UpdateDAL(TMSCategories _categories)
        {
            return ExecuteScalarInt32Sp("TMS_Categories_Update",
                        ParamBuilder.Par("ID", _categories.ID),
                            ParamBuilder.Par("PrimaryCategoryName", _categories.PrimaryCategoryName),
                            ParamBuilder.Par("SecondaryCategoryName", _categories.SecondaryCategoryName),
                            ParamBuilder.Par("PrimaryDescription", _categories.PrimaryDescription),
                            ParamBuilder.Par("SecondaryDescription", _categories.SecondaryDescription),
                            ParamBuilder.Par("Code", _categories.Code),
                            ParamBuilder.Par("UpdatedBy", _categories.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _categories.UpdatedDate),
                            ParamBuilder.Par("IsActive", _categories.IsActive),
                            ParamBuilder.Par("CategoryType", _categories.CategoryType));
        }

        /// <summary>
        /// TMSs the categories delete dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_DeleteDAL(TMSCategories _categories)
        {
            return ExecuteScalarInt32Sp("TMS_Categories_Delete",
                        ParamBuilder.Par("ID", _categories.ID),
                            ParamBuilder.Par("UpdatedBy", _categories.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _categories.UpdatedDate));
        }

        /// <summary>
        /// TMSs the categories duplication check dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_DuplicationCheckDAL(TMSCategories _categories)
        {
            return ExecuteScalarSPInt32("TMS_Categories_DuplicationCheck",
                            ParamBuilder.Par("ID", _categories.ID),
                             ParamBuilder.Par("OrganizationID", _categories.OrganizationID),
                            ParamBuilder.Par("Code", _categories.Code));
        }

        #endregion Add Edit Delete GetAll GetByID for the Categories
    }
}
