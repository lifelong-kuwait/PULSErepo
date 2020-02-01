﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Web.Views.Report.SpLReports
{
    public class ReportData
    {
        public ReportData()
        {
            this.ReportParameters = new List<Parameter>();
            this.DataParameters = new List<Parameter>();
        }

        public bool IsLocal { get; set; }
        public string ReportName { get; set; }
        public List<Parameter> ReportParameters { get; set; }
        public List<Parameter> DataParameters { get; set; }
    }

    public class Parameter
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
    }
}