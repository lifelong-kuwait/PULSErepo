using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.Jobs
{
    public class JobReferance:IDataMapper
    {
        //[ID]
        public long ID { get; set; }

      //,[PersonID]
        public long PersonID { get; set; }

      //,[ReferName]
        public string ReferName { get; set; }
      //,[JobTitle]
        public string JobTitle { get; set; }
      //,[Relation]
        public string Relation { get; set; }
      //,[PhoneNumber]
        public string PhoneNumber { get; set; }
     // ,[Company]
        public string Company { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            PersonID = dr.GetLong("PersonID");
            ReferName = dr.GetString("ReferName");
            JobTitle = dr.GetString("JobTitle");
            Relation = dr.GetString("Relation");
            PhoneNumber = dr.GetString("PhoneNumber");
            Company = dr.GetString("Company");
        }
    }
}
