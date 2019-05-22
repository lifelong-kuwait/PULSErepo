// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-23-2016
// ***********************************************************************
// <copyright file="ILookupDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Admin.Lookup;

namespace TMS.DataObjects.Interfaces.TMS.Admin
{
    /// <summary>
    /// Interface ILookupDAL
    /// </summary>
    public interface ILookupDAL
    {
        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        IList<Lookup> GetLookupData(bool Status, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        IList<Lookup> GetLookupData_byOrganization(bool Status,string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Inserts the lookup record dal.
        /// </summary>
        /// <param name="_objLookup">The obj lookup.</param>
        /// <returns>System.Int64.</returns>
        long InsertLookupRecordDAL(Lookup _objLookup);

        /// <summary>
        /// Updates the lookup record dal.
        /// </summary>
        /// <param name="_objLookup">The obj lookup.</param>
        /// <returns>System.Int32.</returns>
        int UpdateLookupRecordDAL(Lookup _objLookup);

        //LookupDetails Sections Admin
        /// <summary>
        /// Inserts the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookup">The obj lookup.</param>
        /// <returns>System.Int64.</returns>
        long InsertLookupDetailRecordDAL(LookupDetail _objLookup);

        /// <summary>
        /// Gets the lookup detail data dal.
        /// </summary>
        /// <param name="LookupId">The lookup identifier.</param>
        /// <returns>IList&lt;LookupDetail&gt;.</returns>
        IList<LookupDetail> GetLookupDetailDataDAL(long LookupId);

        /// <summary>
        /// Updates the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookupDetail">The obj lookup detail.</param>
        /// <returns>System.Int32.</returns>
        int UpdateLookupDetailRecordDAL(LookupDetail _objLookupDetail);

        /// <summary>
        /// Deletes the lookup detail record dal.
        /// </summary>
        /// <param name="_objLookupDetail">The obj lookup detail.</param>
        /// <returns>System.Int32.</returns>
        int DeleteLookupDetailRecordDAL(LookupDetail _objLookupDetail);
    }
}