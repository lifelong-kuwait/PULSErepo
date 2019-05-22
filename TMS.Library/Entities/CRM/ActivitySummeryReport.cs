using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library.Entities.CRM
{
    public class ActivitySummeryReport : IDataMapper
    {
        public long ID { get; set; }
        public string DelayedVisits { get; set; }
        public string IncomingVisits { get; set; }
        public string OutgoingVisits { get; set; }
        public string DelayedCalls { get; set; }
        public string IncomingCalls { get; set; }
        public string OutgoingCalls { get; set; }
        public string ForwardedCalls { get; set; }
        public string Name { get; set; }
        


        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            DelayedVisits = dr.GetString("DelayedVisits");
            IncomingVisits = dr.GetString("IncomingVisits");
            OutgoingVisits = dr.GetString("OutgoingVisits");
            DelayedCalls = dr.GetString("DelayedCalls");
            Name = dr.GetString("Name");
            IncomingCalls = dr.GetString("IncomingCalls");
            ForwardedCalls = dr.GetString("ForwardedCalls");
            OutgoingCalls = dr.GetString("OutgoingCalls");


        }
    }
}

