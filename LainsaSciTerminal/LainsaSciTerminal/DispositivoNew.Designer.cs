namespace LainsaSciTerminal
{
    partial class DispositivoNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.mnuAceptar = new System.Windows.Forms.MenuItem();
            this.txtCaptura = new System.Windows.Forms.TextBox();
            this.lblCaptura = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbInst = new System.Windows.Forms.ComboBox();
            this.lblInstalacion = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.Add(this.mnuSalir);
            this.mnuMain.MenuItems.Add(this.mnuAceptar);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuAceptar
            // 
            this.mnuAceptar.Text = "Aceptar";
            this.mnuAceptar.Click += new System.EventHandler(this.mnuAceptar_Click);
            // 
            // txtCaptura
            // 
            this.txtCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaptura.Location = new System.Drawing.Point(16, 48);
            this.txtCaptura.Name = "txtCaptura";
            this.txtCaptura.Size = new System.Drawing.Size(202, 21);
            this.txtCaptura.TabIndex = 1;
            // 
            // lblCaptura
            // 
            this.lblCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaptura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblCaptura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCaptura.Location = new System.Drawing.Point(34, 11);
            this.lblCaptura.Name = "lblCaptura";
            this.lblCaptura.Size = new System.Drawing.Size(156, 34);
            this.lblCaptura.Text = "Lea o introduzca el código de barras";
            this.lblCaptura.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.cmbInst);
            this.panel2.Controls.Add(this.lblInstalacion);
            this.panel2.Controls.Add(this.cmbModelo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbTipo);
            this.panel2.Controls.Add(this.lblTipo);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 190);
            // 
            // cmbInst
            // 
            this.cmbInst.Location = new System.Drawing.Point(68, 51);
            this.cmbInst.Name = "cmbInst";
            this.cmbInst.Size = new System.Drawing.Size(169, 22);
            this.cmbInst.TabIndex = 3;
            // 
            // lblInstalacion
            // 
            this.lblInstalacion.Location = new System.Drawing.Point(3, 51);
            this.lblInstalacion.Name = "lblInstalacion";
            this.lblInstalacion.Size = new System.Drawing.Size(68, 20);
            this.lblInstalacion.Text = "Instalación";
            // 
            // cmbModelo
            // 
            this.cmbModelo.Location = new System.Drawing.Point(53, 134);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(184, 22);
            this.cmbModelo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.Text = "Modelo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Location = new System.Drawing.Point(34, 89);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(203, 22);
            this.cmbTipo.TabIndex = 4;
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(3, 89);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(41, 20);
            this.lblTipo.Text = "Tipo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 21);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(3, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 23);
            this.lblNombre.Text = "Nombre";
            // 
            // DispositivoNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtCaptura);
            this.Controls.Add(this.lblCaptura);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "DispositivoNew";
            this.Text = "FALCK-SCI Dispositivo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DispositivoNew_KeyDown);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuAceptar;
        private System.Windows.Forms.TextBox txtCaptura;
        private System.Windows.Forms.Label lblCaptura;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbInst;
        private System.Windows.Forms.Label lblInstalacion;

    }
}