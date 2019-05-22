

namespace ReportingClassLibrary
{
    using TMS.Business.Interfaces.TMS;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using TMS.Library.TMS.Persons;
    using TMS.Business.TMS.Report;

    /// <summary>
    /// Summary description for TrainarDetailReport.
    /// </summary>
    public partial class TrainarDetailReport : Telerik.Reporting.Report
    {
        //protected IReportBAL _ReportBAL;
        //protected readonly IPersonBAL _PersonBAL;
        public TrainarDetailReport()
        {
            InitializeComponent();
            //this.DataSource = Report_GetALLBAL(_ReportBAL);
        }

        //public IList<Person> Report_GetALLBAL(IReportBAL objReportBAL)
        //{
        //    _ReportBAL = objReportBAL;
        //    if (objReportBAL == null)
        //    {
        //        objReportBAL = new ReportBAL();
        //        _ReportBAL = objReportBAL;
        //    }
        //    //TrainerDetailReport(_ReportBAL);
        //    return _ReportBAL.Report_GetALLBAL();
        //}

    }
}


//namespace TMS.Web.controllers
//{

//    using System;
//    using System.Linq;
//    using TMS.Business.Interfaces.TMS;
//    using System.Windows.Forms;
//    using ReportingClassLibrary;
//    using Library.TMS.Persons;
//    using System.Collections.Generic;

//    public class TrainarDetailReportController : BaseCollection
//    {
//        private IReportBAL _ReportBAL;
//        private readonly IPersonBAL _PersonBAL;

//        public TrainarDetailReportController(IReportBAL objReportBal)
//        {
//            _ReportBAL = objReportBal;
//            //Report_GetALLBAL();
//        }


//        public IList<Person> Report_GetALLBAL()
//        {
//            var _report = _ReportBAL.Report_GetALLBAL();
//            return _report;
//        }

//    }
//}


