// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-27-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-28-2018
// ***********************************************************************
// <copyright file="ConfigurationDALCourseMaterials.cs" company="LifeLong www.lifelongkuwait.com">
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
        #region CourseMaterials

        /// <summary>
        /// Courses the materials get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        public List<CourseMaterials> CourseMaterials_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<CourseMaterials> CourseMaterials = new List<CourseMaterials>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_CourseMaterials_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    CourseMaterials = multi.Read<CourseMaterials>().AsList<CourseMaterials>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return CourseMaterials.ToList();
        }

        /// <summary>
        /// Courses the materials get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        public List<CourseMaterials> CourseMaterials_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<CourseMaterials> CourseMaterials = new List<CourseMaterials>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid= Oid });
                using (var multi = conn.QueryMultiple("TMS_CourseMaterials_GetAllbyOrg", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    CourseMaterials = multi.Read<CourseMaterials>().AsList<CourseMaterials>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return CourseMaterials.ToList();
        }

        /// <summary>
        /// Courses the materials create dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int64.</returns>
        public long CourseMaterials_CreateDAL(CourseMaterials _objCourseMaterials)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseMaterials_Create", parameters,
                    ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                    ParamBuilder.Par("SecondaryMaterial", _objCourseMaterials.SecondaryMaterial),
                    ParamBuilder.Par("OrganizationID", _objCourseMaterials.OrganizationID),
                    ParamBuilder.Par("CreatedBy", _objCourseMaterials.CreatedBy),
                    ParamBuilder.Par("CreatedDate", _objCourseMaterials.CreatedDate));
        }

        /// <summary>
        /// Courses the materials update dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_UpdateDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarInt32Sp("TMS_CourseMaterials_Update",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                                    ParamBuilder.Par("SecondaryMaterial", _objCourseMaterials.SecondaryMaterial),
                                    ParamBuilder.Par("UpdatedBy", _objCourseMaterials.UpdatedBy),
                                    ParamBuilder.Par("UpdatedDate", _objCourseMaterials.UpdatedDate));
        }

        /// <summary>
        /// Courses the materials delete dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_DeleteDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarInt32Sp("TMS_CourseMaterials_Delete",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    ParamBuilder.Par("UpdatedBy", _objCourseMaterials.UpdatedBy),
                                    ParamBuilder.Par("UpdatedDate", _objCourseMaterials.UpdatedDate));
        }

        /// <summary>
        /// Courses the materials duplication check dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_DuplicationCheckDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarSPInt32("TMS_CourseMaterials_DuplicationCheck",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                                    ParamBuilder.Par("OrganizationID", _objCourseMaterials.OrganizationID));
        }

        #endregion CourseMaterials
        public int CourseMaterials_CheckDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarSPInt32("TMS_CourseMaterials_Check",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    //  ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                                    ParamBuilder.Par("OrganizationID", _objCourseMaterials.OrganizationID));
        }

        public int CourseClassMaterials_CheckDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarSPInt32("TMS_CourseClassMaterials_Check",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    //  ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                                    ParamBuilder.Par("OrganizationID", _objCourseMaterials.OrganizationID));
        }

        public int CourseSessionMaterials_CheckDAL(CourseMaterials _objCourseMaterials)
        {
            return ExecuteScalarSPInt32("TMS_CourseSessionMaterials_Check",
                                    ParamBuilder.Par("ID", _objCourseMaterials.ID),
                                    //  ParamBuilder.Par("PrimaryMaterial", _objCourseMaterials.PrimaryMaterial),
                                    ParamBuilder.Par("OrganizationID", _objCourseMaterials.OrganizationID));
        }

    }
}