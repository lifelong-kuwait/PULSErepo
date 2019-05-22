namespace TelerikReportLibrary
{
    partial class Report2
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.objectDataSource2 = new Telerik.Reporting.ObjectDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.sqlDataSource12 = new Telerik.Reporting.SqlDataSource();
            this.objectDataSource3 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataMember = "DDlQuery";
            this.objectDataSource2.DataSource = typeof(ReportingClassLibrary.TestReportFactory);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BackgroundColor = System.Drawing.Color.Linen;
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox7.Value = "Name";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox8.Value = "Date of Birth";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox9.Value = "Code No.";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8999608755111694D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox10.Value = "Created Date";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.10000002384185791D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8002350926399231D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox11.Value = "Reg";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox2});
            this.detail.Name = "detail";
            this.detail.Style.BackgroundColor = System.Drawing.Color.Azure;
            this.detail.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox3.Value = "=Fields.AddedByAlias";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:g}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox4.Value = "=Fields.DateOfBirth";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox5.Value = "=Fields.PersonRegCode";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0:D}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8999608755111694D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox6.Value = "=Fields.CreatedDate";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6999993324279785D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80023574829101562D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox2.Value = "=Fields.ID";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // sqlDataSource12
            // 
            this.sqlDataSource12.ConnectionString = "Default";
            this.sqlDataSource12.Name = "sqlDataSource12";
            this.sqlDataSource12.SelectCommand = "SELECT        ID AS PersonID, P_DisplayName\r\nFROM            Person\r\nWHERE IsDele" +
    "ted = 0 AND IsActive = 1";
            // 
            // objectDataSource3
            // 
            this.objectDataSource3.DataMember = "TestQuery";
            this.objectDataSource3.DataSource = typeof(ReportingClassLibrary.TestReportFactory);
            this.objectDataSource3.Name = "objectDataSource3";
            this.objectDataSource3.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("ID", typeof(int), "= Parameters.ID1.Value")});
            // 
            // Report2
            // 
            this.DataSource = this.objectDataSource3;
            this.Filters.Add(new Telerik.Reporting.Filter("=ID", Telerik.Reporting.FilterOperator.Equal, "= Parameters.ID1.Value"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "Report2";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AutoRefresh = true;
            reportParameter1.AvailableValues.DataSource = this.objectDataSource2;
            reportParameter1.AvailableValues.DisplayMember = "AddedByAlias";
            reportParameter1.AvailableValues.ValueMember = "ID";
            reportParameter1.Name = "ID1";
            reportParameter1.Text = "ID1";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "10024";
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.AddedByAlias", Telerik.Reporting.SortDirection.Desc));
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.8000001907348633D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.SqlDataSource sqlDataSource12;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.ObjectDataSource objectDataSource2;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.ObjectDataSource objectDataSource3;
    }
}