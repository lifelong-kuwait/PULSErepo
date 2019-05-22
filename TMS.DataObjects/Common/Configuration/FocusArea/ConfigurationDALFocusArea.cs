// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-27-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-27-2018
// ***********************************************************************
// <copyright file="ConfigurationDALFocusArea.cs" company="LifeLong www.lifelongkuwait.com">
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
        #region"FocusAreas"


        /// <summary>
        /// Focuses the areas get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        public List<FocusAreas> FocusAreas_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<FocusAreas> FocusAreas = new List<FocusAreas>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("FocusAreas_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    FocusAreas = multi.Read<FocusAreas>().AsList<FocusAreas>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return FocusAreas.ToList();
        }

        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        public List<FocusAreas> FocusAreasbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<FocusAreas> FocusAreas = new List<FocusAreas>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid=Oid });
                using (var multi = conn.QueryMultiple("FocusAreas_GetAllbyOrganization", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    FocusAreas = multi.Read<FocusAreas>().AsList<FocusAreas>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return FocusAreas.ToList();
        }

        /// <summary>
        /// Focuses the areas create dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int64.</returns>
        public long FocusAreas_CreateDAL(FocusAreas _objFocusAreas)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("FocusAreas_Create", parameters,
                                ParamBuilder.Par("PrimaryFocusAreaName", _objFocusAreas.PrimaryFocusAreaName),
                                ParamBuilder.Par("SecondaryFocusAreaName", _objFocusAreas.SecondaryFocusAreaName),
                                 ParamBuilder.Par("OrganizationID", _objFocusAreas.OrganizationID),
                                ParamBuilder.Par("CreatedBy", _objFocusAreas.CreatedBy),
                                ParamBuilder.Par("CreatedDate", _objFocusAreas.CreatedDate));
        }

        /// <summary>
        /// Focuses the areas update dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_UpdateDAL(FocusAreas _objFocusAreas)
        {
            return ExecuteScalarInt32Sp("FocusAreas_Update",
                                ParamBuilder.Par("ID", _objFocusAreas.ID),
                                ParamBuilder.Par("PrimaryFocusAreaName", _objFocusAreas.PrimaryFocusAreaName),
                                ParamBuilder.Par("SecondaryFocusAreaName", _objFocusAreas.SecondaryFocusAreaName),
                                ParamBuilder.Par("UpdatedBy", _objFocusAreas.UpdatedBy),
                                ParamBuilder.Par("UpdatedDate", _objFocusAreas.UpdatedDate));
        }

        /// <summary>
        /// Focuses the areas delete dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_DeleteDAL(FocusAreas _objFocusAreas)
        {

            return ExecuteScalarInt32Sp("FocusAreas_Delete",
                                ParamBuilder.Par("ID", _objFocusAreas.ID),
                                ParamBuilder.Par("UpdatedBy", _objFocusAreas.UpdatedBy),
                                ParamBuilder.Par("UpdatedDate", _objFocusAreas.UpdatedDate));
        }

        /// <summary>
        /// Focuses the areas duplication check dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_DuplicationCheckDAL(FocusAreas _objFocusAreas)
        {
            return ExecuteScalarSPInt32("FocusAreas_DuplicationCheck",
                    ParamBuilder.Par("ID", _objFocusAreas.ID),
                                ParamBuilder.Par("PrimaryFocusAreaName", _objFocusAreas.PrimaryFocusAreaName),
                                 ParamBuilder.Par("OrganizationID", _objFocusAreas.OrganizationID)
                               );
        }


        public int CourseMeterialMap_DuplicationCheckDAL(CourseMeterialsMapping _objlogmap)
        {
            return ExecuteScalarSPInt32("CourseMetereilMap_DuplicationCheck",
                    ParamBuilder.Par("ID", _objlogmap.ID),
                                ParamBuilder.Par("CourseMaterialID", _objlogmap.CourseMaterialID),
                                 ParamBuilder.Par("CourseID", _objlogmap.CourseID)
                               );
        }

        public int ManageLogistic_DuplicationCheckDAL(CourseLogisticRequirementsMapping _objlogmap)
        {

            {
                return ExecuteScalarSPInt32("CourseLogisticMap_DuplicationCheck",
                        ParamBuilder.Par("ID", _objlogmap.ID),
                                    ParamBuilder.Par("CourseLogisticRequirementID", _objlogmap.CourseLogisticRequirementID),
                                     ParamBuilder.Par("CourseID", _objlogmap.CourseID)
                                   );
            }
        }

        #endregion
    }
}