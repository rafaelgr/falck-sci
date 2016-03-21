namespace LainsaSciTerminal
{
    partial class DispostitivoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.nueva_sustitucion = new System.Windows.Forms.MenuItem();
            this.nueva_incidencia = new System.Windows.Forms.MenuItem();
            this.grdRevisiones = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdTipoA = new System.Windows.Forms.DataGrid();
            this.lblAnomalia = new System.Windows.Forms.Label();
            this.grdIncidencias = new System.Windows.Forms.DataGrid();
            this.lblIncidencias = new System.Windows.Forms.Label();
            this.lblSustituciones = new System.Windows.Forms.Label();
            this.lblRevisiones = new System.Windows.Forms.Label();
            this.grdSustituciones = new System.Windows.Forms.DataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTipoOp = new System.Windows.Forms.Label();
            this.lblInst = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.Add(this.mnuSalir);
            this.mnuMain.MenuItems.Add(this.mnuGeneral);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuGeneral
            // 
            this.mnuGeneral.MenuItems.Add(this.nueva_sustitucion);
            this.mnuGeneral.MenuItems.Add(this.nueva_incidencia);
            this.mnuGeneral.Text = "Menu";
            // 
            // nueva_sustitucion
            // 
            this.nueva_sustitucion.Text = "Crear sustitución";
            this.nueva_sustitucion.Click += new System.EventHandler(this.nueva_sustitucion_Click);
            // 
            // nueva_incidencia
            // 
            this.nueva_incidencia.Text = "Crear incidencia";
            this.nueva_incidencia.Click += new System.EventHandler(this.nueva_incidencia_Click);
            // 
            // grdRevisiones
            // 
            this.grdRevisiones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdRevisiones.Location = new System.Drawing.Point(0, 63);
            this.grdRevisiones.Name = "grdRevisiones";
            this.grdRevisiones.Size = new System.Drawing.Size(221, 57);
            this.grdRevisiones.TabIndex = 3;
            this.grdRevisiones.DoubleClick += new System.EventHandler(this.grdRevisiones_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.grdTipoA);
            this.panel1.Controls.Add(this.lblAnomalia);
            this.panel1.Controls.Add(this.grdIncidencias);
            this.panel1.Controls.Add(this.lblIncidencias);
            this.panel1.Controls.Add(this.lblSustituciones);
            this.panel1.Controls.Add(this.lblRevisiones);
            this.panel1.Controls.Add(this.grdSustituciones);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grdRevisiones);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 325);
            // 
            // grdTipoA
            // 
            this.grdTipoA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTipoA.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdTipoA.Location = new System.Drawing.Point(0, 281);
            this.grdTipoA.Name = "grdTipoA";
            this.grdTipoA.Size = new System.Drawing.Size(182, 44);
            this.grdTipoA.TabIndex = 12;
            // 
            // lblAnomalia
            // 
            this.lblAnomalia.Location = new System.Drawing.Point(0, 268);
            this.lblAnomalia.Name = "lblAnomalia";
            this.lblAnomalia.Size = new System.Drawing.Size(100, 14);
            this.lblAnomalia.Text = "Anomalías:";
            // 
            // grdIncidencias
            // 
            this.grdIncidencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIncidencias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdIncidencias.Location = new System.Drawing.Point(0, 212);
            this.grdIncidencias.Name = "grdIncidencias";
            this.grdIncidencias.Size = new System.Drawing.Size(182, 52);
            this.grdIncidencias.TabIndex = 6;
            this.grdIncidencias.DoubleClick += new System.EventHandler(this.grdIncidencias_DoubleClick);
            // 
            // lblIncidencias
            // 
            this.lblIncidencias.Location = new System.Drawing.Point(0, 200);
            this.lblIncidencias.Name = "lblIncidencias";
            this.lblIncidencias.Size = new System.Drawing.Size(100, 18);
            this.lblIncidencias.Text = "Incidencias:";
            // 
            // lblSustituciones
            // 
            this.lblSustituciones.Location = new System.Drawing.Point(0, 123);
            this.lblSustituciones.Name = "lblSustituciones";
            this.lblSustituciones.Size = new System.Drawing.Size(103, 13);
            this.lblSustituciones.Text = "Sustituciones:";
            // 
            // lblRevisiones
            // 
            this.lblRevisiones.Location = new System.Drawing.Point(3, 42);
            this.lblRevisiones.Name = "lblRevisiones";
            this.lblRevisiones.Size = new System.Drawing.Size(100, 18);
            this.lblRevisiones.Text = "Revisiones:";
            // 
            // grdSustituciones
            // 
            this.grdSustituciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSustituciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdSustituciones.Location = new System.Drawing.Point(0, 141);
            this.grdSustituciones.Name = "grdSustituciones";
            this.grdSustituciones.Size = new System.Drawing.Size(182, 56);
            this.grdSustituciones.TabIndex = 9;
            this.grdSustituciones.DoubleClick += new System.EventHandler(this.grdSustituciones_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.lblTipoOp);
            this.panel2.Controls.Add(this.lblInst);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 39);
            // 
            // lblTipoOp
            // 
            this.lblTipoOp.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoOp.Location = new System.Drawing.Point(4, 15);
            this.lblTipoOp.Name = "lblTipoOp";
            this.lblTipoOp.Size = new System.Drawing.Size(211, 15);
            this.lblTipoOp.Text = "label2";
            // 
            // lblInst
            // 
            this.lblInst.BackColor = System.Drawing.Color.Transparent;
            this.lblInst.Location = new System.Drawing.Point(4, 1);
            this.lblInst.Name = "lblInst";
            this.lblInst.Size = new System.Drawing.Size(211, 14);
            this.lblInst.Text = "label1";
            // 
            // DispostitivoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "DispostitivoForm";
            this.Text = "FALCK-SCI Dispositivo";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.DataGrid grdRevisiones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRevisiones;
        private System.Windows.Forms.Label lblIncidencias;
        private System.Windows.Forms.DataGrid grdIncidencias;
        private System.Windows.Forms.Label lblSustituciones;
        private System.Windows.Forms.DataGrid grdSustituciones;
        private System.Windows.Forms.DataGrid grdTipoA;
        private System.Windows.Forms.Label lblAnomalia;
        private System.Windows.Forms.Label lblTipoOp;
        private System.Windows.Forms.Label lblInst;
        private System.Windows.Forms.MenuItem nueva_incidencia;
        private System.Windows.Forms.MenuItem nueva_sustitucion;
    }
}