// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="TMS_Attachments.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Common.Attachment
{
    /// <summary>
    /// Class TMS_Attachments.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class TMS_Attachments : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the open identifier.
        /// </summary>
        /// <value>The open identifier.</value>
        public long OpenID { get; set; }

        /// <summary>
        /// Gets or sets the type of the open.
        /// </summary>
        /// <value>The type of the open.</value>
        public int OpenType { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        [Display(Name = "TMSAttachmentFileName", ResourceType = typeof(lr))]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [Display(Name = "TMSAttachmentFile", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "TMSAttachmentFileRequired")]
        public string file { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>The type of the file.</value>
        [Display(Name = "TMSAttachmentFileType", ResourceType = typeof(lr))]
        public AttachmentsFileType FileType { get; set; }

        /// <summary>
        /// Gets or sets the file parent root folder.
        /// </summary>
        /// <value>The file parent root folder.</value>
        public string FileParentRootFolder { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        public long FileSize { get; set; }

        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>The file extension.</value>
        public string FileExtension { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "TMSAttachmentDescription", ResourceType = typeof(lr))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the valid till.
        /// </summary>
        /// <value>The valid till.</value>
        [Display(Name = "TMSAttachmentValidTill", ResourceType = typeof(lr))]
        public DateTime? ValidTill { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is completed.
        /// </summary>
        /// <value><c>true</c> if this instance is completed; otherwise, <c>false</c>.</value>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the completed date.
        /// </summary>
        /// <value>The completed date.</value>
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            OpenID = dr.GetInt64("OpenID");
            OpenType = dr.GetInt32("OpenType");
            FileName = dr.GetString("FileName");
            FileType = (AttachmentsFileType)dr.GetInt16("FileType");
            FileParentRootFolder = dr.GetString("FileParentRootFolder");
            file = dr.GetString("FileParentRootFolder");
            FilePath = dr.GetString("FilePath");
            FileSize = dr.GetInt64("FileSize");
            FileExtension = dr.GetString("FileExtension");
            Description = dr.GetString("Description");
            ValidTill = dr.GetDateTime("ValidTill");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            IsCompleted = dr.GetBoolean("IsCompleted");
            CompletedDate = dr.GetDateTime("CompletedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            IsValid = dr.GetBoolean("IsValid");
        }
    }
}