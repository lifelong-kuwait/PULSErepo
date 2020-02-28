// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-14-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ClassDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.Language;
using TMS.Library.Entities.Common.Configuration;
using System;
using System.Data;

namespace TMS.DataObjects.TMS.Program
{
    /// <summary>
    /// Class ClassDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.IClassDAL" />
    public class ClassDAL : DBGenerics, IClassDAL
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
        public List<Classes> TMS_Classes_GetAllDAL(long CourseId,int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Classes> Course = new List<Classes>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CourseID= CourseId, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_Classes_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Classes>().AsList<Classes>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }
        
        /// <returns>List&lt;Classes&gt;.</returns>
        public IList<MapLanguage> TMS_Classes_GetAllDAL(long CourseId, string SearchText)
        {
            var _CourseLanguageData = ExecuteListSp<MapLanguage>(@"TMS_CourseLanguage_GetAll", ParamBuilder.Par("CourseID", CourseId),ParamBuilder.Par("SearchText", SearchText));

            return _CourseLanguageData;
        }

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
        public List<Classes> TMS_ClassesByOrganization_GetAllDAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<Classes> Course = new List<Classes>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CourseID = CourseId, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid });
                using (var multi = conn.QueryMultiple("TMS_Classes_GetAllByOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Classes>().AsList<Classes>();
                    //if (!multi.IsConsumed)
                    //    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }
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
        public List<Classes> TMS_ClassesAllByOrganization_GetAllDAL(long CourseId, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid, long PersonId)
        {
            List<Classes> Course = new List<Classes>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CourseID = CourseId, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid , PersonId = PersonId });
                using (var multi = conn.QueryMultiple("TMS_Classes_GetAllClassesByOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Classes>().AsList<Classes>();
                    //if (!multi.IsConsumed)
                    //    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }
        public List<PersonRoleGroup> personRoleGroupsDAL(long UserID)
        {
            List<PersonRoleGroup> Course = new List<PersonRoleGroup>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { PersonID = UserID });
                using (var multi = conn.QueryMultiple("TMS_PersonRolesAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<PersonRoleGroup>().AsList<PersonRoleGroup>();
                    //if (!multi.IsConsumed)
                    //    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }

        public IList<CourseLogisticRequirements> CourseLogistic_GetAllByOrgDAL(string Culture, long OrganizationID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<CourseLogisticRequirements> Person = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Culture = Culture, ClassID = ClassID, OrganizationID = OrganizationID });
                using (var multi = conn.QueryMultiple("TMS_CourseLogisticGetAllOrg", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<CourseLogisticRequirements>().AsList<CourseLogisticRequirements>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Person.ToList();
        }




        public List<Classes> TMS_TrainerClasses_GetAllDAL(long id, ref int Total)
        {
            List<Classes> Course = new List<Classes>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { TrainerID = id});
                using (var multi = conn.QueryMultiple("TMS_Trainer_GetAllTrainerClasses", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Classes>().AsList<Classes>();
                    Total = multi.Read<int>().FirstOrDefault<int>();

                }

                conn.Close();
            }
            return Course.ToList();
        }


        public List<Classes> TMS_TrainerClasses_GetByOrganizationIdDAL(long id, long CompnayID, ref int Total)
        {
            List<Classes> Course = new List<Classes>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { TrainerID = id, CompnayID=CompnayID });
                using (var multi = conn.QueryMultiple("TMS_Trainer_GetAllOrganizationTrainerClasses", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Classes>().AsList<Classes>();
                    Total = multi.Read<int>().FirstOrDefault<int>();

                }

                conn.Close();
            }
            return Course.ToList();
        }

        /// <summary>
        /// TMSs the classes get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Classes.</returns>
        public Classes TMS_Classes_GetByIdDAL(string ID)
        {
            Classes Course = new Classes();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ID = ID });
                Course = conn.Query<Classes>("TMS_Classes_GetByID", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<Classes>(); ;

                conn.Close();
            }
            return Course;
        }

        /// <summary>
        /// Gets the course detail by identifier for new class dal.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Count">The count.</param>
        /// <returns>Course.</returns>
        public Course GetCourseDetailByIdForNewClassDAL(string Id, ref int Count)
        {
            Course Course = new Course();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CourseID = Id });
                using (var multi = conn.QueryMultiple("TMS_Classes_GetDetailByCourseID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Course>().FirstOrDefault<Course>();
                    if (!multi.IsConsumed)
                        Count = multi.Read<int>().FirstOrDefault<int>();
                }
                conn.Close();
            }

            return Course;
        }

        /// <summary>
        /// TMSs the classes create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Classes_CreateDAL(Classes _Classes)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Classes_Create", parameters,
                            ParamBuilder.Par("PrimaryClassTitle", _Classes.PrimaryClassTitle),
                            ParamBuilder.Par("SecondaryClassTitle", _Classes.SecondaryClassTitle),
                            ParamBuilder.Par("ClassName", _Classes.ClassName),
                            ParamBuilder.Par("CourseID", _Classes.CourseID),
                            ParamBuilder.Par("LanguageID", _Classes.LanguageID),
                            ParamBuilder.Par("ClassTypeID", _Classes.ClassTypeID),
                            ParamBuilder.Par("OrganizationID", _Classes.OrganizationID),
                            ParamBuilder.Par("ClassDuration", _Classes.ClassDuration),
                            ParamBuilder.Par("ClassDurationType", _Classes.ClassDurationType),
                            ParamBuilder.Par("StartDate", _Classes.StartDate),
                            ParamBuilder.Par("EndDate", _Classes.EndDate),
                            ParamBuilder.Par("StartTime", _Classes.StartTime),
                            ParamBuilder.Par("EndTime", _Classes.EndTime),
                            ParamBuilder.Par("EvaluationLink", _Classes.EvaluationLink),
                            ParamBuilder.Par("FollowUp", _Classes.FollowUp),
                            ParamBuilder.Par("FollowUpCompleted", _Classes.FollowUpCompleted),
                            ParamBuilder.Par("MinimumAttendanceRequirement", _Classes.MinimumAttendanceRequirement),
                            ParamBuilder.Par("MaximumSessionPerDay", _Classes.MaximumSessionPerDay),
                            ParamBuilder.Par("MinimumTrainee", _Classes.MinimumTrainee),
                            ParamBuilder.Par("SendEmails", _Classes.SendEmails),
                            ParamBuilder.Par("ClassFee", _Classes.ClassFee),
                            ParamBuilder.Par("FeeCurrency", _Classes.FeeCurrency),
                            ParamBuilder.Par("Discount", _Classes.Discount),
                            ParamBuilder.Par("DefaultDiscount", _Classes.DefaultDiscount),
                            ParamBuilder.Par("TranslationRequiredID", _Classes.TranslationRequiredID),
                            ParamBuilder.Par("VendorID", _Classes.VendorID),
                            ParamBuilder.Par("CreatedBy", _Classes.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Classes.CreatedDate));
        }

        /// <summary>
        /// TMSs the classes create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_CourseLanguage_CreateDAL(MapLanguage _Corelanguage, long CourseId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseLanguage_Create", parameters,
                            ParamBuilder.Par("LanguageID",_Corelanguage.LanguageID),
                            ParamBuilder.Par("CourseID",CourseId),
                            ParamBuilder.Par("CreatedBy", _Corelanguage.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Corelanguage.CreatedDate));
        }

        /// <summary>
        /// TMSs the classes update dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Classes_UpdateDAL(Classes _Classes)
        {
            return ExecuteScalarInt32Sp("TMS_Classes_Update",
                        ParamBuilder.Par("ID", _Classes.ID),
                        ParamBuilder.Par("PrimaryClassTitle", _Classes.PrimaryClassTitle),
                        ParamBuilder.Par("SecondaryClassTitle", _Classes.SecondaryClassTitle),
                        ParamBuilder.Par("CourseID", _Classes.CourseID),
                        ParamBuilder.Par("LanguageID", _Classes.LanguageID),
                        ParamBuilder.Par("ClassTypeID", _Classes.ClassTypeID),
                        ParamBuilder.Par("ClassDuration", _Classes.ClassDuration),
                        ParamBuilder.Par("ClassDurationType", _Classes.ClassDurationType),
                        ParamBuilder.Par("StartDate", _Classes.StartDate),
                        ParamBuilder.Par("EndDate", _Classes.EndDate),
                        ParamBuilder.Par("StartTime", _Classes.StartTime),
                        ParamBuilder.Par("EndTime", _Classes.EndTime),
                        ParamBuilder.Par("EvaluationLink", _Classes.EvaluationLink),
                        ParamBuilder.Par("FollowUp", _Classes.FollowUp),
                        ParamBuilder.Par("FollowUpCompleted", _Classes.FollowUpCompleted),
                        ParamBuilder.Par("MinimumAttendanceRequirement", _Classes.MinimumAttendanceRequirement),
                        ParamBuilder.Par("MaximumSessionPerDay", _Classes.MaximumSessionPerDay),
                        ParamBuilder.Par("MinimumTrainee", _Classes.MinimumTrainee),
                        ParamBuilder.Par("SendEmails", _Classes.SendEmails),
                        ParamBuilder.Par("ClassFee", _Classes.ClassFee),
                        ParamBuilder.Par("FeeCurrency", _Classes.FeeCurrency),
                        ParamBuilder.Par("Discount", _Classes.Discount),
                        ParamBuilder.Par("DefaultDiscount", _Classes.DefaultDiscount),
                        ParamBuilder.Par("TranslationRequiredID", _Classes.TranslationRequiredID),
                        ParamBuilder.Par("VendorID", _Classes.VendorID),
                        ParamBuilder.Par("UpdatedBy", _Classes.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Classes.UpdatedDate)

            );
        }
        /// <summary>
        /// TMSs the classes update dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Classes_SessionCountDAL(long _ClassesID)
        {



            DataSet avd = ExecuteDataSetSP("ClassSessionCount",
                        ParamBuilder.Par("@ClassID", Convert.ToInt64(_ClassesID)));
            if(avd.Tables[0].Rows.Count <= 0)
            {
                return 0;
            }
            else
            {
                int i = Convert.ToInt32(avd.Tables[0].Rows[0]["maximum"]);
                return i;
            }
            
        }
        /// <summary>int TMS_Classes_SessionCountDAL(int _ClassesID);
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
            public int TMS_Classes_DeleteDAL(Classes _Classes)
        {
            return ExecuteScalarInt32Sp("TMS_Classes_Delete",
                        ParamBuilder.Par("ID", _Classes.ID),
                        ParamBuilder.Par("UpdatedBy", _Classes.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Classes.UpdatedDate)

            );
        }

        public int TMS_CourseLanguage_UpdateDAL(MapLanguage _Corelanguage, long CourseId)
        {
            return ExecuteScalarInt32Sp("TMS_CourseLanguage_Update",
                        ParamBuilder.Par("OldLanguageID", _Corelanguage.ID),
                        ParamBuilder.Par("NewLanguageID", _Corelanguage.LanguageID),
                        ParamBuilder.Par("CourseID", CourseId),
                        ParamBuilder.Par("ModifiedBy", _Corelanguage.ModifiedBy),
                        ParamBuilder.Par("ModifiedDate", _Corelanguage.ModifiedDate),
                        ParamBuilder.Par("MapperId", _Corelanguage.ID2)

            );
        }

        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_CourseLanguage_DeleteDAL(MapLanguage _Corelanguage, long CourseId)
        {
            return ExecuteScalarInt32Sp("TMS_CourseLanguage_Delete",
                        ParamBuilder.Par("ID", _Corelanguage.ID),
                        ParamBuilder.Par("CourseID",CourseId),
                        ParamBuilder.Par("UpdatedBy", _Corelanguage.ModifiedBy),
                        ParamBuilder.Par("UpdatedDate", _Corelanguage.ModifiedDate)

            );
        }

        #region "Class Trainee"

        /// <summary>
        /// Classes the trainee mapping get all dal.
        /// </summary>
        /// <param name="Culture">The culture.</param>
        /// <param name="ClassID">The class identifier.</param>
        /// <returns>IList&lt;ClassTraineeMapping&gt;.</returns>
        public IList<ClassTraineeMapping> ClassTraineeMapping_GetAllDAL(string Culture, long ClassID)
        {
            List<ClassTraineeMapping> LoginUserList = new List<ClassTraineeMapping>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_ClassTraineeMapping_GetAll";
                DynamicParameters param = new DynamicParameters(new { Culture = Culture, ClassID = ClassID });
                var ClassTraineeMappingDictionary = new Dictionary<long, ClassTraineeMapping>();
                LoginUserList = conn.Query<ClassTraineeMapping, Person, ClassTraineeMapping>(
                       qry, (loginUsers, person) =>
                       {
                           ClassTraineeMapping ClassTraineeMappingEntry;
                           if (!ClassTraineeMappingDictionary.TryGetValue(loginUsers.ID, out ClassTraineeMappingEntry))
                           {
                               ClassTraineeMappingEntry = loginUsers;
                               ClassTraineeMappingEntry.Person = new Person();
                               ClassTraineeMappingDictionary.Add(ClassTraineeMappingEntry.ID, ClassTraineeMappingEntry);
                           }
                           if (person != null)
                               ClassTraineeMappingEntry.Person = person;
                           return ClassTraineeMappingEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "PersonID")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }

        
        public IList<ClassTraineeMapping> ClassTraineeMapping_GetAllDALOrganization(string Culture, long ClassID,long OrganizationID)
        {
            List<ClassTraineeMapping> LoginUserList = new List<ClassTraineeMapping>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_ClassTraineeMapping_GetAllOrganization";
                DynamicParameters param = new DynamicParameters(new { Culture = Culture, ClassID = ClassID , OrganizationID = OrganizationID });
                var ClassTraineeMappingDictionary = new Dictionary<long, ClassTraineeMapping>();
                LoginUserList = conn.Query<ClassTraineeMapping, Person, ClassTraineeMapping>(
                       qry, (loginUsers, person) =>
                       {
                           ClassTraineeMapping ClassTraineeMappingEntry;
                           if (!ClassTraineeMappingDictionary.TryGetValue(loginUsers.ID, out ClassTraineeMappingEntry))
                           {
                               ClassTraineeMappingEntry = loginUsers;
                               ClassTraineeMappingEntry.Person = new Person();
                               ClassTraineeMappingDictionary.Add(ClassTraineeMappingEntry.ID, ClassTraineeMappingEntry);
                           }
                           if (person != null)
                               ClassTraineeMappingEntry.Person = person;
                           return ClassTraineeMappingEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "PersonID")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }
        public IList<ClassTraineeMappingCertificatePrint> ClassTraineeMappingCertificate_GetAllBALOrganizationDAL(string Culture, long ClassID, long OrganizationID,long CertificateID)
        {
            List<ClassTraineeMappingCertificatePrint> LoginUserList = new List<ClassTraineeMappingCertificatePrint>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_ClassTraineeMapping_GetAllOrganizationForCertificatePrint";
                DynamicParameters param = new DynamicParameters(new { Culture = Culture, ClassID = ClassID, OrganizationID = OrganizationID, CertificateID= CertificateID });
                var ClassTraineeMappingDictionary = new Dictionary<long, ClassTraineeMappingCertificatePrint>();
                LoginUserList = conn.Query<ClassTraineeMappingCertificatePrint, Person, ClassTraineeMappingCertificatePrint>(
                       qry, (loginUsers, person) =>
                       {
                           ClassTraineeMappingCertificatePrint ClassTraineeMappingEntry;
                           if (!ClassTraineeMappingDictionary.TryGetValue(loginUsers.ID, out ClassTraineeMappingEntry))
                           {
                               ClassTraineeMappingEntry = loginUsers;
                               ClassTraineeMappingEntry.Person = new Person();
                               ClassTraineeMappingDictionary.Add(ClassTraineeMappingEntry.ID, ClassTraineeMappingEntry);
                           }
                           if (person != null)
                               ClassTraineeMappingEntry.Person = person;
                           return ClassTraineeMappingEntry;
                       }, param, commandType: System.Data.CommandType.StoredProcedure,
                       splitOn: "PersonID")
                   .Distinct()
                   .ToList();
                conn.Close();
            }
            return LoginUserList;
            // ExecuteListSp<LoginUsers>("TMS_Users_GetAll");
        }

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
        public IList<Person> ClassTrainee_GetAllByClassIDForCreatingDAL(string Culture, long ClassID,int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText , Culture = Culture, ClassID = ClassID });
                using (var multi = conn.QueryMultiple("TMS_ClassTraineeMapping_GetAllByClassIDForCreating", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Person.ToList();
        }

        /// <summary>
        /// TMSs the class trainee mapping create dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        /// 
        public IList<Person> ClassTrainee_GetAllByClassIDForCreatingDALOrganization(string Culture, long OrganizationID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Culture = Culture, ClassID = ClassID, OrganizationID= OrganizationID });
                using (var multi = conn.QueryMultiple("TMS_ClassTraineeMapping_GetAllByClassIDForCreatingOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Person.ToList();
        }
        public IList<ClassTraineeRulesVerify> TMS_ClassTraineeMapping_BussinesRuleVerifyDAL(string _Classes, string PersonId, long organizationId)
        {
            List<ClassTraineeRulesVerify> Person = new List<ClassTraineeRulesVerify>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ClassID = _Classes, PersonID = PersonId, OrganizationID = organizationId });
                using (var multi = conn.QueryMultiple("TMS_Session_TraineeAvailabilityVerifyByPersonAndClass", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<ClassTraineeRulesVerify>().AsList<ClassTraineeRulesVerify>(); 
                }
                conn.Close();
            }
            return Person.ToList();
        }


        public long TMS_ClassTraineeMapping_CreateDAL(ClassTraineeMapping _Classes, string PersonIds)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_ClassTraineeMapping_Create", parameters,
                            ParamBuilder.Par("ClassID", _Classes.ClassID),
                            ParamBuilder.Par("PersonID", PersonIds),
                            ParamBuilder.Par("CreatedBy", _Classes.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Classes.CreatedDate));
        }

        /// <summary>
        /// TMSs the class trainee mapping delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_ClassTraineeMapping_DeleteDAL(ClassTraineeMapping _Classes)
        {
            return ExecuteScalarInt32Sp("TMS_ClassTraineeMapping_Delete",
                        ParamBuilder.Par("ID", _Classes.ID),
                        ParamBuilder.Par("UpdatedBy", _Classes.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Classes.UpdatedDate)

            );
        }

        #endregion "Class Trainee"


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
        public IList<Person> TrainerGetAllExceptClassTrainerDAL(string Culture, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Culture = Culture, ClassID = ClassID });
                using (var multi = conn.QueryMultiple("TrainerGetAllExceptClassTrainer_ClassID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Person.ToList();
        }



        public IList<Person> TrainerGetAllOrganizationExceptClassTrainerDAL(string Culture,long CompnayID, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Person> Person = new List<Person>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Culture = Culture, CompnayID= CompnayID, ClassID = ClassID });
                using (var multi = conn.QueryMultiple("TrainerGetAllOrganizationExceptClassTrainer_ClassID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Person = multi.Read<Person>().AsList<Person>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Person.ToList();
        }


        /// <summary>
        /// Trainers the open mapping create by person ids dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <param name="PersonIds">The person ids.</param>
        /// <returns>System.Int64.</returns>
        public long TrainerOpenMapping_CreateByPersonIdsDAL(ClassTrainerMapping _Classes, string PersonIds)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TrainerOpenMapping_CreateByPersonIds", parameters,
                            ParamBuilder.Par("OpenId", _Classes.ClassID),
                            ParamBuilder.Par("PersonID", PersonIds),
                            ParamBuilder.Par("CreatedBy", _Classes.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Classes.CreatedDate));
        }

        #region Class Logistics

        public IList<CourseLogisticRequirements> TMS_ClassLogisticsDLL_GetAllDAL(string culture, long CompanyID, long ClassID)
        {
            List<CourseLogisticRequirements> LoginUserAddGroups = new List<CourseLogisticRequirements>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_ClassLogisticDLL_GetAllByCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                param.Add("@OrganizationID", CompanyID);
                param.Add("@ClassID", ClassID);
                LoginUserAddGroups = conn.Query<CourseLogisticRequirements>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<CourseLogisticRequirements>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }

        public List<CourseLogisticRequirements> TMS_ClassLogistics_GetAllDAL(long ClassID)
        {
            //var _CourseLanguageData = ExecuteListSp<CourseLogisticRequirements>(@"TMS_ClassLogistic_GetAll", ParamBuilder.Par("CourseID", ClassID));

            //return _CourseLanguageData;

            List<CourseLogisticRequirements> Venue = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { CourseID = ClassID});
                Venue = conn.Query<CourseLogisticRequirements>("TMS_ClassLogistic_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseLogisticRequirements>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long TMS_ClassLogistics_CreateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_ClassLogistic_Create", parameters,
                            ParamBuilder.Par("LogisticID", _Logistics.ID),
                            ParamBuilder.Par("ClassID", ClassID),
                            ParamBuilder.Par("CreatedBy", _Logistics.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Logistics.CreatedDate));
        }

        public int TMS_ClassLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return ExecuteScalarInt32Sp("TMS_ClassLogistic_Update",
                        ParamBuilder.Par("ID", _Logistics.ID),
                        ParamBuilder.Par("LogisticsID", _Logistics.ID),
                        ParamBuilder.Par("ClassID", ClassID),
                        ParamBuilder.Par("ModifiedBy", _Logistics.UpdatedBy),
                        ParamBuilder.Par("ModifiedDate", _Logistics.UpdatedDate)

            );
        }

        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_ClassLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return ExecuteScalarInt32Sp("TMS_ClassLogistics_Delete",
                        ParamBuilder.Par("ID", _Logistics.ID),
                        ParamBuilder.Par("ClassID", ClassID),
                        ParamBuilder.Par("UpdatedBy", _Logistics.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Logistics.UpdatedDate)

            );
        }

        #endregion

        #region Session Logistics

        public IList<CourseLogisticRequirements> TMS_SessionLogisticsDLL_GetAllDAL(string culture)
        {
            List<CourseLogisticRequirements> LoginUserAddGroups = new List<CourseLogisticRequirements>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_ClassLogisticDLL_GetAllByCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                LoginUserAddGroups = conn.Query<CourseLogisticRequirements>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<CourseLogisticRequirements>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }

        public List<CourseLogisticRequirements> TMS_SessionLogistics_GetAllDAL(long ClassID)
        {
            //var _CourseLanguageData = ExecuteListSp<CourseLogisticRequirements>(@"TMS_ClassLogistic_GetAll", ParamBuilder.Par("CourseID", ClassID));

            //return _CourseLanguageData;

            List<CourseLogisticRequirements> Venue = new List<CourseLogisticRequirements>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { CourseID = 20009 });
                Venue = conn.Query<CourseLogisticRequirements>("TMS_SessionLogistic_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<CourseLogisticRequirements>();
                conn.Close();
            }
            return Venue.ToList();
        }

        public long TMS_SessionLogistics_CreateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_SessionLogistic_Create", parameters,
                            ParamBuilder.Par("LogisticID", _Logistics.ID),
                            ParamBuilder.Par("ClassID", 20009),
                            ParamBuilder.Par("CreatedBy", _Logistics.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Logistics.CreatedDate));
        }

        public int TMS_SessionLogistics_UpdateDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return ExecuteScalarInt32Sp("TMS_SessionLogistic_Update",
                        ParamBuilder.Par("ID", _Logistics.ID),
                        ParamBuilder.Par("LogisticsID", _Logistics.ID),
                        ParamBuilder.Par("ClassID", 20009),
                        ParamBuilder.Par("ModifiedBy", _Logistics.UpdatedBy),
                        ParamBuilder.Par("ModifiedDate", _Logistics.UpdatedDate)

            );
        }

        /// <summary>
        /// TMSs the classes delete dal.
        /// </summary>
        /// <param name="_Classes">The classes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_SessionLogistics_DeleteDAL(CourseLogisticRequirements _Logistics, long ClassID)
        {
            return ExecuteScalarInt32Sp("TMS_SessionLogistics_Delete",
                        ParamBuilder.Par("ID", _Logistics.ID),
                        ParamBuilder.Par("ClassID", 20009),
                        ParamBuilder.Par("UpdatedBy", _Logistics.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Logistics.UpdatedDate)

            );
        }

        #endregion
    }
}