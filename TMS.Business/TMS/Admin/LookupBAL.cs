// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="LookupBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Admin;
using TMS.DataObjects.Interfaces.TMS.Admin;
using TMS.DataObjects.TMS.Admin;
using TMS.Library.Admin.Lookup;

namespace TMS.Business.Admin
{
    /// <summary>
    /// Class LookupBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Admin.ILookupBAL" />
    public class LookupBAL : ILookupBAL
    {
        /// <summary>
        /// The dal
        /// </summary>
        public ILookupDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupBAL" /> class.
        /// </summary>
        public LookupBAL()
        {
            DAL = new LookupDAL();
        }

        /// <summary>
        /// Gets the lookup data bal.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public IList<Lookup> GetLookupDataBAL(bool Status, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.GetLookupData(Status, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Gets the lookup data bal.
        /// </summary>
        /// <param name="Status">if set to <c>true</c> [status].</param>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public IList<Lookup> GetLookupDataBAL_byOrganization(bool Status,string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.GetLookupData_byOrganization(Status,Oid, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Inserts the lookup record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int64.</returns>
        public long InsertLookupRecordBAL(Lookup _objLookup)
        {
            return DAL.InsertLookupRecordDAL(_objLookup);
        }

        /// <summary>
        /// Updates the lookup record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateLookupRecordBAL(Lookup _objLookup)
        { return DAL.UpdateLookupRecordDAL(_objLookup); }

        /// <summary>
        /// Inserts the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookup">The object lookup.</param>
        /// <returns>System.Int64.</returns>
        public long InsertLookupDetailRecordBAL(LookupDetail _objLookup)
        {
            return DAL.InsertLookupDetailRecordDAL(_objLookup);
        }

        /// <summary>
        /// Gets the lookup detail data bal.
        /// </summary>
        /// <param name="LookupId">The lookup identifier.</param>
        /// <returns>IList&lt;LookupDetail&gt;.</returns>
        public IList<LookupDetail> GetLookupDetailDataBAL(long LookupId)
        {
            return DAL.GetLookupDetailDataDAL(LookupId);
        }

        /// <summary>
        /// Updates the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookupDetail">The object lookup detail.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateLookupDetailRecordBAL(LookupDetail _objLookupDetail)
        {
            return DAL.UpdateLookupDetailRecordDAL(_objLookupDetail);
        }

        /// <summary>
        /// Deletes the lookup detail record bal.
        /// </summary>
        /// <param name="_objLookupDetail">The object lookup detail.</param>
        /// <returns>System.Int32.</returns>
        public int DeleteLookupDetailRecordBAL(LookupDetail _objLookupDetail)
        {
            return DAL.DeleteLookupDetailRecordDAL(_objLookupDetail);
        }
    }
}