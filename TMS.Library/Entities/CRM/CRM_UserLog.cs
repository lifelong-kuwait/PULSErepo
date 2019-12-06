using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;
using TMS.Library.TMS.Organization;
using TMS.Library.Users;

namespace TMS.Library.Entities.CRM
{
   public  class CRM_UserLog : IDataMapper
    {

        public long ID { get; set; }
        public DateTime? Date { get; set; }
        public long? OrganizationID { get; set; }
        public string Levels { get; set; }
        public string MachineName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public long? UserID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; }
        public bool isResolved { get; set; }
        public DateTime? ResolvedData { get; set; }
        public long? ResolvedBy { get; set; }
        public string ResolverName { get; set; }
        public string OrgName { get; set; }

        public string UserName { get; set; }


        public OrganizationModel organizationModel { get; set; }
       public LoginUsers users { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("Id");
            Date = dr.GetDateTime("Date");
            OrganizationID = dr.GetInt64("OrganizationID");
            Levels = dr.GetString("Levels");
            MachineName = dr.GetString("MachineName");
            Message = dr.GetString("Message");
            Exception = dr.GetString("Exception");
            UserID = dr.GetInt64("UserID");
            Controller = dr.GetString("Controller");
            Action = dr.GetString("Action");
            Parameter = dr.GetString("Parameter");
            isResolved = dr.GetBoolean("isResolved");
            ResolvedData = dr.GetDateTime("ResolvedData");
            ResolvedBy = dr.GetInt64("ResolvedBy");
            ResolverName = dr.GetString("ResolverName");
            OrgName = dr.GetString("OrgName");
            UserName = dr.GetString("UserName");

        }
    }

}
