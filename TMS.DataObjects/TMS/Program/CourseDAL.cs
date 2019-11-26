// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 11-05-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="CourseDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Coordinator;
using TMS.Library.Entities.TMS.Course;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.TMS
{
    /// <summary>
    /// Class CourseDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.ICourseDAL" />
    public class CourseDAL : DBGenerics, ICourseDAL
    {
        /// <summary>
        /// TMSs the courses get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public List<Course> TMS_Courses_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Course> Course = new List<Course>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_Courses_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Course>().AsList<Course>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }

        /// <summary>
        /// TMSs the courses get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public List<Course> TMS_CoursesByOrganization_GetAllDAL(int page,int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid,long PersonID)
        {
            List<Course> Course = new List<Course>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid,Page= page ,PersonId= PersonID });
                using (var multi = conn.QueryMultiple("TMS_CoursesByOrganization_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Course>().AsList<Course>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
        }
        /// <summary>
        /// TMSs the courses get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public long TMS_CoursesDeleteCheckDAL(string CourseId, string Oid)
        {
            var parameters = new[] { ParamBuilder.Par("Count", 0) };
            return ExecuteInt64withOutPutparameterSp("Course_Delete_Cheque", parameters,
                    ParamBuilder.Par("CourseID", CourseId),
                     ParamBuilder.Par("OID", Oid)
                    );
        }

        /// <summary>
        /// TMSs the courses get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        public Course TMS_Courses_GetByIdDAL(string ID)
        {
            Course Course = new Course();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ID = ID });
                Course = conn.Query<Course>("TMS_Courses_GetById", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<Course>(); ;

                conn.Close();
            }
            return Course;
        }
        /// <summary>
        /// TMSs the courses get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        public List<CourseDataBar> CourseDataBarDAL(DateTime startdate, DateTime lastdate, long CompanyId)
        {
            var _PersonData = ExecuteListSp<CourseDataBar>("CourseBarData", ParamBuilder.Par("monthstart", startdate), ParamBuilder.Par("monthEndDate", lastdate), ParamBuilder.Par("CompanyId", CompanyId));
            return _PersonData.ToList();
        }
        /// <summary>
        /// TMSs the courses get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        public List<CourseDataBar> CourseFutureDataBarDAL(DateTime startdate, DateTime lastdate, long CompanyId)
        {
            var _PersonData = ExecuteListSp<CourseDataBar>("CourseFutureBarData", ParamBuilder.Par("monthstart", startdate), ParamBuilder.Par("monthEndDate", lastdate), ParamBuilder.Par("CompanyId", CompanyId));
            return _PersonData.ToList();
        }
        /// <summary>
        /// TMSs the courses get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        public List<CourseDataBar> ClassFutureDataBarDAL(DateTime startdate, DateTime lastdate, long CompanyId)
        {
            var _PersonData = ExecuteListSp<CourseDataBar>("ClasseFutureBarData", ParamBuilder.Par("monthstart", startdate), ParamBuilder.Par("monthEndDate", lastdate), ParamBuilder.Par("CompanyId", CompanyId));
            return _PersonData.ToList();
        }
        /// <summary>
        /// Courses the category code by course identifier dal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        public string CourseCategoryCodeByCourseIdDAL(long id)
        {
            var code = "";
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Id = id });
                code = conn.ExecuteScalar<string>("SELECT Code FROM dbo.TMS_Categories WHERE ID=@Id", dbParam);

                conn.Close();
            }
            return code;
        }

        /// <summary>
        /// TMSs the courses create dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Courses_CreateDAL(Course _Course)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Courses_Create", parameters,
                                    ParamBuilder.Par("PrimaryName", _Course.PrimaryName),
                                    ParamBuilder.Par("SecondaryName", _Course.SecondaryName),
                                    ParamBuilder.Par("CourseCategoryId", _Course.CourseCategoryId),
                                    ParamBuilder.Par("CourseDuration", _Course.CourseDuration),
                                    ParamBuilder.Par("CourseDurationType", _Course.CourseDurationType),
                                    ParamBuilder.Par("CourseVendorID", _Course.CourseVendorID),
                                    ParamBuilder.Par("OrganizationID", _Course.OrganizationID),
                                    ParamBuilder.Par("Rating", _Course.Rating),
                                    ParamBuilder.Par("Notes", _Course.Notes),
                                    ParamBuilder.Par("MinimumAttendanceRequirement", _Course.MinimumAttendanceRequirement),
                                    ParamBuilder.Par("MinimumTrainee", _Course.MinimumTrainee),
                                    ParamBuilder.Par("CourseFee", _Course.CourseFee),
                                    ParamBuilder.Par("FeeCurrency", _Course.FeeCurrency),
                                    ParamBuilder.Par("CourseCode", _Course.CourseCode),
                                    ParamBuilder.Par("SalesCommission", _Course.SalesCommission),
                                    ParamBuilder.Par("PreRequisites", _Course.PreRequisites),
                                    ParamBuilder.Par("FeedbackFormID", _Course.FeedbackFormID),
                                    ParamBuilder.Par("CreatedBy", _Course.CreatedBy),
                                    ParamBuilder.Par("CreatedDate", _Course.CreatedDate),
                                    ParamBuilder.Par("IsActive", _Course.IsActive));
        }

        /// <summary>
        /// TMSs the courses update dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Courses_UpdateDAL(Course _Course)
        {
            return ExecuteScalarInt32Sp("TMS_Courses_Update",
                        ParamBuilder.Par("ID", _Course.ID),
                        ParamBuilder.Par("PrimaryName", _Course.PrimaryName),
                        ParamBuilder.Par("SecondaryName", _Course.SecondaryName),
                        ParamBuilder.Par("CourseCategoryId", _Course.CourseCategoryId),
                        ParamBuilder.Par("CourseDuration", _Course.CourseDuration),
                        ParamBuilder.Par("CourseDurationType", _Course.CourseDurationType),
                        ParamBuilder.Par("CourseVendorID", _Course.CourseVendorID),
                        ParamBuilder.Par("Rating", _Course.Rating),
                        ParamBuilder.Par("Notes", _Course.Notes),
                        ParamBuilder.Par("MinimumAttendanceRequirement", _Course.MinimumAttendanceRequirement),
                        ParamBuilder.Par("MinimumTrainee", _Course.MinimumTrainee),
                        ParamBuilder.Par("CourseFee", _Course.CourseFee),
                        ParamBuilder.Par("FeeCurrency", _Course.FeeCurrency),
                        ParamBuilder.Par("CourseCode", _Course.CourseCode),
                        ParamBuilder.Par("SalesCommission", _Course.SalesCommission),
                        ParamBuilder.Par("PreRequisites", _Course.PreRequisites),
                        ParamBuilder.Par("FeedbackFormID", _Course.FeedbackFormID),
                        ParamBuilder.Par("UpdatedBy", _Course.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Course.UpdatedDate),
                        ParamBuilder.Par("IsActive", _Course.IsActive)

            );
        }
        /// <summary>
        /// TMSs the courses Dublicate primary name check.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Courses_Dublicate_PrimaryNameDAL(Course _Course)
        {
            return ExecuteScalarSPInt32("TMS_Courses_Dublication_Primary_Name",
                        ParamBuilder.Par("UserID", _Course.CreatedBy),
                        ParamBuilder.Par("CousrseFirstName", _Course.PrimaryName)
            );
        }
        /// <summary>
        /// TMSs the courses delete dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Courses_DeleteDAL(Course _Course)
        {
            return ExecuteScalarInt32Sp("TMS_Courses_Delete",
                        ParamBuilder.Par("ID", _Course.ID),
                        ParamBuilder.Par("UpdatedBy", _Course.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Course.UpdatedDate)

            );
        }

        public int class_CheckDAL(Course _Course,long CompanyID)
        {
            return ExecuteScalarInt32Sp("TMS_Courses_DeleteCheck",
                        ParamBuilder.Par("ID", _Course.ID),
                        ParamBuilder.Par("OrganizationID", CompanyID)

            );
        }

        public int Session_CheckBAL(Sessions _Course, long CompanyID)
        {
            return ExecuteScalarInt32Sp("TMS_Session_DeleteCheck",
                        ParamBuilder.Par("ID", _Course.ID),
                         ParamBuilder.Par("MyCount", 0)

            );
        }
        public IList<Sessions> TMS_SessionAttendance_GetAllDAL(Sessions _Course)
        {
            List<Sessions> Course = new List<Sessions>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Session_Attandance_DeleteCheck";
                DynamicParameters param = new DynamicParameters();

                param.Add("@ID", _Course.ID);
                Course = conn.Query<Sessions>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Sessions>();
                conn.Close();
            }
            return Course;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }
        public IList<Sessions> TMS_SessionAttendance_GetAllByIDDAL(int _Course)
        {
            List<Sessions> Course = new List<Sessions>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_Session_Attandance_DeleteCheck";
                DynamicParameters param = new DynamicParameters();

                param.Add("@ID", _Course);
                Course = conn.Query<Sessions>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<Sessions>();
                conn.Close();
            }
            return Course;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }
        //  int Session_CheckBAL(Sessions _Course, long CompanyID);
        #region Course Coordinator
        public IList<CourseCoordinatorMapping> TMS_CourseCoordinator_GetAllDAL(long CourseID)
        {
            List<CourseCoordinatorMapping> Course = new List<CourseCoordinatorMapping>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_CourseCoordinator_GetAll";
                DynamicParameters param = new DynamicParameters();
             
                param.Add("@CourseID", CourseID);
                Course = conn.Query<CourseCoordinatorMapping>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<CourseCoordinatorMapping>();
                conn.Close();
            }
            return Course;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }

        //public List<CourseCoordinate> CourseCoordinatorMapping(long CourseID)
        //{
        //    List<CourseCoordinate> Course = new List<CourseCoordinate>();
        //    using (var conn = new SqlConnection(DBHelper.ConnectionString))
        //    {
        //        conn.Open();
        //        DynamicParameters dbParams = new DynamicParameters();
        //        dbParams.AddDynamicParams(new { CourseID = CourseID });
        //        using (var multi = conn.QueryMultiple("TMS_CourseCoordinator_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
        //        {
        //            Course = multi.Read<CourseCoordinate>().AsList<CourseCoordinate>();
        //          //  Total = multi.Read<int>().FirstOrDefault<int>();
        //        }

        //        conn.Close();
        //    }
        //    return Course.ToList();
        //}


        /// <returns>List&lt;Classes&gt;.</returns>
        //public IList<CourseCoordinatorMapping> TMS_CourseCoordinator_GetAllDAL(long CourseId)
        //{
        //    //var _CourseLanguageData = ExecuteListSp<CourseCoordinatorMapping>(@"TMS_CourseCoordinator_GetAll", ParamBuilder.Par("CourseID", CourseId));

        //    //return _CourseLanguageData;

        //    //List<CourseCoordinatorMapping> LoginUserList = new List<CourseCoordinatorMapping>();
        //    //var conString = DBHelper.ConnectionString;
        //    //using (var conn = new SqlConnection(conString))
        //    //{
        //    //    conn.Open();
        //    //    string qry = @"TMS_CourseCoordinator_GetAll";
        //    //    DynamicParameters param = new DynamicParameters(new { CourseID = CourseId });
        //    //    var ClassTraineeMappingDictionary = new Dictionary<long, CourseCoordinatorMapping>();
        //    //    LoginUserList = conn.Query<CourseCoordinatorMapping, Person, CourseCoordinatorMapping>(
        //    //           qry, (loginUsers, person) =>
        //    //           {
        //    //               CourseCoordinatorMapping ClassTraineeMappingEntry;
        //    //               if (!ClassTraineeMappingDictionary.TryGetValue(loginUsers.ID, out ClassTraineeMappingEntry))
        //    //               {
        //    //                   ClassTraineeMappingEntry = loginUsers;
        //    //                   ClassTraineeMappingEntry.Person = new List<Person>();
        //    //                   ClassTraineeMappingDictionary.Add(ClassTraineeMappingEntry.ID, ClassTraineeMappingEntry);
        //    //               }
        //    //               if (person != null)
        //    //                   ClassTraineeMappingEntry.Person.Add(person);
        //    //               return ClassTraineeMappingEntry;
        //    //           }, param, commandType: System.Data.CommandType.StoredProcedure,
        //    //           splitOn: "CoordinateIDs")
        //    //       .Distinct()
        //    //       .ToList();
        //    //    conn.Close();
        //    //}
        //    //LoginUserList.FirstOrDefault().DisplayName = LoginUserList.FirstOrDefault().Person.FirstOrDefault().P_DisplayName;
        //    //return LoginUserList;


        //    List<CourseCoordinatorMapping> LoginUserList = new List<CourseCoordinatorMapping>();
        //    var conString = DBHelper.ConnectionString;
        //    using (var conn = new SqlConnection(conString))
        //    {
        //        conn.Open();
        //        string qry = @"TMS_CourseCoordinator_GetAll";
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@CourseID", CourseId);
        //        var LoginUsersDictionary = new Dictionary<long, CourseCoordinatorMapping>();
        //        LoginUserList = conn.Query<CourseCoordinatorMapping, Person, CourseCoordinatorMapping>(
        //               qry, (loginUsers, Groups) =>
        //               {
        //                   CourseCoordinatorMapping loginUsersEntry;
        //                   if (!LoginUsersDictionary.TryGetValue(loginUsers.ID, out loginUsersEntry))
        //                   {
        //                       loginUsersEntry = loginUsers;
        //                       loginUsersEntry.Person = new List<Person>();
        //                       LoginUsersDictionary.Add(loginUsersEntry.ID, loginUsersEntry);
        //                   }
        //                   if (Groups != null)
        //                       loginUsersEntry.Person.Add(Groups);
        //                   return loginUsersEntry;
        //               }, param, commandType: System.Data.CommandType.StoredProcedure,
        //               splitOn: "ID")
        //           .Distinct()
        //           .ToList();
        //        conn.Close();
        //    }
        //    LoginUserList.FirstOrDefault().DisplayName = LoginUserList.FirstOrDefault().Person.FirstOrDefault().P_DisplayName;
        //    return LoginUserList;
        //}

        public long TMS_CourseCoordinate_CreateDAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseCoordinator_Create", parameters,
                            ParamBuilder.Par("CoordinateID", _Coordinate.CoordinateID),
                            ParamBuilder.Par("CourseID", CourseId),
                            ParamBuilder.Par("CreatedBy", _Coordinate.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Coordinate.CreatedDate));
        }

        public int TMS_CourseCoordinate_UpdateDAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            
            return ExecuteScalarInt32Sp("TMS_CourseCoordinator_Update",
                            ParamBuilder.Par("ID",_Coordinate.ID),
                             ParamBuilder.Par("CID", _Coordinate.CID),
                            ParamBuilder.Par("CoordinateID", _Coordinate.CoordinateID),
                            ParamBuilder.Par("CourseID", _Coordinate.CourseID),
                            ParamBuilder.Par("ModifiedBy", _Coordinate.ModifiedBy),
                            ParamBuilder.Par("ModifiedDate", _Coordinate.ModifiedDate));
        }

        public int TMS_CourseCoordinate_DeleteDAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            return ExecuteScalarInt32Sp("TMS_CourseCoordinator_Delete",
                        ParamBuilder.Par("ID", _Coordinate.ID),
                        ParamBuilder.Par("CourseID", CourseId),
                        ParamBuilder.Par("UpdatedBy", _Coordinate.ModifiedBy),
                        ParamBuilder.Par("UpdatedDate", _Coordinate.ModifiedDate)

            );
        }

        #endregion

        #region Course Focus Area

        public IList<FocusAreas> TMS_FocusAreaDLL_GetAllDAL(string culture,long CompanyID)
        {
            List<FocusAreas> LoginUserAddGroups = new List<FocusAreas>();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_FocusAreaDLL_GetAllByCulture";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Culture", culture);
                param.Add("@OrganizationID", CompanyID);
                LoginUserAddGroups = conn.Query<FocusAreas>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).AsList<FocusAreas>();
                conn.Close();
            }
            return LoginUserAddGroups;// ExecuteListSp<LoginUserAddGroups>("TMS_Groups_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));

        }

        /// <returns>List&lt;Classes&gt;.</returns>
        public IList<FocusAreas> TMS_CourseFocusArea_GetAllDAL(long CourseId)
        {
            var _CourseLanguageData = ExecuteListSp<FocusAreas>(@"TMS_CourseFocusArea_GetAll", ParamBuilder.Par("CourseID", CourseId));

            return _CourseLanguageData;
        }

        public long TMS_CourseFocusArea_CreateDAL(FocusAreas _Coordinate, long CourseId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_CourseFocus_Create", parameters,
                            ParamBuilder.Par("FocusID", _Coordinate.ID),
                            ParamBuilder.Par("CourseID", CourseId),
                            ParamBuilder.Par("CreatedBy", _Coordinate.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Coordinate.CreatedDate));
        }

        public int TMS_CourseFocusArea_UpdateDAL(FocusAreas _Coordinate, long CourseId)
        {

            return ExecuteScalarInt32Sp("TMS_CourseFocusArea_Update",
                            ParamBuilder.Par("FocusID", _Coordinate.ID),
                            ParamBuilder.Par("OldID", _Coordinate.OLdID),
                            ParamBuilder.Par("CourseID", CourseId),
                            ParamBuilder.Par("ModifiedBy", _Coordinate.UpdatedBy),
                            ParamBuilder.Par("ModifiedDate", _Coordinate.UpdatedDate));
        }

        public int TMS_CourseFocusArea_DeleteDAL(FocusAreas _Coordinate, long CourseId)
        {
            return ExecuteScalarInt32Sp("TMS_CourseFocus_Delete",
                        ParamBuilder.Par("ID", _Coordinate.ID),
                        ParamBuilder.Par("CourseID", CourseId),
                        ParamBuilder.Par("UpdatedBy", _Coordinate.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Coordinate.UpdatedDate)

            );
        }
        public int TMS_CourseFocusArea_DublicationDAL(FocusAreas _focusarea, long CourseId)
        {
            return ExecuteScalarSPInt32("TMS_CourseFocus_DublicationCheck",
                        ParamBuilder.Par("CourseID", CourseId),
                        ParamBuilder.Par("FocusID", _focusarea.ID),
                        ParamBuilder.Par("CreatedBy", _focusarea.CreatedBy)
            );
        }

        #endregion


    }
}