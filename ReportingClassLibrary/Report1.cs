namespace TelerikReportLibrary
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class Report1 : Telerik.Reporting.Report
    {
        public Report1(string invoiceNumber)
        {

            InitializeComponent();

            //SqlConnection sqlConnection = new SqlConnection();
            //SqlCommand sqlCommand = new SqlCommand();
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            //sqlConnection.ConnectionString = "Data Source=(local);Initial Catalog=ZssDcposDat;" +
            //                                  "Integrated Security=True;MultipleActiveResultSets=True";

            //sqlCommand.CommandText = "SELECT ItemDesc,Price,Qty, Total FROM InvoiceLine where InvoiceNo ='" + invoiceNumber + "'";

            //sqlCommand.Connection = sqlConnection;

            //sqlDataAdapter.SelectCommand = sqlCommand;

            //this.DataSource = sqlDataAdapter;
        }
    }
}