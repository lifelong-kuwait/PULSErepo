using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Library.Entities.TMS.Program
{
  public  class TRainerDetail
    {
        public long TrainerID { get; set; }
        public long ClssID { get; set; }
        public string FullName { get; set; }
        public string PersonRegCode { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
