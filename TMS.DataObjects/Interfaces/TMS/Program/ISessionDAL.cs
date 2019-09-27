// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-25-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-04-2018
// ***********************************************************************
// <copyright file="ISessionDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.TMS.Program;

namespace TMS.DataObjects.Interfaces.TMS.Program
{
    /// <summary>
    /// Interface ISessionDAL
    /// </summary>
    public interface ISessionDAL
    {
        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        List<Sessions> TMS_Sessions_GetALLByCultureDAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        List<Sessions> TMS_SessionsbyOrganization_GetALLByCultureDAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        List<Sessions> TMS_SessionsbyOrganization_GetALLSessionsByCultureDAL(long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid);

        
        /// <summary>
        /// TMSs the sessions get all by culture dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Sessions&gt;.</returns>
        Sessions TMS_Session_GetByIdDAL(string ID);
        /// <summary>
        /// TMSs the sessions create dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Sessions_CreateDAL(Sessions _Sessions);

        /// <summary>
        /// TMSs the sessions update dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Sessions_UpdateDAL(Sessions _Sessions);

        /// <summary>
        /// TMSs the sessions delete dal.
        /// </summary>
        /// <param name="_Sessions">The sessions.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Sessions_DeleteDAL(Sessions _Sessions);
        /// <summary>
        /// Gets the class detail by class identifier for new session dal.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="sid">The sid.</param>
        /// <returns>SessionCreationRules.</returns>
        SessionCreationRules GetClassDetailByClassIdForNewSessionDAL(string ClassID, string sid);
        /// <summary>
        /// TMSs the session check valid session dal.
        /// </summary>
        /// <param name="Sessions">The sessions.</param>
        /// <returns>SessionCreationRules.</returns>
        SessionCreationRules TMS_Session_CheckValidSessionDAL(Sessions Sessions);
        int GetSessionVenueOccupancyDetailDAL(Sessions Sessions);
        int GetSessionVenueOccupancyDetailUPDAL(Sessions Sessions);
        int User_EmailCheckDAL(long CompanyID, string Email);

        List<Sessions> TMS_SessionsTrainer_GetALLByCultureDAL(string Email, long ClassID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText, string Oid);


    }
}