// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="PersonDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.TMS.Admin.Config;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;
using System.Linq;
using System.Data;
using TMS.Library.Entities.Common.Configuration.Venues;
using System.Data.Common;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.Entities.CRM;
using TMS.Library.ModelMapper;
using TMS.Library.Entities.TMS.Persons;
using TMS.Library.TMS.Organization;

namespace TMS.DataObjects.TMS
{
    /// <summary>
    /// Class PersonDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.IPersonDAL" />
    public class PersonDAL : DBGenerics, IPersonDAL
    {
        /// <summary>
        /// Persons the get alldal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        private string ConnectionString = DBHelper.ConnectionString;
        public IList<Person> Person_GetALLDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();

                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, FlagDateTime = date });
                using (var multi = conn.QueryMultiple("TMS_Prospect_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                    foreach (var single in Person)
                    {
                        if (single.FlagCount > 0)
                        {
                            single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                        }
                    }
                }

                conn.Close();
                //var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
                //var _PersonData = ExecuteListSp<Person>("TMS_Person_GetByOrganizationID", ParamBuilder.Par("oid", ID), ParamBuilder.Par("FlagDateTime", date));
                //foreach (var single in _PersonData)
                //{
                //    if (single.FlagCount > 0)
                //    {
                //        single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                //    }
                //}
                //return _PersonData;
            }
            return Person.ToList();
        }



        public IList<Person> Prospect_GetALLDAL(string CurrentCulture, long CompanyID, string SearchText)
        {
            List<Person> Person = new List<Person>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Person>("TMS_Prospect_GetByCulture", ParamBuilder.Par("@culture", CurrentCulture), ParamBuilder.Par("@ID", CompanyID), ParamBuilder.Par("SearchText", SearchText), ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
                //  Person = _PersonData.Read<Trainer>().AsList<Trainer>();
            }
            //    Total = _PersonData.Read<int>().FirstOrDefault<int>();
            return _PersonData;


        }

        //    ()
        //{
        //    var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
        //    var _PersonData = ExecuteListSp<Person>(@"TMS_Prospect_GetAll", ParamBuilder.Par("FlagDateTime", date));
        //    foreach (var single in _PersonData)
        //    {
        //        if (single.FlagCount > 0)
        //        {
        //            single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
        //        }
        //    }
        //    return _PersonData;
        //}

        /// <summary>
        /// Persons the get alldal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Person> PersonOrganization_GetALLDAL(string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();

                dbParam.AddDynamicParams(new { ID = ID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, FlagDateTime = date });
                using (var multi = conn.QueryMultiple("TMS_Person_GetByOrganizationID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                    foreach (var single in Person)
                    {
                        if (single.FlagCount > 0)
                        {
                            single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                        }
                    }
                }

                conn.Close();
                //var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
                //var _PersonData = ExecuteListSp<Person>("TMS_Person_GetByOrganizationID", ParamBuilder.Par("oid", ID), ParamBuilder.Par("FlagDateTime", date));
                //foreach (var single in _PersonData)
                //{
                //    if (single.FlagCount > 0)
                //    {
                //        single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                //    }
                //}
                //return _PersonData;
            }
            return Person.ToList();
        }

        public IList<Person> Person_GetALLDAL_Report()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Person>(@"TMS_Prospect_GetAll_Report", ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
            }
            return _PersonData;
        }

        public IList<Person> Person_Record_GetAllByIdDAL(string ID)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Person>("TMS_Person_GetByID", ParamBuilder.Par("pid", ID), ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
            }
            return _PersonData;
        }



        /// <summary>
        /// Persons the get all by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        public Person Person_GetAllByIdDAL(string ID)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteSinglewithSP<Person>("TMS_Person_GetByID", ParamBuilder.Par("pid", ID), ParamBuilder.Par("FlagDateTime", date));
            if (_PersonData == null)
            {
                return null;
            }
            else if (_PersonData.FlagCount > 0)
            {
                _PersonData.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", _PersonData.FlagIDs));
            }
            return _PersonData;
        }


        public Person Prospect_GetAllByIdDAL(string ID)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteSinglewithSP<Person>("TMS_Prospect_GetByID", ParamBuilder.Par("pid", ID), ParamBuilder.Par("FlagDateTime", date));
            if (_PersonData == null)
            {
                return null;
            }
            else if (_PersonData.FlagCount > 0)
            {
                _PersonData.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", _PersonData.FlagIDs));
            }
            return _PersonData;
        }



        public Person Person_GetAllByIdDALdetailCard(string ID)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteSinglewithSP<Person>("TMS_User_GetByID_CardDetail", ParamBuilder.Par("pid", ID), ParamBuilder.Par("FlagDateTime", date));
            if (_PersonData == null)
            {
                return null;
            }
            else if (_PersonData.FlagCount > 0)
            {
                _PersonData.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", _PersonData.FlagIDs));
            }
            return _PersonData;
        }

        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType, long RoleID)
        {
            PersonResponse _Response = new PersonResponse();
            CustomGenerics.CustomGenerics _obj = new CustomGenerics.CustomGenerics();
            return _obj.InsertRecordPersonReturnObject(_objPerson, clientType, RoleID);
        }
        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public List<PersonBarData> PersonBarBALDAL(DateTime startdate, DateTime lastdate,long CompanyId)
        {
            var _PersonData = ExecuteListSp<PersonBarData>("PersonTrainerTraineeData", ParamBuilder.Par("monthstart", startdate), ParamBuilder.Par("monthEndDate", lastdate), ParamBuilder.Par("CompanyId", CompanyId));
            return _PersonData.ToList();
            //List<PersonBarData> _PersonData = new List<PersonBarData>();
            //var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    dbParam.AddDynamicParams(new { monthstart = startdate, monthEndDate = lastdate, });
            //    using (var multi = conn.QueryMultiple("PersonTrainerTraineeData", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        _PersonData = multi.Read<PersonBarData>().AsList<PersonBarData>();

            //    }

            //    conn.Close();
            //}
            //return _PersonData.ToList();
        }
       

        public PersonResponse ProspectInsertNewPersonDAL(Person _objPerson, string clientType, long RoleID)
        {
            PersonResponse _Response = new PersonResponse();
            CustomGenerics.CustomGenerics _obj = new CustomGenerics.CustomGenerics();
            return _obj.InsertRecordProspectReturnObject(_objPerson, clientType, RoleID);
        }


        public int Loginperson_DuplicationCheckDAL(Person _objPerson)
        {
            return ExecuteScalarSPInt32("TMS_Person_DuplicationCheck",
             ParamBuilder.Par("Email", _objPerson.Email)
                  );
        }
        /// <summary>
        /// Persons the update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_UpdateDAL(Person _objPerson)
        {
            return ExecuteScalarInt32Sp("TMS_Person_Update",
                             ParamBuilder.Par("ID", _objPerson.ID),
                            ParamBuilder.Par("SalutationID", _objPerson.SalutationID),
                            ParamBuilder.Par("P_FirstName", _objPerson.P_FirstName),
                            ParamBuilder.Par("P_LastName", _objPerson.P_LastName),
                            ParamBuilder.Par("P_MiddleName", _objPerson.P_MiddleName),
                            ParamBuilder.Par("P_DisplayName", _objPerson.P_DisplayName),
                            ParamBuilder.Par("S_FirstName", _objPerson.S_FirstName),
                            ParamBuilder.Par("S_LastName", _objPerson.S_LastName),
                            ParamBuilder.Par("S_MiddleName", _objPerson.S_MiddleName),
                            ParamBuilder.Par("S_DisplayName", _objPerson.S_DisplayName),
                            ParamBuilder.Par("EngagementStatusId", _objPerson.EngagementStatusId),
                            ParamBuilder.Par("OrganizationID", _objPerson.OrganizationID),
                            ParamBuilder.Par("DepartmentID", _objPerson.DepartmentID),
                            ParamBuilder.Par("Notes", _objPerson.Notes),
                            ParamBuilder.Par("NationalIdentity", _objPerson.NationalIdentity),
                            ParamBuilder.Par("OfficialIdentificationTypeID", _objPerson.OfficialIdentificationTypeID),
                            ParamBuilder.Par("OfficialIDNumber", _objPerson.OfficialIDNumber),
                            ParamBuilder.Par("DateOfBirth", _objPerson.DateOfBirth),
                            ParamBuilder.Par("AvailabilityFrom", _objPerson.AvailabilityFrom),
                            ParamBuilder.Par("AvailabilityTo", _objPerson.AvailabilityTo),
                            ParamBuilder.Par("LoyaltyPoint", _objPerson.LoyaltyPoint),
                            ParamBuilder.Par("LoyaltyPointRedeemed", _objPerson.LoyaltyPointRedeemed),
                            ParamBuilder.Par("Designation", _objPerson.Designation),
                            ParamBuilder.Par("Password", _objPerson.Password),
                            ParamBuilder.Par("Gender", _objPerson.Gender),
                            ParamBuilder.Par("Nationality", 0),
                            ParamBuilder.Par("Type", _objPerson.Type),
                            ParamBuilder.Par("IsCoordinator", _objPerson.IsCoordinator),
                            ParamBuilder.Par("Rating", _objPerson.Rating),
                            ParamBuilder.Par("ClientType", _objPerson.ClientType),
                            ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate),
                            ParamBuilder.Par("IsActive", true),
                            ParamBuilder.Par("UserID", _objPerson.UserID),
                            ParamBuilder.Par("AdditionalComments", _objPerson.AdditionalComments),
                            ParamBuilder.Par("IsOnline", _objPerson.IsOnline),
                            ParamBuilder.Par("MaritalStatus", _objPerson.MaritalStatus),
                            ParamBuilder.Par("VendorID", _objPerson.VendorID),
                            ParamBuilder.Par("NickName", _objPerson.NickName),
                            ParamBuilder.Par("Alias", _objPerson.Alias)
                        );
        }

        /// <summary>
        /// Persons the delete dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_DeleteDAL(Person _objPerson)
        {
            return ExecuteScalarSPInt32("TMS_Person_Delete",
                           // ParamBuilder.OutPar("IsDeleted" ,_objPerson.IsDeleted),
                           ParamBuilder.Par("ID", _objPerson.ID), 
                            ParamBuilder.Par("EmailId", _objPerson.EmailID),
                           ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate));
        }

        public int Person_ActiveDAL(Person _objPerson)
        {
            return ExecuteScalarSPInt32("TMS_Person_Active",
                           // ParamBuilder.OutPar("IsDeleted" ,_objPerson.IsDeleted),
                           ParamBuilder.Par("ID", _objPerson.ID),
                           ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate));
        }


        /// <summary>
        /// Persons the relation get allby person identifier.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>IList&lt;PersonRelation&gt;.</returns>
        public IList<PersonRelation> PersonRelationGetAllbyPersonID(long PersonID)
        {
            return ExecuteListSp<PersonRelation>("TMS_PersonRelationToPerson_GetbyPersonId", ParamBuilder.Par("PersonID", PersonID));
        }
       
        /// <summary>
        /// Persons the relation to person create dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int64.</returns>
        public long PersonRelationToPerson_CreateDAL(PersonRelation _objPerson)
        {
            var parameters = new[] { ParamBuilder.Par("RelationID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonRelationToPerson_Create", parameters,
                    ParamBuilder.Par("RelationFrom", _objPerson.RelationFrom),
                    ParamBuilder.Par("RelationTo", _objPerson.RelationTo),
                    ParamBuilder.Par("RelationType", _objPerson.RelationType),
                    ParamBuilder.Par("CreatedDate", _objPerson.CreatedDate),
                    ParamBuilder.Par("CreatedBy", _objPerson.CreatedBy)
                    );
        }

        /// <summary>
        /// Persons the relation to person update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_UpdateDAL(PersonRelation _objPerson)
        {
            return ExecuteScalarInt32Sp("TMS_PersonRelationToPerson_Update",
                    ParamBuilder.Par("RelationID", _objPerson.RelationID),
                    ParamBuilder.Par("RelationTo", _objPerson.RelationTo),
                    ParamBuilder.Par("RelationType", _objPerson.RelationType),
                    ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate)
                    );
        }

        /// <summary>
        /// Persons the relation to person delete dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_DeleteDAL(PersonRelation _objPerson)
        {
            return ExecuteScalarInt32Sp("TMS_PersonRelationToPerson_Delete",
                ParamBuilder.Par("RelationID", _objPerson.RelationID),
                ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate));
        }

        /// <summary>
        /// Persons the relation to person duplication check dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int PersonRelationToPerson_DuplicationCheckDAL(PersonRelation _objPerson)
        {
            return ExecuteScalarSPInt32("TMS_PersonRelationToPerson_DuplicationCheck",
                ParamBuilder.Par("PersonFrom", _objPerson.RelationFrom),
                  ParamBuilder.Par("PersonTo", _objPerson.RelationTo),
                     ParamBuilder.Par("RelationID", _objPerson.RelationID)
                  );
        }



        #region "Manage Person Roles"

        /// <summary>
        /// TMSs the person roles mapping create dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonRolesMapping_CreateDAL(PersonRolesMapping _objPersonRoles)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonRolesMapping_Create", parameters,
                            ParamBuilder.Par("PersonID", _objPersonRoles.PersonID),
                            ParamBuilder.Par("RoleID", _objPersonRoles.RoleID),
                            ParamBuilder.Par("CreatedDate", _objPersonRoles.CreatedDate),
                            ParamBuilder.Par("CreatedBy", _objPersonRoles.CreatedBy),
                            ParamBuilder.Par("ClientType", _objPersonRoles.ClientType)
                    );
        }

        /// <summary>
        /// TMSs the person roles mapping create dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_PersonintoUser_CreateDAL(PersonRolesMapping _objPersonRoles)
        {
            Person obj = Person_GetAllByIdDAL(Convert.ToString(_objPersonRoles.PersonID));
            if (obj.NickName==null)
            {
                obj.NickName = "";
            }
                var parameters = new[] { ParamBuilder.Par("UserID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersontoUser_Create", parameters,
                ParamBuilder.Par("P_FirstName", obj.P_FirstName),
                ParamBuilder.Par("P_MiddleName", obj.P_MiddleName),
                ParamBuilder.Par("P_LastName", obj.P_LastName),
                ParamBuilder.Par("P_DisplayName", obj.P_DisplayName),
                ParamBuilder.Par("S_FirstName", obj.S_FirstName),
                ParamBuilder.Par("S_MiddleName", obj.S_MiddleName),
                ParamBuilder.Par("S_LastName", obj.S_LastName),
                ParamBuilder.Par("S_DisplayName", obj.S_DisplayName),
                ParamBuilder.Par("Password", _objPersonRoles.Password),
                ParamBuilder.Par("Email", obj.Email),
                ParamBuilder.Par("UserRole", _objPersonRoles.RoleID),
                ParamBuilder.Par("IsActive", 1),
                ParamBuilder.Par("CompanyID", obj.OrganizationID),
                ParamBuilder.Par("DateOfBirth", obj.DateOfBirth),
               
                ParamBuilder.Par("NickName", obj.NickName),
                ParamBuilder.Par("Salutation", obj.SalutationID),
                ParamBuilder.Par("Gender", obj.Gender),
                ParamBuilder.Par("MaritalStatus", obj.MaritalStatus),
                ParamBuilder.Par("NationalIdentity", obj.NationalIdentity),
                ParamBuilder.Par("ProfileImage", obj.ProfilePicture),
                ParamBuilder.Par("PersonID", _objPersonRoles.PersonID),
                ParamBuilder.Par("CreatedDate", _objPersonRoles.CreatedDate),
                ParamBuilder.Par("CreatedBy", _objPersonRoles.CreatedBy)
                    );
        }
        /// <summary>
        /// TMSs the person roles mapping create dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int64.</returns>
        public int TMS_PersonintoUser_DestroyDAL(Person obj)
        {


            return ExecuteScalarInt32Sp("TMS_TrainerUserDelete",
                ParamBuilder.Par("UserID",obj.UserID),
                ParamBuilder.Par("PersonID", obj.ID)              
                    );
        }
        /// <summary>
        /// TMSs the person roles mapping update dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_UpdateDAL(PersonRolesMapping _objPersonRoles)
        {
            Person obj = Person_GetAllByIdDAL(Convert.ToString(_objPersonRoles.PersonID));

            return ExecuteScalarInt32Sp("TMS_PersonRolesMapping_Update",
                        ParamBuilder.Par("ID", _objPersonRoles.ID),
                        ParamBuilder.Par("RoleID", _objPersonRoles.RoleID),
                        ParamBuilder.Par("PersonID", _objPersonRoles.PersonID),
                        ParamBuilder.Par("Email", obj.Email),
                        ParamBuilder.Par("UpdatedDate", _objPersonRoles.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _objPersonRoles.UpdatedBy)
                       
                    );
        }

        /// <summary>
        /// TMSs the person roles mapping delete dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_DeleteDAL(PersonRolesMapping _objPersonRoles)
        {
            Person obj = Person_GetAllByIdDAL(Convert.ToString(_objPersonRoles.PersonID));
            if(obj.Email==null)
            {
                obj.Email = "";
            }
            
            return ExecuteScalarInt32Sp("TMS_PersonRolesMapping_Delete",
                        ParamBuilder.Par("ID", _objPersonRoles.ID),
                        ParamBuilder.Par("RoleID", _objPersonRoles.RoleID),
                        ParamBuilder.Par("Email", obj.Email),
                        ParamBuilder.Par("personID", _objPersonRoles.PersonID),
                        ParamBuilder.Par("UpdatedDate", _objPersonRoles.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _objPersonRoles.UpdatedBy));
        }

        /// <summary>
        /// TMSs the person roles mapping duplication check dal.
        /// </summary>
        /// <param name="_objPersonRoles">The object person roles.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_PersonRolesMapping_DuplicationCheckDAL(PersonRolesMapping _objPersonRoles)
        {
            return ExecuteScalarSPInt32("TMS_PersonRolesMapping_DuplicationCheck",
                        ParamBuilder.Par("PersonID", _objPersonRoles.PersonID),
                        ParamBuilder.Par("RoleID", _objPersonRoles.RoleID)
                  );
        }

        /// <summary>
        /// TMSs the person roles mapping getby person iddal.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>IList&lt;PersonRolesMapping&gt;.</returns>
        public IList<PersonRolesMapping> TMS_PersonRolesMapping_GetbyPersonIDDAL(long PersonID, long CompanyID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            IList<PersonRolesMapping> Venue = new List<PersonRolesMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, PersonID = PersonID, CompanyID = CompanyID });
                using (var multi = conn.QueryMultiple("TMS_PersonRolesMapping_GetbyPersonID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Venue = multi.Read<PersonRolesMapping>().AsList<PersonRolesMapping>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Venue.ToList();
        }

        public IList<Person> TMS_Coordinate_GetAllByCultureDAL(string culture)
        {
            List<Person> LoginUserAddGroups = new List<Person>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_PersonGroup_GetAllByCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                LoginUserAddGroups = conn.Query<Person>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Person>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }
        public List<OrganizationModel> GetOrganizationLogoDAL(long OrgID)
        {
            List<OrganizationModel> LoginUserAddGroups = new List<OrganizationModel>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Organizations_ProfilePicture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", OrgID);
                LoginUserAddGroups = conn.Query<OrganizationModel>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList< OrganizationModel>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }
        
        public DataTable GetTrainerDetailsForReportsDAL(long ClassID, long TrainerID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Person_GetTrainerDetailsForReports");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@TrainerID", TrainerID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }
        public DataTable GetTraineeDetailsForReportsDAL(long ClassID, long TrainerID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("Tran_Person_GetTraineeDetailsForReports");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@TraineeID", TrainerID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }


            // return ExecuteDataSet("Tran_Person_GetTraineeDetailsForReports", ParamBuilder.Par("ClassID", ClssID), ParamBuilder.Par("TraineeID", TrainerID));

            // return ExecuteDataSet("Tran_Person_GetTraineeDetailsForReports", ParamBuilder.Par("ClassID", ClssID), ParamBuilder.Par("TraineeID", TrainerID));

        }



        public DataTable GetVenueDetailsForReportsDAL(long ClssID, long VenueID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("Tran_Venue_GetVenueDetailsForReports");
            cmd.Parameters.AddWithValue("@ClassID", ClssID);
            cmd.Parameters.AddWithValue("@VenueID", VenueID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }


            //  return ExecuteDataSet("Tran_Venue_GetVenueDetailsForReports", ParamBuilder.Par("ClassID", ClssID), ParamBuilder.Par("VenueID", VenueID));

        }

        public DataTable GetCourseReportDataDAL(long ClassID, long CourseID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_AttendancesCourse_GetReportData");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }


            //  return ExecuteDataSet("TMS_AttendancesCourse_GetReportData", ParamBuilder.Par("ClassID", ClassID), ParamBuilder.Par("CourseID", CourseID));

        }

        public DataTable GetClassDetailReportDataDAL(long ClassID, long CourseID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("Tran_Classes_GetClassDetailsForReports");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }


            // return ExecuteDataSet("Tran_Classes_GetClassDetailsForReports", ParamBuilder.Par("ClassID", ClassID), ParamBuilder.Par("CourseID", CourseID));

        }

        public DataTable GetOccVenueDetailsForReportsDAL(long ClassID, long VenueID, DateTime StartDate, DateTime EndDate)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("Tran_Venue_GetVenueOccupancyReports");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@VenueID", VenueID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }



                //    return ExecuteDataSet("GetDataForVenueMatrix", ParamBuilder.Par("VenueID", VenueID)).Tables[0];

            }



            //   return ExecuteDataSet("Tran_Venue_GetVenueOccupancyReports", ParamBuilder.Par("ClassID", ClassID), ParamBuilder.Par("VenueID", VenueID), ParamBuilder.Par("StartDate", StartDate), ParamBuilder.Par("EndDate", EndDate));

        }
        public DataTable GetCertificateReportsDAL(string PersonId, long ClassID, long companyID, string Culture,long currentUser,long CertificateID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_OrganizationForCertificatePrintData");
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@PersonID", PersonId);
            cmd.Parameters.AddWithValue("@OrganizationID", companyID);
            cmd.Parameters.AddWithValue("@Culture", Culture);
            cmd.Parameters.AddWithValue("@CurrentUser", currentUser);
            cmd.Parameters.AddWithValue("@CertificateID", CertificateID);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }



                //    return ExecuteDataSet("GetDataForVenueMatrix", ParamBuilder.Par("VenueID", VenueID)).Tables[0];

            }



            //   return ExecuteDataSet("Tran_Venue_GetVenueOccupancyReports", ParamBuilder.Par("ClassID", ClassID), ParamBuilder.Par("VenueID", VenueID), ParamBuilder.Par("StartDate", StartDate), ParamBuilder.Par("EndDate", EndDate));

        }
        public DataTable GetDataForVenueMatrix(long VenueID)
        {

            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("GetDataForVenueMatrix");
            cmd.Parameters.AddWithValue("@VenueID", VenueID);
            // cmd.Parameters.AddWithValue("@CourseID", CourseID);
            //   cmd.Parameters.AddWithValue("@Station", comboBox1.SelectedItem.ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }



                //    return ExecuteDataSet("GetDataForVenueMatrix", ParamBuilder.Par("VenueID", VenueID)).Tables[0];

            }

        }    //Library.Entities.Common.Configuration.Venues.Venues GetByID(long ID)
             //{
             //    return 
             //}

        IList<Venues> IPersonDAL.GetByID(long ID)
        {
            //  return ExecuteListSp(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("ID", ID));
            var venue = ExecuteListSp<Venues>(@"Tran_Venue_GetByID", ParamBuilder.Par("ID", ID));
            return venue.ToList();
        }

        public Classes ClassGetByIDDAL(long CurrentClassID)
        {
            Classes Course = new Classes();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ID = CurrentClassID });
                Course = conn.Query<Classes>("TMS_Classes_GetByID", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<Classes>(); ;

                conn.Close();
            }
            return Course;
        }

        public DataTable AttendanceReportsDAL(long CourseID, long ClassID, DateTime startdate, DateTime enddate)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Attendances_GetReportData");
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@WeekStartDate", startdate);
            cmd.Parameters.AddWithValue("@WeekEndDate", enddate);

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable ClassFutureReportDAL(long CurrentCourseCategoryID, DateTime ClassReportStartDateFrom, DateTime ClassReportStartDateTo, int ClassTypeID, bool ShowFutureClasses,long CompanyId)
        {
            ShowFutureClasses = false;
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Courses_GetClassReportByCourseCategoryID");
            cmd.Parameters.AddWithValue("@CourseCategoryID", CurrentCourseCategoryID);
            cmd.Parameters.AddWithValue("@ClassTypeID", ClassTypeID);
            cmd.Parameters.AddWithValue("@DateFrom", ClassReportStartDateFrom);
            cmd.Parameters.AddWithValue("@DateTo", ClassReportStartDateTo);
            cmd.Parameters.AddWithValue("@ShowFutureClasses", ShowFutureClasses);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable DailyVenueUtalizationReportsDAL(DateTime Startday, DateTime Endday, long venueid)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Class_WeeklyUtilizationReport");
            cmd.Parameters.AddWithValue("@StartDate", Startday);
            cmd.Parameters.AddWithValue("@EndDate", Endday);
            cmd.Parameters.AddWithValue("@VenueID", venueid);


            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }
        public DataTable DailyVenueUtalizationReports2DAL(DateTime Startday, DateTime Endday, long venueid)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Class_WeeklyUtilizationReport2");
            cmd.Parameters.AddWithValue("@StartDate", Startday);
            cmd.Parameters.AddWithValue("@EndDate", Endday);
            cmd.Parameters.AddWithValue("@VenueID", venueid);


            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable DailyUtilizationReportDAL(DateTime day, int type,long companyID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Class_DailyUtilizationReport");
            cmd.Parameters.AddWithValue("@Date", day);
            cmd.Parameters.AddWithValue("@OrganizationID", companyID);
            cmd.Parameters.AddWithValue("@venuetype", type);



            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable GetCourseFromTimeSpanDAL(DateTime StartTime, DateTime EndTime)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Courses_GetCourseFromTimeSpan");
            cmd.Parameters.AddWithValue("@StartDate", StartTime);
            cmd.Parameters.AddWithValue("@EndDate", EndTime);



            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable GetTraineePeriodicDataDAL(DateTime StartDate, DateTime EndDate, long CourseID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Trainee_PeriodicReportData");
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);



            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable GetConductedCoursesDataDAL(DateTime StartDate, DateTime EndDate, long CourseID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Course_ConductedCourseReportData");
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);



            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public DataTable SessionsByCourseAndClassIDDAL(long? CourseID, long? ClassID, long CompanyID,DateTime startDate,DateTime EndDate)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;

            SqlCommand cmd = new SqlCommand("TMS_Session_GetByCourseAndClassID");

            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            cmd.Parameters.AddWithValue("@OrganizationID", CompanyID);
            cmd.Parameters.AddWithValue("@MonthstartDate", startDate);
            cmd.Parameters.AddWithValue("@MonthLastDate", EndDate);


            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }


            }
        }

        public List<CRMHowHeardMapping> ManageHowHeard_GetAllDAL(long PersonID)
        {
            List<CRMHowHeardMapping> Venue = new List<CRMHowHeardMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRMHowHeardMapping>("CRM_HowHeardPersonMapping_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRMHowHeardMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public List<CRM_ProspectHistory> AssigmentHistory_GetAllDAL(long PersonID)
        {
            List<CRM_ProspectHistory> Venue = new List<CRM_ProspectHistory>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_ProspectHistory>("CRM_ProspectAssogment_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_ProspectHistory>();
                conn.Close();
            }
            return Venue.ToList();
        }


        public List<CRM_EnrolmentHistory> EnrolmentHistory_GetAllDAL(long PersonID)
        {
            List<CRM_EnrolmentHistory> Venue = new List<CRM_EnrolmentHistory>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_EnrolmentHistory>("CRM_EnrolmentHistory_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_EnrolmentHistory>();
                conn.Close();
            }
            return Venue.ToList();
        }


        public long ManageHowHeard_CreateDAL(CRMHowHeardMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_HowHeardPersonMapping_Create", parameters,
                        ParamBuilder.Par("HowHeardID", _mapping.HowHeardID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }



        public List<CRM_UserMapping> ManageAssigned_GetAllDAL(long PersonID)
        {
            List<CRM_UserMapping> Venue = new List<CRM_UserMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_UserMapping>("CRM_UserPersonMapping_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_UserMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }


        public long ManageAssigned_UpdateDAL(Person _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_UserPersonMapping_Update",
                          //  ParamBuilder.Par("ID", _mapping.ID),
                          ParamBuilder.Par("PersonID", _mapping.ID),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                        ParamBuilder.Par("ClientStatus", _mapping.clientstatus),
                        ParamBuilder.Par("CreatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.UpdatedDate)
                        );
        }
        public long ManageAssigned_CreateDAL(Person _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_UserPersonMapping_Create", parameters,
                      ParamBuilder.Par("PersonID", _mapping.ID),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                        ParamBuilder.Par("ClientStatus", _mapping.CrmClientType),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedDate)
                        );
        }


        public long AssigementHistory_CreateDAL(Person _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_ProspectAssignmentHistory_Create", parameters,
                      ParamBuilder.Par("PersonID", _mapping.ID),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedDate)
                        );
        }

        public long Enrolment_CreateDAL(Person _person)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_ProspectEnrolmenttHistory_Create", parameters,
                      ParamBuilder.Par("PersonID", _person.ID),
                        ParamBuilder.Par("RoleName", _person.RoleName),
                        ParamBuilder.Par("CreatedBy", _person.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _person.CreatedDate)
                        );

        }
        public List<CRM_CourseCategoryMapping> ManageCategory_GetAllDAL(long PersonID)
        {
            List<CRM_CourseCategoryMapping> Venue = new List<CRM_CourseCategoryMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_CourseCategoryMapping>("CRM_CategoryPersonMapping_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_CourseCategoryMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long ManageCategory_CreateDAL(CRM_CourseCategoryMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_CategoryMapping_Create", parameters,
                        ParamBuilder.Par("CategoryID", _mapping.CategoryID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }

        public List<CRM_CourseMapping> ManageProposedCourses_GetAllDAL(long PersonID)
        {
            List<CRM_CourseMapping> Venue = new List<CRM_CourseMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_CourseMapping>("CRM_CoursePersonMapping_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_CourseMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long ManageProposedCourses_CreateDAL(CRM_CourseMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_CourseMapping_Create", parameters,
                        ParamBuilder.Par("CourseID", _mapping.CourseID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }

        public List<CRM_classPersonMapping> ManageScheduledClasses_GetAllDAL(long PersonID)
        {
            List<CRM_classPersonMapping> Venue = new List<CRM_classPersonMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_classPersonMapping>("CRM_ClassPersonMapping_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_classPersonMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long ManageScheduledClasses_CreateDAL(CRM_classPersonMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_ClassMapping_Create", parameters,
                        ParamBuilder.Par("ClassID", _mapping.ClassID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }

        public int ManageScheduledClasses_UpdateDAL(CRM_classPersonMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_ClassSchedule_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                          ParamBuilder.Par("ClassID", _mapping.ClassID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }
        public int ManageScheduledClasses_DublicationDAL(CRM_classPersonMapping _mapping)
        {
            return ExecuteScalarSPInt32("CRM_ClassMapping_Dublication",
                        ParamBuilder.Par("ClassID", _mapping.ClassID),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy));
                        //ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn)); 
        }
        public int ManageScheduledClasses_DeleteDAL(CRM_classPersonMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_ClassSchedule_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));


        }


        public int ManageProposedCourses_UpdateDAL(CRM_CourseMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_CourseMapping_Update",
                       ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("CourseID", _mapping.CourseID),
                       ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                       ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageProposedCourses_DeleteDAL(CRM_CourseMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_CourseMapping_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }




        public int ManageCategory_UpdateDAL(CRM_CourseCategoryMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_CourseCategoryPerson_Update",
                       ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("CategoryID", _mapping.CategoryID),
                       ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                       ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageCategory_DeleteDAL(CRM_CourseCategoryMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_CourseCategoryPerson_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageHowHeard_UpdateDAL(CRMHowHeardMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_HowHeard_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                          ParamBuilder.Par("HowHeardID", _mapping.HowHeardID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageHowHeard_DeleteDAL(CRMHowHeardMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_HowheardMapping_Delete",
                       ParamBuilder.Par("ID", _mapping.ID),
                       ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                       ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageAssigned_UpdateDAL(CRM_UserMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_UserMapping_Update",
                       ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("UserID", _mapping.UserID),
                       ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                       ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageAssigned_DeleteDAL(CRM_UserMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_UserMapping_Delete",
                         ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                         ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public List<CRM_CallManager> ManageRecordCall_GetAllDAL(long PersonID)
        {
            List<CRM_CallManager> Venue = new List<CRM_CallManager>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_CallManager>("CRM_CallManager_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_CallManager>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long ManageRecordCall_CreateDAL(CRM_CallManager _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_CallManager_Create", parameters,
                        ParamBuilder.Par("Notes", _mapping.Notes),
                        ParamBuilder.Par("CallType", _mapping.CallType),
                         ParamBuilder.Par("CallTime", _mapping.CallTime),
                         ParamBuilder.Par("AssignedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }

        public int ManageRecordCall_UpdateDAL(CRM_CallManager _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_CallManager_Update",
                       ParamBuilder.Par("ID", _mapping.ID),
                       ParamBuilder.Par("Notes", _mapping.Notes),
                        ParamBuilder.Par("CallType", _mapping.CallType),
                         ParamBuilder.Par("CallTime", _mapping.CallTime),
                         ParamBuilder.Par("AssignedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                       ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                       ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageRecordCall_DeleteDAL(CRM_CallManager _mapping)
        {

            return ExecuteScalarInt32Sp("CRM_CallManager_Delete",
                         ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                         ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public List<CRM_VisitHistory> ManageRecordVisit_GetAllDAL(long PersonID)
        {
            List<CRM_VisitHistory> Venue = new List<CRM_VisitHistory>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { PersonID = PersonID });
                Venue = conn.Query<CRM_VisitHistory>("CRM_VisitHistory_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CRM_VisitHistory>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long ManageRecordVisit_CreateDAL(CRM_VisitHistory _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_VisitManager_Create", parameters,
                        ParamBuilder.Par("Notes", _mapping.Notes),
                        ParamBuilder.Par("VisitType", _mapping.VisitType),
                         ParamBuilder.Par("VisitDateTime", _mapping.VisitDateTime),
                         ParamBuilder.Par("AssignedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                        ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _mapping.CreatedOn)
                        );
        }

        public int ManageRecordVisit_UpdateDAL(CRM_VisitHistory _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_VisitManager_Update",
                      ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("Notes", _mapping.Notes),
                        ParamBuilder.Par("VisitType", _mapping.VisitType),
                         ParamBuilder.Par("VisitDateTime", _mapping.VisitDateTime),
                         ParamBuilder.Par("AssignedBy", _mapping.UpdatedBy),
                        ParamBuilder.Par("AssignedTo", _mapping.AssignedTo),
                      ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                      ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int ManageRecordVisit_DeleteDAL(CRM_VisitHistory _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_VisitManager_Delete",
                         ParamBuilder.Par("ID", _mapping.ID),
                         ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),
                         ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn));
        }

        public int _PersonRoleCheckDAL(CRM_EnrolmentHistory _objPersonRoles)
        {
            return ExecuteScalarSPInt32("CRM_RoleCheck",
                        ParamBuilder.Par("PersonID", _objPersonRoles.PersonID)

                  );
        }

        public long Enrolment_CreateDAL(CRM_EnrolmentHistory _person)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_ProspectEnrolmenttHistory_Create", parameters,
                      ParamBuilder.Par("PersonID", _person.PersonID),
                        ParamBuilder.Par("RoleName", _person.RoleName),
                        ParamBuilder.Par("CreatedBy", _person.CreatedBy),
                        ParamBuilder.Par("CreatedOn", _person.CreatedOn)
                        );
        }
       public IList<DDlList> GetCourseFromTimeSpanDALDDL(DateTime startDate,DateTime endDate,long useri)
        {
            return ExecuteListSp<DDlList>("TMS_Courses_GetCourseFromTimeSpan", ParamBuilder.Par("StartDAte", startDate), ParamBuilder.Par("EndDate", endDate),ParamBuilder.Par("CreatedByID", useri));
        }
        public IList<DDlList> GetCourseFromTimeSpanListDAL(DateTime StartTime, DateTime EndTime)
        {
            return ExecuteListSp<DDlList>("TMS_Courses_GetCourseFromTimeSpan", ParamBuilder.Par("StartDAte", StartTime), ParamBuilder.Par("EndDate", EndTime));
        }

        public int ManageCourse_DuplicationCheckDAL(CRM_CourseMapping _mapping)
        {
            return ExecuteScalarSPInt32("CRMCourse_DuplicationCheck",
                      ParamBuilder.Par("PersonID", _mapping.PersonID),
                                  ParamBuilder.Par("CourseID", _mapping.CourseID));

        }
        public int ManageCourseCategory_DuplicationCheckDAL(CRM_CourseCategoryMapping _mapping)
        {
            return ExecuteScalarSPInt32("CRMCourseCategory_DuplicationCheck",
                      ParamBuilder.Par("PersonID", _mapping.PersonID),
                                  ParamBuilder.Par("CategoryID", _mapping.CategoryID));

        }
        public int ManageCourse_Assigned(long PID)
        {
            return ExecuteScalarSPInt32("CRM_Course_Assigned",
                      ParamBuilder.Par("PersonID", PID)
                                 );

        }
        public int ManageScheduleCourse_DuplicationCheckDAL(CRM_classPersonMapping _mapping)
        {
            return ExecuteScalarSPInt32("CRMClass_DuplicationCheck",
                     ParamBuilder.Par("PersonID", _mapping.PersonID),
                                 ParamBuilder.Par("ClassID", _mapping.ClassID));
        }
        public IList<T> ExecuteListSp<T>(string query, params DbParameter[] prms) where T : new()
        {
            IList<T> objectList = new List<T>();
            T obj = default(T);

            try
            {
                using (DbConnection connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (DbCommand command = Factory.CreateCommand())
                    {
                        command.CommandTimeout = 30;
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = query;

                        if (prms != null)
                        {
                            command.Parameters.AddRange(prms);
                        }

                        connection.Open();

                        using (DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    obj = new T();

                                    IDataMapper mapper = obj as IDataMapper;
                                    mapper.MapProperties(dataReader);

                                    objectList.Add(obj);
                                }
                            }

                            dataReader.Close();
                        }
                    }
                }
            }
            finally
            {
            }

            return objectList;
        }







        #endregion




    }
}