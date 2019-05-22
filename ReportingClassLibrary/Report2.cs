namespace TelerikReportLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;
    using System.Web.Mvc;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report2.
    /// </summary>
    public partial class Report2 : Telerik.Reporting.Report
    {
        public Report2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            

            //SqlConnection con = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            //con.ConnectionString = "data source=WIN-KPPK5C12UBS;initial catalog=TMS_GUST;integrated security=True;Pooling=False";
            //cmd.CommandText = "SELECT ID, P_DisplayName AS AddedByAlias,DateOfBirth,PersonRegCode,CreatedDate FROM dbo.Person p  WHERE p.IsDeleted = 0 AND p.IsActive = 1";
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //this.DataSource = da;
        }
    }

    //public class dummyPersonModel
    //{
    //    public int ID { get; set; }
    //    public string AddedByAlias { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public string PersonRegCode { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public List<SelectListItem> GetAllPerson { get; set; }
    //}

    //public class dummyPersonViewModel
    //{


    //    readonly List<dummyPersonModel> Persons;

    //    [Display(Name = "Persones")]
    //    public int SelectedPersonId { get; set; }

    //    public string SelectedPerson
    //    {
    //        get { return this.Persons[this.SelectedPersonId].AddedByAlias; }
    //    }

    //    public IEnumerable<SelectListItem> PersonItems
    //    {
    //        get { return new SelectList(Persons, "ID", "AddedByAlias"); }
    //    }

    //    public dummyPersonViewModel(List<dummyPersonModel> persons)
    //    {
    //        this.Persons = persons;
    //    }
    //}

}