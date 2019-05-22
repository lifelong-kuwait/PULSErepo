// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ICommonDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common;

namespace TMS.DataObjects.Interfaces.Common
{
    /// <summary>
    /// Interface ICommonDAL
    /// </summary>
    public interface ICommonDAL
    {
        #region"Notes"

        /// <summary>
        /// TMSs the notes get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        IList<TMS_Notes> TMS_Notes_GetByIdAndTypeDAL(long OpenId, int OpenType);

        /// <summary>
        /// TMSs the notes get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        IList<TMS_Notes> TMS_NotesByOrganization_GetByIdAndTypeDAL(long OpenId, int OpenType,string Oid);

        /// <summary>
        /// TMSs the notes create dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Notes_CreateDAL(TMS_Notes _objTMS_Notes);

        /// <summary>
        /// TMSs the notes update dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Notes_UpdateDAL(TMS_Notes _objTMS_Notes);

        /// <summary>
        /// TMSs the notes delete dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Notes_DeleteDAL(TMS_Notes _objTMS_Notes);

        #endregion
    }
}