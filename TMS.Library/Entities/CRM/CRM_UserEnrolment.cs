using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
    public class CRM_UserEnrolment: IDataMapper
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AddedByAlias { get; set; }
        public int CurrentProspect { get; set; }
        public long UserID { get; set; }
  

        public void MapProperties(DbDataReader dr)
        {
          
          
            AddedByAlias = dr.GetString("AddedByAlias");
            FullName = dr.GetString("FullName");
        //    PersonID = dr.GetInt64("PersonID");
            Email = dr.GetString("Email");

            UserID = dr.GetInt64("UserID");
            CurrentProspect = dr.GetInt32("CurrentProspect");
            //CreatedOn = dr.GetDateTime("CreatedOn");
            //UpdatedBy = dr.GetInt64("UpdatedBy");
            //UpdatedOn = dr.GetDateTime("UpdatedOn");
            //IsDeleted = dr.GetBoolean("IsDeleted");
            //IsActive = dr.GetBoolean("IsActive");
        }
    }
}