//// ***********************************************************************
//// Assembly         : TMS.Library
//// Author           : Almas Shabbir
//// Created          : 12-24-2017
////
//// Last Modified By : Almas Shabbir
//// Last Modified On : 01-27-2018
//// ***********************************************************************
//// <copyright file="Venues.cs" company="LifeLong www.lifelongkuwait.com">
////     Copyright ©  2016
//// </copyright>
//// <summary></summary>
//// ***********************************************************************
//using System;
//using System.ComponentModel.DataAnnotations;
//using TMS.Library.Core.Validation.Kendo;
//using lr = Resources.Resources;

//namespace TMS.Library.Entities.Common.Configuration.Venues
//{
//    /// <summary>
//    /// Class Venues.
//    /// </summary>
//    public class Venues
//    {
//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long ID { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the primary.
//        /// </summary>
//        /// <value>The name of the primary.</value>
//        [Display(Name = "VenuePrimaryName", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenuePrimaryNameRequired")]
//        public string PrimaryName { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the secondary.
//        /// </summary>
//        /// <value>The name of the secondary.</value>
//        [Display(Name = "VenueSecondaryName", ResourceType = typeof(lr))]
//        public string SecondaryName { get; set; }

//        //
//        /// <summary>
//        /// Gets or sets the venue status identifier.
//        /// </summary>
//        /// <value>The venue status identifier.</value>
//        [Display(Name = "VenueStatus", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueStatusRequired")]
//        public VenueStatusType VenueStatusID { get; set; }

//        /// <summary>
//        /// Gets or sets the driving instruction.
//        /// </summary>
//        /// <value>The driving instruction.</value>
//        public string DrivingInstruction { get; set; }

//        /// <summary>
//        /// Gets or sets the coordinates.
//        /// </summary>
//        /// <value>The coordinates.</value>
//        public string Coordinates { get; set; }

//        /// <summary>
//        /// Gets or sets the person identifier.
//        /// </summary>
//        /// <value>The person identifier.</value>
//        public long? PersonID { get; set; }

//        /// <summary>
//        /// Gets or sets the venue code identifier.
//        /// </summary>
//        /// <value>The venue code identifier.</value>
//        [Display(Name = "VenueCode", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCodeRequired")]
//        public string VenueCodeID { get; set; }

//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long OrganizationID { get; set; }

//        /// <summary>
//        /// Gets or sets the rating.
//        /// </summary>
//        /// <value>The rating.</value>
//        [Display(Name = "VenueRating", ResourceType = typeof(lr))]
//        public int? Rating { get; set; }

//        //
//        /// <summary>
//        /// Gets or sets the type of the rate.
//        /// </summary>
//        /// <value>The type of the rate.</value>
//        [Display(Name = "VenueRateType", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueRateTypeRequired")]
//        public RateType RateType { get; set; }

//        /// <summary>
//        /// Gets or sets the cost.
//        /// </summary>
//        /// <value>The cost.</value>
//        [Display(Name = "VenuesCost", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCostRequired")]
//        public decimal? Cost { get; set; }

//        // // //
//        /// <summary>
//        /// Gets or sets the currency.
//        /// </summary>
//        /// <value>The currency.</value>
//        [Display(Name = "VenueCurrency", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CurrencyRequired")]
//        public int Currency { get; set; }

//        /// <summary>
//        /// Gets or sets the setup.
//        /// </summary>
//        /// <value>The setup.</value>
//        [Display(Name = "VenueSetup", ResourceType = typeof(lr))]
//        public string Setup { get; set; }

//        /// <summary>
//        /// Gets or sets the notes.
//        /// </summary>
//        /// <value>The notes.</value>
//        [Display(Name = "TMSNotesText", ResourceType = typeof(lr))]
//        public string Notes { get; set; }

//        /// <summary>
//        /// Gets or sets the capacity.
//        /// </summary>
//        /// <value>The capacity.</value>
//        [Display(Name = "VenueCapacity", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCapacityRequired")]
//        public string Capacity { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the contact person.
//        /// </summary>
//        /// <value>The name of the contact person.</value>
//        [Display(Name = "VenueContactPerson", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonRequired")]
//        public string ContactPersonName { get; set; }

//        /// <summary>
//        /// Gets or sets the contact person phone.
//        /// </summary>
//        /// <value>The contact person phone.</value>
//        [Display(Name = "VenueContactPersonPhone", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonPhoneRequired")]
//        public string ContactPersonPhone { get; set; }

