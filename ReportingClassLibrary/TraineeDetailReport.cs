namespace ReportingClassLibrary
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for TraineeDetailReport.
    /// </summary>
    public partial class TraineeDetailReport : Telerik.Reporting.Report
    {
        public TraineeDetailReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            con.ConnectionString = "data source=WIN-KPPK5C12UBS;initial catalog=TMS_GUST;integrated security=True;Pooling=False";
            cmd.CommandText = "SELECT P_DisplayName AS AddedByAlias,DateOfBirth,PersonRegCode,CreatedDate FROM dbo.Person p  WHERE p.IsDeleted = 0 AND p.IsActive = 1";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            this.DataSource = da;
        }
    }
}