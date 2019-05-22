// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="CommonBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Common;
using TMS.DataObjects.Common;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library.Common;

namespace TMS.Business.Common
{
    /// <summary>
    /// Class CommonBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.ICommonBAL" />
    public class CommonBAL : ICommonBAL
    {
        private readonly ICommonDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonBAL"/> class.
        /// </summary>
        public CommonBAL()
        {
            DAL = new CommonDAL();
        }
        #region"Notes"
        /// <summary>
        /// TMSs the notes get by identifier and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        public IList<TMS_Notes> TMS_Notes_GetByIdAndTypeBAL(long OpenId, int OpenType)
        {
            return DAL.TMS_Notes_GetByIdAndTypeDAL(OpenId, OpenType);
        }

        /// <summary>
        /// TMSs the notes get by identifier and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        public IList<TMS_Notes> TMS_NotesByOrganization_GetByIdAndTypeBAL(long OpenId, int OpenType,string Oid)
        {
            return DAL.TMS_NotesByOrganization_GetByIdAndTypeDAL(OpenId, OpenType,Oid);
        }
        /// <summary>
        /// TMSs the notes create bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Notes_CreateBAL(TMS_Notes _objTMS_Notes)
        {
            return DAL.TMS_Notes_CreateDAL(_objTMS_Notes);
        }
        /// <summary>
        /// TMSs the notes update bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Notes_UpdateBAL(TMS_Notes _objTMS_Notes)
        {
            return DAL.TMS_Notes_UpdateDAL(_objTMS_Notes);
        }
        /// <summary>
        /// TMSs the notes delete bal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Notes_DeleteBAL(TMS_Notes _objTMS_Notes)
        {
            return DAL.TMS_Notes_DeleteDAL(_objTMS_Notes);
        }
        #endregion
    }
}