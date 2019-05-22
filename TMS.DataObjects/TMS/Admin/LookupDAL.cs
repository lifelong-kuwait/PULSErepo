// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-03-2016
// ***********************************************************************
// <copyright file="LookupDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Admin;
using TMS.Library.Admin.Lookup;

namespace TMS.DataObjects.TMS.Admin
{
    /// <summary>
    /// Class LookupDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.Admin.ILookupDAL" />
    public class LookupDAL : DBGenerics, ILookupDAL
    {
        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public IList<Lookup> GetLookupData(bool Status, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Lookup> Course = new List<Lookup>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Status = Status, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_lookup_GetAll", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Lookup>().AsList<Lookup>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();

            // return ExecuteList<Lookup>("Select * from Lookup where IsActive=@IsActive", ParamBuilder.Par("@IsActive", Status));
        }

        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public IList<Lookup> GetLookupData_byOrganization(bool Status,string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Lookup> Course = new List<Lookup>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { Status = Status,Oid=Oid, StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("TMS_lookup_GetAllOrganizationID", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Course = multi.Read<Lookup>().AsList<Lookup>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Course.ToList();
            // return ExecuteList<Lookup>("Select l.* from Lookup as L LEFT OUTER JOIN Organizations as o ON o.ID=l.OrganizationID  where l.IsActive=@IsActive and l.OrganizationID=@Oid", ParamBuilder.Par("@IsActive", Status),ParamBuilder.Par("@Oid",Oid));
        }

        /// <summary>
        /// Inserts the lookup record dal.
        /// </summary>
        /// <param name="_objLookup">The objLookup.</param>
        /// <returns>System.Int64.</returns>
        public long InsertLookupRecordDAL(Lookup _objLookup)
        {
            var parameters = new[] { ParamBuilder.Par("@LookupId", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Admin_LookupInsertRecord", parameters,
               ParamBuilder.Par("@LookupP_Name", _objLookup.LookupP_Name), ParamBuilder.Par("@LookupS_Name", _objLookup.LookupS_Name), ParamBuilder.Par("@OrganizationID", _objLookup.OrganizationID), ParamBuilder.Par("@CreatedBy", _objLookup.Createdby));
        }

        /// <summary>
        /// Upates the lookup record dal.
        /// </summary>
        /// <param name="_objLookup">The objLookup.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateLookupRecordDAL(Lookup _objLookup)
        {
            return ExecuteScalarInt32Sp("TMS_Admin_LookupUpdateRecord",
                 ParamBuilder.Par("@LookupP_Name", _objLookup.LookupP_Name), ParamBuilder.Par("@LookupS_Name", _objLookup.LookupS_Name),
              ParamBuilder.Par("@UpdatedBy", _objLookup.Updatedby), ParamBuilder.Par("@LookupId", _objLookup.LookupID));
        }

        /// <summary>
        /// Inserts the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookupDetail">The object lookup detail.</param>
        /// <returns>System.Int64.</returns>
        public long InsertLookupDetailRecordDAL(LookupDetail _objLookupDetail)
        {
            var parameters = new[] { ParamBuilder.Par("@LookupDetailId", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Admin_LookupDetailInsertRecord", parameters,
               ParamBuilder.Par("@LookupDetailP_Name", _objLookupDetail.LookupDetailP_Name), ParamBuilder.Par("@LookupDetailS_Name", _objLookupDetail.LookupDetailS_Name),
               ParamBuilder.Par("@CreatedBy", _objLookupDetail.Createdby), ParamBuilder.Par("@CreatedDate", _objLookupDetail.CreatedDate),
                ParamBuilder.Par("@LookupId", _objLookupDetail.LookupID), ParamBuilder.Par("@IsActive", _objLookupDetail.IsActive), ParamBuilder.Par("@IsSelected", _objLookupDetail.IsSelected)

               );
        }

        /// <summary>
        /// Gets the lookup detail data dal.
        /// </summary>
        /// <param name="LookupId">The lookup identifier.</param>
        /// <returns>IList&lt;LookupDetail&gt;.</returns>
        public IList<LookupDetail> GetLookupDetailDataDAL(long LookupId)
        {
            return ExecuteList<LookupDetail>("Select * from LookupDetail where IsDeleted=0 and LookupId=@LookupId ", ParamBuilder.Par("@LookupId", LookupId)
                );
        }

        /// <summary>
        /// Updates the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookupDetail">The objLookup detail.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateLookupDetailRecordDAL(LookupDetail _objLookupDetail)
        {
            return ExecuteScalarInt32Sp("TMS_Admin_LookupDetailUpdateRecord",
                ParamBuilder.Par("@LookupDetailP_Name", _objLookupDetail.LookupDetailP_Name), ParamBuilder.Par("@LookupDetailS_Name", _objLookupDetail.LookupDetailS_Name),
               ParamBuilder.Par("@Updatedby", _objLookupDetail.Updatedby), ParamBuilder.Par("@UpdatedDate", _objLookupDetail.UpdatedDate),
                ParamBuilder.Par("@LookupDetaiId", _objLookupDetail.LookupDetaiId), ParamBuilder.Par("@IsActive", _objLookupDetail.IsActive), ParamBuilder.Par("@IsSelected", _objLookupDetail.IsSelected),
                ParamBuilder.Par("@LookupID", _objLookupDetail.LookupID));
        }

        /// <summary>
        /// Deletes the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookupDetail">The objLookup detail.</param>
        /// <returns>System.Int32.</returns>
        public int DeleteLookupDetailRecordDAL(LookupDetail _objLookupDetail)
        {
            return ExecuteScalarInt32Sp("TMS_Admin_LookupDetailDeleteRecord",
               ParamBuilder.Par("@Updatedby", _objLookupDetail.Updatedby), ParamBuilder.Par("@UpdatedDate", _objLookupDetail.UpdatedDate),
                ParamBuilder.Par("@LookupDetaiId", _objLookupDetail.LookupDetaiId));
        }
    }
}