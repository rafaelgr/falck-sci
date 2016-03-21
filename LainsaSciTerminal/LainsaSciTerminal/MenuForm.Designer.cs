namespace LainsaSciTerminal
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mnuMain;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.mnuConsulta = new System.Windows.Forms.MenuItem();
            this.mnuCambio = new System.Windows.Forms.MenuItem();
            this.mnuProgramaciones = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.imgFalck = new System.Windows.Forms.PictureBox();
            this.lblMensaje = new System.Windows.Forms.Label();
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
            this.mnuGeneral.MenuItems.Add(this.mnuConsulta);
            this.mnuGeneral.MenuItems.Add(this.mnuCambio);
            this.mnuGeneral.MenuItems.Add(this.mnuProgramaciones);
            this.mnuGeneral.MenuItems.Add(this.menuItem1);
            this.mnuGeneral.MenuItems.Add(this.menuItem2);
            this.mnuGeneral.MenuItems.Add(this.menuItem3);
            this.mnuGeneral.MenuItems.Add(this.menuItem4);
            this.mnuGeneral.Text = "Menu";
            this.mnuGeneral.Click += new System.EventHandler(this.mnuGeneral_Click);
            // 
            // mnuConsulta
            // 
            this.mnuConsulta.Text = "Consulta";
            this.mnuConsulta.Click += new System.EventHandler(this.mnuConsulta_Click);
            // 
            // mnuCambio
            // 
            this.mnuCambio.Text = "Sustitución";
            this.mnuCambio.Click += new System.EventHandler(this.mnuCambio_Click);
            // 
            // mnuProgramaciones
            // 
            this.mnuProgramaciones.Text = "Programaciones";
            this.mnuProgramaciones.Click += new System.EventHandler(this.mnuProgramaciones_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Sustituciones";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Incidencias";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Crear Dispositivo";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Realizar Revisiones";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // imgFalck
            // 
            this.imgFalck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgFalck.Image = ((System.Drawing.Image)(resources.GetObject("imgFalck.Image")));
            this.imgFalck.Location = new System.Drawing.Point(40, 3);
            this.imgFalck.Name = "imgFalck";
            this.imgFalck.Size = new System.Drawing.Size(161, 50);
            this.imgFalck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.Location = new System.Drawing.Point(40, 66);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(161, 143);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.imgFalck);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "MenuForm";
            this.Text = "FALCK SCI ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.PictureBox imgFalck;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.MenuItem mnuCambio;
        private System.Windows.Forms.MenuItem mnuConsulta;
        private System.Windows.Forms.MenuItem mnuProgramaciones;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
    }
}