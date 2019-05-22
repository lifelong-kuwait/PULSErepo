using System;
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.TMS.Admin.Config;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.TMS.Prospect
{
    public class ProspectDAL : DBGenerics, IProspectDAL
    {
        /// <summary>
        /// Persons the get alldal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Person> Person_GetALLDAL()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Person>(@"TMS_Prospect_GetAll", ParamBuilder.Par("FlagDateTime", date));
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

        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType,long RoleID)
        {
            PersonResponse _Response = new PersonResponse();
            CustomGenerics.CustomGenerics _obj = new CustomGenerics.CustomGenerics();
            return _obj.InsertRecordPersonReturnObject(_objPerson, clientType,RoleID);
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
                            ParamBuilder.Par("IsActive", _objPerson.IsActive),
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
                           ParamBuilder.Par("ID", _objPerson.ID),
                           ParamBuilder.Par("UpdatedBy", _objPerson.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objPerson.UpdatedDate));
        }

        public PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType)
        {
            throw new NotImplementedException();
        }
    }
}
