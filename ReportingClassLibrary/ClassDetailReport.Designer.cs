namespace ReportingClassLibrary
{
    partial class ClassDetailReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.SortingAction sortingAction1 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction2 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction3 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction4 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction5 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction6 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassDetailReport));
            Telerik.Reporting.CustomAction customAction1 = new Telerik.Reporting.CustomAction();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.sqlDataSource2 = new Telerik.Reporting.SqlDataSource();
            this.sqlDataSource3 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox14 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            sortingAction1.SortingExpression = "= Fields.PrimaryClassTitle";
            sortingAction1.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox1.Action = sortingAction1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.359992265701294D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.StyleName = "BlueOpal.TableHeader";
            this.textBox1.Value = "Code";
            // 
            // textBox2
            // 
            sortingAction2.SortingExpression = "= Fields.ClassName";
            sortingAction2.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox2.Action = sortingAction2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.162075400352478D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "BlueOpal.TableHeader";
            this.textBox2.Value = "Class Name";
            // 
            // textBox3
            // 
            sortingAction3.SortingExpression = "= Fields.SessionName";
            sortingAction3.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox3.Action = sortingAction3;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3183251619338989D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.StyleName = "BlueOpal.TableHeader";
            this.textBox3.Value = "Session Name";
            // 
            // textBox4
            // 
            sortingAction4.SortingExpression = "= Fields.ScheduleDate";
            sortingAction4.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox4.Action = sortingAction4;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1516584157943726D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.StyleName = "BlueOpal.TableHeader";
            this.textBox4.Value = "Session Date";
            // 
            // textBox5
            // 
            sortingAction5.SortingExpression = "= Fields.StartTime";
            sortingAction5.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox5.Action = sortingAction5;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4224917888641357D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.StyleName = "BlueOpal.TableHeader";
            this.textBox5.Value = "Start Time";
            // 
            // textBox6
            // 
            sortingAction6.SortingExpression = "= Fields.EndTime";
            sortingAction6.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this});
            this.textBox6.Action = sortingAction6;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3958330154418945D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.StyleName = "BlueOpal.TableHeader";
            this.textBox6.Value = "End Time";
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionString = "Default";
            this.sqlDataSource2.Name = "sqlDataSource2";
            this.sqlDataSource2.SelectCommand = "dbo.TMS_ClassesDLL";
            this.sqlDataSource2.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // sqlDataSource3
            // 
            this.sqlDataSource3.ConnectionString = "Default";
            this.sqlDataSource3.Name = "sqlDataSource3";
            this.sqlDataSource3.SelectCommand = "SELECT ID as Value,PrimaryName as Text FROM TMS_Courses\r\n";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.3599921464920044D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1620757579803467D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.3183251619338989D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1516581773757935D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4224916696548462D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.3958324193954468D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox7);
            this.table1.Body.SetCellContent(0, 1, this.textBox8);
            this.table1.Body.SetCellContent(0, 2, this.textBox9);
            this.table1.Body.SetCellContent(0, 3, this.textBox10);
            this.table1.Body.SetCellContent(0, 4, this.textBox11);
            this.table1.Body.SetCellContent(0, 5, this.textBox12);
            tableGroup1.Name = "p_DisplayName";
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "className";
            tableGroup2.ReportItem = this.textBox2;
            tableGroup3.Name = "personRegCode";
            tableGroup3.ReportItem = this.textBox3;
            tableGroup4.Name = "createdDate";
            tableGroup4.ReportItem = this.textBox4;
            tableGroup5.Name = "dateOfBirth";
            tableGroup5.ReportItem = this.textBox5;
            tableGroup6.Name = "group";
            tableGroup6.ReportItem = this.textBox6;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.ColumnGroups.Add(tableGroup5);
            this.table1.ColumnGroups.Add(tableGroup6);
            this.table1.DataSource = this.sqlDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.table1.Name = "table1";
            tableGroup7.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup7.Name = "detail";
            this.table1.RowGroups.Add(tableGroup7);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.8103752136230469D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.table1.StyleName = "BlueOpal.TableNormal";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.359992265701294D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.StyleName = "BlueOpal.TableBody";
            this.textBox7.Value = "= Fields.PrimaryClassTitle";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.162075400352478D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox8.StyleName = "BlueOpal.TableBody";
            this.textBox8.Value = "= Fields.ClassName";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3183251619338989D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox9.StyleName = "BlueOpal.TableBody";
            this.textBox9.Value = "= Fields.SessionName";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:d}";
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1516584157943726D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox10.StyleName = "BlueOpal.TableBody";
            this.textBox10.Value = "=Fields.ScheduleDate";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4224917888641357D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox11.StyleName = "BlueOpal.TableBody";
            this.textBox11.Value = "= Fields.StartTime";
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3958330154418945D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox12.StyleName = "BlueOpal.TableBody";
            this.textBox12.Value = "=Fields.EndTime";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Default";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@ClassID", System.Data.DbType.String, "= Parameters.ClassID.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@CourseID", System.Data.DbType.String, "= Parameters.CourseID.Value")});
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox13.Name = "ReportNameTextBox";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.8207931518554688D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.textBox13.Style.BackgroundImage.ImageData = ((System.Drawing.Image)(resources.GetObject("textBox13.Style.BackgroundImage.ImageData")));
            this.textBox13.Style.BackgroundImage.MimeType = "image/png";
            this.textBox13.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Segoe UI";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Class Detail Report";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.49370083212852478D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.1896224021911621D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6207537055015564D), Telerik.Reporting.Drawing.Unit.Inch(0.39370077848434448D));
            this.textBox14.Style.Font.Name = "Segoe UI";
            this.textBox14.Value = "Page: {PageNumber}";
            // 
            // ClassDetailReport
            // 
            this.Action = customAction1;
            this.DataSource = null;
            this.Filters.Add(new Telerik.Reporting.Filter("@ClassID", Telerik.Reporting.FilterOperator.Equal, "= Parameters.ClassID.Value"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "ClassDetailReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AutoRefresh = true;
            reportParameter1.AvailableValues.DataSource = this.sqlDataSource2;
            reportParameter1.AvailableValues.DisplayMember = "Text";
            reportParameter1.AvailableValues.ValueMember = "Value";
            reportParameter1.Name = "ClassID";
            reportParameter1.Text = "Select Class";
            reportParameter1.Value = "5";
            reportParameter1.Visible = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.AvailableValues.DataSource = this.sqlDataSource3;
            reportParameter2.AvailableValues.DisplayMember = "Text";
            reportParameter2.AvailableValues.ValueMember = "Value";
            reportParameter2.Name = "CourseID";
            reportParameter2.Text = "Select Course";
            reportParameter2.Value = "15";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "BlueOpal.TableNormal")});
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            styleRule2.Style.Font.Name = "Segoe UI";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "BlueOpal.TableBody")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            styleRule3.Style.Font.Name = "Segoe UI";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "BlueOpal.TableHeader")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            styleRule4.Style.Font.Name = "Segoe UI";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.8207931518554688D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.SqlDataSource sqlDataSource3;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.SqlDataSource sqlDataSource2;
    }
}