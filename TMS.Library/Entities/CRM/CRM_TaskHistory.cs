using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
   public class CRM_TaskHistory : IDataMapper
    {
       
        public long ID { get; set; }
        public DateTime? TaskDate { get; set; }
        public long AssignedBy { get; set; }
        public long AssignedTo { get; set; }
        public Int32 Status { get; set; }
        public string AddedByAlias { get; set; }
     //   public string UpdatedByAlias { get; set; }
        
        public long TaskID { get; set; }
        public int TaskType { get; set; }
        public long CreatedBy { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        //{
        //    get
        //    {
        //        return TaskType != null ? Fd.GetDisplayName(TaskType) : "NotSpecified";
        //    }
        //}
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            TaskDate = dr.GetDateTime("TaskDate");
            AssignedBy = dr.GetInt64("AssignBy");
            TaskID = dr.GetInt64("TaskID");
            AssignedTo = dr.GetInt64("AssignTo");       
            Status = dr.GetInt32("Status");
            AddedByAlias = dr.GetString("AddedByAlias");
           // UpdatedByAlias = dr.GetString("UpdatedByAlias");
            Description = dr.GetString("Description");           
            TaskType = dr.GetInt32("TaskType");         
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UserName = dr.GetString("UserName");
            
        }
    }

}
