// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-25-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="SessionDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Program;
using TMS.Library.Entities.TMS.Program;
using System;

namespace TMS.DataObjects.TMS.Program
{
    /// <summary>
    /// Class SessionDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.Program.ISessionDAL" />
    public class SessionDAL : DBGenerics, ISessionDAL
    {
        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public List<Sessions> TMS_Sessions_GetALLByCultureDAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Sessions> Sessions = new List<Sessions>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new {  ClassID=ClassID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_Sessions_GetALLByCulture", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Sessions = multi.Read<Sessions>().AsList<Sessions>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Sessions.ToList();
        }





        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>

        public Sessions TMS_Session_GetByIdDAL(string ID)
        {
            Sessions Sessions = new Sessions();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ID = ID });
                Sessions = conn.Query<Sessions>("TMS_Sessions_GetById", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<Sessions>();
                conn.Close();
            }
            return Sessions;
        }

        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public List<Sessions> TMS_SessionsbyOrganization_GetALLByCultureDAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<Sessions> Sessions = new List<Sessions>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ClassID = ClassID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid });
                using (var multi = conn.QueryMultiple("TMS_Sessions_GetALLByCultureandOrganization", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Sessions = multi.Read<Sessions>().AsList<Sessions>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Sessions.ToList();
        }

        /// <summary>
        /// TMSs the sessions create dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Sessions_CreateDAL(Sessions _Sessions)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Sessions_Create", parameters,
                            ParamBuilder.Par("SessionName", _Sessions.SessionName),
                            ParamBuilder.Par("ClassID", _Sessions.ClassID),
                            ParamBuilder.Par("LanguageID", _Sessions.LanguageID),
                            ParamBuilder.Par("ScheduleDate", _Sessions.ScheduleDate),
                            ParamBuilder.Par("StartTime", _Sessions.StartTime),
                            ParamBuilder.Par("EndTime", _Sessions.EndTime),
                            ParamBuilder.Par("TrainerID", _Sessions.TrainerID),
                            ParamBuilder.Par("OrganizationID", _Sessions.OrganizationID),
                            ParamBuilder.Par("IsLastSession", _Sessions.IsLastSession),
                            ParamBuilder.Par("LectureConducted", _Sessions.LectureConducted),
                            ParamBuilder.Par("VenueID", _Sessions.VenueID),
                            ParamBuilder.Par("CreatedBy", _Sessions.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Sessions.CreatedDate));
        }

        /// <summary>
        /// TMSs the sessions update dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Sessions_UpdateDAL(Sessions _Sessions)
        {
            return ExecuteScalarInt32Sp("TMS_Sessions_Update",
                             ParamBuilder.Par("ID", _Sessions.ID),
                            ParamBuilder.Par("LanguageID", _Sessions.LanguageID),
                            ParamBuilder.Par("ScheduleDate", _Sessions.ScheduleDate),
                            ParamBuilder.Par("StartTime", _Sessions.StartTime),
                            ParamBuilder.Par("EndTime", _Sessions.EndTime),
                            ParamBuilder.Par("TrainerID", _Sessions.TrainerID),
                            ParamBuilder.Par("IsLastSession", _Sessions.IsLastSession),
                            ParamBuilder.Par("LectureConducted", _Sessions.LectureConducted),
                            ParamBuilder.Par("VenueID", _Sessions.VenueID),
                            ParamBuilder.Par("UpdatedBy", _Sessions.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _Sessions.UpdatedDate)

            );
        }

        /// <summary>
        /// TMSs the sessions delete dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Sessions_DeleteDAL(Sessions _Sessions)
        {
            return ExecuteScalarInt32Sp("TMS_Sessions_Delete",
                            ParamBuilder.Par("ID", _Sessions.ID),
                            ParamBuilder.Par("UpdatedBy", _Sessions.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _Sessions.UpdatedDate)

            );
        }


        /// <summary>
        /// Gets the class detail by class identifier for new session dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="sid">The sid.</param>
        /// <returns>SessionCreationRules.</returns>
        public SessionCreationRules GetClassDetailByClassIdForNewSessionDAL(string ClassID, string sid)
        {
            SessionCreationRules SessionCreationRules = new SessionCreationRules();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ClassID = ClassID ,SessionID=sid});

                SessionCreationRules = conn.Query<SessionCreationRules>("TMS_Session_GetDetailByClassID", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<SessionCreationRules>();
                conn.Close();
            }

            return SessionCreationRules;
        }


        /// <summary>
        /// TMSs the session check valid session dal.
        /// </summary>
        /// <param name="Sessions">The sessions.</param>
        /// <returns>SessionCreationRules.</returns>
        public SessionCreationRules TMS_Session_CheckValidSessionDAL(Sessions Sessions)
        {
            SessionCreationRules SessionCreationRules = new SessionCreationRules();

            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { ClassID = Sessions.ClassID, SessionID = Sessions.ID, VenueID= Sessions.VenueID, TrainerID = Sessions.TrainerID , ScheduleDate = Sessions.ScheduleDate,
                    StartTime = Sessions.StartTime,  EndTime = Sessions.EndTime, 
                });

                SessionCreationRules = conn.Query<SessionCreationRules>("TMS_Session_CheckValidSession", dbParam, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<SessionCreationRules>();
                conn.Close();
            }

            return SessionCreationRules;
        }

        public int User_EmailCheckDAL(long CompanyID, string Email)
        {
            return ExecuteScalarSPInt32("TMS_Trainer_EmailCheck",
                   ParamBuilder.Par("OrganizationID", CompanyID),
                               ParamBuilder.Par("Email", Email));

        }

        public List<Sessions> TMS_SessionsTrainer_GetALLByCultureDAL(string Email, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid)
        {
            List<Sessions> Sessions = new List<Sessions>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Email= Email, ClassID = ClassID, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid });
                using (var multi = conn.QueryMultiple("TMS_Sessions_GetALLByCultureandTrainer", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Sessions = multi.Read<Sessions>().AsList<Sessions>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Sessions.ToList();
        }
    }
}