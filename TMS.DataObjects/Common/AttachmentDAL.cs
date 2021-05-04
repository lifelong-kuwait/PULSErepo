// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="AttachmentDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common;
using TMS.Library;
using TMS.Library.Common;
using TMS.Library.Common.Attachment;

namespace TMS.DataObjects.Common
{
    /// <summary>
    /// Class AttachmentDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.IAttachmentDAL" />
    public class AttachmentDAL : DBGenerics, IAttachmentDAL
    {

        #region"For Person organization attachments"

        /// <summary>
        /// TMSs the attachment get by identifier and type dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>IList&lt;TMS_Attachments&gt;.</returns>
        public IList<TMS_Attachments> TMS_Attachment_GetByIdAndTypeDAL(long OpenId, int OpenType)
        {
            List<TMS_Attachments> localList = new List<TMS_Attachments>();

            var x= ProfileAndLogoFromDatabase(OpenId, OpenType);
            if(x==null)
            {

            }else
            {
                localList.Add(x);
            }
            
            localList.AddRange(ExecuteListSp<TMS_Attachments>("TMS_Attachments_GetbyIdandType", ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType)));
            return localList;
        }

        /// <summary>
        /// Profiles the and logo from database.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>TMS_Attachments.</returns>
        internal TMS_Attachments ProfileAndLogoFromDatabase(long OpenId, int OpenType)
        {
            var model = ExecuteSinglewithSP<TMS_Attachments>("TMS_Attachments_GetProfileLogobyIdandType", ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType));
            if(model==null){
              TMS_Attachments LocalModel= new TMS_Attachments(){
              ID=-1,FileType=AttachmentsFileType.AttachmentsFileType_ProfilePicture,FileName="people.png",FilePath="~/images/i/",Description="This is default image and this will hide when you add new profile picture"
              };
                model= LocalModel;
            }
            else
            {
                model = null;
            }
            return model;
        }

        /// <summary>
        /// TMSs the attachment get single by identifier and type dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMS_Attachments.</returns>
        public TMS_Attachments TMS_Attachment_GetSingleByIdAndTypeDAL(long ID)
        {
            return ExecuteSinglewithSP<TMS_Attachments>("TMS_Attachments_GetSinglebyIdandType", ParamBuilder.Par("ID", ID));
        }

        /// <summary>
        /// TMSs the attachment create dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Attachment_CreateDAL(TMS_Attachments _objTMS_Attachments)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_Attachments_Create", parameters,
                    ParamBuilder.Par("OpenID", _objTMS_Attachments.OpenID),
                    ParamBuilder.Par("OpenType", _objTMS_Attachments.OpenType),
                    ParamBuilder.Par("FileName", _objTMS_Attachments.FileName),
                    ParamBuilder.Par("FileType", _objTMS_Attachments.FileType),
                    ParamBuilder.Par("FileParentRootFolder", _objTMS_Attachments.FileParentRootFolder),
                    ParamBuilder.Par("FilePath", _objTMS_Attachments.FilePath),
                    ParamBuilder.Par("FileSize", _objTMS_Attachments.FileSize),
                    ParamBuilder.Par("FileExtension", _objTMS_Attachments.FileExtension),
                    ParamBuilder.Par("Description", _objTMS_Attachments.Description),
                    ParamBuilder.Par("ValidTill", _objTMS_Attachments.ValidTill),
                    ParamBuilder.Par("CreatedBy", _objTMS_Attachments.CreatedBy),
                    ParamBuilder.Par("CreatedDate", _objTMS_Attachments.CreatedDate));
        }

        /// <summary>
        /// TMSs the attachment update dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_UpdateDAL(TMS_Attachments _objTMS_Attachments)
        {
            return ExecuteScalarInt32Sp("TMS_Attachments_Update",
                    ParamBuilder.Par("ID", _objTMS_Attachments.ID),
                    ParamBuilder.Par("Description", _objTMS_Attachments.Description),
                    ParamBuilder.Par("ValidTill", _objTMS_Attachments.ValidTill),
                    ParamBuilder.Par("UpdatedBy", _objTMS_Attachments.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objTMS_Attachments.UpdatedDate));
        }
        /// <summary>
        /// TMSs the attachment update dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_UpdateForJobDAL(long PersonID,long AttachmentID)
        {
            return ExecuteScalarInt32Sp("TMS_Attachment_Update_Jobs",
                    ParamBuilder.Par("ID", AttachmentID),
                    ParamBuilder.Par("PersonID",PersonID));
        }
        

        /// <summary>
        /// TMSs the attachment delete dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_DeleteDAL(TMS_Attachments _objTMS_Attachments)
        {
            return ExecuteScalarInt32Sp("TMS_Attachments_Delete",
                    ParamBuilder.Par("ID", _objTMS_Attachments.ID),
                    ParamBuilder.Par("UpdatedBy", _objTMS_Attachments.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objTMS_Attachments.UpdatedDate));
        }

        /// <summary>
        /// TMSs the attachment completed dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedDAL(TMS_Attachments _objTMS_Attachments)
        {
            return ExecuteScalarInt32Sp("TMS_Attachments_Completed",
                    ParamBuilder.Par("ID", _objTMS_Attachments.ID),
                    ParamBuilder.Par("FileParentRootFolder", _objTMS_Attachments.FileParentRootFolder),
                     ParamBuilder.Par("Description", _objTMS_Attachments.Description),
                    ParamBuilder.Par("ValidTill", _objTMS_Attachments.ValidTill),
                    ParamBuilder.Par("CompletedDate", _objTMS_Attachments.CompletedDate));
        }

        /// <summary>
        /// TMSs the attachment completed profile logo dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedProfileLogoDAL(TMS_Attachments _objTMS_Attachments)
        {
            return ExecuteScalarInt32Sp("TMS_Attachment_CompletedProfileLogo",
                    ParamBuilder.Par("ID", _objTMS_Attachments.ID),
                    ParamBuilder.Par("OpenID", System.Convert.ToInt32( _objTMS_Attachments.OpenID)),
                    ParamBuilder.Par("OpenType", _objTMS_Attachments.OpenType),
                    ParamBuilder.Par("CompletedDate", _objTMS_Attachments.CompletedDate));
        }

        /// <summary>
        /// TMSs the attachment completed organization logo dal.
        /// </summary>
        /// <param name="_objTMS_Attachments">The object TMS attachments.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Attachment_CompletedOrganizationLogoDAL(TMS_Attachments _objTMS_Attachments)
        {
            return ExecuteScalarInt32Sp("TMS_Attachment_CompletedOrganizationLogo",
                    ParamBuilder.Par("ID", _objTMS_Attachments.ID),
                    ParamBuilder.Par("OpenID", _objTMS_Attachments.OpenID),
                    ParamBuilder.Par("OpenType", _objTMS_Attachments.OpenType),
                     ParamBuilder.Par("FileParentRootFolder", _objTMS_Attachments.FileParentRootFolder),
                    ParamBuilder.Par("FilePath", _objTMS_Attachments.FilePath),
                    ParamBuilder.Par("CompletedDate", _objTMS_Attachments.CompletedDate));
        }

        #endregion
    }
}