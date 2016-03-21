namespace LainsaSciTerminal
{
    partial class CSNForm
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
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.lblPlantilla = new System.Windows.Forms.Label();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSN = new System.Windows.Forms.CheckBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuPrimero = new System.Windows.Forms.MenuItem();
            this.mnuAnterior = new System.Windows.Forms.MenuItem();
            this.mnuSiguiente = new System.Windows.Forms.MenuItem();
            this.mnuUltimo = new System.Windows.Forms.MenuItem();
            this.mnuFin = new System.Windows.Forms.MenuItem();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.BackColor = System.Drawing.Color.White;
            this.lblDispositivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispositivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDispositivo.ForeColor = System.Drawing.Color.Blue;
            this.lblDispositivo.Location = new System.Drawing.Point(0, 19);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(240, 20);
            this.lblDispositivo.Text = "-----------";
            this.lblDispositivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlantilla
            // 
            this.lblPlantilla.BackColor = System.Drawing.Color.White;
            this.lblPlantilla.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlantilla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPlantilla.ForeColor = System.Drawing.Color.Blue;
            this.lblPlantilla.Location = new System.Drawing.Point(0, 0);
            this.lblPlantilla.Name = "lblPlantilla";
            this.lblPlantilla.Size = new System.Drawing.Size(240, 19);
            this.lblPlantilla.Text = "Revisión: Quinquenal de extintores. (1/3)";
            this.lblPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblComentarios
            // 
            this.lblComentarios.BackColor = System.Drawing.Color.SeaShell;
            this.lblComentarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentarios.Location = new System.Drawing.Point(0, 0);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(240, 20);
            this.lblComentarios.Text = "Comentarios:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.BackColor = System.Drawing.Color.White;
            this.txtComentarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtComentarios.Location = new System.Drawing.Point(0, 24);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(240, 73);
            this.txtComentarios.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.chkSN);
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 103);
            // 
            // chkSN
            // 
            this.chkSN.BackColor = System.Drawing.Color.SeaShell;
            this.chkSN.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSN.Location = new System.Drawing.Point(0, 0);
            this.chkSN.Name = "chkSN";
            this.chkSN.Size = new System.Drawing.Size(33, 103);
            this.chkSN.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.SeaShell;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNombre.Location = new System.Drawing.Point(39, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(201, 103);
            this.lblNombre.Text = "Nombre del campo";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaShell;
            this.panel3.Controls.Add(this.lblComentarios);
            this.panel3.Controls.Add(this.txtComentarios);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 97);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuSalir);
            this.mainMenu1.MenuItems.Add(this.mnuPrimero);
            this.mainMenu1.MenuItems.Add(this.mnuAnterior);
            this.mainMenu1.MenuItems.Add(this.mnuSiguiente);
            this.mainMenu1.MenuItems.Add(this.mnuUltimo);
            this.mainMenu1.MenuItems.Add(this.mnuFin);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
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
            this.mnuSiguiente.Text = ">";
            this.mnuSiguiente.Click += new System.EventHandler(this.mnuSiguiente_Click);
            // 
            // mnuUltimo
            // 
            this.mnuUltimo.Text = ">>";
            this.mnuUltimo.Click += new System.EventHandler(this.mnuUltimo_Click);
            // 
            // mnuFin
            // 
            this.mnuFin.Text = "FIN";
            this.mnuFin.Click += new System.EventHandler(this.mnuFin_Click);
            // 
            // lblPosicion
            // 
            this.lblPosicion.BackColor = System.Drawing.Color.White;
            this.lblPosicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPosicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPosicion.ForeColor = System.Drawing.Color.Blue;
            this.lblPosicion.Location = new System.Drawing.Point(0, 39);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(240, 20);
            this.lblPosicion.Text = "-----------";
            this.lblPosicion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CSNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.lblPlantilla);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "CSNForm";
            this.Text = "FALCK -SCI Revisión";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CSNForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Label lblPlantilla;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSN;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuPrimero;
        private System.Windows.Forms.MenuItem mnuAnterior;
        private System.Windows.Forms.MenuItem mnuSiguiente;
        private System.Windows.Forms.MenuItem mnuUltimo;
        private System.Windows.Forms.MenuItem mnuFin;
        private System.Windows.Forms.Label lblPosicion;

    }
}