//        /// <summary>
//        /// Gets or sets the contact person email.
//        /// </summary>
//        /// <value>The contact person email.</value>
//        [Display(Name = "VenueContactPersonEmail", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonEmailRequired")]
//        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
//                                      ErrorMessageResourceName = "EmailInValid")]
//        public string ContactPersonEmail { get; set; }

//        /// <summary>
//        /// Gets or sets the available from.
//        /// </summary>
//        /// <value>The available from.</value>
//        [Display(Name = "VenueAvailableFrom", ResourceType = typeof(lr))]
//        public DateTime? AvailableFrom { get; set; }

//        /// <summary>
//        /// Gets or sets the available from string.
//        /// </summary>
//        /// <value>The available from string.</value>
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionStartTimeRequired")]
//        [Display(Name = "VenueAvailableFrom", ResourceType = typeof(lr))]
//        public string AvailableFromString { get; set; }

//        /// <summary>
//        /// Gets or sets the available to.
//        /// </summary>
//        /// <value>The available to.</value>
//        [Display(Name = "VenueAvailableTo", ResourceType = typeof(lr))]
//        public DateTime? AvailableTo { get; set; }

//        /// <summary>
//        /// Gets or sets the available to string.
//        /// </summary>
//        /// <value>The available to string.</value>
//        [Display(Name = "VenueAvailableTo", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionEndTimeRequired")]
//        [GreaterDate(EarlierDateField = "AvailableFromString", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "EndDateShouldBeGreaterThanStartDate")]
//        public string AvailableToString { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is common.
//        /// </summary>
//        /// <value><c>true</c> if this instance is common; otherwise, <c>false</c>.</value>
//        [Display(Name = "VenueIsCommon", ResourceType = typeof(lr))]
//        public bool IsCommon { get; set; }

//        /// <summary>
//        /// Gets or sets the address line1.
//        /// </summary>
//        /// <value>The address line1.</value>
//        [Display(Name = "AddressAddressOne", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressAddressOneRequired")]
//        public string AddressLine1 { get; set; }

//        /// <summary>
//        /// Gets or sets the address line2.
//        /// </summary>
//        /// <value>The address line2.</value>
//        [Display(Name = "AddressAddressTwo", ResourceType = typeof(lr))]
//        public string AddressLine2 { get; set; }

//        /// <summary>
//        /// Gets or sets the zip code.
//        /// </summary>
//        /// <value>The zip code.</value>
//        [Display(Name = "AddressZipCode", ResourceType = typeof(lr))]
//        public string ZipCode { get; set; }

//        /// <summary>
//        /// Gets or sets the country identifier.
//        /// </summary>
//        /// <value>The country identifier.</value>
//        [Display(Name = "AddressCountry", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressCountryRequired")]
//        public long CountryID { get; set; }

//        /// <summary>
//        /// Gets or sets the country.
//        /// </summary>
//        /// <value>The country.</value>
//        public string Country { get; set; }

//        /// <summary>
//        /// Gets or sets the state identifier.
//        /// </summary>
//        /// <value>The state identifier.</value>
//        [Display(Name = "AddressStateRegion", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressStateRegionRequired")]
//        public long StateID { get; set; }

//        /// <summary>
//        /// Gets or sets the state.
//        /// </summary>
//        /// <value>The state.</value>
//        public string State { get; set; }

//        /// <summary>
//        /// Gets or sets the city.
//        /// </summary>
//        /// <value>The city.</value>
//        public string City { get; set; }

//        /// <summary>
//        /// Gets or sets the city identifier.
//        /// </summary>
//        /// <value>The city identifier.</value>
//        [Display(Name = "AddressCity", ResourceType = typeof(lr))]
//        public long? CityID { get; set; }

//        /// <summary>
//        /// Gets or sets the created by.
//        /// </summary>
//        /// <value>The created by.</value>
//        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
//        public long CreatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the created date.
//        /// </summary>
//        /// <value>The created date.</value>
//        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
//        public DateTime CreatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated by.
//        /// </summary>
//        /// <value>The updated by.</value>
//        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
//        public long? UpdatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the updated date.
//        /// </summary>
//        /// <value>The updated date.</value>
//        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
//        public DateTime? UpdatedDate { get; set; }

