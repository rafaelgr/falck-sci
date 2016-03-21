namespace LainsaSciTerminal
{
    partial class RevisionesGrid
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
            this.lblREA = new System.Windows.Forms.Label();
            this.lblPRO = new System.Windows.Forms.Label();
            this.lblPLA = new System.Windows.Forms.Label();
            this.grdRevisiones = new System.Windows.Forms.DataGrid();
            this.lblInst = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.Add(this.mnuSalir);
            this.mnuMain.MenuItems.Add(this.mnuGeneral);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Atrás";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuGeneral
            // 
            this.mnuGeneral.Text = "Menu";
            // 
            // lblREA
            // 
            this.lblREA.BackColor = System.Drawing.Color.White;
            this.lblREA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblREA.Location = new System.Drawing.Point(0, 30);
            this.lblREA.Name = "lblREA";
            this.lblREA.Size = new System.Drawing.Size(240, 15);
            this.lblREA.Text = "REALIZADA: 10";
            // 
            // lblPRO
            // 
            this.lblPRO.BackColor = System.Drawing.Color.White;
            this.lblPRO.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPRO.Location = new System.Drawing.Point(0, 15);
            this.lblPRO.Name = "lblPRO";
            this.lblPRO.Size = new System.Drawing.Size(240, 15);
            this.lblPRO.Text = "PROGRAMADA: 10";
            // 
            // lblPLA
            // 
            this.lblPLA.BackColor = System.Drawing.Color.White;
            this.lblPLA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPLA.Location = new System.Drawing.Point(0, 0);
            this.lblPLA.Name = "lblPLA";
            this.lblPLA.Size = new System.Drawing.Size(240, 15);
            this.lblPLA.Text = "PLANIFICADA: 10";
            // 
            // grdRevisiones
            // 
            this.grdRevisiones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdRevisiones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdRevisiones.Location = new System.Drawing.Point(0, 64);
            this.grdRevisiones.Name = "grdRevisiones";
            this.grdRevisiones.Size = new System.Drawing.Size(240, 204);
            this.grdRevisiones.TabIndex = 3;
            this.grdRevisiones.DoubleClick += new System.EventHandler(this.grdRevisiones_DoubleClick);
            this.grdRevisiones.CurrentCellChanged += new System.EventHandler(this.grdRevisiones_CurrentCellChanged);
            // 
            // lblInst
            // 
            this.lblInst.BackColor = System.Drawing.Color.White;
            this.lblInst.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInst.ForeColor = System.Drawing.Color.Blue;
            this.lblInst.Location = new System.Drawing.Point(-3, 45);
            this.lblInst.Name = "lblInst";
            this.lblInst.Size = new System.Drawing.Size(240, 16);
            this.lblInst.Text = "-----------";
            this.lblInst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RevisionesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblInst);
            this.Controls.Add(this.lblREA);
            this.Controls.Add(this.lblPRO);
            this.Controls.Add(this.lblPLA);
            this.Controls.Add(this.grdRevisiones);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "RevisionesGrid";
            this.Text = "FALCK -SCI (Revisiones)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RevisionesGrid_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.Label lblREA;
        private System.Windows.Forms.Label lblPRO;
        private System.Windows.Forms.Label lblPLA;
        private System.Windows.Forms.DataGrid grdRevisiones;
        private System.Windows.Forms.Label lblInst;
    }
}