namespace LainsaSciTerminal
{
    partial class CFinalForm
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
            this.mnuPrimero = new System.Windows.Forms.MenuItem();
            this.mnuAnterior = new System.Windows.Forms.MenuItem();
            this.mnuSiguiente = new System.Windows.Forms.MenuItem();
            this.mnuUltimo = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuAceptar = new System.Windows.Forms.MenuItem();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.lblPlantilla = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbTipoAnomalia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSustituciones = new System.Windows.Forms.Button();
            this.btnIncidencias = new System.Windows.Forms.Button();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrimero
            // 
            this.mnuPrimero.Text = "<<";
            this.mnuPrimero.Click += new System.EventHandler(this.mnuPrimero_Click);
            // 
            // mnuAnterior
            // 
            this.mnuAnterior.Text = "<";
            this.mnuAnterior.Click += new System.EventHandler(this.mnuAnterior_Click);
            // 
            // mnuSiguiente
            // 
            this.mnuSiguiente.Enabled = false;
            this.mnuSiguiente.Text = ">";
            this.mnuSiguiente.Click += new System.EventHandler(this.mnuSiguiente_Click);
            // 
            // mnuUltimo
            // 
            this.mnuUltimo.Enabled = false;
            this.mnuUltimo.Text = ">>";
            this.mnuUltimo.Click += new System.EventHandler(this.mnuUltimo_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuSalir);
            this.mainMenu1.MenuItems.Add(this.mnuPrimero);
            this.mainMenu1.MenuItems.Add(this.mnuAnterior);
            this.mainMenu1.MenuItems.Add(this.mnuSiguiente);
            this.mainMenu1.MenuItems.Add(this.mnuUltimo);
            this.mainMenu1.MenuItems.Add(this.mnuAceptar);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuAceptar
            // 
            this.mnuAceptar.Text = "ACEPTAR";
            this.mnuAceptar.Click += new System.EventHandler(this.mnuAceptar_Click);
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.BackColor = System.Drawing.Color.White;
            this.lblDispositivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispositivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDispositivo.ForeColor = System.Drawing.Color.Blue;
            this.lblDispositivo.Location = new System.Drawing.Point(0, 16);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(243, 18);
            this.lblDispositivo.Text = "-----------";
            this.lblDispositivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDispositivo.ParentChanged += new System.EventHandler(this.lblDispositivo_ParentChanged);
            // 
            // lblPlantilla
            // 
            this.lblPlantilla.BackColor = System.Drawing.Color.White;
            this.lblPlantilla.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlantilla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPlantilla.ForeColor = System.Drawing.Color.Blue;
            this.lblPlantilla.Location = new System.Drawing.Point(0, 0);
            this.lblPlantilla.Name = "lblPlantilla";
            this.lblPlantilla.Size = new System.Drawing.Size(243, 16);
            this.lblPlantilla.Text = "Revisión: Quinquenal de extintores. (1/3)";
            this.lblPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.cmbUsuario);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 51);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbUsuario.Location = new System.Drawing.Point(0, 20);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(240, 22);
            this.cmbUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(240, 20);
            this.lblUsuario.Text = "Usuario";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaShell;
            this.panel3.Controls.Add(this.dtpFecha);
            this.panel3.Controls.Add(this.lblFecha);
            this.panel3.Location = new System.Drawing.Point(3, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 51);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(0, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(91, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFecha.Location = new System.Drawing.Point(0, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(91, 20);
            this.lblFecha.Text = "Fecha";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.txtResultado);
            this.panel1.Controls.Add(this.lblResultado);
            this.panel1.Location = new System.Drawing.Point(3, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 48);
            // 
            // txtResultado
            // 
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResultado.Location = new System.Drawing.Point(0, 20);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(237, 21);
            this.txtResultado.TabIndex = 4;
            // 
            // lblResultado
            // 
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Location = new System.Drawing.Point(0, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(237, 20);
            this.lblResultado.Text = "Resultado:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.txtComentario);
            this.panel4.Controls.Add(this.lblComentario);
            this.panel4.Location = new System.Drawing.Point(3, 213);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 56);
            // 
            // txtComentario
            // 
            this.txtComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComentario.Location = new System.Drawing.Point(0, 20);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(237, 26);
            this.txtComentario.TabIndex = 5;
            // 
            // lblComentario
            // 
            this.lblComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentario.Location = new System.Drawing.Point(0, 0);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(237, 20);
            this.lblComentario.Text = "Comentarios";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaShell;
            this.panel5.Controls.Add(this.cmbTipoAnomalia);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(100, 109);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(140, 51);
            // 
            // cmbTipoAnomalia
            // 
            this.cmbTipoAnomalia.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTipoAnomalia.Location = new System.Drawing.Point(0, 20);
            this.cmbTipoAnomalia.Name = "cmbTipoAnomalia";
            this.cmbTipoAnomalia.Size = new System.Drawing.Size(140, 22);
            this.cmbTipoAnomalia.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.Text = "Tipo anomalia";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SeaShell;
            this.panel6.Controls.Add(this.btnSustituciones);
            this.panel6.Controls.Add(this.btnIncidencias);
            this.panel6.Location = new System.Drawing.Point(3, 275);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 26);
            // 
            // btnSustituciones
            // 
            this.btnSustituciones.Location = new System.Drawing.Point(141, 3);
            this.btnSustituciones.Name = "btnSustituciones";
            this.btnSustituciones.Size = new System.Drawing.Size(93, 20);
            this.btnSustituciones.TabIndex = 7;
            this.btnSustituciones.Text = "Sustituciones";
            this.btnSustituciones.Click += new System.EventHandler(this.btnSustituciones_Click);
            // 
            // btnIncidencias
            // 
            this.btnIncidencias.Location = new System.Drawing.Point(56, 3);
            this.btnIncidencias.Name = "btnIncidencias";
            this.btnIncidencias.Size = new System.Drawing.Size(79, 20);
            this.btnIncidencias.TabIndex = 6;
            this.btnIncidencias.Text = "Incidencias";
            this.btnIncidencias.Click += new System.EventHandler(this.btnIncidencias_Click);
            // 
            // lblPosicion
            // 
            this.lblPosicion.BackColor = System.Drawing.Color.White;
            this.lblPosicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPosicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPosicion.ForeColor = System.Drawing.Color.Blue;
            this.lblPosicion.Location = new System.Drawing.Point(0, 34);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(243, 18);
            this.lblPosicion.Text = "-----------";
            this.lblPosicion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CFinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 285);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.lblPlantilla);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "CFinalForm";
            this.Text = "FALCK -SCI Revisión";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CFinalForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuPrimero;
        private System.Windows.Forms.MenuItem mnuAnterior;
        private System.Windows.Forms.MenuItem mnuSiguiente;
        private System.Windows.Forms.MenuItem mnuUltimo;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Label lblPlantilla;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuItem mnuAceptar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmbTipoAnomalia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSustituciones;
        private System.Windows.Forms.Button btnIncidencias;
        private System.Windows.Forms.Label lblPosicion;

    }
}