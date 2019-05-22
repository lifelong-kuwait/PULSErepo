using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.Interfaces.TMS
{
    public interface IReportDAL
    {

        IList<Person> Report_GetALLDAL();
    }
}
