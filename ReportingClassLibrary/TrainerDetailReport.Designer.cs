namespace ReportingClassLibrary
{
    partial class TrainerDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainerDetailReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productNumberCaptionTextBox = new Telerik.Reporting.TextBox();
            this.nameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.orderQtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unitPriceCaptionTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.productNumberDataTextBox = new Telerik.Reporting.TextBox();
            this.nameDataTextBox = new Telerik.Reporting.TextBox();
            this.orderQtyDataTextBox = new Telerik.Reporting.TextBox();
            this.unitPriceDataTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44003930687904358D);
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNumberCaptionTextBox,
            this.nameCaptionTextBox,
            this.orderQtyCaptionTextBox,
            this.unitPriceCaptionTextBox,
            this.lineTotalCaptionTextBox});
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // productNumberCaptionTextBox
            // 
            sortingAction1.SortingExpression = "= Fields.ProductNumber";
            this.productNumberCaptionTextBox.Action = sortingAction1;
            this.productNumberCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.800079345703125D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.productNumberCaptionTextBox.Name = "productNumberCaptionTextBox";
            this.productNumberCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999605894088745D), Telerik.Reporting.Drawing.Unit.Inch(0.47988176345825195D));
            this.productNumberCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.productNumberCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.productNumberCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.productNumberCaptionTextBox.StyleName = "Caption";
            this.productNumberCaptionTextBox.Value = "Course Name";
            // 
            // nameCaptionTextBox
            // 
            sortingAction2.SortingExpression = "= Fields.Name";
            this.nameCaptionTextBox.Action = sortingAction2;
            this.nameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.nameCaptionTextBox.Name = "nameCaptionTextBox";
            this.nameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999213695526123D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.nameCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.nameCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.nameCaptionTextBox.StyleName = "Caption";
            this.nameCaptionTextBox.Value = "Name";
            // 
            // orderQtyCaptionTextBox
            // 
            sortingAction3.SortingExpression = "= Fields.OrderQty";
            this.orderQtyCaptionTextBox.Action = sortingAction3;
            this.orderQtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.orderQtyCaptionTextBox.Name = "orderQtyCaptionTextBox";
            this.orderQtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.orderQtyCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.orderQtyCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.orderQtyCaptionTextBox.StyleName = "Caption";
            this.orderQtyCaptionTextBox.Value = "Reg Code";
            // 
            // unitPriceCaptionTextBox
            // 
            sortingAction4.SortingExpression = "= Fields.UnitPrice";
            this.unitPriceCaptionTextBox.Action = sortingAction4;
            this.unitPriceCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5001187324523926D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.unitPriceCaptionTextBox.Name = "unitPriceCaptionTextBox";
            this.unitPriceCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3998816013336182D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.unitPriceCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.unitPriceCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitPriceCaptionTextBox.StyleName = "Caption";
            this.unitPriceCaptionTextBox.Value = "Class Name";
            // 
            // lineTotalCaptionTextBox
            // 
            sortingAction5.SortingExpression = "= Fields.LineTotal";
            this.lineTotalCaptionTextBox.Action = sortingAction5;
            this.lineTotalCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9000792503356934D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.lineTotalCaptionTextBox.Name = "lineTotalCaptionTextBox";
            this.lineTotalCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9998815059661865D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.lineTotalCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.lineTotalCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.lineTotalCaptionTextBox.StyleName = "Caption";
            this.lineTotalCaptionTextBox.Value = "Class Duration";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.90000057220459D), Telerik.Reporting.Drawing.Unit.Inch(1.0999212265014648D));
            this.textBox13.Style.BackgroundImage.ImageData = ((System.Drawing.Image)(resources.GetObject("textBox13.Style.BackgroundImage.ImageData")));
            this.textBox13.Style.BackgroundImage.MimeType = "image/png";
            this.textBox13.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Segoe UI";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Trainer Detail Report";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.48003944754600525D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNumberDataTextBox,
            this.nameDataTextBox,
            this.orderQtyDataTextBox,
            this.unitPriceDataTextBox,
            this.lineTotalDataTextBox});
            this.detail.Name = "detail";
            // 
            // productNumberDataTextBox
            // 
            this.productNumberDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05D));
            this.productNumberDataTextBox.Name = "productNumberDataTextBox";
            this.productNumberDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.100000262260437D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.productNumberDataTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.productNumberDataTextBox.StyleName = "Data";
            this.productNumberDataTextBox.Value = "=Fields.PersonRegCode";
            // 
            // nameDataTextBox
            // 
            this.nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.nameDataTextBox.Name = "nameDataTextBox";
            this.nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.699881911277771D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.nameDataTextBox.StyleName = "Data";
            this.nameDataTextBox.Value = "=Fields.P_DisplayName";
            // 
            // orderQtyDataTextBox
            // 
            this.orderQtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.800079345703125D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.orderQtyDataTextBox.Name = "orderQtyDataTextBox";
            this.orderQtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999608278274536D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.orderQtyDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.orderQtyDataTextBox.StyleName = "Data";
            this.orderQtyDataTextBox.Value = "=Fields.CourseName";
            // 
            // unitPriceDataTextBox
            // 
            this.unitPriceDataTextBox.Format = "{0:C2}";
            this.unitPriceDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5001192092895508D), Telerik.Reporting.Drawing.Unit.Inch(0.000118255615234375D));
            this.unitPriceDataTextBox.Name = "unitPriceDataTextBox";
            this.unitPriceDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.39988112449646D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.unitPriceDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitPriceDataTextBox.StyleName = "Data";
            this.unitPriceDataTextBox.Value = "=Fields.ClassTitle";
            // 
            // lineTotalDataTextBox
            // 
            this.lineTotalDataTextBox.Format = "{0:C2}";
            this.lineTotalDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9000792503356934D), Telerik.Reporting.Drawing.Unit.Inch(5.91278076171875E-05D));
            this.lineTotalDataTextBox.Name = "lineTotalDataTextBox";
            this.lineTotalDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9998819828033447D), Telerik.Reporting.Drawing.Unit.Inch(0.47992119193077087D));
            this.lineTotalDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.lineTotalDataTextBox.StyleName = "Data";
            this.lineTotalDataTextBox.Value = "= Format(\'{0:d}\',Fields.StartDate) + \" - \"+   Format(\'{0:d}\',Fields.EndDate)";
            // 
            // TrainerDetailReport
            // 
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.pageHeaderSection1,
            this.detail});
            this.Name = "TrainerDetailReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Name = "Segoe UI Light";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            styleRule2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            styleRule3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            styleRule3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(161)))), ((int)(((byte)(82)))));
            styleRule3.Style.Font.Name = "Segoe UI";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.079999998211860657D);
            styleRule3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D);
            styleRule3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            styleRule4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.Font.Name = "Segoe UI";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule4.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.079999998211860657D);
            styleRule4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D);
            styleRule4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.9000000953674316D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox productNumberDataTextBox;
        private Telerik.Reporting.TextBox nameDataTextBox;
        private Telerik.Reporting.TextBox orderQtyDataTextBox;
        private Telerik.Reporting.TextBox unitPriceDataTextBox;
        private Telerik.Reporting.TextBox lineTotalDataTextBox;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.TextBox productNumberCaptionTextBox;
        private Telerik.Reporting.TextBox nameCaptionTextBox;
        private Telerik.Reporting.TextBox orderQtyCaptionTextBox;
        private Telerik.Reporting.TextBox unitPriceCaptionTextBox;
        private Telerik.Reporting.TextBox lineTotalCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
    }
}