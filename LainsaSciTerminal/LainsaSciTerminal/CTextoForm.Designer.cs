namespace LainsaSciTerminal
{
    partial class CTextoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.lblPlantilla = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuPrimero = new System.Windows.Forms.MenuItem();
            this.mnuAnterior = new System.Windows.Forms.MenuItem();
            this.mnuSiguiente = new System.Windows.Forms.MenuItem();
            this.mnuUltimo = new System.Windows.Forms.MenuItem();
            this.mnuFin = new System.Windows.Forms.MenuItem();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.txtComentarios);
            this.panel1.Controls.Add(this.lblComentarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 233);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(4, 28);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(233, 21);
            this.txtValor.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(4, 5);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(233, 20);
            this.lblNombre.Text = "Nombre del campo:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtComentarios.Location = new System.Drawing.Point(0, 95);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(257, 138);
            this.txtComentarios.TabIndex = 2;
            // 
            // lblComentarios
            // 
            this.lblComentarios.Location = new System.Drawing.Point(3, 72);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(222, 20);
            this.lblComentarios.Text = "Comentarios:";
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDispositivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDispositivo.ForeColor = System.Drawing.Color.Blue;
            this.lblDispositivo.Location = new System.Drawing.Point(0, 15);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(257, 17);
            this.lblDispositivo.Text = "-----------";
            this.lblDispositivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlantilla
            // 
            this.lblPlantilla.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlantilla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPlantilla.ForeColor = System.Drawing.Color.Blue;
            this.lblPlantilla.Location = new System.Drawing.Point(0, 0);
            this.lblPlantilla.Name = "lblPlantilla";
            this.lblPlantilla.Size = new System.Drawing.Size(257, 15);
            this.lblPlantilla.Text = "Revisión: Quinquenal de extintores. (1/3)";
            this.lblPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblPosicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPosicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPosicion.ForeColor = System.Drawing.Color.Blue;
            this.lblPosicion.Location = new System.Drawing.Point(0, 32);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(257, 17);
            this.lblPosicion.Text = "-----------";
            this.lblPosicion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CTextoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(257, 285);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.lblPlantilla);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "CTextoForm";
            this.Text = "FALCK -SCI Revisión";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTextoForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Label lblPlantilla;
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