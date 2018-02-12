namespace LainsaSciInformes
{
    partial class RptConsultaDispositivo
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptConsultaDispositivo));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.nombreCaptionTextBox = new Telerik.Reporting.TextBox();
            this.numero_industriaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.clienteCaptionTextBox = new Telerik.Reporting.TextBox();
            this.instalacionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tipo_dispositivoCaptionTextBox = new Telerik.Reporting.TextBox();
            this.posicionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fecha_caducidadCaptionTextBox = new Telerik.Reporting.TextBox();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.nombreDataTextBox = new Telerik.Reporting.TextBox();
            this.numero_industriaDataTextBox = new Telerik.Reporting.TextBox();
            this.clienteDataTextBox = new Telerik.Reporting.TextBox();
            this.instalacionDataTextBox = new Telerik.Reporting.TextBox();
            this.tipo_dispositivoDataTextBox = new Telerik.Reporting.TextBox();
            this.posicionDataTextBox = new Telerik.Reporting.TextBox();
            this.fecha_caducidadDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "LainsaSciInformes.Properties.Settings.scidosimetria2";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@Parameter1", System.Data.DbType.String, "=Parameters.Parameter1.Value")});
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.56121063232421875D);
            this.labelsGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nombreCaptionTextBox,
            this.numero_industriaCaptionTextBox,
            this.clienteCaptionTextBox,
            this.instalacionCaptionTextBox,
            this.tipo_dispositivoCaptionTextBox,
            this.posicionCaptionTextBox,
            this.fecha_caducidadCaptionTextBox});
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            // 
            // nombreCaptionTextBox
            // 
            this.nombreCaptionTextBox.CanGrow = true;
            this.nombreCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.nombreCaptionTextBox.Name = "nombreCaptionTextBox";
            this.nombreCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.57916665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.nombreCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.nombreCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.nombreCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.nombreCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.nombreCaptionTextBox.Style.Font.Name = "Arial";
            this.nombreCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.nombreCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.nombreCaptionTextBox.StyleName = "Caption";
            this.nombreCaptionTextBox.Value = "dispositivo";
            // 
            // numero_industriaCaptionTextBox
            // 
            this.numero_industriaCaptionTextBox.CanGrow = true;
            this.numero_industriaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.6000787615776062D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.numero_industriaCaptionTextBox.Name = "numero_industriaCaptionTextBox";
            this.numero_industriaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992125034332275D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.numero_industriaCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.numero_industriaCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.numero_industriaCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.numero_industriaCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.numero_industriaCaptionTextBox.Style.Font.Name = "Arial";
            this.numero_industriaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.numero_industriaCaptionTextBox.StyleName = "Caption";
            this.numero_industriaCaptionTextBox.Value = "industria";
            // 
            // clienteCaptionTextBox
            // 
            this.clienteCaptionTextBox.CanGrow = true;
            this.clienteCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.clienteCaptionTextBox.Name = "clienteCaptionTextBox";
            this.clienteCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992132186889648D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.clienteCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.clienteCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.clienteCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.clienteCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.clienteCaptionTextBox.Style.Font.Name = "Arial";
            this.clienteCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.clienteCaptionTextBox.StyleName = "Caption";
            this.clienteCaptionTextBox.Value = "cliente";
            // 
            // instalacionCaptionTextBox
            // 
            this.instalacionCaptionTextBox.CanGrow = true;
            this.instalacionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3000791072845459D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.instalacionCaptionTextBox.Name = "instalacionCaptionTextBox";
            this.instalacionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999215126037598D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.instalacionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.instalacionCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.instalacionCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.instalacionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.instalacionCaptionTextBox.Style.Font.Name = "Arial";
            this.instalacionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.instalacionCaptionTextBox.StyleName = "Caption";
            this.instalacionCaptionTextBox.Value = "instalación";
            // 
            // tipo_dispositivoCaptionTextBox
            // 
            this.tipo_dispositivoCaptionTextBox.CanGrow = true;
            this.tipo_dispositivoCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6000792980194092D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.tipo_dispositivoCaptionTextBox.Name = "tipo_dispositivoCaptionTextBox";
            this.tipo_dispositivoCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0393645763397217D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.tipo_dispositivoCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.tipo_dispositivoCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tipo_dispositivoCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tipo_dispositivoCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.tipo_dispositivoCaptionTextBox.Style.Font.Name = "Arial";
            this.tipo_dispositivoCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipo_dispositivoCaptionTextBox.StyleName = "Caption";
            this.tipo_dispositivoCaptionTextBox.Value = "tipo";
            // 
            // posicionCaptionTextBox
            // 
            this.posicionCaptionTextBox.CanGrow = true;
            this.posicionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.6701188087463379D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.posicionCaptionTextBox.Name = "posicionCaptionTextBox";
            this.posicionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999921977519989D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.posicionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.posicionCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.posicionCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.posicionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.posicionCaptionTextBox.Style.Font.Name = "Arial";
            this.posicionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionCaptionTextBox.StyleName = "Caption";
            this.posicionCaptionTextBox.Value = "POSICION\t";
            // 
            // fecha_caducidadCaptionTextBox
            // 
            this.fecha_caducidadCaptionTextBox.CanGrow = true;
            this.fecha_caducidadCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6701197624206543D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.fecha_caducidadCaptionTextBox.Name = "fecha_caducidadCaptionTextBox";
            this.fecha_caducidadCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.76047712564468384D), Telerik.Reporting.Drawing.Unit.Inch(0.47999998927116394D));
            this.fecha_caducidadCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.fecha_caducidadCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.fecha_caducidadCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.fecha_caducidadCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.fecha_caducidadCaptionTextBox.Style.Font.Name = "Arial";
            this.fecha_caducidadCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fecha_caducidadCaptionTextBox.StyleName = "Caption";
            this.fecha_caducidadCaptionTextBox.Value = "Fecha Cad";
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.62516409158706665D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox,
            this.pictureBox1});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(101.07083892822266D), Telerik.Reporting.Drawing.Unit.Mm(15.350000381469727D));
            this.reportNameTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.reportNameTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reportNameTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.reportNameTextBox.Style.Color = System.Drawing.Color.Black;
            this.reportNameTextBox.Style.Font.Name = "Arial";
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "DISPOSITIVOS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2007155418396D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox1.MimeType = "image/jpeg";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2298812866210938D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nombreDataTextBox,
            this.numero_industriaDataTextBox,
            this.clienteDataTextBox,
            this.instalacionDataTextBox,
            this.tipo_dispositivoDataTextBox,
            this.posicionDataTextBox,
            this.fecha_caducidadDataTextBox});
            this.detail.Name = "detail";
            // 
            // nombreDataTextBox
            // 
            this.nombreDataTextBox.CanGrow = true;
            this.nombreDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.nombreDataTextBox.Name = "nombreDataTextBox";
            this.nombreDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.57916659116745D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nombreDataTextBox.Style.Font.Name = "Arial";
            this.nombreDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.nombreDataTextBox.StyleName = "Data";
            this.nombreDataTextBox.Value = "=Fields.nombre";
            // 
            // numero_industriaDataTextBox
            // 
            this.numero_industriaDataTextBox.CanGrow = true;
            this.numero_industriaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.6000787615776062D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.numero_industriaDataTextBox.Name = "numero_industriaDataTextBox";
            this.numero_industriaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992130994796753D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.numero_industriaDataTextBox.Style.Font.Name = "Arial";
            this.numero_industriaDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.numero_industriaDataTextBox.StyleName = "Data";
            this.numero_industriaDataTextBox.Value = "=Fields.numero_industria";
            // 
            // clienteDataTextBox
            // 
            this.clienteDataTextBox.CanGrow = true;
            this.clienteDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.clienteDataTextBox.Name = "clienteDataTextBox";
            this.clienteDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992132186889648D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.clienteDataTextBox.Style.Font.Name = "Arial";
            this.clienteDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.clienteDataTextBox.StyleName = "Data";
            this.clienteDataTextBox.Value = "=Fields.cliente";
            // 
            // instalacionDataTextBox
            // 
            this.instalacionDataTextBox.CanGrow = true;
            this.instalacionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3000786304473877D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.instalacionDataTextBox.Name = "instalacionDataTextBox";
            this.instalacionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999217510223389D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.instalacionDataTextBox.Style.Font.Name = "Arial";
            this.instalacionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.instalacionDataTextBox.StyleName = "Data";
            this.instalacionDataTextBox.Value = "=Fields.instalacion";
            // 
            // tipo_dispositivoDataTextBox
            // 
            this.tipo_dispositivoDataTextBox.CanGrow = true;
            this.tipo_dispositivoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6000792980194092D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.tipo_dispositivoDataTextBox.Name = "tipo_dispositivoDataTextBox";
            this.tipo_dispositivoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0393645763397217D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tipo_dispositivoDataTextBox.Style.Font.Name = "Arial";
            this.tipo_dispositivoDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipo_dispositivoDataTextBox.StyleName = "Data";
            this.tipo_dispositivoDataTextBox.Value = "=Fields.tipo_dispositivo";
            // 
            // posicionDataTextBox
            // 
            this.posicionDataTextBox.CanGrow = true;
            this.posicionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.6701188087463379D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.posicionDataTextBox.Name = "posicionDataTextBox";
            this.posicionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999921977519989D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.posicionDataTextBox.Style.Font.Name = "Arial";
            this.posicionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionDataTextBox.StyleName = "Data";
            this.posicionDataTextBox.Value = "=Fields.posicion";
            // 
            // fecha_caducidadDataTextBox
            // 
            this.fecha_caducidadDataTextBox.CanGrow = true;
            this.fecha_caducidadDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6701197624206543D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.fecha_caducidadDataTextBox.Name = "fecha_caducidadDataTextBox";
            this.fecha_caducidadDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.76047724485397339D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fecha_caducidadDataTextBox.Style.Font.Name = "Arial";
            this.fecha_caducidadDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fecha_caducidadDataTextBox.StyleName = "Data";
            this.fecha_caducidadDataTextBox.Value = "=Fields.fecha_caducidad";
            // 
            // RptConsultaDispositivo
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooter;
            group1.GroupHeader = this.labelsGroupHeader;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.pageHeader,
            this.pageFooter,
            this.reportFooter,
            this.detail});
            this.Name = "RptConsultaDispositivo";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.MultiValue = true;
            reportParameter1.Name = "Parameter1";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(97)))), ((int)(((byte)(74)))));
            styleRule1.Style.Font.Name = "Georgia";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(174)))), ((int)(((byte)(173)))));
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(168)))), ((int)(((byte)(212)))));
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            styleRule2.Style.Font.Name = "Georgia";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Georgia";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Georgia";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4999995231628418D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeader;
        private Telerik.Reporting.TextBox nombreCaptionTextBox;
        private Telerik.Reporting.TextBox numero_industriaCaptionTextBox;
        private Telerik.Reporting.TextBox clienteCaptionTextBox;
        private Telerik.Reporting.TextBox instalacionCaptionTextBox;
        private Telerik.Reporting.TextBox tipo_dispositivoCaptionTextBox;
        private Telerik.Reporting.TextBox posicionCaptionTextBox;
        private Telerik.Reporting.TextBox fecha_caducidadCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooter;
        private Telerik.Reporting.Group labelsGroup;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox nombreDataTextBox;
        private Telerik.Reporting.TextBox numero_industriaDataTextBox;
        private Telerik.Reporting.TextBox clienteDataTextBox;
        private Telerik.Reporting.TextBox instalacionDataTextBox;
        private Telerik.Reporting.TextBox tipo_dispositivoDataTextBox;
        private Telerik.Reporting.TextBox posicionDataTextBox;
        private Telerik.Reporting.TextBox fecha_caducidadDataTextBox;
        private Telerik.Reporting.PictureBox pictureBox1;
    }
}