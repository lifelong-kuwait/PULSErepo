// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-04-2017
// ***********************************************************************
// <copyright file="ITMSResourcesBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Admin;

namespace TMS.Business.Interfaces.Admin
{
    /// <summary>
    /// Interface ITMSResourcesBAL
    /// </summary>
    public interface ITMSResourcesBAL
    {
        /// <summary>
        /// Gets the TMS resource bal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        IList<TMSResource> GetTMSResourceBAL(int Page, int PageSize, ref int Total, string SearchText);
        /// <summary>
        /// Gets the TMS resource bal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        IList<TMSResource> GetTMSResourceBALbyOrganization(int Page, int PageSize, ref int Total, string Oid, string SearchText);

        /// <summary>
        /// Inserts the dual TMS resource bal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>ResourceCreationDual.</returns>
        ResourceCreationDual InsertDualTMSResourceBAL(TMSResource _obj);
        /// <summary>
        /// Updates the dual TMS resource bal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        ResourceCreationDual InsertOrgResourceBAL(TMSResource _obj);
        /// <summary>
        /// Updates the dual TMS resource bal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        
        int UpdateDualTMSResourceBAL(TMSResource _obj);
        /// <summary>
        /// Resources the exist count bal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        int ResourceExistCountBAL(string Name);

        /// <summary>
        /// Resources the exist count bal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        int LanguageExistCountBAL(long CompnayID);
    }
}
