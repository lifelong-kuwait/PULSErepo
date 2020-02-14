using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.Task
{
    public class Sls_Task : IDataMapper
    {
        public class Users
        {
           
            public long UserID { get; set; }
            public string P_FirstName { get; set; }
            public string P_LastName { get; set; }
        }


        public Sls_Task()
        {
            this.User = new List<Users>();
            this.User1 = new List<Users>();
        }

        [Display(Name = "Users", ResourceType = typeof(lr))]
        public List<Users> User { get; set; }

        [Display(Name = "User1", ResourceType = typeof(lr))]
        public List<Users> User1 { get; set; }

        public long ID { get; set; }
        [Display(Name = "Prospect", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ProspectRequired")]
        public string LeadID { get; set; }
        //public long LeadIDs { get; set; }
      //  public long ProspectID { get; set; }
        public DateTime DueDate { get; set; }
        [Display(Name = "AssignedBy", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ProspectRequired")]
        public long AssignedBy { get; set; }
        [Display(Name = "AssignedTo", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "AssignedToReqired")]
        public long AssignedTo { get; set; }
        public long ActionID { get; set; }
        public long OrganizationID { get; set; }
        public Int32 Status { get; set; }
        [Display(Name = "Description", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "DescriptionRequired")]

        public string Description { get; set; }
        public string UserName { get; set; }
        public int TaskType { get; set; }
        public DateTime CompletionTime { get; set; }
        public Boolean IsComplete { get; set; }
        public Boolean IsDraft { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsActive { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }

    public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");

            LeadID = dr.GetString("LeadID");
            //ProspectID = dr.GetInt64("ProspectID");
            
            DueDate = dr.GetDateTime("DueDate");
            AssignedBy = dr.GetInt64("AssignedBy");
            AssignedTo = dr.GetInt64("AssignedTo");
            OrganizationID = dr.GetInt64("OrganizationID");
            Status = dr.GetInt32("Status");
            Description = dr.GetString("Description");
            UserName = dr.GetString("UserName");           
            TaskType = dr.GetInt32("TaskType");
            CompletionTime = dr.GetDateTime("CompletionTime");
            IsComplete = dr.GetBoolean("IsComplete");
            IsDraft = dr.GetBoolean("IsDraft");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            ModifiedBy = dr.GetInt64("ModifiedBy");
            ModifiedOn = dr.GetDateTime("ModifiedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            AddedByAlias= dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            
        }
    }

}
