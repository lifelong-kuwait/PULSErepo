// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-08-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="AttachmentBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Common;
using TMS.DataObjects.Common;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library.Common.Attachment;

namespace TMS.Business.Common
{
    /// <summary>
    /// Class AttachmentBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.IAttachmentBAL" />
    public class AttachmentBAL : IAttachmentBAL
    {
        /// <summary>
        /// The dal
        /// </summary>
        private readonly IAttachmentDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentBAL" /> class.
        /// </summary>
        public AttachmentBAL()
        {
            DAL = new AttachmentDAL();
        }

        #region"For Person organization attachments"

        /// <summary>
        /// TMSs the attachment get single by id and type bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMS_Attachments.</returns>
        public TMS_Attachments TMS_Attachment_GetSingleByIdAndTypeBAL(long ID)
        {
            return DAL.TMS_Attachment_GetSingleByIdAndTypeDAL(ID);
        }

        /// <summary>
        /// TMSs the attachment get by id and type bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Attachments&gt;.</returns>
        public IList<TMS_Attachments> TMS_Attachment_GetByIdAndTypeBAL(long OpenId, int OpenType)
        {
            return DAL.TMS_Attachment_GetByIdAndTypeDAL(OpenId, OpenType);
        }
        public int TMS_Attachment_UpdateForJobBAL(long PersonID, long AttachmentId)
        {
        
            return DAL.TMS_Attachment_UpdateForJobDAL(PersonID, AttachmentId);
        }


        /// <summary>
        /// TMSs the attachment create bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Attachment_CreateBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_CreateDAL(_objTMS_Attachments);
        }

        /// <summary>
        /// TMSs the attachment update bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_UpdateBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_UpdateDAL(_objTMS_Attachments);
        }

        /// <summary>
        /// TMSs the attachment delete bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_DeleteBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_DeleteDAL(_objTMS_Attachments);
        }

        /// <summary>
        /// TMSs the attachment completed bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_CompletedDAL(_objTMS_Attachments);
        }

        /// <summary>
        /// TMSs the attachment completed profile logo bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedProfileLogoBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_CompletedProfileLogoDAL(_objTMS_Attachments);
        }

        /// <summary>
        /// TMSs the attachment completed organization logo bal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedOrganizationLogoBAL(TMS_Attachments _objTMS_Attachments)
        {
            return DAL.TMS_Attachment_CompletedOrganizationLogoDAL(_objTMS_Attachments);
        }

        #endregion
    }
}