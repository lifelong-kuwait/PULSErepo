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
  public  class CRM_VisitHistory : IDataMapper
    {
        public long ID { get; set; }
        public long PersonID { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        
        public string PerformedBy { get; set; }
        [Display(Name = "Notes", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "NotesReqired")]
        public string Notes { get; set; }
        public long AssignedTo { get; set; }
        public long? AssignedBy { get; set; }
        [Display(Name = "VisitType", ResourceType = typeof(lr))]
        public Visittype VisitType { get; set; }
        [Display(Name = "VisitDateTime", ResourceType = typeof(lr))]
        public DateTime VisitDateTime { get; set; }
        public string VisitDateTimes { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
          //  PerformedBy = dr.GetString("PerformedBy");
            Notes = dr.GetString("Notes");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            VisitDateTimes = dr.GetString("VisitDateTimes");
            PersonID = dr.GetInt64("PersonID");
            AssignedTo = dr.GetInt64("AssignedTo");
            PerformedBy = dr.GetString("PerformedBy");
        AssignedBy = dr.GetInt64("AssignedBy");
            VisitType = (Visittype)dr.GetByte("VisitType");
            VisitDateTime = dr.GetDateTime("VisitDateTime");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}

