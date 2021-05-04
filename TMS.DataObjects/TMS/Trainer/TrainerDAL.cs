using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.TMS.Trainers;
using TMS.Library.TMS.Admin.Config;
using TMS.Library.TMS.Trainer;

namespace TMS.DataObjects.TMS
{
    public class TrainerDAL : DBGenerics, ITrainerDAL
    {

        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonDAL(Trainer _objTrainer, string clientType,long RoleID)
        {
            PersonResponse _Response = new PersonResponse();
            CustomGenerics.CustomGenerics _obj = new CustomGenerics.CustomGenerics();
            return _obj.InsertRecordTrainerReturnObject(_objTrainer, clientType,RoleID);
        }

        /// <summary>
        /// Persons the get alldal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Trainer> Trainer_GetALLDAL()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Trainer>(@"TMS_Trainer_GetAll", ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
            }
            return _PersonData;
        }

        public IList<Trainer> Trainer_GetAllDAL(string Culture,long RoleID, string oid,  string SearchText)
        {


            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();

            //    dbParam.AddDynamicParams(new { culture = Culture, RoleID = RoleID, oid = oid, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, FlagDateTime = date });
            //    using (var multi = conn.QueryMultiple("TMS_Trainer_GetByCulture", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        Person = multi.Read<Trainer>().AsList<Trainer>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();
            //        foreach (var single in Person)
            //        {
            //            if (single.FlagCount > 0)
            //            {
            //                single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));

            //                // single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
            //            }
            //        }
            //    }

            //    conn.Close();

            //}
            //return Person.ToList();
            //ParamBuilder.Par("StartRowIndex", StartRowIndex), ParamBuilder.Par("PageSize", PageSize), ParamBuilder.Par("SortExpression", SortExpression),
            List<Trainer> Person = new List<Trainer>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Trainer>("TMS_Trainer_GetByCulture", ParamBuilder.Par("@culture", Culture), ParamBuilder.Par("@RoleID", RoleID), ParamBuilder.Par("@oid", oid),  ParamBuilder.Par("SearchText", SearchText), ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
            }
            return _PersonData;
        }
       public IList<Trainer> DeletedPerson_GetAllDAL(string culture, long ID, string SearchText)
        {
            
                List<Trainer> Person = new List<Trainer>();
                var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
                var _PersonData = ExecuteListSp<Trainer>("TMS_DeletedPerson_GetbyCulture", ParamBuilder.Par("@culture", culture), ParamBuilder.Par("@ID", ID), ParamBuilder.Par("SearchText", SearchText), ParamBuilder.Par("FlagDateTime", date));
                foreach (var single in _PersonData)
                {
                    if (single.FlagCount > 0)
                    {
                        single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                    }
                    //  Person = _PersonData.Read<Trainer>().AsList<Trainer>();
                }
             
                return _PersonData;

            }
        
        public IList<Trainer> TrainerOrganization_GetAllDAL(ref int Total,string culture, long RoleID, string ID,  string SearchText,string SortExpression,int StartRowIndex,int page,int PageSize,long PersonID,bool jobFlage)
        {
            List<Trainer> _PersonData = new List<Trainer>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ID = ID, SearchText = SearchText, culture = culture, RoleID = RoleID, FlagDateTime=date, SortExpression=SortExpression, StartRowIndex= StartRowIndex,page=page,PageSize=PageSize,UserID=PersonID, jobFlage= jobFlage });
                using (var multi = conn.QueryMultiple("TMS_TrainerOrganization_GetByCulture", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _PersonData = multi.Read<Trainer>().AsList<Trainer>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }




            //var _PersonData = ExecuteListSp<Trainer>("TMS_TrainerOrganization_GetByCulture", ParamBuilder.Par("@culture", culture), ParamBuilder.Par("@RoleID", RoleID),
            //    ParamBuilder.Par("@ID", ID),  ParamBuilder.Par("SearchText", SearchText), ParamBuilder.Par("FlagDateTime", date), ParamBuilder.Par("SortExpression", SortExpression), ParamBuilder.Par("StartRowIndex", StartRowIndex), ParamBuilder.Par("Page", page), ParamBuilder.Par("PageSize", PageSize));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
              //  Person = _PersonData.Read<Trainer>().AsList<Trainer>();
            }
            //int   Total = _PersonData.Read<int>().FirstOrDefault<int>();
            return _PersonData.ToList();

            //List<Trainer> trainer = new List<Trainer>();
            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParams = new DynamicParameters();
            //    dbParams.AddDynamicParams(new { culture = culture, RoleID = RoleID, ID = ID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
            //    using (var _PersonData = conn.QueryMultiple("TMS_TrainerOrganization_GetByCulture", dbParams, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        foreach (var single in _PersonData)
            //        {
            //            if (single.FlagCount > 0)
            //            {
            //                single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
            //            }
            //        }

            //        trainer = _PersonData.Read<Trainer>().AsList<Trainer>();
            //        Total = _PersonData.Read<int>().FirstOrDefault<int>();

            //    }

            //    conn.Close();
            //}
            //return _PersonData.ToList();



            //List<Trainer> Person = new List<Trainer>();

            //using (var conn = new SqlConnection(DBHelper.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters dbParam = new DynamicParameters();
            //    var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();

            //    dbParam.AddDynamicParams(new { culture= culture, RoleID= RoleID, ID = ID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, FlagDateTime = date });
            //    using (var multi = conn.QueryMultiple("TMS_TrainerOrganization_GetByCulture", dbParam, commandType: System.Data.CommandType.StoredProcedure))
            //    {
            //        Person = multi.Read<Trainer>().AsList<Trainer>();
            //        if (!multi.IsConsumed)
            //            Total = multi.Read<int>().FirstOrDefault<int>();
            //        foreach (var single in Person)
            //        {
            //            if (single.FlagCount > 0)
            //            {
            //                single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
            //            }
            //        }
            //    }

            //    conn.Close();
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
            //return Person.ToList();

        //}

        /// <summary>
        /// Persons the update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Trainer_UpdateDAL(Trainer _objTrainer)
        {
            return ExecuteScalarInt32Sp("TMS_Trainer_Update",
                             ParamBuilder.Par("ID", _objTrainer.ID),
                            ParamBuilder.Par("SalutationID", _objTrainer.SalutationID),
                            ParamBuilder.Par("P_FirstName", _objTrainer.P_FirstName),
                            ParamBuilder.Par("P_LastName", _objTrainer.P_LastName),
                            ParamBuilder.Par("P_MiddleName", _objTrainer.P_MiddleName),
                            ParamBuilder.Par("P_DisplayName", _objTrainer.P_DisplayName),
                            ParamBuilder.Par("S_FirstName", _objTrainer.S_FirstName),
                            ParamBuilder.Par("S_LastName", _objTrainer.S_LastName),
                            ParamBuilder.Par("S_MiddleName", _objTrainer.S_MiddleName),
                            ParamBuilder.Par("S_DisplayName", _objTrainer.S_DisplayName),
                            ParamBuilder.Par("EngagementStatusId", _objTrainer.EngagementStatusId),
                            ParamBuilder.Par("OrganizationID", _objTrainer.OrganizationID),
                            ParamBuilder.Par("DepartmentID", _objTrainer.DepartmentID),
                            ParamBuilder.Par("Notes", _objTrainer.Notes),
                            ParamBuilder.Par("NationalIdentity", _objTrainer.NationalIdentity),
                            ParamBuilder.Par("OfficialIdentificationTypeID", _objTrainer.OfficialIdentificationTypeID),
                            ParamBuilder.Par("OfficialIDNumber", _objTrainer.OfficialIDNumber),
                            ParamBuilder.Par("DateOfBirth", _objTrainer.DateOfBirth),
                            ParamBuilder.Par("AvailabilityFrom", _objTrainer.AvailabilityFrom),
                            ParamBuilder.Par("AvailabilityTo", _objTrainer.AvailabilityTo),
                            ParamBuilder.Par("LoyaltyPoint", _objTrainer.LoyaltyPoint),
                            ParamBuilder.Par("LoyaltyPointRedeemed", _objTrainer.LoyaltyPointRedeemed),
                            ParamBuilder.Par("Designation", _objTrainer.Designation),
                            ParamBuilder.Par("Password", _objTrainer.Password),
                            ParamBuilder.Par("Gender", _objTrainer.Gender),
                            ParamBuilder.Par("Nationality", 0),
                            ParamBuilder.Par("Type", _objTrainer.Type),
                            ParamBuilder.Par("IsCoordinator", _objTrainer.IsCoordinator),
                            ParamBuilder.Par("Rating", _objTrainer.Rating),
                            ParamBuilder.Par("ClientType", _objTrainer.ClientType),
                            ParamBuilder.Par("UpdatedBy", _objTrainer.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _objTrainer.UpdatedDate),
                            ParamBuilder.Par("IsActive", _objTrainer.IsActive),
                            ParamBuilder.Par("UserID", _objTrainer.UserID),
                            ParamBuilder.Par("AdditionalComments", _objTrainer.AdditionalComments),
                            ParamBuilder.Par("IsOnline", _objTrainer.IsOnline),
                            ParamBuilder.Par("MaritalStatus", _objTrainer.MaritalStatus),
                            ParamBuilder.Par("VendorID", _objTrainer.VendorID),
                            ParamBuilder.Par("NickName", _objTrainer.NickName),
                            ParamBuilder.Par("Alias", _objTrainer.Alias)
                        );
        }

        /// <summary>
        /// Trainer the delete dal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>System.Int32.</returns>
        public int Trainer_DeleteDAL(Trainer _objTranier)
        {
            return ExecuteScalarSPInt32("TMS_Trainer_Delete",
                           ParamBuilder.Par("ID", _objTranier.ID),
                           ParamBuilder.Par("UpdatedBy", _objTranier.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objTranier.UpdatedDate));
        }

        /// <summary>
        /// Trainer Detail Card person dal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>Trainer.</returns>
        public Trainer Trainer_GetAllByIdDALdetailCard(string ID)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteSinglewithSP<Trainer>("TMS_Trainer_GetByID_CardDetail", ParamBuilder.Par("pid", ID), ParamBuilder.Par("FlagDateTime", date));
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
    }
}
