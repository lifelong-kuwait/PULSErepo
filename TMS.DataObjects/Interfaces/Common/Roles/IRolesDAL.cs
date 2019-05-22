// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-28-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IRolesDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Common.Roles;

namespace TMS.DataObjects.Interfaces.Common
{
    /// <summary>
    /// Interface IRolesDAL
    /// </summary>
    public interface IRolesDAL
    {
        /// <summary>
        /// Roles the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        List<Roles> Roles_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Roles the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        List<Roles> Roles_GetAllDALbyOrganization(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);


        List<Roles> Roles_GetAll_DAL(ref int Total);
        /// <summary>
        /// Roles the create dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int64.</returns>
        long Roles_CreateDAL(Roles _Roles);

        /// <summary>
        /// Roles the update dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_UpdateDAL(Roles _Roles);

        /// <summary>
        /// Roles the delete dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_DeleteDAL(Roles _Roles);
        /// <summary>
        /// Roles the duplication check dal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_DuplicationCheckDAL(Roles _Roles);
    }
}