using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
    public class CRM_CourseMapping : IDataMapper
    {
        public long ID { get; set; }
        public string CourseName { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        public long PersonID { get; set; }
        public long CourseID { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            CourseName = dr.GetString("CourseName");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias= dr.GetString("UpdatedByAlias");
            PersonID = dr.GetInt64("PersonID");
            CourseID = dr.GetInt64("CourseID");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedOn = dr.GetDateTime("CreatedOn");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedOn = dr.GetDateTime("UpdatedOn");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
        }
    }
}
