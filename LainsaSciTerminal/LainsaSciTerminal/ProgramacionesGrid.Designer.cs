namespace LainsaSciTerminal
{
    partial class ProgramacionesGrid
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
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.grdProgramas = new System.Windows.Forms.DataGrid();
            this.lblSC = new System.Windows.Forms.Label();
            this.lblEC = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.mnuGeneral.Text = "Menu";
            // 
            // grdProgramas
            // 
            this.grdProgramas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdProgramas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdProgramas.Location = new System.Drawing.Point(0, 48);
            this.grdProgramas.Name = "grdProgramas";
            this.grdProgramas.Size = new System.Drawing.Size(240, 220);
            this.grdProgramas.TabIndex = 0;
            this.grdProgramas.DoubleClick += new System.EventHandler(this.grdProgramas_DoubleClick);
            // 
            // lblSC
            // 
            this.lblSC.BackColor = System.Drawing.Color.White;
            this.lblSC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSC.Location = new System.Drawing.Point(0, 0);
            this.lblSC.Name = "lblSC";
            this.lblSC.Size = new System.Drawing.Size(240, 15);
            this.lblSC.Text = "SIN COMENZAR: 10";
            // 
            // lblEC
            // 
            this.lblEC.BackColor = System.Drawing.Color.White;
            this.lblEC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEC.Location = new System.Drawing.Point(0, 15);
            this.lblEC.Name = "lblEC";
            this.lblEC.Size = new System.Drawing.Size(240, 15);
            this.lblEC.Text = "EN CURSO: 10";
            // 
            // lblF
            // 
            this.lblF.BackColor = System.Drawing.Color.White;
            this.lblF.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblF.Location = new System.Drawing.Point(0, 30);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(240, 15);
            this.lblF.Text = "FINALIZADA: 10";
            // 
            // ProgramacionesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.lblEC);
            this.Controls.Add(this.lblSC);
            this.Controls.Add(this.grdProgramas);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "ProgramacionesGrid";
            this.Text = "FALCK - SCI (Programas)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgramacionesGrid_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.DataGrid grdProgramas;
        private System.Windows.Forms.Label lblSC;
        private System.Windows.Forms.Label lblEC;
        private System.Windows.Forms.Label lblF;
    }
}