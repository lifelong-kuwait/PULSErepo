using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Common.Groups
{
    public class SecurityGroups : IDataMapper
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }

        [Display(Name = "GroupsPrimaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GroupsPrimaryNameRequired")]
        public string PrimaryGroupName { get; set; }

        [Display(Name = "GroupsSecondaryName", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "GroupsSecondaryNameRequired")]
        public string SecondaryGroupName { get; set; }

        [Display(Name = "GroupsIsDeleteAllowed", ResourceType = typeof(lr))]
        public bool IsDeleteAllowed { get; set; }

        public long OrganizationID { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public IList<GroupsPermission> Permission { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        

        public void MapProperties(DbDataReader dr)
        {
            GroupId = dr.GetInt64("GroupId");
            PrimaryGroupName = dr.GetString("PrimaryGroupName");
            SecondaryGroupName = dr.GetString("SecondaryGroupName");
            IsDeleteAllowed = dr.GetBoolean("IsDeleteAllowed");
            OrganizationID = dr.GetInt64("OrganizationID");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
        }
    }
}