using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.TMS.Persons
{
   public class PersonBarData : IDataMapper
    {
        public string month { get; set; }
        public int person { get; set; }
        public int trainer { get; set; }
        public int trainee { get; set; }
        public void MapProperties(DbDataReader dr)
        {
            person = dr.GetInt32("PersonCount");
            trainer = dr.GetInt32("TrainerCount");
            trainee = dr.GetInt32("TraineeCount");
        }
    }

}
