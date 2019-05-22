namespace ReportingClassLibrary
{
    using TMS.Business.Interfaces.TMS;
    using TMS.Library.TMS.Persons;
    using System;
    using TMS.Business.TMS.Report;
    using TMS.DataObjects.Generics;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for TrainerDetailReport.
    /// </summary>
    public partial class TrainerDetailReport : Telerik.Reporting.Report
    {
        protected  IReportBAL _ReportBAL;
        protected readonly IPersonBAL _PersonBAL;
        public TrainerDetailReport()
        {
            InitializeComponent();
            //Bind(_PersonBAL);
            this.DataSource= Report_GetALLBAL(_ReportBAL);
        }

        public TrainerDetailReport(IReportBAL objReportBAL)
        {
            //InitializeComponent();
            _ReportBAL = objReportBAL;
            //Report_GetALLBAL();
            //Bind();
        }

        public void Bind()
        {
            var _report = _ReportBAL.Report_GetALLBAL();
            this.DataSource = _report;
        }

        public IList<Person> Report_GetALLBAL(IReportBAL objReportBAL)
        {
            _ReportBAL = objReportBAL;
            if(objReportBAL == null)
            {
                objReportBAL = new ReportBAL();
                _ReportBAL = objReportBAL;
            }
            //TrainerDetailReport(_ReportBAL);
            return _ReportBAL.Report_GetALLBAL();
        }
    }
}