// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-30-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-31-2017
// ***********************************************************************
// <copyright file="ConfigurationDALTrainer.cs" company="LifeLong www.lifelongkuwait.com">
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
using TMS.Library;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Common.Roles;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region Add Edit Delete GetAll GetByID for the Trainer

        /// <summary>
        /// Manages the trainer get all dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;TrainerOpenMapping&gt;.</returns>
        public List<TrainerOpenMapping> ManageTrainer_GetAllDAL(long OpenId, int OpenType)
        {
            List<TrainerOpenMapping> Venue = new List<TrainerOpenMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OpenId = OpenId, OpenType = OpenType });
                Venue = conn.Query<TrainerOpenMapping>("TrainerOpenMapping_GetAllByTypeAndId", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<TrainerOpenMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }
        public long ManageLogisticMap_CreateDAL(CourseLogisticRequirementsMapping _mapping)
        {


            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CourseLogisticMapping_Create", parameters,
                        ParamBuilder.Par("CourseLogisticRequirementID", _mapping.CourseLogisticRequirementID),
                          ParamBuilder.Par("CourseID", _mapping.CourseID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedDate)
                        );
        }


        public long ManageCourseMeterialMap_CreateDAL(CourseMeterialsMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("ManageCourseMeterialMap_Create", parameters,
                        ParamBuilder.Par("CourseMaterialID", _mapping.CourseMaterialID),
                        ParamBuilder.Par("CourseID", _mapping.CourseID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedOn)
                        );
        }

        public long ManageSessionMeterialMap_CreateDAL(SessionMeterialsMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("ManageSessionCourseMeterialMap_Create", parameters,
                        ParamBuilder.Par("CourseMaterialID", _mapping.CourseMaterialID),
                        ParamBuilder.Par("SessionID", _mapping.SessionID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedOn)
                        );
        }


        public long ManageCourseClassMeterialMap_CreateDAL(ClassMeterialsMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("ManageClassCourseMeterialMap_Create", parameters,
                        ParamBuilder.Par("CourseMaterialID", _mapping.CourseMaterialID),
                        ParamBuilder.Par("ClassID", _mapping.ClassID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedOn)
                        );
        }

        public long Audit_CreateBAL(string IpAddress, DateTime createddate, long oid, long userid, EventType events, string browser)
        {
          //  AuditLog audit = new AuditLog();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Auditlog_Create", parameters,
                        ParamBuilder.Par("IPAddress", IpAddress),
                        ParamBuilder.Par("EventType", events),
                      //  ParamBuilder.Par("NewValue", audit.NewValue),
                    //    ParamBuilder.Par("OldValue", audit.OldValue),
                          ParamBuilder.Par("OrganizationID", oid),
                        ParamBuilder.Par("BrowserName", browser),
                          ParamBuilder.Par("CreatedBy", userid),
                        ParamBuilder.Par("CreatedDate", createddate)
                        
                        );
        }


     

        public int ManageLogisticMap_UpdateDAL(CourseLogisticRequirementsMapping _mapping)
        {
            return ExecuteScalarInt32Sp("TrainerOpenMapping_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("CourseLogisticRequirementID", _mapping.CourseLogisticRequirementID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)
                        );
        }

        public int ManageCourseMeterialMap_UpdateDAL(CourseMeterialsMapping _mapping)
        {
            return ExecuteScalarInt32Sp("TrainerOpenMapping_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("CourseMaterialID", _mapping.CourseMaterialID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedOn),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)
                        );
        }


        public int ManageCourseClassMeterialMap_DeleteDAL(ClassMeterialsMapping _mapping)
        {
            return ExecuteScalarInt32Sp("ManageCourseClassMeterialMap_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedOn),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)

                        );
        }

        public int ManageCourseMeterialMap_DeleteDAL(CourseMeterialsMapping _mapping)
        {
            return ExecuteScalarInt32Sp("ManageCourseMeterialMap_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedOn),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)

                        );
        }



        public int ManageLogisticMap_DeleteDAL(CourseLogisticRequirementsMapping _mapping)
        {
            return ExecuteScalarInt32Sp("ManageLogisticMap_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)

                        );
        }

        public IList<DDlList> CourseLogistic_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("CourseLogistic_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }


        public IList<DDlList> CourseMeterial_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("CourseMeterial_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }

        public IList<DDlList> HowHeard_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("HowHeard_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }



        public IList<DDlList> CRMUser_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("CRM_User_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }


        public IList<DDlList> CRMCourses_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("CRM_Courses_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }

        public IList<DDlList> CRMClasses_GetAllByCultureDAL(string culture, long CompnayID)
        {

            return ExecuteListSp<DDlList>("CRM_Classes_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

        }

        
        /// <summary>
        /// Manages the trainer get by id dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TrainerOpenMapping.</returns>
        public TrainerOpenMapping ManageTrainer_GetByIDDAL(long ID)
        {
            TrainerOpenMapping Venue = new TrainerOpenMapping();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { ID = ID });
                Venue = conn.Query<TrainerOpenMapping>("TrainerOpenMapping_GetbyId", dbParams, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<TrainerOpenMapping>();
                conn.Close();
            }
            return Venue;
        }

        /// <summary>
        /// Manages the trainer create dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        public long ManageTrainer_CreateDAL(TrainerOpenMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TrainerOpenMapping_Create", parameters,
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("OpenId", _mapping.OpenId),
                        ParamBuilder.Par("OpenType", _mapping.OpenType),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedDate)
                        );
        }

        /// <summary>
        /// Manages the trainer update dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_UpdateDAL(TrainerOpenMapping _mapping)
        {
            return ExecuteScalarInt32Sp("TrainerOpenMapping_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)
                        );
        }

        /// <summary>
        /// Manages the trainer delete dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_DeleteDAL(TrainerOpenMapping _mapping)
        {
            return ExecuteScalarInt32Sp("TrainerOpenMapping_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)

                        );
        }

        /// <summary>
        /// Manages the trainer duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_DuplicationCheckDAL(TrainerOpenMapping _mapping)
        {
            return ExecuteScalarSPInt32("TrainerOpenMapping_DuplicationCheck",
                    ParamBuilder.Par("PersonID", _mapping.PersonID),
                                ParamBuilder.Par("OpenId", _mapping.OpenId), ParamBuilder.Par("OpenType", _mapping.OpenType));
        }

        /// <summary>
        /// Manages the trainer duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_AvailabilityCheckDAL(TrainerOpenMapping _mapping)
        {
            return ExecuteScalarSPInt32("TrainerOpenMapping_AvalabilityCheck",
                    ParamBuilder.Par("PersonID", _mapping.PersonID),
                    ParamBuilder.Par("OpenId", _mapping.OpenId));
        }

        /// <summary>
        /// Manages the trainer get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ManageTrainer_GetAllByCultureDAL(string culture, int OpenType, long OpenId, long CompnayID)
        {
            switch (OpenType)
            {
                case -1:
                    return ExecuteListSp<DDlList>("TrainerOpenMapping_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
                case 3:
                    return ExecuteListSp<DDlList>("TrainerOpenMapping_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

                default:
                    return ExecuteListSp<DDlList>("TrainerOpenMapping_ByOpenIdAndTypeAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType), ParamBuilder.Par("OrganizationID", CompnayID));
            }
        }
        /// <summary>
        /// Manages the trainer get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ManageVenue_GetAllByCultureDAL(string culture, int OpenType, long OpenId, long CompnayID)
        {
            //switch (OpenType)
            //{
            //    case -1:
            //        return ExecuteListSp<DDlList>("TrainerOpenMapping_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
            //    case 3:
            //        return ExecuteListSp<DDlList>("TrainerOpenMapping_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

            //    default:
                    return ExecuteListSp<DDlList>("Venues_ByOpenIdAndTypeAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType), ParamBuilder.Par("OrganizationID", CompnayID));
            //}
        }

        #endregion Add Edit Delete GetAll GetByID for the Trainer
    }
}