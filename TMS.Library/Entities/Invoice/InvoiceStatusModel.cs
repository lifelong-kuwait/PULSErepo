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
   public class InvoiceStatusModel : IDataMapper
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
        public long Invoice_ID { get; set; }

        

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
        [Display(Name = "StatusName", ResourceType = typeof(lr))]

        public string Status_Name { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "Description", ResourceType = typeof(lr))]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "CreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(Name = "CreatedDate", ResourceType = typeof(lr))]
        public DateTime CreatedDate { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        
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

        public string usersName { get; set; }
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Invoice_ID = dr.GetLong("Invoice_ID");
            Type = (InvoiceStatus)dr.GetByte("Type");
            Description = dr.GetString("Description");
            CreatedBy = dr.GetLong("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetLong("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            Organization_ID = dr.GetLong("Organization_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDeleted = dr.GetBoolean("IsDeleted");
        }
    }
}
