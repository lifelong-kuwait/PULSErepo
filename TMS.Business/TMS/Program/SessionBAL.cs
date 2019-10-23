// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-25-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="SessionBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.Program;
using TMS.DataObjects.Interfaces.TMS.Program;
using TMS.Library.Entities.TMS.Program;

namespace TMS.Business.TMS.Program
{
    /// <summary>
    /// Class SessionBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.Program.ISessionBAL" />
    public class SessionBAL : ISessionBAL
    {
        private readonly ISessionDAL _SessionBAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionBAL"/> class.
        /// </summary>
        /// <param name="_ISessionDAL">The i session dal.</param>
        public SessionBAL(ISessionDAL _ISessionDAL)
        {
            _SessionBAL = _ISessionDAL;
        }
        /// <summary>
        /// TMSs the sessions get all by culture bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public Sessions TMS_Session_GetByIdBAL(string ID)
        {
            return _SessionBAL.TMS_Session_GetByIdDAL(ID);
        }
        /// <summary>
        /// TMSs the sessions get all by culture bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public List<Sessions> TMS_Sessions_GetALLByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _SessionBAL.TMS_Sessions_GetALLByCultureDAL(ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }
        /// <summary>
        /// TMSs the sessions get all by culture bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public List<SessionWeekBarData> TMS_Sessions_BarBAL(string FirstDate, string lastDate, long companyID)
        {
            return _SessionBAL.TMS_Sessions_BarDAL(FirstDate, lastDate, companyID);
        }
        /// <summary>
        /// TMSs the sessions get all by culture bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public IList<Sessions> TMS_SessionsbyOrganization_GetALLByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            return _SessionBAL.TMS_SessionsbyOrganization_GetALLByCultureDAL(ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);
        }
        /// <summary>
        /// TMSs the sessions get all by culture bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        public List<Sessions> TMS_SessionsbyOrganization_GetALLSessionsByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid, int page)
        {
            return _SessionBAL.TMS_SessionsbyOrganization_GetALLSessionsByCultureDAL(ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText, Oid,page);
        }
        
        /// <summary>
        /// TMSs the sessions create bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Sessions_CreateBAL(Sessions _Sessions)
        {
            return _SessionBAL.TMS_Sessions_CreateDAL(_Sessions);
        }

        /// <summary>
        /// TMSs the sessions update bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Sessions_UpdateBAL(Sessions _Sessions)
        {
            return _SessionBAL.TMS_Sessions_UpdateDAL(_Sessions);
        }

        /// <summary>
        /// TMSs the sessions delete bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Sessions_DeleteBAL(Sessions _Sessions)
        {
            return _SessionBAL.TMS_Sessions_DeleteDAL(_Sessions);
        }

        /// <summary>
        /// Gets the class detail by class identifier for new session bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="sid">The sid.</param>
        /// <returns>SessionCreationRules.</returns>
        public SessionCreationRules GetClassDetailByClassIdForNewSessionBAL(string ClassID, string sid) => _SessionBAL.GetClassDetailByClassIdForNewSessionDAL( ClassID, sid);

        /// <summary>
        /// Gets the class detail by class identifier for new session bal.
        /// </summary>
        /// <param name="Sessions">The sessions.</param>
        /// <returns>SessionCreationRules.</returns>
        public SessionCreationRules GetClassDetailByClassIdForNewSessionBAL(Sessions Sessions) { return _SessionBAL.TMS_Session_CheckValidSessionDAL(Sessions); }
        public int GetSessionVenueOccupancyDetailBAL(Sessions Sessions)
        {
             return _SessionBAL.GetSessionVenueOccupancyDetailDAL(Sessions); 
        }
        public int GetSessionVenueOccupancyDetailUPBAL(Sessions Sessions)
        {
            return _SessionBAL.GetSessionVenueOccupancyDetailUPDAL(Sessions);
        }
        public int User_EmailCheckBAL(long CompanyID, string Email)
        {
            return _SessionBAL.User_EmailCheckDAL(CompanyID,Email);
        }

        public List<Sessions> TMS_SessionsTrainer_GetALLByCultureBAL(string Email, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid)
        {
            return _SessionBAL.TMS_SessionsTrainer_GetALLByCultureDAL(Email,ClassID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText, Oid);

        }
    }
}