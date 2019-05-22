using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.TMS.Admin.Config;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.TMS
{
    public class ReportDAL: DBGenerics,IReportDAL
    {
        public IList<Person> Report_GetALLDAL()
        {
           // var _PersonData = ExecuteLists<Person>("TMS_Person_GetTrainerDetailsForReports");
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var _PersonData = ExecuteListSp<Person>(@"TMS_Person_GetTrainerDetailsForReports", ParamBuilder.Par("FlagDateTime", date));
            foreach (var single in _PersonData)
            {
                if (single.FlagCount > 0)
                {
                    single.Flags = ExecuteListSp<PersonFlagsNested>(@"TMS_PersonFlags_GetAllFlagIDs", ParamBuilder.Par("FlagIDs", single.FlagIDs));
                }
            }
            return _PersonData;
        }
      
    }
}
