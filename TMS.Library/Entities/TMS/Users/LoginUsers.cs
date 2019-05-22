// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-24-2017
// ***********************************************************************
// <copyright file="LoginUsers.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Web.Mvc;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Users
{
    /// <summary>
    /// Class LoginUserGroups.
    /// </summary>
    public class LoginUserGroups
    {
        /// <summary>
        /// Gets or sets the mapping identifier.
        /// </summary>
        /// <value>The mapping identifier.</value>
        public long MappingId { get; set; }
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public string GroupName { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        private bool _IsNew = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        public bool IsNew
        {
            get { return _IsNew; }
            set { _IsNew = value; }
        }
    }

    /// <summary>
    /// Class LoginUserAddGroups.
    /// </summary>
    public class LoginUserAddGroups
    {
        /// <summary>
        /// Gets or sets the mapping identifier.
        /// </summary>
        /// <value>The mapping identifier.</value>
        public long MappingId { get; set; }



        public long CompnayID { get; set; }
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public string GroupName { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        private bool _IsNew = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        public bool IsNew
        {
            get { return _IsNew; }
            set { _IsNew = value; }
        }
    }

    /// <summary>
    /// Class LoginUsers.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class LoginUsers : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginUsers"/> class.
        /// </summary>
        public LoginUsers()
        {
            this.UserGroups = new List<LoginUserGroups>();
        }

        /// <summary>
        /// Gets or sets the user groups.
        /// </summary>
        /// <value>The user groups.</value>
        [Display(Name = "UserSecuritgroups", ResourceType = typeof(lr))]
        public List<LoginUserGroups> UserGroups { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public long UserID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the p.
        /// </summary>
        /// <value>The first name of the p.</value>
        [Display(Name = "UserPrimaryFirstName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserPrimaryFirstNameRequired")]
        public string P_FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the p middle.
        /// </summary>
        /// <value>The name of the p middle.</value>
        [Display(Name = "UserPrimaryMiddleName", ResourceType = typeof(lr))]

        public string P_MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "UserPrimaryLastName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserPrimaryLastNameRequired")]
        public string P_LastName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "UserPrimaryDisplayName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserPrimaryDisplayNameRequired")]
        public string P_DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the s.
        /// </summary>
        /// <value>The first name of the s.</value>
        public string S_FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the s middle.
        /// </summary>
        /// <value>The name of the s middle.</value>
        public string S_MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the last name of the s.
        /// </summary>
        /// <value>The last name of the s.</value>
        public string S_LastName { get; set; }
        /// <summary>
        /// Gets or sets the display name of the s.
        /// </summary>
        /// <value>The display name of the s.</value>
        public string S_DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Display(Name = "UserPassword", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "LoginPasswordRequired")]

        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [Display(Name = "UserConfirmPassword", ResourceType = typeof(lr))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Display(Name = "UserEmail", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserEmailRequired")]
        [Remote("IsUserWithEmail_Available", "User", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserEmailAlreadyExist", AdditionalFields = "InitialEmail")]
        [RegularExpression("^([\\w\\.\\-]+)@([a-zA-Z_]+)((\\.(\\w){2,3})+)$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInValid")]
        //[EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>The user role.</value>
        public int UserRole { get; set; }
        /// <summary>
        /// Gets or sets the name of the user role.
        /// </summary>
        /// <value>The name of the user role.</value>
        public string UserRoleName { get; set; }

        /// <summary>
        /// Gets or sets the validation code.
        /// </summary>
        /// <value>The validation code.</value>
        public string ValidationCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Display(Name = "GridIsActiveColumnTitle", ResourceType = typeof(lr))]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is company user.
        /// </summary>
        /// <value><c>true</c> if this instance is company user; otherwise, <c>false</c>.</value>
        public bool IsCompanyUser { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        public long CompanyID { get; set; }

        [NotMapped]
        public string OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin.
        /// </summary>
        /// <value><c>true</c> if this instance is admin; otherwise, <c>false</c>.</value>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Display(Name = "DateOfBirth", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserDateOfBirthRequired")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the how heard about us.
        /// </summary>
        /// <value>The how heard about us.</value>
        public int HowHeardAboutUs { get; set; }

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
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public long Parent { get; set; }

        /// <summary>
        /// Gets or sets the name of the nick.
        /// </summary>
        /// <value>The name of the nick.</value>
        [Display(Name = "UserNickName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserNickNameRequired")]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the salutation.
        /// </summary>
        /// <value>The salutation.</value>
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonSalutationRequired")]
        [Display(Name = "PersonSalutation", ResourceType = typeof(lr))]
        public Int16 Salutation { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public long DepartmentID { get; set; }


        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonGenderRequired")]
        [Display(Name = "Gender", ResourceType = typeof(lr))]
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets the p gender.
        /// </summary>
        /// <value>The p gender.</value>
        public string P_Gender { get; set; }
        /// <summary>
        /// Gets or sets the s gender.
        /// </summary>
        /// <value>The s gender.</value>
        public string S_Gender { get; set; }
        /// <summary>
        /// Gets or sets the education.
        /// </summary>
        /// <value>The education.</value>
        public string Education { get; set; }
        /// <summary>
        /// Gets or sets the employee status.
        /// </summary>
        /// <value>The employee status.</value>
        public Int16 EmployeeStatus { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        public long MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the p marital status.
        /// </summary>
        /// <value>The p marital status.</value>
        public string P_MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the s marital status.
        /// </summary>
        /// <value>The s marital status.</value>
        public string S_MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the type of the national identifier.
        /// </summary>
        /// <value>The type of the national identifier.</value>
        public long NationalIdType { get; set; }
        ///// <summary>
        ///// Gets or sets the type of the p national identifier.
        ///// </summary>
        ///// <value>The type of the p national identifier.</value>
        //public string P_NantionalIDType { get; set; }
        ///// <summary>
        ///// Gets or sets the type of the s national identifier.
        ///// </summary>
        ///// <value>The type of the s national identifier.</value>
        //public string S_NantionalIDType { get; set; }

        /// <summary>
        /// Gets or sets the national identity.
        /// </summary>
        /// <value>The national identity.</value>
        public string NationalIdentity { get; set; }

        /// <summary>
        /// Gets or sets the twitter.
        /// </summary>
        /// <value>The twitter.</value>
        public string Twitter { get; set; }
        /// <summary>
        /// Gets or sets the facebook.
        /// </summary>
        /// <value>The facebook.</value>
        public string Facebook { get; set; }
        /// <summary>
        /// Gets or sets the google plus.
        /// </summary>
        /// <value>The google plus.</value>
        public string GooglePlus { get; set; }
        /// <summary>
        /// Gets or sets the skype.
        /// </summary>
        /// <value>The skype.</value>
        public string Skype { get; set; }
        /// <summary>
        /// Gets or sets the flicker.
        /// </summary>
        /// <value>The flicker.</value>
        public string Flicker { get; set; }
        /// <summary>
        /// Gets or sets the MSN.
        /// </summary>
        /// <value>The MSN.</value>
        public string MSN { get; set; }
        public string UpdatedByAlias { get; set; }
        
        /// <summary>
        /// Gets or sets the instagram.
        /// </summary>
        /// <value>The instagram.</value>
        public string Instagram { get; set; }
        /// <summary>
        /// Gets or sets the last login.
        /// </summary>
        /// <value>The last login.</value>
        public DateTime LastLogin { get; set; }
        /// <summary>
        /// Gets or sets the UTC offset.
        /// </summary>
        /// <value>The UTC offset.</value>
        public string UTCOffset { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the pulse identifier.
        /// </summary>
        /// <value>The pulse identifier.</value>
        public string PulseID { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public string EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>The profile image.</value>
        public string ProfileImage { get; set; }
        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>The address identifier.</value>
        public long AddressID { get; set; }
        /// <summary>
        /// Gets or sets the type of the sales processing.
        /// </summary>
        /// <value>The type of the sales processing.</value>
        public Int16 SalesProcessingType { get; set; }
        /// <summary>
        /// Gets or sets the profile theme.
        /// </summary>
        /// <value>The profile theme.</value>
        public string ProfileTheme { get; set; }

        /// <summary>
        /// Gets or sets the locked out attempt.
        /// </summary>
        /// <value>The locked out attempt.</value>
        public int LockedOutAttempt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked out.
        /// </summary>
        /// <value><c>true</c> if this instance is locked out; otherwise, <c>false</c>.</value>
        public bool IsLockedOut { get; set; }
        /// <summary>
        /// Gets or sets the locked out date.
        /// </summary>
        /// <value>The locked out date.</value>
        public DateTime LockedOutDate { get; set; }
        /// <summary>
        /// Gets or sets the culture identifier.
        /// </summary>
        /// <value>The culture identifier.</value>
        public Int16 CultureID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is send create password email.
        /// </summary>
        /// <value><c>true</c> if this instance is send create password email; otherwise, <c>false</c>.</value>
        public bool IsSendCreatePasswordEmail { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        /// <summary>
        /// Gets or sets the group ids.
        /// </summary>
        /// <value>The group ids.</value>
        public string GroupIds { get; set; }
        [NotMapped]
        public string GroupName { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            UserID = dr.GetInt64("UserID");

            P_FirstName = dr.GetString("P_FirstName");
            P_LastName = dr.GetString("P_LastName");
            P_MiddleName = dr.GetString("P_MiddleName");
            P_DisplayName = dr.GetString("P_DisplayName");
            S_FirstName = dr.GetString("S_FirstName");
            S_MiddleName = dr.GetString("S_MiddleName");
            S_LastName = dr.GetString("S_LastName");
            S_DisplayName = dr.GetString("S_DisplayName");
            Salutation = dr.GetByte("Salutation");
            Email = dr.GetString("Email");
            //UserRole = dr.GetInt32("UserRole");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            //ValidationCode = dr.GetString("ValidationCode");
            IsActive = dr.GetBoolean("IsActive");
            //  IsCompanyUser = dr.GetBoolean("IsCompanyUser");
            //CompanyID = dr.GetInt64("CompanyID");
            OrganizationName = dr.GetString("OrganizationName");
            IsDeleted = dr.GetBoolean("IsDeleted");
            //IsAdmin = dr.GetBoolean("IsAdmin");
            DateOfBirth = dr.GetDateTime("DateOfBirth");
            NickName = dr.GetString("NickName");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            CreatedDate = dr.GetDateTime("CreatedDate");
            Description = dr.GetString("Description");
            //  DepartmentID = dr.GetInt64("DepartmentID");
            Gender = dr.GetByte("Gender");

            ProfileImage = dr.GetStringForProfile("ProfileImage");
            ProfileTheme = dr.GetString("Theme");
            LockedOutAttempt = dr.GetInt32("LockedOutAttempt");
            LockedOutDate = dr.GetDateTime("LockedOutDate");
            IsLockedOut = dr.GetBoolean("IsLockedOut");
            AddedByAlias = dr.GetString("AddedByAlias");
            GroupIds = dr.GetString("GroupIds");
            GroupName = dr.GetString("GroupName");
        }
    }
}