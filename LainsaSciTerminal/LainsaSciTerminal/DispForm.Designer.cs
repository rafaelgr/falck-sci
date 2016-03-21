namespace LainsaSciTerminal
{
    partial class DispForm
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
            this.lblInst = new System.Windows.Forms.Label();
            this.lblTipoOp = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grdTipoA = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInst
            // 
            this.lblInst.BackColor = System.Drawing.Color.White;
            this.lblInst.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInst.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInst.ForeColor = System.Drawing.Color.Blue;
            this.lblInst.Location = new System.Drawing.Point(0, 0);
            this.lblInst.Name = "lblInst";
            this.lblInst.Size = new System.Drawing.Size(243, 17);
            this.lblInst.Text = "--";
            this.lblInst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTipoOp
            // 
            this.lblTipoOp.BackColor = System.Drawing.Color.White;
            this.lblTipoOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTipoOp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTipoOp.ForeColor = System.Drawing.Color.Blue;
            this.lblTipoOp.Location = new System.Drawing.Point(0, 17);
            this.lblTipoOp.Name = "lblTipoOp";
            this.lblTipoOp.Size = new System.Drawing.Size(243, 15);
            this.lblTipoOp.Text = "--";
            this.lblTipoOp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.mnuGeneral.MenuItems.Add(this.menuItem1);
            this.mnuGeneral.MenuItems.Add(this.menuItem2);
            this.mnuGeneral.MenuItems.Add(this.menuItem3);
            this.mnuGeneral.Text = "Menu";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Revisiones";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Sustituciones";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Incidencias";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.grdTipoA);
            this.panel4.Location = new System.Drawing.Point(3, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 121);
            // 
            // grdTipoA
            // 
            this.grdTipoA.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdTipoA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTipoA.Location = new System.Drawing.Point(0, 0);
            this.grdTipoA.Name = "grdTipoA";
            this.grdTipoA.Size = new System.Drawing.Size(240, 121);
            this.grdTipoA.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 13);
            this.label2.Text = "Anomalías:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 15);
            this.label1.Text = "--";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(0, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 15);
            this.label3.Text = "--";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DispForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTipoOp);
            this.Controls.Add(this.lblInst);
            this.Controls.Add(this.label2);
            this.Menu = this.mnuMain;
            this.Name = "DispForm";
            this.Text = "FALCK-SCI Dispositivo";
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInst;
        private System.Windows.Forms.Label lblTipoOp;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGrid grdTipoA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}