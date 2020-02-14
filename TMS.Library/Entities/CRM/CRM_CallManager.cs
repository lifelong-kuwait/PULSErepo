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
   public class CRM_CallManager : IDataMapper
    {
       
        public long ID { get; set; }
        [Display(Name = "PerformedBy", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "InvoiceNumberRequired")]
        public string PerformedBy { get; set; }
        public long PersonID { get; set; }
        [Display(Name = "GridAddedBy", ResourceType = typeof(lr))]

        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        [Display(Name = "Notes", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "NotesReqired")]
        public string Notes { get; set; }
        public string CallTimes { get; set; }
        [Display(Name = "AssignedTo", ResourceType = typeof(lr))]
        public long AssignedTo { get; set; }
        public long? AssignedBy { get; set; }
        [Display(Name = "CallType", ResourceType = typeof(lr))]
        public Calltype CallType { get; set; }
        [Display(Name = "CallTime", ResourceType = typeof(lr))]
        public DateTime CallTime { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            PerformedBy = dr.GetString("PerformedBy");
            Notes = dr.GetString("Notes");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            CallTimes = dr.GetString("CallTimes");
            PersonID = dr.GetInt64("PersonID");
            AssignedTo = dr.GetInt64("AssignedTo");
            AssignedBy = dr.GetInt64("AssignedBy");
            CallType =(Calltype)dr.GetByte("CallType");
            CallTime = dr.GetDateTime("CallTime");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}

