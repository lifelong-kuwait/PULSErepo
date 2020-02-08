using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using TMS.Library.Users;
using lr = Resources.Resources;
namespace TMS.Library.Entities.Invoice
{
   public class DepositDetail : IDataMapper
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
        [Display(Name = "InvoiceID", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PrimaryCourseNameRequired")]
        public string Invoice_ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "PaymentType", ResourceType = typeof(lr))]
        public DepositType Payment_Type { get; set; }
        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "PaymentType", ResourceType = typeof(lr))]
        public string  Payment_Type_Value
        {
            get
            {
                return Payment_Type != null ? Fd.GetDisplayName(Payment_Type) : "NotSpecified";
            }
        }

        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        [Display(Name = "Detail", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public string Detail { get; set; }


        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "Payment", ResourceType = typeof(lr))]
        /// 
        public double Payment { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "TotalPayment", ResourceType = typeof(lr))]
        /// 
        public double Total_Payment { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "Balance", ResourceType = typeof(lr))]
        public double Balance { get; set; }
        
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(Name = "CreatedBy", ResourceType = typeof(lr))]
        public long Created_By { get; set; }

        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        [Display(Name = "CreatedDate", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public DateTime Created_Date { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public long Updated_By { get; set; }
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        //[Display(Name = "CourseMinimumAttendanceRequirement", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public DateTime Updated_Date { get; set; }
        /// <summary>
        /// Gets or sets the PreRequisites.
        /// </summary>
        /// <value>The  PreRequisites.</value>
       // [Display(Name = "CoursePreRequisites", ResourceType = typeof(lr))]
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

        public string usersAddedBy { get; set; }
        public void MapProperties(System.Data.Common.DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Invoice_ID = dr.GetString("Invoice_ID");
            Payment_Type = (DepositType)dr.GetByte("Payment_Type");
            Detail = dr.GetString("Detail");
            Payment = dr.GetDouble("Payment");
            Total_Payment = dr.GetDouble("Total_Payment");
            Balance = dr.GetDouble("Balance");
            Created_By = dr.GetLong("Created_By");
            Updated_By = dr.GetLong("Updated_By"); 
             Created_Date = dr.GetDateTime("Created_Date");
            Updated_Date = dr.GetDateTime("Updated_Date");
            Organization_ID = dr.GetLong("Organization_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
        }
    }
}
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
