using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Admin.Config;
using static TMS.Library.Users.Users;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Library.TMS.Trainer
{
    public class Trainer : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the salutation identifier.
        /// </summary>
        /// <value>The salutation identifier.</value>
        [Display(Name = "PersonSalutation", ResourceType = typeof(lr))]
        public Salutation SalutationID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the p.
        /// </summary>
        /// <value>The first name of the p.</value>
        [Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonP_FirstNameRequired")]
        public string P_FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "PersonP_LastName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonP_LastNameRequired")]
        public string P_LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the p middle.
        /// </summary>
        /// <value>The name of the p middle.</value>
        [Display(Name = "PersonP_MiddleName", ResourceType = typeof(lr))]
        public string P_MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "PersonP_DisplayName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonP_DisplayNameRequired")]
        public string P_DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the s.
        /// </summary>
        /// <value>The first name of the s.</value>
        [Display(Name = "PersonS_FirstName", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonS_FirstNameRequired")]
        public string S_FirstName { get; set; }
        [Display(Name = "clientstatus", ResourceType = typeof(lr))]
        public CRMClientType? CRMClientType { get; set; }
        /// <summary>
        /// Gets or sets the last name of the s.
        /// </summary>
        /// <value>The last name of the s.</value>
        [Display(Name = "PersonS_LastName", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonS_LastNameRequired")]
        public string S_LastName { get; set; }

        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the name of the s middle.
        /// </summary>
        /// <value>The name of the s middle.</value>
        [Display(Name = "PersonS_MiddleName", ResourceType = typeof(lr))]
        public string S_MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the s.
        /// </summary>
        /// <value>The display name of the s.</value>
        [Display(Name = "PersonS_DisplayName", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonS_DisplaynameRequired")]
        public string S_DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the engagement status identifier.
        /// </summary>
        /// <value>The engagement status identifier.</value>
        [Display(Name = "PersonEngagementStatus", ResourceType = typeof(lr))]
        public long EngagementStatusId { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>The organization identifier.</value>
        [Display(Name = "PersonOrganization", ResourceType = typeof(lr))]
        public long OrganizationID { get; set; }

        [NotMapped]
        [Display(Name = "PersonOrganization", ResourceType = typeof(lr))]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        [Display(Name = "PersonDepartment", ResourceType = typeof(lr))]
        public long DepartmentID { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(Name = "PersonDepartment", ResourceType = typeof(lr))]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the national identity.
        /// </summary>
        /// <value>The national identity.</value>
        [Display(Name = "PersonNationalIdentity", ResourceType = typeof(lr))]
        public string NationalIdentity { get; set; }

        /// <summary>
        /// Gets or sets the official identification type identifier.
        /// </summary>
        /// <value>The official identification type identifier.</value>
        [Display(Name = "PersonOfficialIdentificationType", ResourceType = typeof(lr))]
        public OfficialIdentificationType OfficialIdentificationTypeID { get; set; }

        /// <summary>
        /// Gets or sets the official identifier number.
        /// </summary>
        /// <value>The official identifier number.</value>
        [Display(Name = "PersonOfficialIDNumber", ResourceType = typeof(lr))]
        public string OfficialIDNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Display(Name = "DateOfBirth", ResourceType = typeof(lr))]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the availability from.
        /// </summary>
        /// <value>The availability from.</value>
        public DateTime AvailabilityFrom { get; set; }

        /// <summary>
        /// Gets or sets the availability to.
        /// </summary>
        /// <value>The availability to.</value>
        public DateTime AvailabilityTo { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty point.
        /// </summary>
        /// <value>The Loyalty point.</value>
        public long LoyaltyPoint { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty point redeemed.
        /// </summary>
        /// <value>The Loyalty point redeemed.</value>
        public long LoyaltyPointRedeemed { get; set; }

        /// <summary>
        /// Gets or sets the person reg code.
        /// </summary>
        /// <value>The person reg code.</value>
        [Display(Name = "PersonRegistrationCode", ResourceType = typeof(lr))]
        public string PersonRegCode { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>The designation.</value>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Display(Name = "Gender", ResourceType = typeof(lr))]
        public Gender Gender { get; set; }

        //[Display(Name = "PersonNationality", ResourceType = typeof(lr))]
        //public Nationality Nationality { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Display(Name = "PersonType", ResourceType = typeof(lr))]
        public long Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is coordinator.
        /// </summary>
        /// <value><c>true</c> if this instance is coordinator; otherwise, <c>false</c>.</value>
        [Display(Name = "PersonIsCoordinator", ResourceType = typeof(lr))]
        public bool IsCoordinator { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "PersonRating", ResourceType = typeof(lr))]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the type of the client.
        /// </summary>
        /// <value>The type of the client.</value>
        [Display(Name = "PersonClientType", ResourceType = typeof(lr))]
        public ClientType ClientType { get; set; }

        [NotMapped]
        [Display(Name ="PersonType",ResourceType =typeof(lr))]
        public personType _personType { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
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
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }

        [Display(Name = "Assigned To", ResourceType = typeof(lr))]
        public IList<UsersNested> User { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public long UserID { get; set; }

        /// <summary>
        /// Gets or sets the additional comments.
        /// </summary>
        /// <value>The additional comments.</value>
        public string AdditionalComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is online.
        /// </summary>
        /// <value><c>true</c> if this instance is online; otherwise, <c>false</c>.</value>
        public bool IsOnline { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is online.
        /// </summary>
        /// <value><c>true</c> if this instance is online; otherwise, <c>false</c>.</value>
        [NotMapped]
        [Display(Name = "TrainerLogin", ResourceType = typeof(lr))]
        public bool? IsLogin { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        [Display(Name = "MaritalStatus", ResourceType = typeof(lr))]
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>The vendor identifier.</value>
        public long VendorID { get; set; }
        /// <summary>
        /// Gets or sets the picture identifier.
        /// </summary>
        /// <value>The picture identifier.</value>
        public string PictureID { get; set; }
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>The attachment identifier.</value>
        public string AttachmentId { get; set; }
        /// <summary>
        /// Gets or sets the profile picture.
        /// </summary>
        /// <value>The profile picture.</value>
        public string ProfilePicture { get; set; }

        //public string NationalityValue
        //{
        //    get
        //    {
        //        return Fd.GetDisplayName(Nationality);
        //    }
        //}

        /// <summary>
        /// Gets the gender value.
        /// </summary>
        /// <value>The gender value.</value>
        public string GenderValue
        {
            get
            {
                return Gender != null ? Fd.GetDisplayName(Gender) : "NotSpecified";
            }
        }

        /// <summary>
        /// Gets or sets the name of the nick.
        /// </summary>
        /// <value>The name of the nick.</value>
        [Display(Name = "PersonNickName", ResourceType = typeof(lr))]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>The alias.</value>
        [Display(Name = "PersonAlias", ResourceType = typeof(lr))]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>The contact number.</value>
        [Display(Name = "PersonPhoneNumber", ResourceType = typeof(lr))]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PersonPhoneNumberNotValid")]
        [RegularExpression(@"^[0-9]*$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PersonPhoneNumberNotValid")]

        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>The extension.</value>
        [Display(Name = "PersonPhoneExtension", ResourceType = typeof(lr))]
        [RegularExpression(@"^[0-9]*$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PhoneExtensionnotValid")]

        public string Extension { get; set; }

        [Display(Name = "IDTypes", ResourceType = typeof(lr))]
        public IDType IDtype { get; set; }

        [Display(Name = "TypeID", ResourceType = typeof(lr))]
        public long TypeID { get; set; }
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        [Display(Name = "PersonPhoneCountryCode", ResourceType = typeof(lr))]
        public long CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Display(Name = "PersonContactEmail", ResourceType = typeof(lr))]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
                                      ErrorMessageResourceName = "EmailInValid")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        public long EmailID { get; set; }
        /// <summary>
        /// Gets or sets the phone identifier.
        /// </summary>
        /// <value>The phone identifier.</value>
        public long PhoneID { get; set; }
        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        public string ClassTitle { get; set; }
        public string CourseName { get; set; }
        //public DateTime StartTime { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public DateTime EndTime { get; set; }
        [NotMapped]
        public string Country { get; set; }
        public string PClassTitle { get; set; }
        /// <summary>
        /// Gets or sets the flag count.
        /// </summary>
        /// <value>The flag count.</value>
        public int FlagCount { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        [Display(Name = "Flags", ResourceType = typeof(lr))]
        public IList<PersonFlagsNested> Flags { get; set; }

        /// <summary>
        /// Gets or sets the flag i ds.
        /// </summary>
        /// <value>The flag i ds.</value>
        public string FlagIDs { get; set; }
        public string UpdatedByAlias { get; set; }
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            EmailID = dr.GetLong("EmailID");
            Email = dr.GetString("Email");
            PhoneID = dr.GetLong("PhoneID");
            CountryCode = dr.GetLong("CountryCode");
            Extension = dr.GetString("Extension");
            ContactNumber = dr.GetString("ContactNumber");
            ID = dr.GetInt64("ID");
            SalutationID = (Salutation)dr.GetByte("SalutationID");
            P_FirstName = dr.GetString("P_FirstName");
            P_LastName = dr.GetString("P_LastName");
            P_MiddleName = dr.GetString("P_MiddleName");
            P_DisplayName = dr.GetString("P_DisplayName");
            S_FirstName = dr.GetString("S_FirstName");
            S_LastName = dr.GetString("S_LastName");
            S_MiddleName = dr.GetString("S_MiddleName");
            S_DisplayName = dr.GetString("S_DisplayName");
            EngagementStatusId = dr.GetInt64("EngagementStatusId");
            OrganizationID = dr.GetInt64("OrganizationID");
            OrganizationName = dr.GetString("OrganizationName");
            DepartmentID = dr.GetInt64("DepartmentID");
            Notes = dr.GetString("Notes");
            NationalIdentity = dr.GetString("NationalIdentity");
            OfficialIdentificationTypeID = (OfficialIdentificationType)dr.GetByte("OfficialIdentificationTypeID");
            OfficialIDNumber = dr.GetString("OfficialIDNumber");
            DateOfBirth = dr.GetDateTime("DateOfBirth");
            AvailabilityFrom = dr.GetDateTime("AvailabilityFrom");
            AvailabilityTo = dr.GetDateTime("AvailabilityTo");
            LoyaltyPoint = dr.GetInt64("LoyaltyPoint");
            LoyaltyPointRedeemed = dr.GetInt64("LoyaltyPointRedeemed");
            PersonRegCode = dr.GetString("PersonRegCode");
            Designation = dr.GetString("Designation");
            Password = dr.GetString("Password");
            Gender = (Gender)dr.GetByte("Gender");
            RoleName =dr.GetString("RoleName");
            Type = dr.GetByte("Type");
            IsCoordinator = dr.GetBoolean("IsCoordinator");
            Rating = dr.GetInt32("Rating");
            if (CRMClientType == null)
                CRMClientType = 0;
            else
                CRMClientType = (CRMClientType)dr.GetByte("CrmClientType");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            UserID = dr.GetInt64("UserID");
            AdditionalComments = dr.GetString("AdditionalComments");
            IsOnline = dr.GetBoolean("IsOnline");
            MaritalStatus = (MaritalStatus)dr.GetByte("MaritalStatus");
            VendorID = dr.GetInt64("VendorID");
            ProfilePicture = dr.GetStringForProfile("ProfilePicture");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            NickName = dr.GetString("NickName");
            Alias = dr.GetString("Alias");
            AddedByAlias = dr.GetString("AddedByAlias");
            ClassTitle = dr.GetString("ClassTitle");
            CourseName = dr.GetString("CourseName");
            //StartDate = dr.GetDateTime("StartDate");
            //EndDate = dr.GetDateTime("EndDate");
            //StartTime = dr.GetDateTime("StartTime");
            //EndTime = dr.GetDateTime("EndTime");
            Country = dr.GetString("Country");
            PClassTitle = dr.GetString("PClassTitle");
            FlagCount = dr.GetInt32("FlagCount");
            FlagIDs = dr.GetString("FlagIDs");
            IsLogin = dr.GetBoolean("IsLogin");
        }

    }



    /// <summary>
    /// Class Fd.
    /// </summary>
    public static class Fd
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null)
                return String.Empty;

            object[] attribs = field.GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attribs.Length > 0)
            {
                return ((DisplayAttribute)attribs[0]).GetName();
            }
            return value.ToString();
        }
    }

    /// <summary>
    /// Class PersonFlagsModel.
    /// </summary>
    public class PersonFlagsModel
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
    }

    /// <summary>
    /// Class PersonResponce.
    /// </summary>
    public class PersonResponse
    {
        /// <summary>
        /// Gets or sets the person reg code.
        /// </summary>
        /// <value>The person reg code.</value>
        public string PersonRegCode { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }
    }

    /// <summary>
    /// Class PersonAttachment.
    /// </summary>
    public class PersonAttachment
    {
        /// <summary>
        /// Gets or sets the picturename.
        /// </summary>
        /// <value>The picturename.</value>
        public string picturename { get; set; }
        /// <summary>
        /// Gets or sets the attachmentname.
        /// </summary>
        /// <value>The attachmentname.</value>
        public List<AttachmentPersonData> attachmentname { get; set; }
    }

    /// <summary>
    /// Class AttachmentPersonData.
    /// </summary>
    public class AttachmentPersonData
    {
        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>The uid.</value>
        public string uid { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
    }

    /// <summary>
    /// Class PersonRolesMapping.
    /// </summary>
    public class PersonRolesMapping
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public long PersonID { get; set; }

        //
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        [Display(Name = "RolesDropDownTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "RolesDropDownTitleRequired")]
        public long RoleID { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        [Display(Name = "RolesDropDownTitle", ResourceType = typeof(lr))]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
    }
}
