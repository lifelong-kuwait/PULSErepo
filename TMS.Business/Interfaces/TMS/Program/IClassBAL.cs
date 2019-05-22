// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-14-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="IClassBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.Language;
using TMS.Library.Entities.Common.Configuration;

namespace TMS.Business.Interfaces.TMS.Program
{
    /// <summary>
    /// Interface IClassBAL
    /// </summary>
    public interface IClassBAL
    {
        /// <summary>
        /// TMSs the classes get all bal.
        /// </summary>
        /// <param name="CourseId">The course identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Classes&gt;.</returns>
        List<Classes> TMS_Classes_GetAllBAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        IList<CourseLogisticRequirements> CourseLogistic_GetAllByOrgBAL(string Culture, long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <returns>List&lt;Classes&gt;.</returns>
        IList<MapLanguage> TMS_Classes_GetAllBAL(long CourseId, string SearchText);

        /// <summary>
        /// TMSs the classes get all bal.
        /// </summary>
        /// <param name="CourseId">The course identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Classes&gt;.</returns>
        List<Classes> TMS_ClassesByOrganization_GetAllBAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        List<Classes> TMS_TrainerClasses_GetByIdBAL(long id, ref int Total);
        
        /// <summary>
        /// TMSs the classes get by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Classes.</returns>
        Classes TMS_Classes_GetByIdBAL(string ID);

        /// <summary>
        /// Gets the course detail by identifier for new class bal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Count">The count.</param>
        /// <returns>Course.</returns>
        Course GetCourseDetailByIdForNewClassBAL(string Id, ref int Count);
        /// <summary>
        /// TMSs the classes create bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Classes_CreateBAL(Classes _Classes);
        /// <returns>System.Int64.</returns>
        long TMS_CourseLanguage_CreateBAL(MapLanguage _Corelanguage, long CourseId);
        /// <summary>
        /// TMSs the classes update bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Classes_UpdateBAL(Classes _Classes);
        /// <summary>
        /// TMSs the classes delete dal.
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
        /// Classes the trainee mapping get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <returns>IList&lt;ClassTraineeMapping&gt;.</returns>
        IList<ClassTraineeMapping> ClassTraineeMapping_GetAllBAL(string Culture, long ClassID);

        IList<ClassTraineeMapping> ClassTraineeMapping_GetAllBALOrganization(string Culture, long ClassID,long CompnayID);
        /// <summary>
        /// Trainers the get all except class trainer bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> TrainerGetAllExceptClassTrainerBAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);



        IList<Person> TrainerGetAllOrganizationExceptClassTrainerBAL(string Culture,long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Classes the trainee get all by class identifier for creating bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> ClassTrainee_GetAllByClassIDForCreatingBAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);


        IList<Person> ClassTrainee_GetAllByClassIDForCreatingBALOrganization(string Culture,long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the class trainee mapping create bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        long TMS_ClassTraineeMapping_CreateBAL(ClassTraineeMapping _Classes, string PersonIds);
        /// <summary>
        /// TMSs the class trainee mapping delete bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_ClassTraineeMapping_DeleteBAL(ClassTraineeMapping _Classes);
        /// <summary>
        /// Trainers the open mapping create by person ids bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        long TrainerOpenMapping_CreateByPersonIdsBAL(ClassTrainerMapping _Classes, string PersonIds);
        List<Classes> TMS_TrainerClasses_GetByOrganizationIdBAL(long id, long companyID, ref int Total);

        #region Class Logistics

        IList<CourseLogisticRequirements> TMS_ClassLogisticsDLL_GetAllBAL(string Culture,long CompanyID, long ClassID);

        List<CourseLogisticRequirements> TMS_ClassLogestics_GetAllBAL(long ClassID);

        long TMS_ClassLogistics_CreateBAL(CourseLogisticRequirements _logistics, long ClassID);
        
        int TMS_ClassLogistics_UpdateDAL(CourseLogisticRequirements _logistics, long ClassID);

        int TMS_ClassLogistics_DeleteDAL(CourseLogisticRequirements _logistics, long ClassID);

        #endregion

        #region Session Logistics

        IList<CourseLogisticRequirements> TMS_SessionLogisticsDLL_GetAllBAL(string Culture);

        List<CourseLogisticRequirements> TMS_SessionLogestics_GetAllBAL(long ClassID);

        long TMS_SessionLogistics_CreateBAL(CourseLogisticRequirements _logistics, long ClassID);

        int TMS_SessionLogistics_UpdateDAL(CourseLogisticRequirements _logistics, long ClassID);

        int TMS_SessionLogistics_DeleteDAL(CourseLogisticRequirements _logistics, long ClassID);

        #endregion
    }
}