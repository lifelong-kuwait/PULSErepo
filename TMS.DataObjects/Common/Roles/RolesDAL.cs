// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-28-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-30-2017
// ***********************************************************************
// <copyright file="RolesDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library.Entities.Common.Roles;

namespace TMS.DataObjects.Common
{
    /// <summary>
    /// Class RolesDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.IRolesDAL" />
    public class RolesDAL : DBGenerics, IRolesDAL
    {
        #region Add Edit Delete GetAll GetByID for the Roles

        /// <summary>
        /// Roleses the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        public List<Roles> Roles_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Roles> role = new List<Roles>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("Roles_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    role = multi.Read<Roles>().AsList<Roles>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return role.ToList();
        }

        /// <summary>
        /// Roleses the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        public List<Roles> Roles_GetAllDALbyOrganization(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<Roles> role = new List<Roles>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid=Oid });
                using (var multi = conn.QueryMultiple("Roles_GetAllbyOrganization", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    role = multi.Read<Roles>().AsList<Roles>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return role.ToList();
        }

        public List<Roles> Roles_GetAll_DAL(ref int Total)
        {
            List<Roles> role = new List<Roles>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                //DynamicParameters dbParams = new DynamicParameters();
               // dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("Roles_GetAll", commandType: System.Data.CommandType.StoredProcedure))
                {
                    role = multi.Read<Roles>().AsList<Roles>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return role.ToList();
        }

        /// <summary>
        /// Roleses the create dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int64.</returns>
        public long Roles_CreateDAL(Roles _Roles)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Roles_Create", parameters,
                    ParamBuilder.Par("RolePrimaryName", _Roles.RolePrimaryName),
                    ParamBuilder.Par("RoleSecondaryName", _Roles.RoleSecondaryName),
                    ParamBuilder.Par("IsDefaultTrainer", _Roles.IsDefaultTrainer),
                    ParamBuilder.Par("OrganizationID",_Roles.OrganizationID),
                    ParamBuilder.Par("CreatedDate", _Roles.CreatedDate),
                    ParamBuilder.Par("CreatedBy", _Roles.CreatedBy));
        }

        /// <summary>
        /// Roleses the update dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_UpdateDAL(Roles _Roles)
        {
            return ExecuteScalarInt32Sp("Roles_Update",
                         ParamBuilder.Par("ID", _Roles.ID),
                    ParamBuilder.Par("RolePrimaryName", _Roles.RolePrimaryName),
                    ParamBuilder.Par("RoleSecondaryName", _Roles.RoleSecondaryName),
                    ParamBuilder.Par("IsDefaultTrainer", _Roles.IsDefaultTrainer),
                    ParamBuilder.Par("UpdatedDate", _Roles.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _Roles.UpdatedBy)
            );
        }

        /// <summary>
        /// Roleses the delete dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_DeleteDAL(Roles _Roles)
        {
            return ExecuteScalarInt32Sp("Roles_Delete",
                    ParamBuilder.Par("ID", _Roles.ID),
                    ParamBuilder.Par("UpdatedDate", _Roles.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _Roles.UpdatedBy)
            );
        }

        /// <summary>
        /// Roleses the duplication check dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_DuplicationCheckDAL(Roles _Roles)
        {
            return ExecuteScalarSPInt32("Roles_DuplicationCheck",
                    ParamBuilder.Par("ID", _Roles.ID),
                    ParamBuilder.Par("Name", _Roles.RolePrimaryName));
        }//

        #endregion Add Edit Delete GetAll GetByID for the Roles



       
    }
}