// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="CommonDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library.Common;

namespace TMS.DataObjects.Common
{
    /// <summary>
    /// Class CommonDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.ICommonDAL" />
    public class CommonDAL : DBGenerics, ICommonDAL
    {
        #region"Notes"
        /// <summary>
        /// TMSs the notes get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        public IList<TMS_Notes> TMS_Notes_GetByIdAndTypeDAL(long OpenId, int OpenType)
        {
            return ExecuteListSp<TMS_Notes>("TMS_Notes_GetAllbyOpenIdandType", ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType));
        }

        /// <summary>
        /// TMSs the notes get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Notes&gt;.</returns>
        public IList<TMS_Notes> TMS_NotesByOrganization_GetByIdAndTypeDAL(long OpenId, int OpenType,string Oid)
        {
            return ExecuteListSp<TMS_Notes>("TMS_NotesByOrganization_GetAllbyOpenIdandType", ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType), ParamBuilder.Par("Oid", Oid));
        }

        /// <summary>
        /// TMSs the notes create dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Notes_CreateDAL(TMS_Notes _objTMS_Notes)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Notes_Create", parameters,
                    ParamBuilder.Par("OpenID",_objTMS_Notes.OpenID),
                    ParamBuilder.Par("OpenType",_objTMS_Notes.OpenType),
                    ParamBuilder.Par("OrganizationID", _objTMS_Notes.OrganizationID),
                    ParamBuilder.Par("NotesText",_objTMS_Notes.NotesText),
                    ParamBuilder.Par("CreatedBy",_objTMS_Notes.CreatedBy),
                    ParamBuilder.Par("CreatedDate",_objTMS_Notes.CreatedDate));
        }

        /// <summary>
        /// TMSs the notes update dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Notes_UpdateDAL(TMS_Notes _objTMS_Notes)
        {
            return ExecuteScalarInt32Sp("TMS_Notes_Update",                
                    ParamBuilder.Par("ID",_objTMS_Notes.ID),
                    ParamBuilder.Par("NotesText",_objTMS_Notes.NotesText),
                    ParamBuilder.Par("UpdatedBy",_objTMS_Notes.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate",_objTMS_Notes.UpdatedDate));
        }

        /// <summary>
        /// TMSs the notes delete dal.
        /// </summary>
        /// <param name="_objTMS_Notes">The object TMS notes.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Notes_DeleteDAL(TMS_Notes _objTMS_Notes)
        {
            return ExecuteScalarInt32Sp("TMS_Notes_Delete",
                    ParamBuilder.Par("ID", _objTMS_Notes.ID),
                    ParamBuilder.Par("UpdatedBy", _objTMS_Notes.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objTMS_Notes.UpdatedDate));
        }
        #endregion

    }
}