using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.TMS.Program
{
    public class SessionWeekBarData : IDataMapper
    {
        public string week { get; set; }
        public int sessionsCount { get; set; }
        public string customColor { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            sessionsCount = dr.GetInt32("SessionsCount");
        }
    }

}
