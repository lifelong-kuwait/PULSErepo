﻿using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;
using TMS.Library.Users;
using TMS.Library.TMS.Organization;
using TMS.Library.ModelMapper;
using System.Data.Common;

namespace TMS.Library.Entities.Invoice
{
    public class InvoiceChanges : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }


        /// <summary>
        /// Gets or sets the name of the primary.
        /// </summary>
        /// <value>The name of the primary.</value>
        //[Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CustomerPrimaryNameRequired")]
        public long Invoice_ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        //[Display(Name = "CustomerSecondaryName", ResourceType = typeof(lr))]
        public double Old_Sub_total { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        //[Display(Name = "PersonP_MiddleName", ResourceType = typeof(lr))]
        public double Old_Net_Value { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        //[Display(Name = "PersonP_LastName", ResourceType = typeof(lr))]
        public double Old_Tax_Value { get; set; }
        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>Customer_Type
        /// <value>The course category identifier.</value>
        //[Display(Name = "CustomerType", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CustomerTypeRequired")]
        public TaxType Old_Tax_Type { get; set; }
        //[Display(Name = "UserEmail", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserEmailRequired")]
        //[RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInValid")]
        public double Old_Tax_Percentage { get; set; }
        //[Display(Name = "PersonPhoneNumber", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonPhoneNumberRequired")]
        public double Old_Discount { get; set; }
        public double Old_Discount_Vlaue { get; set; }
        public long Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        /// <summary>
        /// Gets or sets the minimum trainee.
        /// </summary>
        /// <value>The minimum trainee.</value>
        //[Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
        public long Organization_ID { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public bool IsDeleted { get; set; }

        public LoginUsers Creator { get; set; }
     
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Invoice_ID = dr.GetLong("Invoice_ID");
            Old_Sub_total = dr.GetDouble("Old_Sub_total");
            Old_Net_Value = dr.GetDouble("Old_Net_Value");
            Old_Tax_Value = dr.GetDouble("Old_Tax_Value");
            Old_Tax_Type =(TaxType) dr.GetByte("Old_Tax_Type");
            Old_Tax_Percentage = dr.GetDouble("Old_Tax_Percentage");
            Old_Discount = dr.GetDouble("Old_Discount");
            Old_Discount_Vlaue = dr.GetDouble("Old_Discount_Vlaue");
            Created_By = dr.GetLong("Created_By");
            Created_Date = dr.GetDateTime("Created_Date");
            Organization_ID = dr.GetLong("Organization_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
        }
    }
}
