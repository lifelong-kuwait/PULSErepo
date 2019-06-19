// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IPersonDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using TMS.Library.Entities.CRM;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;

namespace TMS.DataObjects.Interfaces.TMS
{
    /// <summary>
    /// Interface IPersonDAL
    /// </summary>
    public interface IPersonDAL
    {
        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType,long RoleID);


        PersonResponse ProspectInsertNewPersonDAL(Person _objPerson, string clientType, long RoleID);
        int Loginperson_DuplicationCheckDAL(Person _objPerson);
        //PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType);
        /// <summary>
        /// Persons the get all dal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> Person_GetALLDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);


        IList<Person> Prospect_GetALLDAL(string CurrentCulture, long CompanyID, string SearchText);
        /// <summary>
        /// Persons the get all dal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> PersonOrganization_GetALLDAL(string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);
        IList<Person> Person_GetALLDAL_Report();
        IList<Person> Person_Record_GetAllByIdDAL(string ID);
        /// <summary>
        /// Persons the get all by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        Person Person_GetAllByIdDAL(string ID);
        Person Prospect_GetAllByIdDAL(string ID);

        int ManageCourse_Assigned(long PID);

        Classes ClassGetByIDDAL(long CurrentClassID);

        Person Person_GetAllByIdDALdetailCard(string ID);

        /// <summary>
        /// Persons the update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_UpdateDAL(Person _objPerson);

        /// <summary>
        /// Persons the delete dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_DeleteDAL(Person _objPerson);

        int Person_ActiveDAL(Person _objPerson);

        

        /// <summary>
        /// Persons the relation get allby person identifier.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>IList&lt;PersonRelation&gt;.</returns>
        IList<PersonRelation> PersonRelationGetAllbyPersonID(long PersonID);

        /// <summary>
        /// Persons the relation to person create dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int64.</returns>
        long PersonRelationToPerson_CreateDAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_UpdateDAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person delete dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_DeleteDAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person duplication check dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_DuplicationCheckDAL(PersonRelation _objPerson);

        /// <summary>
        /// TMSs the person roles mapping create dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonRolesMapping_CreateDAL(PersonRolesMapping _objPersonRoles);

        long Enrolment_CreateDAL(CRM_EnrolmentHistory _objPersonRoles);

        

        /// <summary>
        /// TMSs the person roles mapping create dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonintoUser_CreateDAL(PersonRolesMapping _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping update dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_UpdateDAL(PersonRolesMapping _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping delete dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_DeleteDAL(PersonRolesMapping _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping duplication check dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_DuplicationCheckDAL(PersonRolesMapping _objPersonRoles);


