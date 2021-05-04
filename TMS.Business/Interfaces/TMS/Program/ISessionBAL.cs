// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-25-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ISessionBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS.Persons;

namespace TMS.Business.Interfaces.TMS.Program
{
    /// <summary>
    /// Interface ISessionBAL
    /// </summary>
    public interface ISessionBAL
    {
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
        List<Sessions> TMS_Sessions_GetALLByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);
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
        List<SessionWeekBarData> TMS_Sessions_BarBAL(string FirstDate, string  lastDate, long companyID);

        /// <summary>
        /// TMSs the courses get by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        Sessions TMS_Session_GetByIdBAL(string ID);
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
        IList<Sessions> TMS_SessionsbyOrganization_GetALLByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);
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
        List<Sessions> TMS_SessionsbyOrganization_GetALLSessionsByCultureBAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid,int page, long personId);

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
        List<Sessions> TMS_SessionsTrainer_GetALLByCultureBAL(string Email,long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid);


        /// <summary>
        /// TMSs the sessions create bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Sessions_CreateBAL(Sessions _Sessions);

        /// <summary>
        /// TMSs the sessions update bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Sessions_UpdateBAL(Sessions _Sessions);

        /// <summary>
        /// TMSs the sessions delete bal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Sessions_DeleteBAL(Sessions _Sessions);
        /// <summary>
        /// Gets the class detail by class identifier for new session bal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="sid">The sid.</param>
        /// <returns>SessionCreationRules.</returns>
        SessionCreationRules GetClassDetailByClassIdForNewSessionBAL(string ClassID, string sid);
        /// <summary>
        /// Gets the class detail by class identifier for new session bal.
        /// </summary>
        /// <param name="Sessions">The sessions.</param>
        /// <returns>SessionCreationRules.</returns>
        SessionCreationRules GetClassDetailByClassIdForNewSessionBAL(Sessions Sessions);
        int GetSessionVenueOccupancyDetailBAL(Sessions Sessions);
        string GetSessionVenueOccupancyDetailStringBAL(Sessions Sessions);
        int GetSessionVenueOccupancyDetailUPBAL(Sessions Sessions);
        int User_EmailCheckBAL(long CompanyID, string Email);

    }
}