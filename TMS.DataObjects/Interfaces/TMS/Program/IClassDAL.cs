// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-14-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="IClassDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.Language;
using TMS.Library.Entities.Common.Configuration;

namespace TMS.DataObjects.Interfaces.TMS
{
    /// <summary>
    /// Interface IClassDAL
    /// </summary>
    public interface IClassDAL
    {
        /// <summary>
        /// TMSs the classes get all dal.
        /// </summary>
        /// <param name="CourseId">The course identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Classes&gt;.</returns>
        List<Classes> TMS_Classes_GetAllDAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <returns>List&lt;Classes&gt;.</returns>
        IList<MapLanguage> TMS_Classes_GetAllDAL(long CourseId, string SearchText);
        IList<CourseLogisticRequirements> CourseLogistic_GetAllByOrgDAL(string Culture, long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);


        /// <summary>
        /// TMSs the classes get all dal.
        /// </summary>
        /// <param name="CourseId">The course identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Classes&gt;.</returns>
        List<Classes> TMS_ClassesByOrganization_GetAllDAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);
        List<Classes> TMS_ClassesAllByOrganization_GetAllDAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid);

        
        List<Classes> TMS_TrainerClasses_GetAllDAL(long id, ref int Total);

        List<Classes> TMS_TrainerClasses_GetByOrganizationIdDAL(long id, long CompnayID, ref int Total);
        /// <summary>
        /// TMSs the classes get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Classes.</returns>
        Classes TMS_Classes_GetByIdDAL(string ID);
        /// <summary>
        /// Gets the course detail by identifier for new class dal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Count">The count.</param>
        /// <returns>Course.</returns>
        Course GetCourseDetailByIdForNewClassDAL(string Id, ref int Count);
        /// <summary>
        /// TMSs the classes create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Classes_CreateDAL(Classes _Classes);
        /// <summary>
        /// TMSs the classes create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        long TMS_CourseLanguage_CreateDAL(MapLanguage _Corelanguage, long CourseId);
        /// <summary>
        /// TMSs the classes update dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Classes_UpdateDAL(Classes _Classes);
        /// <summary>
        /// TMSs the classes update dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Classes_SessionCountDAL(long _ClassesID);
        /// <summary>
        /// TMSs the classes delete dal.int TMS_Classes_SessionCount(int _ClassesID)
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Classes_DeleteDAL(Classes _Classes);
        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_CourseLanguage_UpdateDAL(MapLanguage _Corelanguage, long CourseId);
        int TMS_CourseLanguage_DeleteDAL(MapLanguage _Corelanguage, long CourseId);
        /// <summary>
        /// Classes the trainee mapping get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <returns>IList&lt;ClassTraineeMapping&gt;.</returns>
        IList<ClassTraineeMapping> ClassTraineeMapping_GetAllDAL(string Culture, long ClassID);
        IList<ClassTraineeMapping> ClassTraineeMapping_GetAllDALOrganization(string Culture, long ClassID, long CompnayID);
        IList<ClassTraineeMappingCertificatePrint> ClassTraineeMappingCertificate_GetAllBALOrganizationDAL(string Culture, long ClassID, long CompnayID);

        /// <summary>
        /// Classes the trainee get all by class identifier for creating dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> ClassTrainee_GetAllByClassIDForCreatingDAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);
        /// <summary>
        /// TMSs the class trainee mapping create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        /// 
        IList<Person> ClassTrainee_GetAllByClassIDForCreatingDALOrganization(string Culture, long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);


        long TMS_ClassTraineeMapping_CreateDAL(ClassTraineeMapping _Classes, string PersonIds);
        /// <summary>
        /// TMSs the class trainee mapping delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_ClassTraineeMapping_DeleteDAL(ClassTraineeMapping _Classes);
        /// <summary>
        /// Trainers the get all except class trainer dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> TrainerGetAllExceptClassTrainerDAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);


        IList<Person> TrainerGetAllOrganizationExceptClassTrainerDAL(string Culture,long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Trainers the open mapping create by person ids dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        long TrainerOpenMapping_CreateByPersonIdsDAL(ClassTrainerMapping _Classes, string PersonIds);

        #region Class Logistics

        IList<CourseLogisticRequirements> TMS_ClassLogisticsDLL_GetAllDAL(string CurrentCulture, long CompanyID, long ClassID);

        List<CourseLogisticRequirements> TMS_ClassLogistics_GetAllDAL(long ClassID);
        
        long TMS_ClassLogistics_CreateDAL(CourseLogisticRequirements _Logistics, long ClassID);

        int TMS_ClassLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID);

        int TMS_ClassLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID);

        #endregion

        #region Session Logistics

        IList<CourseLogisticRequirements> TMS_SessionLogisticsDLL_GetAllDAL(string CurrentCulture);

        List<CourseLogisticRequirements> TMS_SessionLogistics_GetAllDAL(long ClassID);

        long TMS_SessionLogistics_CreateDAL(CourseLogisticRequirements _Logistics, long ClassID);

        int TMS_SessionLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID);

        int TMS_SessionLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID);

        #endregion
    }
}