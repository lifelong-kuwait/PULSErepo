// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-04-2017
// ***********************************************************************
// <copyright file="ITMSResourceDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Admin;

namespace TMS.DataObjects.Interfaces.TMS.Admin
{
    /// <summary>
    /// Interface ITMSResourceDAL
    /// </summary>
    public interface ITMSResourceDAL
    {
        /// <summary>
        /// Gets the TMS resource dal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        IList<TMSResource> GetTMSResourceDAL(int Page, int PageSize, ref int Total, string SearchText);
      //  int ResourceExistCountDAL(string Name);
        int LanguageExistCountDAL(long CompnayID);

        /// <summary>
        /// Gets the TMS resource dal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        IList<TMSResource> GetTMSResourceDALbyOrganization(int Page, int PageSize, ref int Total,string Oid, string SearchText);

        /// <summary>
        /// Inserts the dual TMS resource dal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>ResourceCreationDual.</returns>
        ResourceCreationDual InsertDualTMSResourceDAL(TMSResource _obj);
        /// <summary>
        /// Resources the exist count dal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        ResourceCreationDual InsertOrgResourceDAL(TMSResource _obj);

        /// <summary>
        /// Resources the exist count dal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        int ResourceExistCountDAL(string Name);

        /// <summary>
        /// Updates the dual TMS resource dal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        int UpdateDualTMSResourceDAL(TMSResource _obj);
    }
}