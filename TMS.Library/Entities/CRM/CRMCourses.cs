using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Entities.CRM
{
   public class CRMCourses: IDataMapper
    {
      //  public System.Web.SessionState.HttpSessionState Session { get; }
        public long ID { get; set; }
        [Display(Name = "CRM_PCourseName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PrimaryCourseNameRequired")]
        public string PrimaryCourseName { get; set; }
        [Display(Name = "CRM_SCourseName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "SecondaryCourseNameRequired")]
        public string SecondaryCourseName { get; set; }
        [Display(Name = "CRM_Description", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "DescriptionRequired")]

        public string Description { get; set; }
        public long OrganizationID { get; set; }
        public long? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? ModifiedOn { get; set; }

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
        /// Gets or sets the added by alias.
        /// </summary>
        /// <value>The added by alias.</value>
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }

        
        public void MapProperties(DbDataReader dr)
    {
         ID = dr.GetInt64("ID");
        PrimaryCourseName = dr.GetString("PrimaryCourseName");
        SecondaryCourseName = dr.GetString("SecondaryCourseName");
        Description = dr.GetString("Description");
        OrganizationID = dr.GetInt64("OrganizationID");
        CreatedBy = dr.GetInt64("CreatedBy");
        ModifiedBy = dr.GetInt64("ModifiedBy");
        ModifiedOn = dr.GetDateTime("ModifiedOn");
        CreatedDate= dr.GetDateTime("CreatedOn");
        AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            IsDeleted = dr.GetBoolean("IsDeleted");
        Description = dr.GetString("Description");
       IsActive = dr.GetBoolean("IsActive");
        }
}
}