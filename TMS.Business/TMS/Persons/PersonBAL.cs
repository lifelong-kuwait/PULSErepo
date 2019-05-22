// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="PersonBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Common.Configuration;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.DataObjects.Interfaces.TMS;
using TMS.DataObjects.TMS;
using TMS.Library;
using TMS.Library.Entities.CRM;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;

namespace TMS.Business.TMS
{
    /// <summary>
    /// Class PersonBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.IPersonBAL" />
    public class PersonBAL : IPersonBAL
    {
        private readonly IPersonDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public PersonBAL()
        {
            DAL = new PersonDAL();
        }

        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonBAL(Person _objPerson,long RoleID)
        {
            string clientType = string.Empty;
            if (_objPerson.ClientType == ClientType.ClientType_Internal)
                clientType = "I";
            else if (_objPerson.ClientType == ClientType.ClientType_External)
                clientType = "C";

            if (_objPerson.SalutationID == 0)
            {
                _objPerson.SalutationID = Salutation.Not_Specified;
            }
            if (_objPerson.Gender == 0)
            {
                _objPerson.Gender = Gender.Not_Specified;
            }
            var result = DAL.PersonInsertNewPersonDAL(_objPerson, clientType,RoleID);
            if (result.ID != -1)
            {
                if (_objPerson.Flags != null)
                {
                    IConfigurationDAL ConfigDAL = new ConfigurationDAL();
                    foreach (var flg in _objPerson.Flags)
                    {
                        ConfigDAL.PersonFlags_InsertByPersonID(flg.ID, result.ID.ToString(), _objPerson.CreatedBy);
                    }
                }
            }
            return result;
        }



        public PersonResponse ProspectInsertNewPersonBAL(Person _objPerson, long RoleID)
        {
            string clientType = string.Empty;
            if (_objPerson.ClientType == ClientType.ClientType_Internal)
                clientType = "I";
            else if (_objPerson.ClientType == ClientType.ClientType_External)
                clientType = "C";

            if (_objPerson.SalutationID == 0)
            {
                _objPerson.SalutationID = Salutation.Not_Specified;
            }
            if (_objPerson.Gender == 0)
            {
                _objPerson.Gender = Gender.Not_Specified;
            }
            var result = DAL.ProspectInsertNewPersonDAL(_objPerson, clientType, RoleID);
            if (result.ID != -1)
            {
                if (_objPerson.Flags != null)
                {
                    IConfigurationDAL ConfigDAL = new ConfigurationDAL();
                    foreach (var flg in _objPerson.Flags)
                    {
                        ConfigDAL.PersonFlags_InsertByPersonID(flg.ID, result.ID.ToString(), _objPerson.CreatedBy);
                    }
                }
            }
            return result;
        }

        //int Loginperson_DuplicationCheckBAL(Person _objPerson)
        //{
        //    return DAL.Loginperson_DuplicationCheckDAL(_objPerson);
        //}
        int IPersonBAL.Loginperson_DuplicationCheckBAL(Person _objPerson)
        {
            return DAL.Loginperson_DuplicationCheckDAL(_objPerson);
        }
        /// <summary>
        /// Persons the get allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Person> Person_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.Person_GetALLDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        public IList<Person> Prospect_GetALLBAL(string CurrentCulture, long CompanyID, string SearchText)
        {
            return DAL.Prospect_GetALLDAL(CurrentCulture, CompanyID, SearchText);
        }


        /// <summary>
        /// Persons the get organization ID allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Person> PersonOrganization_GetALLBAL(string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.PersonOrganization_GetALLDAL(ID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        public IList<Person> Person_GetALLBAL_Report()
        {
            return DAL.Person_GetALLDAL_Report();
        }

        public IList<Person> Person_Record_GetALLBAL(string ID)
        {
            return DAL.Person_Record_GetAllByIdDAL(ID);
        }
        /// <summary>
        /// Persons the get all by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        /// 
        public Classes ClassGetByID(long CurrentClassID)
        {
            return DAL.ClassGetByIDDAL(CurrentClassID);
        }
        public Person Person_GetAllByIdBAL(string ID)
        {
            return DAL.Person_GetAllByIdDAL(ID);
        }

