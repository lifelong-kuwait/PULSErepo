using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
  public class CRMHowHeardMapping : IDataMapper
    {
        public long ID { get; set; }
        public string OptionName { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        
        public long PersonID { get; set; }
        public long HowHeardID { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn  { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            OptionName = dr.GetString("OptionName");
            AddedByAlias = dr.GetString("AddedByAlias");
            PersonID = dr.GetInt64("PersonID");
            HowHeardID = dr.GetInt64("HowHeardID");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}

   