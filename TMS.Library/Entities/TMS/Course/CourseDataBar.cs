using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.TMS.Course
{
  public  class CourseDataBar : IDataMapper
    {
        public string month { get; set; }
        public int CourseCount { get; set; }
        public string  customColor { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            CourseCount = dr.GetInt32("CoursesCount");
        }
    }

}