        int _PersonRoleCheckDAL(CRM_EnrolmentHistory _objPersonRoles);
        /// <summary>
        /// TMSs the person roles mapping getby person id dal.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;PersonRolesMapping&gt;.</returns>
        IList<PersonRolesMapping> TMS_PersonRolesMapping_GetbyPersonIDDAL(long PersonID,long CompanyID , int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        IList<Person> TMS_Coordinate_GetAllByCultureDAL(string culture);


       DataTable GetTrainerDetailsForReportsDAL(long ClssID, long TrainerID);

        DataTable GetTraineeDetailsForReportsDAL(long ClssID, long TrainerID);
        DataTable GetTraineePeriodicDataDAL(DateTime StartDate, DateTime EndDate, long CourseID);

        DataTable GetConductedCoursesDataDAL(DateTime StartDate, DateTime EndDate, long CourseID);
        DataTable GetVenueDetailsForReportsDAL(long ClssID, long VenueID);

        DataTable GetCourseFromTimeSpanDAL(DateTime StartTime, DateTime EndTime);
        DataTable ClassFutureReportDAL(long CurrentCourseCategoryID, DateTime ClassReportStartDateFrom, DateTime ClassReportStartDateTo, int ClassTypeID, bool ShowFutureClasses);
        DataTable AttendanceReportsDAL(long CourseID, long ClassID, DateTime startdate, DateTime enddate);
        DataTable GetOccVenueDetailsForReportsDAL(long ClassID, long VenueID, DateTime StartTime, DateTime EndTime);
        DataTable GetCourseReportDataDAL(long ClassID, long CourseID);

        DataTable DailyVenueUtalizationReportsDAL(DateTime Startday, DateTime Endday, long venueid);
        DataTable DailyUtilizationReportDAL(DateTime day, int type);
        DataTable GetClassDetailReportDataDAL(long ClassID, long CourseID);
        DataTable GetDataForVenueMatrix(long VenueID);

        DataTable SessionsByCourseAndClassIDDAL(long? CourseID, long? ClassID,long CompanyID);

     

       IList< Library.Entities.Common.Configuration.Venues.Venues> GetByID(long ID);

        List<CRMHowHeardMapping> ManageHowHeard_GetAllDAL(long PersonID);
        List<CRM_ProspectHistory> AssigmentHistory_GetAllDAL(long PersonID);

        List<CRM_EnrolmentHistory> EnrolmentHistory_GetAllDAL(long PersonID);
        long ManageHowHeard_CreateDAL(CRMHowHeardMapping _mapping);

        List<CRM_UserMapping> ManageAssigned_GetAllDAL(long PersonID);
        
         long ManageAssigned_UpdateDAL(Person _person);
        long ManageAssigned_CreateDAL(Person _person );
        long AssigementHistory_CreateDAL(Person _person);
        long Enrolment_CreateDAL(Person _person);
        List<CRM_CourseCategoryMapping> ManageCategory_GetAllDAL(long PersonID);

        long ManageCategory_CreateDAL(CRM_CourseCategoryMapping _mapping);

        int ManageCategory_UpdateDAL(CRM_CourseCategoryMapping _mapping);

        int ManageCategory_DeleteDAL(CRM_CourseCategoryMapping _mapping);

        

        #   region proposedCourses
        List<CRM_CourseMapping> ManageProposedCourses_GetAllDAL(long PersonID);

        long ManageProposedCourses_CreateDAL(CRM_CourseMapping _mapping);

        int ManageProposedCourses_UpdateDAL(CRM_CourseMapping _mapping);

        int ManageProposedCourses_DeleteDAL(CRM_CourseMapping _mapping);

        #endregion proposedCourses

        #region ScheduledClasses

        List<CRM_classPersonMapping> ManageScheduledClasses_GetAllDAL(long PersonID);

        long ManageScheduledClasses_CreateDAL(CRM_classPersonMapping _mapping);

        int ManageScheduledClasses_UpdateDAL(CRM_classPersonMapping _mapping);

        int ManageScheduledClasses_DeleteDAL(CRM_classPersonMapping _mapping);



        int ManageHowHeard_UpdateDAL(CRMHowHeardMapping _mapping);


        int ManageHowHeard_DeleteDAL(CRMHowHeardMapping _mapping);


        int ManageAssigned_UpdateDAL(CRM_UserMapping _mapping);


        int ManageAssigned_DeleteDAL(CRM_UserMapping _mapping);



        #endregion ScheduledClasses


        #region Record Call    
        List<CRM_CallManager> ManageRecordCall_GetAllDAL(long PersonID);

        long ManageRecordCall_CreateDAL(CRM_CallManager _mapping);



        int ManageRecordCall_UpdateDAL(CRM_CallManager _mapping);

        int ManageRecordCall_DeleteDAL(CRM_CallManager _mapping);

        #endregion Record Call    


        #region Record Visit    
        List<CRM_VisitHistory> ManageRecordVisit_GetAllDAL(long PersonID);

        long ManageRecordVisit_CreateDAL(CRM_VisitHistory _mapping);



        int ManageRecordVisit_UpdateDAL(CRM_VisitHistory _mapping);

        int ManageRecordVisit_DeleteDAL(CRM_VisitHistory _mapping);

        int ManageCourse_DuplicationCheckDAL(CRM_CourseMapping _mapping);

             int ManageScheduleCourse_DuplicationCheckDAL(CRM_classPersonMapping _mapping);

        #endregion Record Visit    
    }
}