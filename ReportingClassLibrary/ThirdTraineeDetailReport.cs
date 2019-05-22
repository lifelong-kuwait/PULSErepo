namespace ReportingClassLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ThirdTraineeDetailReport.
    /// </summary>
    public partial class ThirdTraineeDetailReport : Telerik.Reporting.Report
    {
        public ThirdTraineeDetailReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //Telerik.Reporting.Filter filter1 = new Telerik.Reporting.Filter();
            //filter1.Expression = "=Fields.CreatedDate";
            //filter1.Operator = Telerik.Reporting.FilterOperator.GreaterThan;
            //filter1.Value = "=10/12/2017";

            //Report.Filters.Add(filter1);
        }
    }
}