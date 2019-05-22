// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ILookupBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Admin.Lookup;

namespace TMS.Business.Interfaces.Admin
{
    /// <summary>
    /// Interface ILookupBAL
    /// </summary>
    public interface ILookupBAL
    {
        /// <summary>
        /// Gets the lookup data bal.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        IList<Lookup> GetLookupDataBAL(bool Status, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Gets the lookup data bal.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        IList<Lookup> GetLookupDataBAL_byOrganization(bool Status,string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Inserts the lookup record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int64.</returns>
        long InsertLookupRecordBAL(Lookup _objLookup);

        /// <summary>
        /// Updates the lookup record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int32.</returns>
        int UpdateLookupRecordBAL(Lookup _objLookup);


        /// <summary>
        /// Inserts the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int64.</returns>
        long InsertLookupDetailRecordBAL(LookupDetail _objLookup);

        /// <summary>
        /// Gets the lookup detail data bal.
        /// </summary>
        /// <param name="LookupId">The lookup identifier.</param>
        /// <returns>IList&lt;LookupDetail&gt;.</returns>
        IList<LookupDetail> GetLookupDetailDataBAL(long LookupId);

        /// <summary>
        /// Updates the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookupDetail">The object lookup detail.</param>
        /// <returns>System.Int32.</returns>
        int UpdateLookupDetailRecordBAL(LookupDetail _objLookupDetail);

        /// <summary>
        /// Deletes the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookupDetail">The object lookup detail.</param>
        /// <returns>System.Int32.</returns>
        int DeleteLookupDetailRecordBAL(LookupDetail _objLookupDetail);
    }
}