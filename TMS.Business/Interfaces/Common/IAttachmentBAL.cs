// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="IAttachmentBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common;
using TMS.Library.Common.Attachment;

namespace TMS.Business.Interfaces.Common
{
    /// <summary>
    /// Interface IAttachmentBAL
    /// </summary>
    public interface IAttachmentBAL
    {

        /// <summary>
        /// TMSs the attachment get single by identifier and type bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMS_Attachments.</returns>
        TMS_Attachments TMS_Attachment_GetSingleByIdAndTypeBAL(long ID);

        /// <summary>
        /// TMSs the attachment get by identifier and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Attachments&gt;.</returns>
        IList<TMS_Attachments> TMS_Attachment_GetByIdAndTypeBAL(long OpenId, int OpenType);

        /// <summary>
        /// TMSs the attachment create bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Attachment_CreateBAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment update bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_UpdateBAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment delete bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_DeleteBAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedBAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed profile logo bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedProfileLogoBAL(TMS_Attachments _objTMS_Attachments);

        /// <summary>
        /// TMSs the attachment completed organization logo bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Attachment_CompletedOrganizationLogoBAL(TMS_Attachments _objTMS_Attachments);
    }
}