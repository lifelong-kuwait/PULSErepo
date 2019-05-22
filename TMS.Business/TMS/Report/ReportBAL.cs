using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Interfaces.TMS;
using TMS.DataObjects.TMS;
using TMS.Library.TMS.Persons;

namespace TMS.Business.TMS.Report
{
    public class ReportBAL:IReportBAL
    {
        private readonly IReportDAL DAL;

        public ReportBAL()
        {
            DAL = new ReportDAL();
        }
        public IList<Person> Report_GetALLBAL()
        {
            return DAL.Report_GetALLDAL();
        }
    }
}