//        //
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is deleted.
//        /// </summary>
//        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
//        public bool IsDeleted { get; set; }

//        //
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is active.
//        /// </summary>
//        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
//        public bool IsActive { get; set; }

//        /// <summary>
//        /// Gets or sets the added by alias.
//        /// </summary>
//        /// <value>The added by alias.</value>
//        public string AddedByAlias { get; set; }
//    }

//    /// <summary>
//    /// Class VenueOpenMapping.
//    /// </summary>
//    public class VenueOpenMapping
//    {
//        /// <summary>
//        /// Gets or sets the identifier.
//        /// </summary>
//        /// <value>The identifier.</value>
//        public long ID { get; set; }

//        /// <summary>
//        /// Gets or sets the venue identifier.
//        /// </summary>
//        /// <value>The venue identifier.</value>
//        [Display(Name = "VenueName", ResourceType = typeof(lr))]
//        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueOpenTypeRequired")]
//        public long VenueID { get; set; }

//        /// <summary>
//        /// Gets or sets the open identifier.
//        /// </summary>
//        /// <value>The open identifier.</value>
//        public long OpenId { get; set; }

//        /// <summary>
//        /// Gets or sets the type of the open.
//        /// </summary>
//        /// <value>The type of the open.</value>
//        public int OpenType { get; set; }

//        /// <summary>
//        /// Gets or sets the created by.
//        /// </summary>
//        /// <value>The created by.</value>
//        public long CreatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets the created date.
//        /// </summary>
//        /// <value>The created date.</value>
//        public DateTime CreatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated date.
//        /// </summary>
//        /// <value>The updated date.</value>
//        public DateTime? UpdatedDate { get; set; }

//        /// <summary>
//        /// Gets or sets the updated by.
//        /// </summary>
//        /// <value>The updated by.</value>
//        public long? UpdatedBy { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is deleted.
//        /// </summary>
//        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
//        public bool IsDeleted { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is active.
//        /// </summary>
//        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
//        public bool IsActive { get; set; }

//        /// <summary>
//        /// Gets or sets the name of the venue.
//        /// </summary>
//        /// <value>The name of the venue.</value>
//        public string VenueName { get; set; }
//        /// <summary>
//        /// Gets or sets the added by alias.
//        /// </summary>
//        /// <value>The added by alias.</value>
//        public string AddedByAlias { get; set; }
//    }
//}




// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-24-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-27-2018
// ***********************************************************************
// <copyright file="Venues.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Common.Configuration.Venues
{
    /// <summary>
    /// Class Venues.
    /// </summary>
    public class Venues
    {
        //private IDataReader dbReader;

        //public Venues(IDataReader dbReader)
        //{
        //    this.dbReader = dbReader;
        //}

        //public Venues()
        //{
        //}

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the primary.
        /// </summary>
        /// <value>The name of the primary.</value>
        [Display(Name = "VenuePrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenuePrimaryNameRequired")]
        public string PrimaryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "VenueSecondaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueSecondaryNameRequired")]
        public string SecondaryName { get; set; }

        //
        /// <summary>
        /// Gets or sets the venue status identifier.
        /// </summary>
        /// <value>The venue status identifier.</value>
        [Display(Name = "VenueStatus", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueStatusRequired")]
        public VenueStatusType VenueStatusID { get; set; }

        /// <summary>
        /// Gets or sets the driving instruction.
        /// </summary>
        /// <value>The driving instruction.</value>
        public string DrivingInstruction { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public string Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public long? PersonID { get; set; }

        /// <summary>
        /// Gets or sets the venue code identifier.
        /// </summary>
        /// <value>The venue code identifier.</value>
        [Display(Name = "VenueCode", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCodeRequired")]
        public string VenueCodeID { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "VenueRating", ResourceType = typeof(lr))]
        public int? Rating { get; set; }

        //
        /// <summary>
        /// Gets or sets the type of the rate.
        /// </summary>
        /// <value>The type of the rate.</value>
        [Display(Name = "VenueRateType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueRateTypeRequired")]
        public RateType RateType { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        [Display(Name = "VenuesCost", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCostRequired")]
        public decimal? Cost { get; set; }

        // // //
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [Display(Name = "VenueCurrency", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CurrencyRequired")]
        public int Currency { get; set; }

        /// <summary>
        /// Gets or sets the setup.
        /// </summary>
        /// <value>The setup.</value>
        [Display(Name = "VenueSetup", ResourceType = typeof(lr))]
        public string Setup { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(Name = "TMSNotesText", ResourceType = typeof(lr))]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        [Display(Name = "VenueCapacity", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueCapacityRequired")]
        public string Capacity { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact person.
        /// </summary>
        /// <value>The name of the contact person.</value>
        [Display(Name = "VenueContactPerson", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonRequired")]
        public string ContactPersonName { get; set; }

        /// <summary>
        /// Gets or sets the contact person phone.
        /// </summary>
        /// <value>The contact person phone.</value>
        [Display(Name = "VenueContactPersonPhone", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonPhoneRequired")]
        public string ContactPersonPhone { get; set; }

        /// <summary>
        /// Gets or sets the contact person email.
        /// </summary>
        /// <value>The contact person email.</value>
        //[Display(Name = "VenueContactPersonEmail", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonEmailRequired")]
        //[RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
        //                              ErrorMessageResourceName = "EmailInValid")]


        [Display(Name = "VenueContactPersonEmail", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueContactPersonEmailRequired")]
        [Remote("IsUserWithEmail_Available", "User", ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserEmailAlreadyExist", AdditionalFields = "InitialEmail")]
        [RegularExpression("^([\\w\\.\\-]+)@([a-zA-Z_]+)((\\.(\\w){2,3})+)$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInValid")]

        public string ContactPersonEmail { get; set; }

        /// <summary>
        /// Gets or sets the available from.
        /// </summary>
        /// <value>The available from.</value>
        [Display(Name = "VenueAvailableFrom", ResourceType = typeof(lr))]
        public DateTime? AvailableFrom { get; set; }

        /// <summary>
        /// Gets or sets the available from string.
        /// </summary>
        /// <value>The available from string.</value>
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionStartTimeRequired")]
        [Display(Name = "VenueAvailableFrom", ResourceType = typeof(lr))]
        public string AvailableFromString { get; set; }

        /// <summary>
        /// Gets or sets the available to.
        /// </summary>
        /// <value>The available to.</value>
        [Display(Name = "VenueAvailableTo", ResourceType = typeof(lr))]
        public DateTime? AvailableTo { get; set; }

        /// <summary>
        /// Gets or sets the available to string.
        /// </summary>
        /// <value>The available to string.</value>
        [Display(Name = "VenueAvailableTo", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SessionEndTimeRequired")]
        public string AvailableToString { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is common.
        /// </summary>
        /// <value><c>true</c> if this instance is common; otherwise, <c>false</c>.</value>
        [Display(Name = "VenueIsCommon", ResourceType = typeof(lr))]
        public bool IsCommon { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Display(Name = "AddressAddressOne", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressAddressOneRequired")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(Name = "AddressAddressTwo", ResourceType = typeof(lr))]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        [Display(Name = "AddressZipCode", ResourceType = typeof(lr))]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>The country identifier.</value>
        [Display(Name = "AddressCountry", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressCountryRequired")]
        public long CountryID { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>The state identifier.</value>
        [Display(Name = "AddressStateRegion", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressStateRegionRequired")]
        public long StateID { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        /// <value>The city identifier.</value>
        [Display(Name = "AddressCity", ResourceType = typeof(lr))]
        public long? CityID { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime UpdatedDate { get; set; }

        //
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        //
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }

        public string UpdatedByAlias { get; set; }
    }

    /// <summary>
    /// Class VenueOpenMapping.
    /// </summary>
    public class VenueOpenMapping
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>The venue identifier.</value>
        [Display(Name = "VenueName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "VenueOpenTypeRequired")]
        public long VenueID { get; set; }

        /// <summary>
        /// Gets or sets the open identifier.
        /// </summary>
        /// <value>The open identifier.</value>
        public long OpenId { get; set; }

        /// <summary>
        /// Gets or sets the type of the open.
        /// </summary>
        /// <value>The type of the open.</value>
        public int OpenType { get; set; }

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
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long UpdatedBy { get; set; }

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
        /// Gets or sets the name of the venue.
        /// </summary>
        /// <value>The name of the venue.</value>
        public string VenueName { get; set; }
        /// <summary>
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }

        public class Venue : List<Venues>
        {

        }
    }
}
