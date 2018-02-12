namespace LainsaSciInformes
{
    partial class RptConsultaDispositivos
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptConsultaDispositivos));
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.rptResumenRevision1 = new LainsaSciInformes.RptResumenRevision();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.rptRevisionDispositivo1 = new LainsaSciInformes.RptRevisionDispositivo();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.fecha_caducidadCaptionTextBox = new Telerik.Reporting.TextBox();
            this.posicionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tipo_dispositivoCaptionTextBox = new Telerik.Reporting.TextBox();
            this.instalacionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.clienteCaptionTextBox = new Telerik.Reporting.TextBox();
            this.numero_industriaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.nombreCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fecha_caducidadDataTextBox = new Telerik.Reporting.TextBox();
            this.posicionDataTextBox = new Telerik.Reporting.TextBox();
            this.tipo_dispositivoDataTextBox = new Telerik.Reporting.TextBox();
            this.instalacionDataTextBox = new Telerik.Reporting.TextBox();
            this.clienteDataTextBox = new Telerik.Reporting.TextBox();
            this.numero_industriaDataTextBox = new Telerik.Reporting.TextBox();
            this.nombreDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rptResumenRevision1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptRevisionDispositivo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox,
            this.pictureBox1});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(200.66000366210938D), Telerik.Reporting.Drawing.Unit.Mm(20.318002700805664D));
            this.reportNameTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.reportNameTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reportNameTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.reportNameTextBox.Style.Color = System.Drawing.Color.Black;
            this.reportNameTextBox.Style.Font.Name = "Arial";
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "=Consulta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0692930221557617D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.pictureBox1.MimeType = "image/jpeg";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2298812866210938D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80000019073486328D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1,
            this.subReport2});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detail.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.detail.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(20.319999694824219D), Telerik.Reporting.Drawing.Unit.Mm(0.00099719362333416939D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("dispositivo", "=ID"));
            instanceReportSource1.ReportDocument = this.rptResumenRevision1;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(167.10981750488281D), Telerik.Reporting.Drawing.Unit.Mm(10.160001754760742D));
            // 
            // rptResumenRevision1
            // 
            this.rptResumenRevision1.Name = "rptResumenRevision1";
            // 
            // subReport2
            // 
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(20.319999694824219D), Telerik.Reporting.Drawing.Unit.Mm(10.163005828857422D));
            this.subReport2.Name = "subReport2";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("dispositivo", "=ID"));
            instanceReportSource2.ReportDocument = this.rptRevisionDispositivo1;
            this.subReport2.ReportSource = instanceReportSource2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(20.319995880126953D), Telerik.Reporting.Drawing.Unit.Mm(5.0800032615661621D));
            // 
            // rptRevisionDispositivo1
            // 
            this.rptRevisionDispositivo1.Name = "RptRevisionDispositivo";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20315010845661163D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.10125732421875D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // fecha_caducidadCaptionTextBox
            // 
            this.fecha_caducidadCaptionTextBox.CanGrow = true;
            this.fecha_caducidadCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.379206657409668D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.fecha_caducidadCaptionTextBox.Name = "fecha_caducidadCaptionTextBox";
            this.fecha_caducidadCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.029960036277771D), Telerik.Reporting.Drawing.Unit.Inch(0.47999998927116394D));
            this.fecha_caducidadCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.fecha_caducidadCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.fecha_caducidadCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.fecha_caducidadCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.fecha_caducidadCaptionTextBox.Style.Font.Name = "Arial";
            this.fecha_caducidadCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fecha_caducidadCaptionTextBox.StyleName = "Caption";
            this.fecha_caducidadCaptionTextBox.Value = "fecha de caducidad";
            // 
            // posicionCaptionTextBox
            // 
            this.posicionCaptionTextBox.CanGrow = true;
            this.posicionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3792057037353516D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.posicionCaptionTextBox.Name = "posicionCaptionTextBox";
            this.posicionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999921977519989D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.posicionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.posicionCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.posicionCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.posicionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.posicionCaptionTextBox.Style.Font.Name = "Arial";
            this.posicionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionCaptionTextBox.StyleName = "Caption";
            this.posicionCaptionTextBox.Value = "posición";
            // 
            // tipo_dispositivoCaptionTextBox
            // 
            this.tipo_dispositivoCaptionTextBox.CanGrow = true;
            this.tipo_dispositivoCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.tipo_dispositivoCaptionTextBox.Name = "tipo_dispositivoCaptionTextBox";
            this.tipo_dispositivoCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1040879487991333D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.tipo_dispositivoCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.tipo_dispositivoCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tipo_dispositivoCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tipo_dispositivoCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.tipo_dispositivoCaptionTextBox.Style.Font.Name = "Arial";
            this.tipo_dispositivoCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipo_dispositivoCaptionTextBox.StyleName = "Caption";
            this.tipo_dispositivoCaptionTextBox.Value = "tipo de dispositivo";
            // 
            // instalacionCaptionTextBox
            // 
            this.instalacionCaptionTextBox.CanGrow = true;
            this.instalacionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.instalacionCaptionTextBox.Name = "instalacionCaptionTextBox";
            this.instalacionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999211549758911D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.instalacionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.instalacionCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.instalacionCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.instalacionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.instalacionCaptionTextBox.Style.Font.Name = "Arial";
            this.instalacionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.instalacionCaptionTextBox.StyleName = "Caption";
            this.instalacionCaptionTextBox.Value = "instalación";
            // 
            // clienteCaptionTextBox
            // 
            this.clienteCaptionTextBox.CanGrow = true;
            this.clienteCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.clienteCaptionTextBox.Name = "clienteCaptionTextBox";
            this.clienteCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999213218688965D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.clienteCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.clienteCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.clienteCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.clienteCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.clienteCaptionTextBox.Style.Font.Name = "Arial";
            this.clienteCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.clienteCaptionTextBox.StyleName = "Caption";
            this.clienteCaptionTextBox.Value = "cliente";
            // 
            // numero_industriaCaptionTextBox
            // 
            this.numero_industriaCaptionTextBox.CanGrow = true;
            this.numero_industriaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000787496566773D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.numero_industriaCaptionTextBox.Name = "numero_industriaCaptionTextBox";
            this.numero_industriaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.89992141723632812D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.numero_industriaCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.numero_industriaCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.numero_industriaCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.numero_industriaCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.numero_industriaCaptionTextBox.Style.Font.Name = "Arial";
            this.numero_industriaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.numero_industriaCaptionTextBox.StyleName = "Caption";
            this.numero_industriaCaptionTextBox.Value = "industria";
            // 
            // nombreCaptionTextBox
            // 
            this.nombreCaptionTextBox.CanGrow = true;
            this.nombreCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.nombreCaptionTextBox.Name = "nombreCaptionTextBox";
            this.nombreCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7999604940414429D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
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
            // fecha_caducidadDataTextBox
            // 
            this.fecha_caducidadDataTextBox.CanGrow = true;
            this.fecha_caducidadDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.379206657409668D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.fecha_caducidadDataTextBox.Name = "fecha_caducidadDataTextBox";
            this.fecha_caducidadDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0299601554870606D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fecha_caducidadDataTextBox.Style.Font.Name = "Arial";
            this.fecha_caducidadDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fecha_caducidadDataTextBox.StyleName = "Data";
            this.fecha_caducidadDataTextBox.Value = "=Fecha_cad";
            // 
            // posicionDataTextBox
            // 
            this.posicionDataTextBox.CanGrow = true;
            this.posicionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3792057037353516D), Telerik.Reporting.Drawing.Unit.Inch(0.59980279207229614D));
            this.posicionDataTextBox.Name = "posicionDataTextBox";
            this.posicionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999921977519989D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.posicionDataTextBox.Style.Font.Name = "Arial";
            this.posicionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionDataTextBox.StyleName = "Data";
            this.posicionDataTextBox.Value = "=Posicion";
            // 
            // tipo_dispositivoDataTextBox
            // 
            this.tipo_dispositivoDataTextBox.CanGrow = true;
            this.tipo_dispositivoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.tipo_dispositivoDataTextBox.Name = "tipo_dispositivoDataTextBox";
            this.tipo_dispositivoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1040879487991333D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tipo_dispositivoDataTextBox.Style.Font.Name = "Arial";
            this.tipo_dispositivoDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipo_dispositivoDataTextBox.StyleName = "Data";
            this.tipo_dispositivoDataTextBox.Value = "=Tipo_disp";
            // 
            // instalacionDataTextBox
            // 
            this.instalacionDataTextBox.CanGrow = true;
            this.instalacionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.instalacionDataTextBox.Name = "instalacionDataTextBox";
            this.instalacionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.instalacionDataTextBox.Style.Font.Name = "Arial";
            this.instalacionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.instalacionDataTextBox.StyleName = "Data";
            this.instalacionDataTextBox.Value = "=Instalacion";
            // 
            // clienteDataTextBox
            // 
            this.clienteDataTextBox.CanGrow = true;
            this.clienteDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.clienteDataTextBox.Name = "clienteDataTextBox";
            this.clienteDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999213218688965D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.clienteDataTextBox.Style.Font.Name = "Arial";
            this.clienteDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.clienteDataTextBox.StyleName = "Data";
            this.clienteDataTextBox.Value = "=Cliente";
            // 
            // numero_industriaDataTextBox
            // 
            this.numero_industriaDataTextBox.CanGrow = true;
            this.numero_industriaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000787496566773D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.numero_industriaDataTextBox.Name = "numero_industriaDataTextBox";
            this.numero_industriaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.89992141723632812D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.numero_industriaDataTextBox.Style.Font.Name = "Arial";
            this.numero_industriaDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.numero_industriaDataTextBox.StyleName = "Data";
            this.numero_industriaDataTextBox.Value = "=Industria";
            // 
            // nombreDataTextBox
            // 
            this.nombreDataTextBox.CanGrow = true;
            this.nombreDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999748170375824D), Telerik.Reporting.Drawing.Unit.Inch(0.59980279207229614D));
            this.nombreDataTextBox.Name = "nombreDataTextBox";
            this.nombreDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999607086181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nombreDataTextBox.Style.Font.Name = "Arial";
            this.nombreDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.nombreDataTextBox.StyleName = "Data";
            this.nombreDataTextBox.Value = "=Dispositivo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(2.5399935245513916D), Telerik.Reporting.Drawing.Unit.Mm(20.316991806030273D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(20.320003509521484D), Telerik.Reporting.Drawing.Unit.Mm(5.0800032615661621D));
            this.textBox1.Style.Visible = false;
            this.textBox1.Value = "= ID";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.604245662689209D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77488154172897339D), Telerik.Reporting.Drawing.Unit.Inch(0.48000004887580872D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.Black;
            this.textBox2.Style.Font.Name = "Arial";
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.StyleName = "Caption";
            this.textBox2.Value = "modelo";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.604245662689209D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77488154172897339D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.Font.Name = "Arial";
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "=Modelo";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.237286567687988D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1406728029251099D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.Style.Font.Name = "Arial";
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "=Observaciones";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.237286567687988D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1406739950180054D), Telerik.Reporting.Drawing.Unit.Inch(0.47999998927116394D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Color = System.Drawing.Color.Black;
            this.textBox5.Style.Font.Name = "Arial";
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "observaciones";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000019073486328D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nombreCaptionTextBox,
            this.numero_industriaCaptionTextBox,
            this.clienteCaptionTextBox,
            this.instalacionCaptionTextBox,
            this.tipo_dispositivoCaptionTextBox,
            this.textBox2,
            this.posicionCaptionTextBox,
            this.fecha_caducidadCaptionTextBox,
            this.textBox5,
            this.nombreDataTextBox,
            this.posicionDataTextBox,
            this.tipo_dispositivoDataTextBox,
            this.instalacionDataTextBox,
            this.clienteDataTextBox,
            this.numero_industriaDataTextBox,
            this.fecha_caducidadDataTextBox,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox7,
            this.textBox6});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.409245491027832D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82796287536621094D), Telerik.Reporting.Drawing.Unit.Inch(0.47999998927116394D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.Black;
            this.textBox7.Style.Font.Name = "Arial";
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Caption";
            this.textBox7.Value = "operativo";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.409245491027832D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82796174287796021D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.Style.Font.Name = "Arial";
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "=Operativo";
            // 
            // RptConsultaDispositivos
            // 
            group1.GroupFooter = this.groupFooterSection1;
            group1.GroupHeader = this.groupHeaderSection1;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=ID"));
            group1.Name = "group1";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "RptConsultaDispositivos";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.5D), Telerik.Reporting.Drawing.Unit.Mm(0.5D), Telerik.Reporting.Drawing.Unit.Mm(0.5D), Telerik.Reporting.Drawing.Unit.Mm(0.5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(11.40000057220459D);
            this.NeedDataSource += new System.EventHandler(this.RptConsultaDispositivos_NeedDataSource_1);
            ((System.ComponentModel.ISupportInitialize)(this.rptResumenRevision1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptRevisionDispositivo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PictureBox pictureBox1;
        private RptResumenRevision rptResumenRevision1;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.TextBox fecha_caducidadCaptionTextBox;
        private Telerik.Reporting.TextBox posicionCaptionTextBox;
        private Telerik.Reporting.TextBox tipo_dispositivoCaptionTextBox;
        private Telerik.Reporting.TextBox instalacionCaptionTextBox;
        private Telerik.Reporting.TextBox clienteCaptionTextBox;
        private Telerik.Reporting.TextBox numero_industriaCaptionTextBox;
        private Telerik.Reporting.TextBox nombreCaptionTextBox;
        private Telerik.Reporting.TextBox fecha_caducidadDataTextBox;
        private Telerik.Reporting.TextBox posicionDataTextBox;
        private Telerik.Reporting.TextBox tipo_dispositivoDataTextBox;
        private Telerik.Reporting.TextBox instalacionDataTextBox;
        private Telerik.Reporting.TextBox clienteDataTextBox;
        private Telerik.Reporting.TextBox numero_industriaDataTextBox;
        private Telerik.Reporting.TextBox nombreDataTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.SubReport subReport2;
        private RptRevisionDispositivo rptRevisionDispositivo1;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
    }
}