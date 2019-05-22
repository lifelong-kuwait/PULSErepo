namespace TMS.Web.Reports
{
    using Business.Interfaces.TMS;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report2.
    /// </summary>
    public partial class Report2 : Telerik.Reporting.Report
    {

        private readonly IPersonBAL _PersonBAL;
        public Report2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
            var _person = _PersonBAL.Person_GetALLBAL_Report();
            this.DataSource = _person;
        }
    }
}