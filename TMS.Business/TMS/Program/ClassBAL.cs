// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-14-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="ClassBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.Program;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.Language;
using TMS.Library.Entities.Common.Configuration;

namespace TMS.Business.TMS.Program
{
    /// <summary>
    /// Class ClassBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.Program.IClassBAL" />
    public class ClassBAL : IClassBAL
    {
        private readonly IClassDAL _ClassDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassBAL"/> class.
        /// </summary>
        /// <param name="__ClassDAL">The class dal.</param>
        public ClassBAL(IClassDAL __ClassDAL)
        {
            _ClassDAL = __ClassDAL;
        }
        public IList<CourseLogisticRequirements> CourseLogistic_GetAllByOrgBAL(string Culture, long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) =>
         _ClassDAL.CourseLogistic_GetAllByOrgDAL(Culture, CompnayID, ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);


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
        public List<Classes> TMS_Classes_GetAllBAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _ClassDAL.TMS_Classes_GetAllDAL( CourseId,StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <returns>List&lt;Classes&gt;.</returns>
        public IList<MapLanguage> TMS_Classes_GetAllBAL(long CourseId, string SearchText)
        {
            return _ClassDAL.TMS_Classes_GetAllDAL(CourseId, SearchText);
        }

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
        public List<Classes> TMS_ClassesByOrganization_GetAllBAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            return _ClassDAL.TMS_ClassesByOrganization_GetAllDAL(CourseId, StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);
        }
        
        public List<Classes> TMS_ClassesAllByOrganization_GetAllBAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid, long PersonId)
        {
            return _ClassDAL.TMS_ClassesAllByOrganization_GetAllDAL(CourseId, StartRowIndex, PageSize, ref Total, SortExpression, SearchText, Oid,PersonId);
        }
        public List<PersonRoleGroup> personRoleGroups(long UserID)
        {
            return _ClassDAL.personRoleGroupsDAL(UserID);

        }
        public List<Classes> TMS_TrainerClasses_GetByIdBAL(long id, ref int Total)
        {
            return _ClassDAL.TMS_TrainerClasses_GetAllDAL(id,ref Total);
        }

        public List<Classes> TMS_TrainerClasses_GetByOrganizationIdBAL(long id,long CompnayID,ref int Total)
        {
            return _ClassDAL.TMS_TrainerClasses_GetByOrganizationIdDAL(id, CompnayID,ref Total);
        }
        /// <summary>
        /// TMSs the classes get by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Classes.</returns>
        public Classes TMS_Classes_GetByIdBAL(string ID)
        {
            return _ClassDAL.TMS_Classes_GetByIdDAL(ID);
        }
        /// <summary>
        /// Gets the course detail by identifier for new class bal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Count">The count.</param>
        /// <returns>Course.</returns>
        public Course GetCourseDetailByIdForNewClassBAL(string Id, ref int Count)
        {
            return _ClassDAL.GetCourseDetailByIdForNewClassDAL(Id,ref Count);
        }

        /// <summary>
        /// TMSs the classes create bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Classes_CreateBAL(Classes _Classes)
        {
            return _ClassDAL.TMS_Classes_CreateDAL(_Classes);
        }

        /// <summary>
        /// TMSs the classes create bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_CourseLanguage_CreateBAL(MapLanguage _Corelanguage, long CourseId)
        {
            return _ClassDAL.TMS_CourseLanguage_CreateDAL(_Corelanguage, CourseId);
        }

        /// <summary>
        /// TMSs the classes update bal.
        /// </summary>;
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Classes_UpdateBAL(Classes _Classes)
        {
            return _ClassDAL.TMS_Classes_UpdateDAL(_Classes);
        }
        /// <summary>
        /// TMSs the classes update bal.
        /// </summary>int TMS_Classes_SessionCount(int _ClassesID);
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Classes_SessionCountBAL(long _ClassesID)
        {
            return _ClassDAL.TMS_Classes_SessionCountDAL(_ClassesID);
        }
        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Classes_DeleteDAL(Classes _Classes)
        {
            return _ClassDAL.TMS_Classes_DeleteDAL(_Classes);
        }
        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_CourseLanguage_UpdateDAL(MapLanguage _Corelanguage, long CourseId)
        {
            return _ClassDAL.TMS_CourseLanguage_UpdateDAL(_Corelanguage, CourseId);
        }

