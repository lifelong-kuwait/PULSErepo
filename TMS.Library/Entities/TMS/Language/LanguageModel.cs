using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.TMS.Language
{
   public class LanguageModel: IDataMapper
    {
      //  public System.Web.SessionState.HttpSessionState Session { get; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public bool? IsDefault { get; set; }
        public string Name { get; set; }
        public long? CompnayID { get; set; }


        public void MapProperties(DbDataReader dr)
        {
            DisplayName = dr.GetString("DisplayName");
            Icon = dr.GetString("Icon");
            IsDefault = false;//dr.GetBoolean("IsDefault");
            Name = dr.GetString("Name");
            CompnayID = dr.GetInt64Nullable("OrganizationID");
        }
    }
}
