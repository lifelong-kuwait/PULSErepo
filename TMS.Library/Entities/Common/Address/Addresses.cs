// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-24-2017
// ***********************************************************************
// <copyright file="Addresses.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library
{
    /// <summary>
    /// Class Addresses.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class Addresses : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

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
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is billing address.
        /// </summary>
        /// <value><c>true</c> if this instance is billing address; otherwise, <c>false</c>.</value>
        public bool IsBillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>The country identifier.</value>
        [Display(Name = "AddressCountry", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressCountryRequired")]
        public long CountryID { get; set; }

        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        /// <value>The type of the address.</value>
        [Display(Name = "AddressType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressTypeRequired")]
        public AddressType AddressType { get; set; }

        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>The state identifier.</value>
        [Display(Name = "AddressStateRegion", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AddressStateRegionRequired")]
        public long StateID { get; set; }

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
        public bool IsActive { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            AddressLine1 = dr.GetString("AddressLine1");
            AddressLine2 = dr.GetString("AddressLine2");
            ZipCode = dr.GetString("ZipCode");
            City = dr.GetString("City");
            CityID = dr.GetInt32("CityID");
            State = dr.GetString("State");
            StateID = dr.GetInt32("StateID");
            IsBillingAddress = dr.GetBoolean("IsBillingAddress");
            Country = dr.GetString("Country");
            CountryID = dr.GetInt32("CountryID");
            AddressType = (AddressType)dr.GetInt32("AddressType");
            CreatedDate = dr.GetDateTime("CreatedDate");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}