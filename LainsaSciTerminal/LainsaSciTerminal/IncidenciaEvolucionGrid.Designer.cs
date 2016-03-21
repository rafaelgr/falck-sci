namespace LainsaSciTerminal
{
    partial class IncidenciasEvolucionGrid
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
            this.grdIncidenciaEvolucion = new System.Windows.Forms.DataGrid();
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.mnuNueva = new System.Windows.Forms.MenuItem();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.lblFechas = new System.Windows.Forms.Label();
            this.lblEstadoPrioridad = new System.Windows.Forms.Label();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grdIncidenciaEvolucion
            // 
            this.grdIncidenciaEvolucion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdIncidenciaEvolucion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdIncidenciaEvolucion.Location = new System.Drawing.Point(0, 86);
            this.grdIncidenciaEvolucion.Name = "grdIncidenciaEvolucion";
            this.grdIncidenciaEvolucion.Size = new System.Drawing.Size(240, 182);
            this.grdIncidenciaEvolucion.TabIndex = 0;
            this.grdIncidenciaEvolucion.DoubleClick += new System.EventHandler(this.grdIncidenciaEvolucion_DoubleClick);
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
            this.mnuGeneral.MenuItems.Add(this.mnuNueva);
            this.mnuGeneral.Text = "Menu";
            // 
            // mnuNueva
            // 
            this.mnuNueva.Text = "Nueva";
            this.mnuNueva.Click += new System.EventHandler(this.mnuNueva_Click);
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.Location = new System.Drawing.Point(3, 0);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(234, 21);
            this.lblDispositivo.Text = "Información dispositivo";
            this.lblDispositivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFechas
            // 
            this.lblFechas.Location = new System.Drawing.Point(3, 21);
            this.lblFechas.Name = "lblFechas";
            this.lblFechas.Size = new System.Drawing.Size(234, 21);
            this.lblFechas.Text = "FA:01/01/2011 FC:02/02/2013";
            this.lblFechas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEstadoPrioridad
            // 
            this.lblEstadoPrioridad.Location = new System.Drawing.Point(3, 42);
            this.lblEstadoPrioridad.Name = "lblEstadoPrioridad";
            this.lblEstadoPrioridad.Size = new System.Drawing.Size(234, 21);
            this.lblEstadoPrioridad.Text = "Estado / Prioridad";
            this.lblEstadoPrioridad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblResponsable
            // 
            this.lblResponsable.Location = new System.Drawing.Point(0, 63);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(234, 21);
            this.lblResponsable.Text = "Responsable";
            this.lblResponsable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IncidenciasEvolucionGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.lblEstadoPrioridad);
            this.Controls.Add(this.lblFechas);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.grdIncidenciaEvolucion);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "IncidenciasEvolucionGrid";
            this.Text = "FALCK - SCI (Evolución incidencias)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdIncidenciaEvolucion;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.MenuItem mnuNueva;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Label lblFechas;
        private System.Windows.Forms.Label lblEstadoPrioridad;
        private System.Windows.Forms.Label lblResponsable;
    }
}