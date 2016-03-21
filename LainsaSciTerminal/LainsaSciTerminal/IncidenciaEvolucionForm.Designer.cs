namespace LainsaSciTerminal
{
    partial class IncidenciaEvolucionForm
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
            this.txtFechaEvolucion = new System.Windows.Forms.TextBox();
            this.lblFechaEvolucion = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkOperativo = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 51);
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
            this.lblUsuario.Size = new System.Drawing.Size(238, 20);
            this.lblUsuario.Text = "Usuario";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaShell;
            this.panel3.Controls.Add(this.txtFechaEvolucion);
            this.panel3.Controls.Add(this.lblFechaEvolucion);
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 51);
            // 
            // txtFechaEvolucion
            // 
            this.txtFechaEvolucion.Enabled = false;
            this.txtFechaEvolucion.Location = new System.Drawing.Point(4, 23);
            this.txtFechaEvolucion.Name = "txtFechaEvolucion";
            this.txtFechaEvolucion.Size = new System.Drawing.Size(197, 21);
            this.txtFechaEvolucion.TabIndex = 2;
            // 
            // lblFechaEvolucion
            // 
            this.lblFechaEvolucion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaEvolucion.Location = new System.Drawing.Point(0, 0);
            this.lblFechaEvolucion.Name = "lblFechaEvolucion";
            this.lblFechaEvolucion.Size = new System.Drawing.Size(228, 20);
            this.lblFechaEvolucion.Text = "Fecha";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.txtComentario);
            this.panel4.Controls.Add(this.lblComentario);
            this.panel4.Location = new System.Drawing.Point(0, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 107);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(4, 23);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(215, 66);
            this.txtComentario.TabIndex = 9;
            // 
            // lblComentario
            // 
            this.lblComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentario.Location = new System.Drawing.Point(0, 0);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(238, 20);
            this.lblComentario.Text = "Comentarios:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaShell;
            this.panel5.Controls.Add(this.chkOperativo);
            this.panel5.Location = new System.Drawing.Point(0, 138);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 33);
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
            this.panel7.Controls.Add(this.btnCerrar);
            this.panel7.Controls.Add(this.btnEliminar);
            this.panel7.Location = new System.Drawing.Point(1, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 25);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(146, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 20);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(124, 20);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar incidencia";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // IncidenciaEvolucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "IncidenciaEvolucionForm";
            this.Text = "Evolucion";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuItem mnuAceptar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaEvolucion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkOperativo;
        private System.Windows.Forms.TextBox txtFechaEvolucion;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnCerrar;
    }
}