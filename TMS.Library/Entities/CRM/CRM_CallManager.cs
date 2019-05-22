using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
   public class CRM_CallManager : IDataMapper
    {
        public long ID { get; set; }
        public string PerformedBy { get; set; }
        public long PersonID { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        
        public string Notes { get; set; }
        public string CallTimes { get; set; }
        public long AssignedTo { get; set; }
        public long? AssignedBy { get; set; }       
        public Calltype CallType { get; set; }
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

