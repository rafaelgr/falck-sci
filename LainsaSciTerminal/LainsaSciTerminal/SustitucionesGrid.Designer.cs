namespace LainsaSciTerminal
{
    partial class SustitucionesGrid
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
            this.grdSustituciones = new System.Windows.Forms.DataGrid();
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.mnuCambio = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // grdSustituciones
            // 
            this.grdSustituciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdSustituciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdSustituciones.Location = new System.Drawing.Point(0, -5);
            this.grdSustituciones.Name = "grdSustituciones";
            this.grdSustituciones.Size = new System.Drawing.Size(240, 273);
            this.grdSustituciones.TabIndex = 0;
            this.grdSustituciones.DoubleClick += new System.EventHandler(this.grdSustituciones_DoubleClick);
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
            this.mnuGeneral.MenuItems.Add(this.mnuCambio);
            this.mnuGeneral.Text = "Menu";
            // 
            // mnuCambio
            // 
            this.mnuCambio.Text = "Nueva";
            this.mnuCambio.Click += new System.EventHandler(this.mnuCambio_Click);
            // 
            // SustitucionesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.grdSustituciones);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "SustitucionesGrid";
            this.Text = "FALCK - SCI (Sustituciones)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SustitucionesGrid_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdSustituciones;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.MenuItem mnuCambio;
    }
}