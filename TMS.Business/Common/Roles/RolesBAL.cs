// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 12-29-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="RolesBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Business.Interfaces.Common;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library.Entities.Common.Roles;

namespace TMS.Business.Common
{
    /// <summary>
    /// Class RolesBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.IRolesBAL" />
    public class RolesBAL : IRolesBAL
    {
        /// <summary>
        /// The role dal
        /// </summary>
        private readonly IRolesDAL _RoleDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesBAL" /> class.
        /// </summary>
        /// <param name="_IRolesDAL">The i roles dal.</param>
        public RolesBAL(IRolesDAL _IRolesDAL)
        {
            _RoleDAL = _IRolesDAL;
        }

        /// <summary>
        /// Roles the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        public List<Roles> Roles_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)=>_RoleDAL.Roles_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        

        /// <summary>
        /// Roles the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        public List<Roles> Roles_GetAllBALbyOrganization(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            return _RoleDAL.Roles_GetAllDALbyOrganization(StartRowIndex, PageSize, ref Total, SortExpression, SearchText, Oid);
        }

        public List<Roles> Roles_GetAll_BAL(ref int Total)
        {
            return _RoleDAL.Roles_GetAll_DAL(ref Total);
        }

        /// <summary>
        /// Roles the create bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int64.</returns>
        public long Roles_CreateBAL(Roles _Roles) => _RoleDAL.Roles_CreateDAL(_Roles);

        /// <summary>
        /// Roles the update bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_UpdateBAL(Roles _Roles) => _RoleDAL.Roles_UpdateDAL(_Roles);

        /// <summary>
        /// Roles the delete bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_DeleteBAL(Roles _Roles) => _RoleDAL.Roles_DeleteDAL(_Roles);

        /// <summary>
        /// Roles the duplication check bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        public int Roles_DuplicationCheckBAL(Roles _Roles) => _RoleDAL.Roles_DuplicationCheckDAL(_Roles);

     
    }
}