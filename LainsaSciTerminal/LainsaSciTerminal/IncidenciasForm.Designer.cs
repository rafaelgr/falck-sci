namespace LainsaSciTerminal
{
    partial class IncidenciasForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuAceptar = new System.Windows.Forms.MenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFechaApertura = new System.Windows.Forms.TextBox();
            this.lblFechaApertura = new System.Windows.Forms.Label();
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
            this.chkOperativo = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnEvolucion = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.txtFechaCierre = new System.Windows.Forms.TextBox();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaPrevista = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
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
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(1, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 51);
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(4, 24);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(215, 21);
            this.txtUser.TabIndex = 1;
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
            this.panel3.Controls.Add(this.txtFechaApertura);
            this.panel3.Controls.Add(this.lblFechaApertura);
            this.panel3.Location = new System.Drawing.Point(1, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(117, 51);
            // 
            // txtFechaApertura
            // 
            this.txtFechaApertura.Enabled = false;
            this.txtFechaApertura.Location = new System.Drawing.Point(4, 23);
            this.txtFechaApertura.Name = "txtFechaApertura";
            this.txtFechaApertura.Size = new System.Drawing.Size(99, 21);
            this.txtFechaApertura.TabIndex = 2;
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaApertura.Location = new System.Drawing.Point(0, 0);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(117, 20);
            this.lblFechaApertura.Text = "Fecha apertura";
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
            this.panel1.Location = new System.Drawing.Point(1, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 72);
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
            this.txtDispODatos.Name = "txtDispODatos";
            this.txtDispODatos.ReadOnly = true;
            this.txtDispODatos.Size = new System.Drawing.Size(237, 21);
            this.txtDispODatos.TabIndex = 6;
            this.txtDispODatos.TabStop = false;
            // 
            // txtDispO
            // 
            this.txtDispO.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDispO.Location = new System.Drawing.Point(0, 20);
            this.txtDispO.Name = "txtDispO";
            this.txtDispO.Size = new System.Drawing.Size(237, 21);
            this.txtDispO.TabIndex = 4;
            // 
            // lblDispO
            // 
            this.lblDispO.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispO.Location = new System.Drawing.Point(0, 0);
            this.lblDispO.Name = "lblDispO";
            this.lblDispO.Size = new System.Drawing.Size(237, 20);
            this.lblDispO.Text = "Dispositivo:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.txtComentario);
            this.panel4.Controls.Add(this.lblComentario);
            this.panel4.Location = new System.Drawing.Point(0, 400);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 56);
            // 
            // txtComentario
            // 
            this.txtComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComentario.Location = new System.Drawing.Point(0, 20);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(237, 24);
            this.txtComentario.TabIndex = 7;
            // 
            // lblComentario
            // 
            this.lblComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentario.Location = new System.Drawing.Point(0, 0);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(237, 20);
            this.lblComentario.Text = "Comentarios:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaShell;
            this.panel5.Controls.Add(this.chkOperativo);
            this.panel5.Location = new System.Drawing.Point(1, 290);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 33);
            // 
            // chkOperativo
            // 
            this.chkOperativo.Location = new System.Drawing.Point(3, 3);
            this.chkOperativo.Name = "chkOperativo";
            this.chkOperativo.Size = new System.Drawing.Size(100, 20);
            this.chkOperativo.TabIndex = 3;
            this.chkOperativo.Text = "Inoperativo";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.SeaShell;
            this.panel7.Controls.Add(this.btnEvolucion);
            this.panel7.Controls.Add(this.btnEliminar);
            this.panel7.Location = new System.Drawing.Point(1, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 25);
            // 
            // btnEvolucion
            // 
            this.btnEvolucion.Location = new System.Drawing.Point(4, 2);
            this.btnEvolucion.Name = "btnEvolucion";
            this.btnEvolucion.Size = new System.Drawing.Size(72, 20);
            this.btnEvolucion.TabIndex = 8;
            this.btnEvolucion.Text = "Evolucion";
            this.btnEvolucion.Click += new System.EventHandler(this.btnEvolucion_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(162, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 20);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SeaShell;
            this.panel6.Controls.Add(this.txtFechaCierre);
            this.panel6.Controls.Add(this.lblFechaCierre);
            this.panel6.Location = new System.Drawing.Point(110, 88);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(124, 51);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.SeaShell;
            this.panel8.Controls.Add(this.cmbResponsable);
            this.panel8.Controls.Add(this.lblResponsable);
            this.panel8.Location = new System.Drawing.Point(0, 237);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(233, 51);
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.Location = new System.Drawing.Point(5, 24);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(215, 22);
            this.cmbResponsable.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.SeaShell;
            this.panel9.Controls.Add(this.cmbPrioridad);
            this.panel9.Controls.Add(this.lblPrioridad);
            this.panel9.Location = new System.Drawing.Point(110, 184);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(124, 51);
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.Location = new System.Drawing.Point(4, 21);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(106, 22);
            this.cmbPrioridad.TabIndex = 4;
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrioridad.Location = new System.Drawing.Point(0, 0);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(124, 20);
            this.lblPrioridad.Text = "Prioridad";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.SeaShell;
            this.panel10.Controls.Add(this.cmbEstado);
            this.panel10.Controls.Add(this.lblEstado);
            this.panel10.Location = new System.Drawing.Point(1, 184);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(117, 51);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Location = new System.Drawing.Point(4, 21);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 22);
            this.cmbEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstado.Location = new System.Drawing.Point(0, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(117, 20);
            this.lblEstado.Text = "Estado";
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaCierre.Location = new System.Drawing.Point(0, 0);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(124, 20);
            this.lblFechaCierre.Text = "Fecha cierre";
            // 
            // txtFechaCierre
            // 
            this.txtFechaCierre.Enabled = false;
            this.txtFechaCierre.Location = new System.Drawing.Point(4, 23);
            this.txtFechaCierre.Name = "txtFechaCierre";
            this.txtFechaCierre.Size = new System.Drawing.Size(106, 21);
            this.txtFechaCierre.TabIndex = 2;
            // 
            // lblResponsable
            // 
            this.lblResponsable.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResponsable.Location = new System.Drawing.Point(0, 0);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(233, 21);
            this.lblResponsable.Text = "Responsable";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.SeaShell;
            this.panel11.Controls.Add(this.dtFechaPrevista);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Location = new System.Drawing.Point(1, 138);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(230, 43);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.Text = "Fecha prevista de cierre";
            // 
            // dtFechaPrevista
            // 
            this.dtFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaPrevista.Location = new System.Drawing.Point(2, 18);
            this.dtFechaPrevista.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtFechaPrevista.Name = "dtFechaPrevista";
            this.dtFechaPrevista.Size = new System.Drawing.Size(217, 22);
            this.dtFechaPrevista.TabIndex = 4;
            this.dtFechaPrevista.Value = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            // 
            // IncidenciasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "IncidenciasForm";
            this.Text = "Incidencia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IncidenciasForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuItem mnuAceptar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDispO;
        private System.Windows.Forms.Label lblDispO;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtDispODatos;
        private System.Windows.Forms.Button btnDO;
        private System.Windows.Forms.Label lblDOId;
        private System.Windows.Forms.CheckBox chkOperativo;
        private System.Windows.Forms.TextBox txtFechaApertura;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnEvolucion;
        private System.Windows.Forms.TextBox txtFechaCierre;
        private System.Windows.Forms.Label lblFechaCierre;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaPrevista;
    }
}