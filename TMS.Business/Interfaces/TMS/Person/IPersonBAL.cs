// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IPersonBAL.cs" company="LifeLong www.lifelongkuwait.com">
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

namespace TMS.Business.Interfaces.TMS
{
    /// <summary>
    /// Interface IPersonBAL
    /// </summary>
    public interface IPersonBAL
    {
        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonBAL(Person _objPerson,long RoeID);

        PersonResponse ProspectInsertNewPersonBAL(Person _objPerson, long RoeID = 3);

        int Loginperson_DuplicationCheckBAL(Person _objPerson);
        /// <summary>
        /// Persons the get allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> Person_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        IList<Person> Prospect_GetALLBAL(string CurrentCulture, long CompanyID, string SearchText);

        IList<Person> Person_GetALLBAL_Report();
        IList<Person> Person_Record_GetALLBAL(string ID);

        /// <summary>
        /// Persons the get by organization ID allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> PersonOrganization_GetALLBAL(string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Persons the get all by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        Person Person_GetAllByIdBAL(string ID);

        Person Prospect_GetAllByIdBAL(string ID);

        Person Person_GetAllByIdBALdetailCard(string ID);

        /// <summary>
        /// Persons the update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_UpdateBAL(Person _objPerson);

     //  int Prospect_UpdateBAL(Person _objPerson);

        /// <summary>
        /// Persons the delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_DeleteBAL(Person _objPerson);

        int Person_ActiveBAL(Person _objPerson);
        
        /// <summary>
        /// Persons the relation get allby person idbal.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>IList&lt;PersonRelation&gt;.</returns>
        IList<PersonRelation> PersonRelationGetAllbyPersonIDBAL(long PersonID);

        /// <summary>
        /// Persons the relation to person create bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int64.</returns>
        long PersonRelationToPerson_CreateBAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_UpdateBAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_DeleteBAL(PersonRelation _objPerson);

        /// <summary>
        /// Persons the relation to person duplication check bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int PersonRelationToPerson_DuplicationCheckBAL(PersonRelation _objPerson);

        /// <summary>
        /// TMSs the person roles mapping create bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonRolesMapping_CreateBAL(PersonRolesMapping _objPersonRoles);

        long Enrolment_CreateBAL(CRM_EnrolmentHistory _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping create bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        long TMS_PersonintoUser_CreateBAL(PersonRolesMapping _objPersonRoles);
       // int LoginPerson_DuplicationCheckBAL(Person person);

        /// <summary>
        /// TMSs the person roles mapping update bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_UpdateBAL(PersonRolesMapping _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping delete bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_DeleteBAL(PersonRolesMapping _objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping duplication check bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        int TMS_PersonRolesMapping_DuplicationCheckBAL(PersonRolesMapping _objPersonRoles);

        int _PersonRoleCheckBAL(CRM_EnrolmentHistory crmhistory);

        /// <summary>
        /// TMSs the person roles mapping getby person idbal.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;PersonRolesMapping&gt;.</returns>
        IList<PersonRolesMapping> TMS_PersonRolesMapping_GetbyPersonIDBAL(long PersonID, long CompanyID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        IList<Person> TMS_Coordinate_GetAllByCultureBAL(string culture);

        // GetTrainerDetailsForReports
        //DataTable GetTrainerDetailsForReports(long ClassID, long TrainerID);
        //DataTable GetTraineeDetailsForReports(long ClassID, long TrainerID);
        //DataTable GetCourseReportData(long ClassID, long CourseID);
        //DataTable GetClassDetailReportData(long ClassID, long CourseID);
        //DataTable GetOccVenueDetailsForReports(long ClassID, long VenueID, DateTime StartTime, DateTime EndTime);

        #region HowHeard

        List<CRMHowHeardMapping> ManageHowHeard_GetAllBAL(long PersonID);

        List<CRM_ProspectHistory> AssigmentHistory_GetAllBAL(long PersonID);

        List<CRM_EnrolmentHistory> EnrolmentHistory_GetAllBAL(long PersonID);

        

        long ManageHowHeard_CreateBAL(CRMHowHeardMapping _mapping);

        int ManageHowHeard_UpdateBAL(CRMHowHeardMapping _mapping);

        int ManageHowHeard_DeleteBAL(CRMHowHeardMapping _mapping);


        #endregion HowHeard

        #region Assigned
        List<CRM_UserMapping> ManageAssigned_GetAllBAL(long PersonID);

        long ManageAssigned_CreateBAL(Person _person);
        long ManageAssigned_UpdateBAL(Person _person);
        long AssigementHistory_CreateBAL(Person _person);

        long Enrolment_CreateBAL(Person _person);

        
        int ManageAssigned_UpdateBAL(CRM_UserMapping _mapping);

        int ManageAssigned_DeleteBAL(CRM_UserMapping _mapping);

        #endregion Assigned


        #region Category
        List<CRM_CourseCategoryMapping> ManageCategory_GetAllBAL(long PersonID);

        long ManageCategory_CreateBAL(CRM_CourseCategoryMapping _mapping);


        int ManageCategory_UpdateBAL(CRM_CourseCategoryMapping _mapping);

        int ManageCategory_DeleteBAL(CRM_CourseCategoryMapping _mapping);

        #endregion Category


        #region proposedCourses

        List<CRM_CourseMapping> ManageProposedCourses_GetAllBAL(long PersonID);

        long ManageProposedCourses_CreateBAL(CRM_CourseMapping _mapping);

        int ManageProposedCourses_UpdateBAL(CRM_CourseMapping _mapping);

        int ManageProposedCourses_DeleteBAL(CRM_CourseMapping _mapping);

        #endregion proposedCourses

        #region ScheduledClasses
        List<CRM_classPersonMapping> ManageScheduledClasses_GetAllBAL(long PersonID);

        long ManageScheduledClasses_CreateBAL(CRM_classPersonMapping _mapping);



        int ManageScheduledClasses_UpdateBAL(CRM_classPersonMapping _mapping);

        int ManageScheduledClasses_DeleteBAL(CRM_classPersonMapping _mapping);

        #endregion ScheduledClasses

        #region Record Call    
        List<CRM_CallManager> ManageRecordCall_GetAllBAL(long PersonID);

        long ManageRecordCall_CreateBAL(CRM_CallManager _mapping);



        int ManageRecordCall_UpdateBAL(CRM_CallManager _mapping);

        int ManageRecordCall_DeleteBAL(CRM_CallManager _mapping);

     # endregion Record Call    


        #region Record Visit    
        List<CRM_VisitHistory> ManageRecordVisit_GetAllBAL(long PersonID);

        long ManageRecordVisit_CreateBAL(CRM_VisitHistory _mapping);



        int ManageRecordVisit_UpdateBAL(CRM_VisitHistory _mapping);

        int ManageRecordVisit_DeleteBAL(CRM_VisitHistory _mapping);

        #endregion Record Visit    


        int ManageCourse_DuplicationCheckBAL(CRM_CourseMapping _mapping);
        int ManageScheduleCourse_DuplicationCheckBAL(CRM_classPersonMapping _mapping);
        
    }
}