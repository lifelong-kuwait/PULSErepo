using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using TMS.Library.Users;
using lr = Resources.Resources;
namespace TMS.Library.Entities.Invoice
{
    public class InvoiceHistory : IDataMapper
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
        [Display(Name = "InvoiceNumber", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PrimaryCourseNameRequired")]
        public long Invoice_Number { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
        [Display(Name = "HistoryName", ResourceType = typeof(lr))]
        public string History_Name { get; set; }

        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        //[Display(Name = "Type", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public InvoiceStatus Type { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "Description", ResourceType = typeof(lr))]
         public string Description { get; set; }
       
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        //[Display(Name = "CourseNotes", ResourceType = typeof(lr))]
        public long User_ID { get; set; }

        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        //[Display(Name = "CourseMinimumAttendanceRequirement", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public DateTime Date_TIME { get; set; }
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
       
        public string usersHistory { get; set; }
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Invoice_Number = dr.GetLong("Invoice_Number");
            History_Name = dr.GetString("History_Name");
            Type = (InvoiceStatus)dr.GetByte("Type");
            Description = dr.GetString("Description");
            User_ID = dr.GetLong("User_ID");
            Date_TIME = dr.GetDateTime("Date_TIME");
            Organization_ID = dr.GetLong("Organization_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
        }
    }
}