        public Person Prospect_GetAllByIdBAL(string ID)
        {
            return DAL.Prospect_GetAllByIdDAL(ID);
        }
        

        public Person Person_GetAllByIdBALdetailCard(string ID)
        {
            return DAL.Person_GetAllByIdDALdetailCard(ID);
        }

        /// <summary>
        /// Persons the update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_UpdateBAL(Person _objPerson)
        {
            IConfigurationDAL ConfigDAL = new ConfigurationDAL();
            if (_objPerson.FlagIDs == null)
            {
                if (_objPerson.Flags != null)
                {
                    for (int i = 0; i < _objPerson.Flags.Count; i++)
                    {
                        if (_objPerson.Flags[i] != null)
                        {
                            ConfigDAL.PersonFlags_InsertByPersonID(_objPerson.Flags[i].ID, _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                            _objPerson.FlagIDs = _objPerson.FlagIDs + _objPerson.Flags[i].ID.ToString();
                            if (_objPerson.Flags.Count - 1 != i)
                            {
                                _objPerson.FlagIDs = _objPerson.FlagIDs.ToString() + ",";
                            }
                        }
                    }
                }
            }
            else
            {
                char[] delimiters = new char[] { ',' };
                List<string> _FlagIDs = _objPerson.FlagIDs.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (_FlagIDs.Count > 0)
                {
                    if (_objPerson.Flags == null)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objPerson.FlagIDs = null;
                    }
                    else if (_objPerson.Flags.Count == 0)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objPerson.FlagIDs = null;
                    }
                    else
                    {
                        if (_objPerson.Flags.Count > _FlagIDs.Count)
                        {
                            for (int i = 0; i < _objPerson.Flags.Count; i++)
                            {
                                var _result = _FlagIDs.FirstOrDefault(stringToCheck => stringToCheck.Contains(_objPerson.Flags[i].ID.ToString()));
                                if (string.IsNullOrEmpty(_result))
                                {
                                    ConfigDAL.PersonFlags_InsertByPersonID(_objPerson.Flags[i].ID, _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                                    _objPerson.FlagIDs = _objPerson.FlagIDs + "," + _objPerson.Flags[i].ID.ToString();
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _FlagIDs.Count; i++)
                            {
                                var _result = _objPerson.Flags.FirstOrDefault(s => s.ID == Convert.ToInt64(_FlagIDs[i]));
                                if (_result == null)
                                {
                                    ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                                }
                            }
                            _objPerson.FlagIDs = "";
                            for (int i = 0; i < _objPerson.Flags.Count; i++)
                            {
                                _objPerson.FlagIDs = _objPerson.FlagIDs + _objPerson.Flags[i].ID.ToString();
                                if (_objPerson.Flags.Count - 1 != i)
                                {
                                    _objPerson.FlagIDs = _objPerson.FlagIDs.ToString() + ",";
                                }
                            }
                        }
                    }
                }
                else
                {
                }
            }
            return DAL.Person_UpdateDAL(_objPerson);
        }

        /// <summary>
        /// Persons the delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_DeleteBAL(Person _objPerson) => DAL.Person_DeleteDAL(_objPerson);
        public int Person_ActiveBAL(Person _objPerson) => DAL.Person_ActiveDAL(_objPerson);


      //  int Person_ActiveBAL(Person _objPerson);
        /// <summary>
        /// Persons the relation get allby person idbal.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>IList&lt;PersonRelation&gt;.</returns>
        public IList<PersonRelation> PersonRelationGetAllbyPersonIDBAL(long PersonID) => DAL.PersonRelationGetAllbyPersonID(PersonID);

        /// <summary>
        /// Persons the relation to person create bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int64.</returns>
        public long PersonRelationToPerson_CreateBAL(PersonRelation _objPerson) => DAL.PersonRelationToPerson_CreateDAL(_objPerson);

        /// <summary>
        /// Persons the relation to person update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_UpdateBAL(PersonRelation _objPerson) => DAL.PersonRelationToPerson_UpdateDAL(_objPerson);

        /// <summary>
        /// Persons the relation to person delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_DeleteBAL(PersonRelation _objPerson) => DAL.PersonRelationToPerson_DeleteDAL(_objPerson);

        /// <summary>
        /// Persons the relation to person duplication check bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_DuplicationCheckBAL(PersonRelation _objPerson) => DAL.PersonRelationToPerson_DuplicationCheckDAL(_objPerson);

        /// <summary>
        /// TMSs the person roles mapping create bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonRolesMapping_CreateBAL(PersonRolesMapping _objPersonRoles) =>  DAL.TMS_PersonRolesMapping_CreateDAL(_objPersonRoles);

        public long Enrolment_CreateBAL(CRM_EnrolmentHistory _objPersonRoles) => DAL.Enrolment_CreateDAL(_objPersonRoles);

     
        /// <summary>
        /// TMSs the person roles mapping create bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonintoUser_CreateBAL(PersonRolesMapping _objPersonRoles) => DAL.TMS_PersonintoUser_CreateDAL(_objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping update bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_UpdateBAL(PersonRolesMapping _objPersonRoles) =>  DAL.TMS_PersonRolesMapping_UpdateDAL(_objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping delete bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_DeleteBAL(PersonRolesMapping _objPersonRoles) =>  DAL.TMS_PersonRolesMapping_DeleteDAL(_objPersonRoles);

        /// <summary>
        /// TMSs the person roles mapping duplication check bal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_DuplicationCheckBAL(PersonRolesMapping _objPersonRoles) => DAL.TMS_PersonRolesMapping_DuplicationCheckDAL(_objPersonRoles);

        public int _PersonRoleCheckBAL(CRM_EnrolmentHistory _objPersonRoles) => DAL._PersonRoleCheckDAL(_objPersonRoles);

      
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
        public IList<PersonRolesMapping> TMS_PersonRolesMapping_GetbyPersonIDBAL(long PersonID, long CompanyID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.TMS_PersonRolesMapping_GetbyPersonIDDAL(PersonID, CompanyID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        }

        public IList<Person> TMS_Coordinate_GetAllByCultureBAL(string culture)
        {
            return DAL.TMS_Coordinate_GetAllByCultureDAL(culture);
        }

        public DataTable GetTrainerDetailsForReports(long ClassID, long TrainerID)
        {
            return DAL.GetTrainerDetailsForReportsDAL(ClassID, TrainerID);
        }

        public DataTable GetTraineeDetailsForReports(long ClassID, long TrainerID)
        {
            return DAL.GetTraineeDetailsForReportsDAL(ClassID, TrainerID);
        }

        public DataTable GetVenueDetailsForReports(long ClassID, long VenueID)
        {
            return DAL.GetVenueDetailsForReportsDAL(ClassID, VenueID);
        }


        public DataTable AttendanceReports(long CourseID, long ClassID, DateTime startdate, DateTime enddate)
        {
            return DAL.AttendanceReportsDAL(CourseID,ClassID, startdate, enddate);
        }

        public DataTable ClassFutureReport(long CurrentCourseCategoryID,DateTime ClassReportStartDateFrom,DateTime ClassReportStartDateTo,bool ShowFutureClasses,int ClassTypeID)
        {
            return DAL.ClassFutureReportDAL(CurrentCourseCategoryID, ClassReportStartDateFrom, ClassReportStartDateTo, ClassTypeID, ShowFutureClasses);
        }
        
        public DataTable GetCourseFromTimeSpan(DateTime StartTime, DateTime EndTime)
        {
            return DAL.GetCourseFromTimeSpanDAL( StartTime, EndTime);
        }
        public DataTable GetOccVenueDetailsForReports(long ClassID, long VenueID,DateTime StartTime,DateTime EndTime)
        {
            return DAL.GetOccVenueDetailsForReportsDAL(ClassID, VenueID, StartTime,EndTime);
        }
        public DataTable GetCourseReportData(long ClassID, long CourseID)
        {
            return DAL.GetCourseReportDataDAL(ClassID, CourseID);
        }

        public DataTable DailyVenueUtalizationReports(DateTime Startday, DateTime Endday,long venueid)
        {
            return DAL.DailyVenueUtalizationReportsDAL(Startday, Endday, venueid);
        }

        public DataTable DailyUtilizationReport(DateTime day, int type)
        {
            return DAL.DailyUtilizationReportDAL(day, type);
        }

        public DataTable GetTraineePeriodicData(DateTime StartDate, DateTime EndDate,long CourseID)
        {
            return DAL.GetTraineePeriodicDataDAL(StartDate, EndDate, CourseID);
        }

        public DataTable GetConductedCoursesData(DateTime StartDate, DateTime EndDate, long CourseID)
        {
            return DAL.GetConductedCoursesDataDAL(StartDate, EndDate, CourseID);
        }

        
        public DataTable GetClassDetailReportData(long ClassID, long CourseID)
        {
            return DAL.GetClassDetailReportDataDAL(ClassID, CourseID);
        }
        public DataTable GetDataForVenueMatrix(long VenueID)
        {
            return DAL.GetDataForVenueMatrix(VenueID);
        }
      
        public DataTable SessionsByCourseAndClassID(long? CourseID, long? ClassID,long CompanyID)
        {
            return DAL.SessionsByCourseAndClassIDDAL(CourseID,ClassID, CompanyID);
        }

        

        public List<Library.Entities.Common.Configuration.Venues.Venues> GetByID(long ID)
        {
           
            return DAL.GetByID(ID).ToList();
        }

        public List<CRMHowHeardMapping> ManageHowHeard_GetAllBAL(long PersonID)
        {
            return DAL.ManageHowHeard_GetAllDAL(PersonID);
        }
        public List<CRM_ProspectHistory> AssigmentHistory_GetAllBAL(long PersonID)
        {
            return DAL.AssigmentHistory_GetAllDAL(PersonID);
        }

       public List<CRM_EnrolmentHistory>EnrolmentHistory_GetAllBAL(long PersonID)
        {
            
                return DAL.EnrolmentHistory_GetAllDAL(PersonID);
            
        }


        public long ManageHowHeard_CreateBAL(CRMHowHeardMapping _mapping)
        {
            return DAL.ManageHowHeard_CreateDAL(_mapping);
        }

        public List<CRM_UserMapping> ManageAssigned_GetAllBAL(long PersonID)
        {
            return DAL.ManageAssigned_GetAllDAL(PersonID);
        }
        public long ManageAssigned_UpdateBAL(Person _person)
        {
            return DAL.ManageAssigned_UpdateDAL(_person);
        }
        public long ManageAssigned_CreateBAL(Person _person )
        {
            return DAL.ManageAssigned_CreateDAL(_person);
        }
        public long AssigementHistory_CreateBAL(Person _person)
        {
            return DAL.AssigementHistory_CreateDAL(_person);
        }

        public long Enrolment_CreateBAL(Person _person)
        {
            return DAL.Enrolment_CreateDAL(_person);
        }
        
        public List<CRM_CourseCategoryMapping> ManageCategory_GetAllBAL(long PersonID)
        {
            return DAL.ManageCategory_GetAllDAL(PersonID);
        }

        public long ManageCategory_CreateBAL(CRM_CourseCategoryMapping _mapping)
        {
            return DAL.ManageCategory_CreateDAL(_mapping);
        }

        public int ManageCategory_UpdateBAL(CRM_CourseCategoryMapping _mapping)
        {
            return DAL.ManageCategory_UpdateDAL(_mapping);
        }

        public int ManageCategory_DeleteBAL(CRM_CourseCategoryMapping _mapping)
        {
            return DAL.ManageCategory_DeleteDAL(_mapping);
        }


        #region proposedCourses
        public List<CRM_CourseMapping> ManageProposedCourses_GetAllBAL(long PersonID)
        {
            return DAL.ManageProposedCourses_GetAllDAL(PersonID);
        }

        public long ManageProposedCourses_CreateBAL(CRM_CourseMapping _mapping)
        {
            return DAL.ManageProposedCourses_CreateDAL(_mapping);
        }

        public int ManageProposedCourses_UpdateBAL(CRM_CourseMapping _mapping)
        {
            return DAL.ManageProposedCourses_UpdateDAL(_mapping);
        }

        public int ManageProposedCourses_DeleteBAL(CRM_CourseMapping _mapping)
        {
            return DAL.ManageProposedCourses_DeleteDAL(_mapping);
        }

        #endregion proposedCourses

        #region ScheduledClasses

        public List<CRM_classPersonMapping> ManageScheduledClasses_GetAllBAL(long PersonID)
        {
            return DAL.ManageScheduledClasses_GetAllDAL(PersonID);
        }

       public long ManageScheduledClasses_CreateBAL(CRM_classPersonMapping _mapping)
        {
            return DAL.ManageScheduledClasses_CreateDAL(_mapping);
        }

        public int ManageScheduledClasses_UpdateBAL(CRM_classPersonMapping _mapping)
        {
            return DAL.ManageScheduledClasses_UpdateDAL(_mapping);
        }

        public int ManageScheduledClasses_DeleteBAL(CRM_classPersonMapping _mapping)
        {
            return DAL.ManageScheduledClasses_DeleteDAL(_mapping);
        }

        public int ManageHowHeard_UpdateBAL(CRMHowHeardMapping _mapping)
        {
            return DAL.ManageHowHeard_UpdateDAL(_mapping);
        }

        public int ManageHowHeard_DeleteBAL(CRMHowHeardMapping _mapping)
        {
            return DAL.ManageHowHeard_DeleteDAL(_mapping);
        }

        public int ManageAssigned_UpdateBAL(CRM_UserMapping _mapping)
        {
            return DAL.ManageAssigned_UpdateDAL(_mapping);
        }

        public int ManageAssigned_DeleteBAL(CRM_UserMapping _mapping)
        {
            return DAL.ManageAssigned_DeleteDAL(_mapping);
        }

        public List<CRM_CallManager> ManageRecordCall_GetAllBAL(long PersonID)
        {
            return DAL.ManageRecordCall_GetAllDAL(PersonID);
        }

        public long ManageRecordCall_CreateBAL(CRM_CallManager _mapping)
        {
            return DAL.ManageRecordCall_CreateDAL(_mapping);
        }

        public int ManageRecordCall_UpdateBAL(CRM_CallManager _mapping)
        {
            return DAL.ManageRecordCall_UpdateDAL(_mapping);
        }

        public int ManageRecordCall_DeleteBAL(CRM_CallManager _mapping)
        {
            return DAL.ManageRecordCall_DeleteDAL(_mapping);
        }




        public List<CRM_VisitHistory> ManageRecordVisit_GetAllBAL(long PersonID)
        {
            return DAL.ManageRecordVisit_GetAllDAL(PersonID);
        }

        public long ManageRecordVisit_CreateBAL(CRM_VisitHistory _mapping)
        {
            return DAL.ManageRecordVisit_CreateDAL(_mapping);
        }

        public int ManageRecordVisit_UpdateBAL(CRM_VisitHistory _mapping)
        {
            return DAL.ManageRecordVisit_UpdateDAL(_mapping);
        }

        public int ManageRecordVisit_DeleteBAL(CRM_VisitHistory _mapping)
        {
            return DAL.ManageRecordVisit_DeleteDAL(_mapping);
        }

        public int ManageCourse_DuplicationCheckBAL(CRM_CourseMapping _mapping)
        {
            return DAL.ManageCourse_DuplicationCheckDAL(_mapping);
        }

        public int ManageScheduleCourse_DuplicationCheckBAL(CRM_classPersonMapping _mapping)
        {
            return DAL.ManageScheduleCourse_DuplicationCheckDAL(_mapping);
        }




        #endregion ScheduledClasses
    }
}