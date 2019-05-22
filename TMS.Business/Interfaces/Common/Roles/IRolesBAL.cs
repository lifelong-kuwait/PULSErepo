// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-29-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IRolesBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Common.Roles;

namespace TMS.Business.Interfaces.Common
{
    /// <summary>
    /// Interface IRolesBAL
    /// </summary>
    public interface IRolesBAL
    {
        /// <summary>
        /// Roles the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        List<Roles> Roles_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Roles the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Roles&gt;.</returns>
        List<Roles> Roles_GetAllBALbyOrganization(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid);


        List<Roles> Roles_GetAll_BAL(ref int Total);
        /// <summary>
        /// Roles the create bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int64.</returns>
        long Roles_CreateBAL(Roles _Roles);

        /// <summary>
        /// Roles the update bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_UpdateBAL(Roles _Roles);

        /// <summary>
        /// Roles the delete bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_DeleteBAL(Roles _Roles);
        /// <summary>
        /// Roles the duplication check bal.
        /// </summary>
        /// <param name="_Roles">The roles.</param>
        /// <returns>System.Int32.</returns>
        int Roles_DuplicationCheckBAL(Roles _Roles);
    }
}