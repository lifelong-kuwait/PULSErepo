using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;
using TMS.Library.Users;
using TMS.Library.TMS.Organization;
using TMS.Library.ModelMapper;
using System.Data.Common;

namespace TMS.Library.Entities.Invoice
{
   public class Customer : IDataMapper
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
        [Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CustomerPrimaryNameRequired")]
        public string Customer_PName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "CustomerSecondaryName", ResourceType = typeof(lr))]
        public string Customer_SName { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
         [Display(Name = "PersonP_MiddleName", ResourceType = typeof(lr))]
        public string Customer_MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "PersonP_LastName", ResourceType = typeof(lr))]
        public string Customer_LastName { get; set; }
        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>Customer_Type
        /// <value>The course category identifier.</value>
        [Display(Name = "CustomerType", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CustomerTypeRequired")]
        public CustomerType Customer_Type { get; set; }
        [Display(Name = "UserEmail", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "UserEmailRequired")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessageResourceType = typeof(Resources.Resources),ErrorMessageResourceName = "EmailInValid")]
        public string Email { get; set; }
        [Display(Name = "PersonPhoneNumber", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PersonPhoneNumberRequired")]
        public string PersonContact { get; set; }
        public string Detail { get; set; }
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

        public string Creator { get; set; }
        public string OrganizationName { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Customer_PName = dr.GetString("Customer_PName");
            Customer_SName = dr.GetString("Customer_SName");
            Customer_MiddleName = dr.GetString("Customer_MiddleName");
            Customer_LastName = dr.GetString("Customer_LastName");
            Customer_Type = (CustomerType)dr.GetInt32("Customer_Type");
            Email = dr.GetString("Email");
            PersonContact = dr.GetString("PersonContact");
            Detail = dr.GetString("Detail");
            Created_By = dr.GetLong("Created_By");
            Created_Date = dr.GetDateTime("Created_Date");
            Organization_ID = dr.GetLong("Organization_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
            Creator = dr.GetString("Creator");
            OrganizationName = dr.GetString("OrganizationName");
        }
    }

}