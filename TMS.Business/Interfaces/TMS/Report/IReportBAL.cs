using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Persons;

namespace TMS.Business.Interfaces.TMS
{
    public interface IReportBAL
    {
        IList<Person> Report_GetALLBAL();
    }
}
