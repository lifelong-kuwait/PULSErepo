// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ICommonBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common;

namespace TMS.Business.Interfaces.Common
{
    /// <summary>
    /// Interface ICommonBAL
    /// </summary>
    public interface ICommonBAL
    {
        #region"Notes"

        /// <summary>
        /// TMSs the notes get by identifier and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        IList<TMS_Notes> TMS_Notes_GetByIdAndTypeBAL(long OpenId, int OpenType);
        
        /// <summary>
        /// TMSs the notes get by identifier and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        IList<TMS_Notes> TMS_NotesByOrganization_GetByIdAndTypeBAL(long OpenId, int OpenType,string Oid);

        /// <summary>
        /// TMSs the notes create bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Notes_CreateBAL(TMS_Notes _objTMS_Notes);

        /// <summary>
        /// TMSs the notes update bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Notes_UpdateBAL(TMS_Notes _objTMS_Notes);

        /// <summary>
        /// TMSs the notes delete bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Notes_DeleteBAL(TMS_Notes _objTMS_Notes);

        #endregion
    }
}