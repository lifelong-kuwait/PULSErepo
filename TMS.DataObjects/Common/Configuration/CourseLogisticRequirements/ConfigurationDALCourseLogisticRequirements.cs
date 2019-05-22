// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 01-28-2018
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-28-2018
// ***********************************************************************
// <copyright file="ConfigurationDALCourseLogisticRequirements.cs" company="LifeLong www.lifelongkuwait.com">
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
using TMS.Library;
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
        #region CourseLogisticRequirements

        /// <summary>
        /// Courses the logistic requirements get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        public List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<CourseLogisticRequirements> CourseLogisticRequirements = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_CourseLogisticRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    CourseLogisticRequirements = multi.Read<CourseLogisticRequirements>().AsList<CourseLogisticRequirements>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return CourseLogisticRequirements.ToList();
        }

        /// <summary>
        /// Courses the logistic requirements get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        public List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<CourseLogisticRequirements> CourseLogisticRequirements = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid=Oid});
                using (var multi = conn.QueryMultiple("TMS_CourseLogisticRequirements_GetAllbyOrg", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    CourseLogisticRequirements = multi.Read<CourseLogisticRequirements>().AsList<CourseLogisticRequirements>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return CourseLogisticRequirements.ToList();
        }

        /// <summary>
        /// Courses the logistic requirements create dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int64.</returns>
        public long CourseLogisticRequirements_CreateDAL(CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseLogisticRequirements_Create", parameters,
                   ParamBuilder.Par("PrimaryRequirementName", _objCourseLogisticRequirements.PrimaryRequirementName),
                   ParamBuilder.Par("SecondaryRequirementName", _objCourseLogisticRequirements.SecondaryRequirementName),
                   ParamBuilder.Par("OrganizationID", _objCourseLogisticRequirements.OrganizationID),
                   ParamBuilder.Par("CreatedBy", _objCourseLogisticRequirements.CreatedBy),
                   ParamBuilder.Par("CreatedDate", _objCourseLogisticRequirements.CreatedDate));
        }

        /// <summary>
        /// Courses the logistic requirements update dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_UpdateDAL(CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            return ExecuteScalarInt32Sp("TMS_CourseLogisticRequirements_Update",
                   ParamBuilder.Par("ID", _objCourseLogisticRequirements.ID),
                   ParamBuilder.Par("PrimaryRequirementName", _objCourseLogisticRequirements.PrimaryRequirementName),
                   ParamBuilder.Par("SecondaryRequirementName", _objCourseLogisticRequirements.SecondaryRequirementName),
                   ParamBuilder.Par("UpdatedBy", _objCourseLogisticRequirements.UpdatedBy),
                   ParamBuilder.Par("UpdatedDate", _objCourseLogisticRequirements.UpdatedDate));
        }

        /// <summary>
        /// Courses the logistic requirements delete dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_DeleteDAL(CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            return ExecuteScalarInt32Sp("TMS_CourseLogisticRequirements_Delete",
                   ParamBuilder.Par("ID", _objCourseLogisticRequirements.ID),
                   ParamBuilder.Par("UpdatedBy", _objCourseLogisticRequirements.UpdatedBy),
                   ParamBuilder.Par("UpdatedDate", _objCourseLogisticRequirements.UpdatedDate));
        }

        /// <summary>
        /// Courses the logistic requirements duplication check dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_DuplicationCheckDAL(CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            return ExecuteScalarSPInt32("TMS_CourseLogisticRequirements_DuplicationCheck",
                   ParamBuilder.Par("ID", _objCourseLogisticRequirements.ID),
                   ParamBuilder.Par("PrimaryRequirementName", _objCourseLogisticRequirements.PrimaryRequirementName));
        }

        #endregion CourseLogisticRequirements

        public List<CourseLogisticRequirementsMapping> ManageCourseMap_GetAllDAL(long OrganizationID,long CourseID)
        {

            List<CourseLogisticRequirementsMapping> Venue = new List<CourseLogisticRequirementsMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = OrganizationID, CourseID= CourseID });
                Venue = conn.Query<CourseLogisticRequirementsMapping>("CourseLogisticRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseLogisticRequirementsMapping>();
                conn.Close();
            }
            return Venue.ToList();


        }



        public List<CourseLogisticRequirements> ManageCourse_GetAllDAL(long OrganizationID)
        {

            List<CourseLogisticRequirements> Venue = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = OrganizationID });
                Venue = conn.Query<CourseLogisticRequirements>("CourseLogisticMAPRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseLogisticRequirements>();
                conn.Close();
            }
            return Venue.ToList();


        }




        public List<CourseMeterialsMapping> ManageCourseMeterialMap_GetAllDAL(long oid, long CourseID)
        {

            List<CourseMeterialsMapping> Venue = new List<CourseMeterialsMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = oid, CourseID= CourseID });
                Venue = conn.Query<CourseMeterialsMapping>("CourseMeterialMapRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseMeterialsMapping>();
                conn.Close();
            }
            return Venue.ToList();


        }


        public List<CourseMeterialsMapping> ManageCourseMeterial_GetAllDAL(long oid)
        {

            List<CourseMeterialsMapping> Venue = new List<CourseMeterialsMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = oid });
                Venue = conn.Query<CourseMeterialsMapping>("CourseMeterialRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseMeterialsMapping>();
                conn.Close();
            }
            return Venue.ToList();


        }


        public List<ClassMeterialsMapping> ManageClassMeterialMap_GetAllDAL(long oid, long ClassID)
        {

            List<ClassMeterialsMapping> Venue = new List<ClassMeterialsMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = oid, ClassID= ClassID });
                Venue = conn.Query<ClassMeterialsMapping>("CourseClassMeterialMapRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<ClassMeterialsMapping>();
                conn.Close();
            }
            return Venue.ToList();


        }
        public int CourseLogisticRequirements_CheckDAL(CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            return ExecuteScalarSPInt32("TMS_CourseLogisticRequirement_Check",
                   ParamBuilder.Par("ID", _objCourseLogisticRequirements.ID),
                   ParamBuilder.Par("OrganizationID", _objCourseLogisticRequirements.OrganizationID));
        }
        

              public List<AuditLog> AuditLog_GetAllDAL(long oid)
        {

            List<AuditLog> Venue = new List<AuditLog>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = oid });
                Venue = conn.Query<AuditLog>("Audit_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<AuditLog>();
                conn.Close();
            }
            return Venue.ToList();


        }



        public List<SessionMeterialsMapping> ManageSessionMeterialMap_GetAllDAL(long oid)
        {

            List<SessionMeterialsMapping> Venue = new List<SessionMeterialsMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OrganizationID = oid });
                Venue = conn.Query<SessionMeterialsMapping>("SessionMeterialMapRequirements_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<SessionMeterialsMapping>();
                conn.Close();
            }
            return Venue.ToList();


        }





    }
}