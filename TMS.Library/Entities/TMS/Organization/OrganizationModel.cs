// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 05-01-2017
// ***********************************************************************
// <copyright file="OrganizationModel.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Organization
{
    /// <summary>
    /// Class OrganizationModel.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class OrganizationModel : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the p.
        /// </summary>
        /// <value>The name of the p.</value>
        [Display(Name = "OrganizationPrimaryName", ResourceType = typeof(lr))]
        [Required]
      //  [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OrganizationPrimaryNameRequired")]
        public string P_Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the s.
        /// </summary>
        /// <value>The name of the s.</value>
        [Display(Name = "OrganizationSecondaryName", ResourceType = typeof(lr))]
        public string S_Name { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        public long CompanyID { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>The fax number.</value>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Display(Name = "OrganizationType", ResourceType = typeof(lr))]
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the pointof contact.
        /// </summary>
        /// <value>The name of the pointof contact.</value>
        [Display(Name = "OrganizationPointOfContact", ResourceType = typeof(lr))]
        public string PointofContactName { get; set; }

        /// <summary>
        /// Gets or sets the pointof contact title.
        /// </summary>
        /// <value>The pointof contact title.</value>
        public string PointofContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the pointof contact email.
        /// </summary>
        /// <value>The pointof contact email.</value>
        public string PointofContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the pointof contact fax.
        /// </summary>
        /// <value>The pointof contact fax.</value>
        public string PointofContactFax { get; set; }

        /// <summary>
        /// Gets or sets the pointof contact phone number.
        /// </summary>
        /// <value>The pointof contact phone number.</value>
        public string PointofContactPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>The type of the business.</value>
        public int BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the business scope.
        /// </summary>
        /// <value>The business scope.</value>
        public int BusinessScope { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>The attachment identifier.</value>
        public long AttachmentID { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [Display(Name = "OrganizationFullName", ResourceType = typeof(lr))]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        [Display(Name = "OrganizationShortName", ResourceType = typeof(lr))]
        //[RequiredIf("P_Name", "", ErrorMessageResourceName = "PersonP_FirstNameRequired", ErrorMessageResourceType = typeof(lr))]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        [Display(Name = "OrganizationLogo", ResourceType = typeof(lr))]
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the handled by.
        /// </summary>
        /// <value>The handled by.</value>
        [Display(Name = "OrganizationHandledBy", ResourceType = typeof(lr))]
        public long HandledBy { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

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
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

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
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [Display(Name = "OrganizationCountry", ResourceType = typeof(lr))]
        public long Country { get; set; }

        /// <summary>
        /// Gets or sets the logo picture.
        /// </summary>
        /// <value>The logo picture.</value>
        public string LogoPicture { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }

        

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>The contact number.</value>
        public string ContactNumber { get; set; }
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        public string CountryCode { get; set; }
        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; set; }
        /// <summary>
        /// Gets or sets the person email.
        /// </summary>
        /// <value>The person email.</value>
        public string PersonEmail { get; set; }
        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        public string P_DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        /// <value>The purpose.</value>
        public string Purpose { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            P_Name = dr.GetString("P_Name");
            S_Name = dr.GetString("S_Name");
            CompanyID = dr.GetInt64("CompanyID");
            PhoneNumber = dr.GetString("PhoneNumber");
            Website = dr.GetString("Website");
            Email = dr.GetString("Email");
            FaxNumber = dr.GetString("FaxNumber");
            Type = dr.GetInt32("Type");
            PointofContactName = dr.GetString("PointofContactName");
            PointofContactTitle = dr.GetString("PointofContactTitle");
            PointofContactEmail = dr.GetString("PointofContactEmail");
            PointofContactFax = dr.GetString("PointofContactFax");
            PointofContactPhoneNumber = dr.GetString("PointofContactPhoneNumber");
            BusinessType = dr.GetInt32("BusinessType");
            BusinessScope = dr.GetInt32("BusinessScope");
            Description = dr.GetString("Description");
            AttachmentID = dr.GetInt64("AttachmentID");
            FullName = dr.GetString("FullName");
            ShortName = dr.GetString("ShortName");
            Logo = dr.GetString("Logo");
            HandledBy = dr.GetInt64("HandledBy");
            Alias = dr.GetString("Alias");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            Country = dr.GetInt64("Country");
            LogoPicture = dr.GetStringForProfile("LogoPicture");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias= dr.GetString("UpdatedByAlias");
            ContactNumber = dr.GetString("ContactNumber");
            CountryCode = dr.GetString("CountryCode");
            Extension = dr.GetString("Extension");
            PersonEmail = dr.GetString("PersonEmail");
            P_DisplayName = dr.GetString("P_DisplayName");
            Purpose  = dr.GetString("Purpose");
        }
    }

    //public class OrganizationAttachmentMapping : IDataMapper
    //{
    //    public long MappingID { get; set; }

    //    public long OrganizationID { get; set; }

    //    public long AttachmentID { get; set; }

    //    public SaveForAttachment AttachmentType { get; set; }

    //    public long CreatedBy { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public long? UpdatedBy { get; set; }

    //    public DateTime? UpdatedDate { get; set; }

    //    public bool IsDeleted { get; set; }

    //    public void MapProperties(DbDataReader dr)
    //    {
    //        MappingID = dr.GetInt64("MappingID");
    //        OrganizationID = dr.GetInt64("OrganizationID");
    //        AttachmentID = dr.GetInt64("AttachmentID");
    //        AttachmentType = (SaveForAttachment)dr.GetByte("AttachmentType");
    //        CreatedBy = dr.GetInt64("CreatedBy");
    //        CreatedDate = dr.GetDateTime("CreatedDate");
    //        UpdatedBy = dr.GetInt64("UpdatedBy");
    //        UpdatedDate = dr.GetDateTime("UpdatedDate");
    //        IsDeleted = dr.GetBoolean("IsDeleted");
    //    }
    //}
}