namespace LainsaSciTerminal
{
    partial class SustitucionForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuAceptar = new System.Windows.Forms.MenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDOId = new System.Windows.Forms.Label();
            this.btnDO = new System.Windows.Forms.Button();
            this.txtDispODatos = new System.Windows.Forms.TextBox();
            this.txtDispO = new System.Windows.Forms.TextBox();
            this.lblDispO = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDSId = new System.Windows.Forms.Label();
            this.btnS = new System.Windows.Forms.Button();
            this.txtDispSDatos = new System.Windows.Forms.TextBox();
            this.txtDispS = new System.Windows.Forms.TextBox();
            this.lblDispS = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuSalir);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.cmbUsuario);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(3, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 36);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbUsuario.Location = new System.Drawing.Point(0, 14);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(240, 22);
            this.cmbUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(240, 14);
            this.lblUsuario.Text = "Usuario";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaShell;
            this.panel3.Controls.Add(this.dtpFecha);
            this.panel3.Controls.Add(this.lblFecha);
            this.panel3.Location = new System.Drawing.Point(3, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 43);
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
            this.panel1.Controls.Add(this.lblDOId);
            this.panel1.Controls.Add(this.btnDO);
            this.panel1.Controls.Add(this.txtDispODatos);
            this.panel1.Controls.Add(this.txtDispO);
            this.panel1.Controls.Add(this.lblDispO);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 80);
            // 
            // lblDOId
            // 
            this.lblDOId.Location = new System.Drawing.Point(130, -3);
            this.lblDOId.Name = "lblDOId";
            this.lblDOId.Size = new System.Drawing.Size(29, 20);
            this.lblDOId.Visible = false;
            // 
            // btnDO
            // 
            this.btnDO.Location = new System.Drawing.Point(165, 0);
            this.btnDO.Name = "btnDO";
            this.btnDO.Size = new System.Drawing.Size(72, 20);
            this.btnDO.TabIndex = 5;
            this.btnDO.Text = "Asignar";
            this.btnDO.Click += new System.EventHandler(this.btnDO_Click);
            // 
            // txtDispODatos
            // 
            this.txtDispODatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDispODatos.Enabled = false;
            this.txtDispODatos.Location = new System.Drawing.Point(0, 41);
            this.txtDispODatos.Multiline = true;
            this.txtDispODatos.Name = "txtDispODatos";
            this.txtDispODatos.ReadOnly = true;
            this.txtDispODatos.Size = new System.Drawing.Size(240, 39);
            this.txtDispODatos.TabIndex = 0;
            this.txtDispODatos.TabStop = false;
            // 
            // txtDispO
            // 
            this.txtDispO.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDispO.Location = new System.Drawing.Point(0, 20);
            this.txtDispO.Name = "txtDispO";
            this.txtDispO.Size = new System.Drawing.Size(240, 21);
            this.txtDispO.TabIndex = 4;
            // 
            // lblDispO
            // 
            this.lblDispO.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispO.Location = new System.Drawing.Point(0, 0);
            this.lblDispO.Name = "lblDispO";
            this.lblDispO.Size = new System.Drawing.Size(240, 20);
            this.lblDispO.Text = "Dispositivo a sustituir:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.txtComentario);
            this.panel4.Controls.Add(this.lblComentario);
            this.panel4.Location = new System.Drawing.Point(0, 277);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 34);
            // 
            // txtComentario
            // 
            this.txtComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComentario.Location = new System.Drawing.Point(0, 14);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(240, 20);
            this.txtComentario.TabIndex = 8;
            // 
            // lblComentario
            // 
            this.lblComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentario.Location = new System.Drawing.Point(0, 0);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(240, 14);
            this.lblComentario.Text = "Comentarios";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaShell;
            this.panel5.Controls.Add(this.cmbEstado);
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Location = new System.Drawing.Point(97, 68);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(140, 43);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbEstado.Location = new System.Drawing.Point(0, 20);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(140, 22);
            this.cmbEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstado.Location = new System.Drawing.Point(0, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(140, 20);
            this.lblEstado.Text = "Estado";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SeaShell;
            this.panel6.Controls.Add(this.lblDSId);
            this.panel6.Controls.Add(this.btnS);
            this.panel6.Controls.Add(this.txtDispSDatos);
            this.panel6.Controls.Add(this.txtDispS);
            this.panel6.Controls.Add(this.lblDispS);
            this.panel6.Location = new System.Drawing.Point(0, 194);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 81);
            // 
            // lblDSId
            // 
            this.lblDSId.Location = new System.Drawing.Point(130, -3);
            this.lblDSId.Name = "lblDSId";
            this.lblDSId.Size = new System.Drawing.Size(29, 20);
            this.lblDSId.Visible = false;
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(165, 0);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(72, 20);
            this.btnS.TabIndex = 7;
            this.btnS.Text = "Asignar";
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // txtDispSDatos
            // 
            this.txtDispSDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDispSDatos.Enabled = false;
            this.txtDispSDatos.Location = new System.Drawing.Point(0, 41);
            this.txtDispSDatos.Multiline = true;
            this.txtDispSDatos.Name = "txtDispSDatos";
            this.txtDispSDatos.ReadOnly = true;
            this.txtDispSDatos.Size = new System.Drawing.Size(240, 39);
            this.txtDispSDatos.TabIndex = 0;
            this.txtDispSDatos.TabStop = false;
            // 
            // txtDispS
            // 
            this.txtDispS.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDispS.Location = new System.Drawing.Point(0, 20);
            this.txtDispS.Name = "txtDispS";
            this.txtDispS.Size = new System.Drawing.Size(240, 21);
            this.txtDispS.TabIndex = 6;
            // 
            // lblDispS
            // 
            this.lblDispS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispS.Location = new System.Drawing.Point(0, 0);
            this.lblDispS.Name = "lblDispS";
            this.lblDispS.Size = new System.Drawing.Size(240, 20);
            this.lblDispS.Text = "Dispositivo sustituto:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.SeaShell;
            this.panel7.Controls.Add(this.btnEliminar);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 25);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(162, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 20);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // SustitucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "SustitucionForm";
            this.Text = "Sustitución";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SustitucionForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuItem mnuAceptar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtDispO;
        private System.Windows.Forms.Label lblDispO;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDispS;
        private System.Windows.Forms.Label lblDispS;
        private System.Windows.Forms.TextBox txtDispODatos;
        private System.Windows.Forms.TextBox txtDispSDatos;
        private System.Windows.Forms.Button btnDO;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Label lblDOId;
        private System.Windows.Forms.Label lblDSId;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnEliminar;
    }
}