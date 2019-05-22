using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
   public class CRM_PersonEnrolment : IDataMapper
    {
        public string AssignedBy { get; set; }
        public string FullName { get; set; }
        public string AssignedTo { get; set; }
        public string AddedByAlias { get; set; }
        public long PersonID { get; set; }
        public long UserID { get; set; }

        public void MapProperties(DbDataReader dr)
        {


            AddedByAlias = dr.GetString("AddedByAlias");
            FullName = dr.GetString("FullName");
            AssignedTo = dr.GetString("AssignedTo");
            AssignedBy = dr.GetString("AssignedBy");
            UserID = dr.GetInt64("UserID");
            //     Email = dr.GetString("Email");

            PersonID = dr.GetInt64("PersonID");
            //CreatedBy = dr.GetInt64("CreatedBy");
            //CreatedOn = dr.GetDateTime("CreatedOn");
            //UpdatedBy = dr.GetInt64("UpdatedBy");
            //UpdatedOn = dr.GetDateTime("UpdatedOn");
            //IsDeleted = dr.GetBoolean("IsDeleted");
            //IsActive = dr.GetBoolean("IsActive");
        }
    }
}