        public int TMS_CourseLanguage_DeleteDAL(MapLanguage _Corelanguage, long CourseId)
        {
            return _ClassDAL.TMS_CourseLanguage_DeleteDAL(_Corelanguage,CourseId);
        }
        /// <summary>
        /// Classes the trainee mapping get all bal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <returns>IList&lt;ClassTraineeMapping&gt;.</returns>
        public IList<ClassTraineeMapping> ClassTraineeMapping_GetAllBAL(string Culture, long ClassID)
        {
            return _ClassDAL.ClassTraineeMapping_GetAllDAL(Culture, ClassID);
        }

        public IList<ClassTraineeMapping> ClassTraineeMapping_GetAllBALOrganization(string Culture, long ClassID, long CompnayID)
        {
            return _ClassDAL.ClassTraineeMapping_GetAllDALOrganization(Culture, ClassID,CompnayID);
        }
        public IList<ClassTraineeMappingCertificatePrint> ClassTraineeMappingCertificate_GetAllBALOrganization(string Culture, long ClassID, long CompnayID,long CertificateID)
        {
            return _ClassDAL.ClassTraineeMappingCertificate_GetAllBALOrganizationDAL(Culture, ClassID, CompnayID,CertificateID);
        }
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
        public IList<Person> TrainerGetAllExceptClassTrainerBAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
              return _ClassDAL.TrainerGetAllExceptClassTrainerDAL(Culture, ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }



        public IList<Person> TrainerGetAllOrganizationExceptClassTrainerBAL(string Culture, long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _ClassDAL.TrainerGetAllOrganizationExceptClassTrainerDAL(Culture, CompnayID, ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

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
        public IList<Person> ClassTrainee_GetAllByClassIDForCreatingBAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) =>
            _ClassDAL.ClassTrainee_GetAllByClassIDForCreatingDAL(Culture, ClassID,StartRowIndex, PageSize, ref Total, SortExpression, SearchText);


        public IList<Person> ClassTrainee_GetAllByClassIDForCreatingBALOrganization(string Culture,long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) =>
           _ClassDAL.ClassTrainee_GetAllByClassIDForCreatingDALOrganization(Culture, CompnayID, ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        /// <summary>
        /// TMSs the class trainee mapping create bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_ClassTraineeMapping_CreateBAL(ClassTraineeMapping _Classes, string PersonIds) => _ClassDAL.TMS_ClassTraineeMapping_CreateDAL(_Classes, PersonIds);
        /// <summary>
        /// TMSs the class trainee mapping delete bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_ClassTraineeMapping_DeleteBAL(ClassTraineeMapping _Classes)=> _ClassDAL.TMS_ClassTraineeMapping_DeleteDAL(_Classes);

        /// <summary>
        /// Trainers the open mapping create by person ids bal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        public long TrainerOpenMapping_CreateByPersonIdsBAL(ClassTrainerMapping _Classes, string PersonIds) => _ClassDAL.TrainerOpenMapping_CreateByPersonIdsDAL(_Classes, PersonIds);

        #region Class Logistics


        public IList<CourseLogisticRequirements> TMS_ClassLogisticsDLL_GetAllBAL(string Culture,long CompanyID, long ClassID)
        {
            return _ClassDAL.TMS_ClassLogisticsDLL_GetAllDAL(Culture,CompanyID,ClassID);
        }

        public List<CourseLogisticRequirements> TMS_ClassLogestics_GetAllBAL(long ClassID)
        {
            return _ClassDAL.TMS_ClassLogistics_GetAllDAL(ClassID);
        }

        public long TMS_ClassLogistics_CreateBAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_ClassLogistics_CreateDAL(_Logistics, ClassID);
        }

        public int TMS_ClassLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_ClassLogistics_UpdateDAL(_Logistics, ClassID);
        }

        public int TMS_ClassLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_ClassLogistics_DeleteDAL(_Logistics, ClassID);
        }

        #endregion

        #region Session Logistics


        public IList<CourseLogisticRequirements> TMS_SessionLogisticsDLL_GetAllBAL(string Culture)
        {
            return _ClassDAL.TMS_SessionLogisticsDLL_GetAllDAL(Culture);
        }

        public List<CourseLogisticRequirements> TMS_SessionLogestics_GetAllBAL(long ClassID)
        {
            return _ClassDAL.TMS_SessionLogistics_GetAllDAL(ClassID);
        }

        public long TMS_SessionLogistics_CreateBAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_SessionLogistics_CreateDAL(_Logistics, ClassID);
        }

        public int TMS_SessionLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_SessionLogistics_UpdateDAL(_Logistics, ClassID);
        }

        public int TMS_SessionLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return _ClassDAL.TMS_SessionLogistics_DeleteDAL(_Logistics, ClassID);
        }


        #endregion
    }
}