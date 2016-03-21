namespace LainsaSciTerminal
{
    partial class IncidenciasGrid
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
            this.grdIncidencias = new System.Windows.Forms.DataGrid();
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.mnuNueva = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // grdIncidencias
            // 
            this.grdIncidencias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdIncidencias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdIncidencias.Location = new System.Drawing.Point(0, -5);
            this.grdIncidencias.Name = "grdIncidencias";
            this.grdIncidencias.Size = new System.Drawing.Size(240, 273);
            this.grdIncidencias.TabIndex = 0;
            this.grdIncidencias.DoubleClick += new System.EventHandler(this.grdIncidencias_DoubleClick);
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
            // IncidenciasGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.grdIncidencias);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "IncidenciasGrid";
            this.Text = "FALCK - SCI (Incidencias)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IncidenciasGrid_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdIncidencias;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.MenuItem mnuNueva;
    }
}