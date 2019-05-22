using System;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.Entities.Common.Roles
{
    //RolesPrimaryNameDuplicateRole
    public class Roles
    {
        public long ID { get; set; }

        [Display(Name = "RolesPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "RolesPrimaryNameRequired")]
        public string RolePrimaryName { get; set; }

        [Display(Name = "RolesSecondaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "RolesSecondaryNameRequired")]
        public string RoleSecondaryName { get; set; }

        [Display(Name = "RolesIsDefaultTrainer", ResourceType = typeof(lr))]
        public bool IsDefaultTrainer { get; set; }

        public long OrganizationID { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public long UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }

    }

    public class TrainerOpenMapping
    {
        public long ID { get; set; }
        [Display(Name = "Trainer", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "TrainerRequired")]
        public long PersonID { get; set; }

        public long OpenId { get; set; }

        public int OpenType { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
        public string PersonName { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        
    }

}