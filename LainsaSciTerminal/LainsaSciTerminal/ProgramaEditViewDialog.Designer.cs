namespace LainsaSciTerminal
{
    partial class ProgramaEditViewDialog
    {
        public static ProgramaEditViewDialog Instance(System.Windows.Forms.BindingSource bindingSource)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            if ((defaultInstance == null))
            {
                defaultInstance = new LainsaSciTerminal.ProgramaEditViewDialog();
                defaultInstance.programaBindingSource.DataSource = bindingSource;
            }
            defaultInstance.programa_idTextBox.Focus();
            defaultInstance.AutoScrollPosition = new System.Drawing.Point(0, 0);
            defaultInstance.programaBindingSource.Position = bindingSource.Position;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            return defaultInstance;
        }
    
        private static ProgramaEditViewDialog defaultInstance;
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.programaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programa_idTextBox = new System.Windows.Forms.TextBox();
            this.fecha_programadaTextBox = new System.Windows.Forms.TextBox();
            this.estadoTextBox = new System.Windows.Forms.TextBox();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
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
            // programaBindingSource
            // 
            this.programaBindingSource.DataMember = "Programa";
            this.programaBindingSource.DataSource = typeof(LainsaSciTerminal.terminalDataSet);
            // 
            // programa_idLabel
            // 
            programa_idLabel.Dock = System.Windows.Forms.DockStyle.Top;
            programa_idLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            programa_idLabel.Location = new System.Drawing.Point(4, 4);
            programa_idLabel.Name = "programa_idLabel";
            programa_idLabel.Size = new System.Drawing.Size(85, 21);
            programa_idLabel.Text = "programa id:";
            // 
            // programa_idTextBox
            // 
            this.programa_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "programa_id", true));
            this.programa_idTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.programa_idTextBox.Location = new System.Drawing.Point(4, 18);
            this.programa_idTextBox.Name = "programa_idTextBox";
            this.programa_idTextBox.Size = new System.Drawing.Size(100, 21);
            this.programa_idTextBox.TabIndex = 1;
            // 
            // fecha_programadaLabel
            // 
            fecha_programadaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            fecha_programadaLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            fecha_programadaLabel.Location = new System.Drawing.Point(4, 50);
            fecha_programadaLabel.Name = "fecha_programadaLabel";
            fecha_programadaLabel.Size = new System.Drawing.Size(122, 21);
            fecha_programadaLabel.Text = "fecha programada:";
            // 
            // fecha_programadaTextBox
            // 
            this.fecha_programadaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "fecha_programada", true));
            this.fecha_programadaTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.fecha_programadaTextBox.Location = new System.Drawing.Point(4, 64);
            this.fecha_programadaTextBox.Name = "fecha_programadaTextBox";
            this.fecha_programadaTextBox.Size = new System.Drawing.Size(100, 21);
            this.fecha_programadaTextBox.TabIndex = 3;
            // 
            // estadoLabel
            // 
            estadoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            estadoLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            estadoLabel.Location = new System.Drawing.Point(4, 96);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(53, 21);
            estadoLabel.Text = "estado:";
            // 
            // estadoTextBox
            // 
            this.estadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "estado", true));
            this.estadoTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.estadoTextBox.Location = new System.Drawing.Point(4, 110);
            this.estadoTextBox.Name = "estadoTextBox";
            this.estadoTextBox.Size = new System.Drawing.Size(100, 21);
            this.estadoTextBox.TabIndex = 5;
            // 
            // comentariosLabel
            // 
            comentariosLabel.Dock = System.Windows.Forms.DockStyle.Top;
            comentariosLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            comentariosLabel.Location = new System.Drawing.Point(4, 142);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(86, 21);
            comentariosLabel.Text = "comentarios:";
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.programaBindingSource, "comentarios", true));
            this.comentariosTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comentariosTextBox.Location = new System.Drawing.Point(4, 156);
            this.comentariosTextBox.Name = "comentariosTextBox";
            this.comentariosTextBox.Size = new System.Drawing.Size(100, 21);
            this.comentariosTextBox.TabIndex = 7;
            // 
            // topBorderPanel
            // 
            this.topBorderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.Size = new System.Drawing.Size(100, 2);
            // 
            // leftBorderPanel
            // 
            this.leftBorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.leftBorderPanel.Name = "leftBorderPanel";
            this.leftBorderPanel.Size = new System.Drawing.Size(4, 100);
            // 
            // rightBorderPanel
            // 
            this.rightBorderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.rightBorderPanel.Name = "rightBorderPanel";
            this.rightBorderPanel.Size = new System.Drawing.Size(4, 100);
            // 
            // ProgramaEditViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.comentariosTextBox);
            this.Controls.Add(comentariosLabel);
            this.Controls.Add(this.estadoTextBox);
            this.Controls.Add(estadoLabel);
            this.Controls.Add(this.fecha_programadaTextBox);
            this.Controls.Add(fecha_programadaLabel);
            this.Controls.Add(this.programa_idTextBox);
            this.Controls.Add(programa_idLabel);
            this.Controls.Add(this.topBorderPanel);
            this.Controls.Add(this.leftBorderPanel);
            this.Controls.Add(this.rightBorderPanel);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ProgramaEditViewDialog";
            this.Text = "ProgramaEditViewDialog";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ProgramaEditViewDialog_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.programaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource programaBindingSource;
        private System.Windows.Forms.TextBox programa_idTextBox;
        private System.Windows.Forms.TextBox fecha_programadaTextBox;
        private System.Windows.Forms.TextBox estadoTextBox;
        private System.Windows.Forms.TextBox comentariosTextBox;
        private System.Windows.Forms.Panel topBorderPanel;
        private System.Windows.Forms.Panel leftBorderPanel;
        private System.Windows.Forms.Panel rightBorderPanel;
    }
}