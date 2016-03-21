namespace LainsaSciTerminal
{
    partial class ProgramaSummaryViewDialog
    {
        public void AttachVisibilityBindings(ControlCollection controls)
        {
            for (int i = 0; (i < controls.Count); i = (i + 1))
            {
                if ((controls[i].DataBindings["Visible"] != null))
                {
                    // Attach event handlers to auto-hide controls.
                    controls[i].DataBindings["Visible"].Format += new System.Windows.Forms.ConvertEventHandler(this.Visibility_Format);
                    controls[i].DataBindings["Visible"].DataSourceUpdateMode = System.Windows.Forms.DataSourceUpdateMode.Never;
                }
            }

        }
    
        public void Visibility_Format(object sender, System.Windows.Forms.ConvertEventArgs e)
        {
            if ((e.Value == System.DBNull.Value))
            {
                e.Value = false;
            }
            else
            {
                e.Value = true;
            }

        }
    
        public static ProgramaSummaryViewDialog Instance(System.Windows.Forms.BindingSource bindingSource)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            if ((defaultInstance == null))
            {
                defaultInstance = new LainsaSciTerminal.ProgramaSummaryViewDialog();
                defaultInstance.programaBindingSource.DataSource = bindingSource;
            }
            defaultInstance.AutoScrollPosition = new System.Drawing.Point(0, 0);
            defaultInstance.programaBindingSource.Position = bindingSource.Position;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            return defaultInstance;
        }
    
        private static ProgramaSummaryViewDialog defaultInstance;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label programa_idLabel;
            System.Windows.Forms.Label fecha_programadaLabel;
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label comentariosLabel;
            this.programaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.editMenuItemMenuItem = new System.Windows.Forms.MenuItem();
            this.programa_idLabel1 = new System.Windows.Forms.Label();
            this.fecha_programadaLabel1 = new System.Windows.Forms.Label();
            this.estadoLabel1 = new System.Windows.Forms.Label();
            this.comentariosLabel1 = new System.Windows.Forms.Label();
            this.topBorderPanel = new System.Windows.Forms.Panel();
            this.leftBorderPanel = new System.Windows.Forms.Panel();
            this.rightBorderPanel = new System.Windows.Forms.Panel();
            programa_idLabel = new System.Windows.Forms.Label();
            fecha_programadaLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            comentariosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.programaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // programa_idLabel
            // 
            programa_idLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "programa_id", true));
            programa_idLabel.Dock = System.Windows.Forms.DockStyle.Top;
            programa_idLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            programa_idLabel.Location = new System.Drawing.Point(4, 2);
            programa_idLabel.Name = "programa_idLabel";
            programa_idLabel.Size = new System.Drawing.Size(232, 21);
            programa_idLabel.Text = "programa id:";
            // 
            // programaBindingSource
            // 
            this.programaBindingSource.DataMember = "Programa";
            this.programaBindingSource.DataSource = typeof(LainsaSciTerminal.terminalDataSet);
            // 
            // fecha_programadaLabel
            // 
            fecha_programadaLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "fecha_programada", true));
            fecha_programadaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            fecha_programadaLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            fecha_programadaLabel.Location = new System.Drawing.Point(4, 43);
            fecha_programadaLabel.Name = "fecha_programadaLabel";
            fecha_programadaLabel.Size = new System.Drawing.Size(232, 21);
            fecha_programadaLabel.Text = "fecha programada:";
            // 
            // estadoLabel
            // 
            estadoLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "estado", true));
            estadoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            estadoLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            estadoLabel.Location = new System.Drawing.Point(4, 84);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(232, 21);
            estadoLabel.Text = "estado:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "comentarios", true));
            comentariosLabel.Dock = System.Windows.Forms.DockStyle.Top;
            comentariosLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            comentariosLabel.Location = new System.Drawing.Point(4, 125);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(232, 21);
            comentariosLabel.Text = "comentarios:";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.editMenuItemMenuItem);
            // 
            // editMenuItemMenuItem
            // 
            this.editMenuItemMenuItem.Text = "Edit";
            this.editMenuItemMenuItem.Click += new System.EventHandler(this.editMenuItemMenuItem_Click);
            // 
            // programa_idLabel1
            // 
            this.programa_idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "programa_id", true));
            this.programa_idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "programa_id", true));
            this.programa_idLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.programa_idLabel1.Location = new System.Drawing.Point(4, 23);
            this.programa_idLabel1.Name = "programa_idLabel1";
            this.programa_idLabel1.Size = new System.Drawing.Size(232, 20);
            // 
            // fecha_programadaLabel1
            // 
            this.fecha_programadaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "fecha_programada", true));
            this.fecha_programadaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "fecha_programada", true));
            this.fecha_programadaLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fecha_programadaLabel1.Location = new System.Drawing.Point(4, 64);
            this.fecha_programadaLabel1.Name = "fecha_programadaLabel1";
            this.fecha_programadaLabel1.Size = new System.Drawing.Size(232, 20);
            // 
            // estadoLabel1
            // 
            this.estadoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "estado", true));
            this.estadoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "estado", true));
            this.estadoLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.estadoLabel1.Location = new System.Drawing.Point(4, 105);
            this.estadoLabel1.Name = "estadoLabel1";
            this.estadoLabel1.Size = new System.Drawing.Size(232, 20);
            // 
            // comentariosLabel1
            // 
            this.comentariosLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "comentarios", true));
            this.comentariosLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.programaBindingSource, "comentarios", true));
            this.comentariosLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comentariosLabel1.Location = new System.Drawing.Point(4, 146);
            this.comentariosLabel1.Name = "comentariosLabel1";
            this.comentariosLabel1.Size = new System.Drawing.Size(232, 20);
            // 
            // topBorderPanel
            // 
            this.topBorderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorderPanel.Location = new System.Drawing.Point(4, 0);
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.Size = new System.Drawing.Size(232, 2);
            // 
            // leftBorderPanel
            // 
            this.leftBorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.leftBorderPanel.Name = "leftBorderPanel";
            this.leftBorderPanel.Size = new System.Drawing.Size(4, 268);
            // 
            // rightBorderPanel
            // 
            this.rightBorderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorderPanel.Location = new System.Drawing.Point(236, 0);
            this.rightBorderPanel.Name = "rightBorderPanel";
            this.rightBorderPanel.Size = new System.Drawing.Size(4, 268);
            // 
            // ProgramaSummaryViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.comentariosLabel1);
            this.Controls.Add(comentariosLabel);
            this.Controls.Add(this.estadoLabel1);
            this.Controls.Add(estadoLabel);
            this.Controls.Add(this.fecha_programadaLabel1);
            this.Controls.Add(fecha_programadaLabel);
            this.Controls.Add(this.programa_idLabel1);
            this.Controls.Add(programa_idLabel);
            this.Controls.Add(this.topBorderPanel);
            this.Controls.Add(this.leftBorderPanel);
            this.Controls.Add(this.rightBorderPanel);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ProgramaSummaryViewDialog";
            this.Text = "ProgramaSummaryViewDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgramaSummaryViewDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.programaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem editMenuItemMenuItem;
        private System.Windows.Forms.BindingSource programaBindingSource;
        private System.Windows.Forms.Label programa_idLabel1;
        private System.Windows.Forms.Label fecha_programadaLabel1;
        private System.Windows.Forms.Label estadoLabel1;
        private System.Windows.Forms.Label comentariosLabel1;
        private System.Windows.Forms.Panel topBorderPanel;
        private System.Windows.Forms.Panel leftBorderPanel;
        private System.Windows.Forms.Panel rightBorderPanel;
    }
}