using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
   public class CRM_EnrolmentHistory : IDataMapper
    {
        public long ID { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
      
        public string AddedByAlias { get; set; }
        public long PersonID { get; set; }
        public long UserID { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public void MapProperties(DbDataReader dr)
        {


            AddedByAlias = dr.GetString("AddedByAlias");
            FullName = dr.GetString("FullName");
            //AssignedTo = dr.GetString("AssignedTo");
            RoleName = dr.GetString("RoleName");
            UserID = dr.GetInt64("UserID");
            ID = dr.GetInt64("ID");

            PersonID = dr.GetInt64("PersonID");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}

