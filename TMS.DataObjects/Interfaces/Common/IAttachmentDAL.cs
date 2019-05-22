// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="IAttachmentDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common;
using TMS.Library.Common.Attachment;

namespace TMS.DataObjects.Interfaces.Common
{
    /// <summary>
    /// Interface IAttachmentDAL
    /// </summary>
    public interface IAttachmentDAL
    {

        #region"For Person organization attachments"

        /// <summary>
        /// TMSs the attachment get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Attachments&gt;.</returns>
        IList<TMS_Attachments> TMS_Attachment_GetByIdAndTypeDAL(long OpenId, int OpenType);

        /// <summary>
        /// TMSs the attachment get single by identifier and type dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMS_Attachments.</returns>
        TMS_Attachments TMS_Attachment_GetSingleByIdAndTypeDAL(long ID);

        /// <summary>
        /// TMSs the attachment create dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Attachment_CreateDAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment update dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_UpdateDAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment delete dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_DeleteDAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedDAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed profile logo dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedProfileLogoDAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed organization logo dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedOrganizationLogoDAL(TMS_Attachments _objTMS_Attachments);

        #endregion
    }
}